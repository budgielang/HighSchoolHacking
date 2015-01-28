/**
 * 
 * 
 * @remarks Because of the differences between Node, NodeList, Element, and
 * HTMLElement, this is still using regular JavaScript. More research required.
 */
(function (settings) {
    var reset = function () {
        document.onreadystatechange = function () {
            if (document.readyState !== "complete") {
                return;
            }

            var sections = document.querySelectorAll("section:not(:first-of-type)"),
                i;

            for (i = 0; i < sections.length; i += 1) {
                initializeSection(sections[i]);
            };

            initializeEmails();
        };
    };

    var initializeSection = function (section) {
        var header = section.children[0],
            article = section.children[1];

        article.setAttribute("heightOld", article.clientHeight);
        article.style.height = article.clientHeight + "px";

        // setTimeout(function () {
        // article.style.height = "0px";
        // }, settings.transitionSpeed);

        header.onclick = headClickOn;
        header.onmouseover = headMouseOver;
        header.onmouseout = headMouseOut;

        header.click();
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

        article.style.height = article.getAttribute("heightOld") + "px";
        header.onclick = headClickOff;
    };

    var headClickOff = function (event) {
        var section = getParentOfTag(event.target, "section"),
            header = section.children[0],
            article = section.children[1];

        header.setAttribute("clicked", "off");

        if (header.getAttribute("hovering") === "on") {
            article.style.height = settings.hoverHeight + "px";
        } else {
            article.style.height = "0px";
        }

        header.onclick = headClickOn;
    }

    var getParentOfTag = function (element, tag) {
        if (!element) {
            return;
        }

        if (element.tagName.toLowerCase() === tag) {
            return element;
        }

        return getParentOfTag(element.parentNode, tag);
    }

    var initializeEmails = function () {
        var elements = document.querySelectorAll(".email"),
            element, email, i;

        for (i = 0; i < elements.length; i += 1) {
            element = elements[i];
            email = element.textContent.replace(" at ", "@");

            element.textContent = email;
            element.setAttribute("href", "mailto:" + email);
        }
    }


    reset();
})({
    "hoverHeight": 49,
    "transitionSpeed": 117
});