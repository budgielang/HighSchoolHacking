/**
 * 
 * 
 * @remarks Because of the differences between Node, NodeList, Element, and
 * HTMLElement, this is still using regular JavaScript. More research required.
 */
(function (settings) {
    var reset = function () {
        document.onreadystatechange = function () {
            if (
                document.readyState !== "interactive"
                && document.readyState !== "complete"
            ) {
                return;
            }

            document.onreadystatechange = undefined;

            initializeEmails();

            window.onresize = initializeSections;
            initializeSections();

            initializeSwitchers();
        };
    };

    var initializeSections = function () {
        var sections = document.querySelectorAll("section:not(:first-of-type)"),
            i;

        for (i = 0; i < sections.length; i += 1) {
            initializeSection(sections[i]);
        }
    };

    var initializeSection = function (section) {
        var header = section.children[0],
            article = section.children[1];

        if (!article) {
            return;
        }

        header.onmouseover = headMouseOver;
        header.onmouseout = headMouseOut;
        header.setAttribute("used", "false");

        article.style.height = "auto";
        article.setAttribute("heightOld", article.clientHeight);

        if (section.getAttribute("contracted")) {
            header.onclick = headClickOn;
            header.setAttribute("clicked", "off");
            article.removeAttribute("contracted");
            article.style.height = "0";
        } else {
            header.setAttribute("clicked", "on");
            header.onclick = headClickOff;
        }

    };

    var headMouseOver = function (event) {
        var section = getParentOfTag(event.target, "section"),
            header = section.children[0],
            article = section.children[1];

        header.setAttribute("hovering", "on");

        if (header.getAttribute("clicked") !== "on") {
            article.style.height = settings.hoverHeight + "px";
        }
    };

    var headMouseOut = function (event) {
        var section = getParentOfTag(event.target, "section"),
            header = section.children[0],
            article = section.children[1];

        header.setAttribute("hovering", "off");

        if (header.getAttribute("clicked") !== "on") {
            article.style.height = "0px";
        }
    };

    var headClickOn = function (event) {
        var section = getParentOfTag(event.target, "section"),
            header = section.children[0],
            article = section.children[1];

        header.setAttribute("clicked", "on");
        article.style.height = article.clientHeight + "px";

        header.onclick = undefined;
        setTimeout(function () {
            article.style.height = article.getAttribute("heightOld") + "px";
            article.removeAttribute("heightOld");
            header.onclick = headClickOff;
        }, 210);
    };

    var headClickOff = function (event) {
        var section = getParentOfTag(event.target, "section"),
            header = section.children[0],
            article = section.children[1];

        header.setAttribute("clicked", "off");
        article.setAttribute("heightOld", article.clientHeight);

        if (header.getAttribute("used") === "false") {
            header.onclick = undefined;
            header.setAttribute("used", "true");
            article.style.height = article.clientHeight + "px";
            setTimeout(function () {
                article.style.height = "0";
                header.onclick = headClickOn;
            }, 21);
        } else if (header.getAttribute("hovering") === "on") {
            article.style.height = settings.hoverHeight + "px";
            header.onclick = headClickOn;
        } else {
            article.style.height = "0";
            header.onclick = headClickOn;
        }

    };

    var getParentOfTag = function (element, tag) {
        if (!element) {
            return;
        }

        if (element.tagName.toLowerCase() === tag) {
            return element;
        }

        return getParentOfTag(element.parentNode, tag);
    };

    var initializeEmails = function () {
        var elements = document.querySelectorAll(".email"),
            element, email, i;

        for (i = 0; i < elements.length; i += 1) {
            element = elements[i];
            email = element.textContent.replace(" at ", "@");

            element.textContent = email;
            element.setAttribute("href", "mailto:" + email);
        }
    };

    var initializeSwitchers = function () {
        var container = document.querySelector("#switchers"),
            languager = document.querySelector("#switcher-language select"),
            lessoner = document.querySelector("#switcher-lesson select"),
            language, lesson;

        if (!container) {
            return;
        }

        language = container.getAttribute("language");
        lesson = container.getAttribute("lesson");

        if (languager) {
            languager.onchange = function () {
                var option = languager.options[languager.selectedIndex],
                    location = "/" + option.innerText + "/" + lesson.split(" ").join("").replace("#", "Sharp");
                window.location = location.replace("#", "Sharp");
            };
        }

        if (lessoner) {
            lessoner.onchange = function () {
                var option = lessoner.options[lessoner.selectedIndex],
                    location = "/" + language + "/" + option.innerText.split(" ").join("-").replace("#", "Sharp");
                window.location = location.replace("#", "Sharp");
            };
        }
    }


    reset();
})({
    "hoverHeight": 49,
    "transitionSpeed": 117
});