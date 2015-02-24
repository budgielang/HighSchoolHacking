# HighSchoolHacking
High School Hacking is a program for high schoolers (and other newcomers) to get more involved with programming. It provides a set of lessons in Python and JavaScript to teach the basics of programming languages, and follows them with a set of activities focused around those language's strengths.

### Hosting
The http://www.highschoolhacking.club website is hosted on Azure, auto-pulling from the main/master GitHub repo/branch. The entire repo is just the Visual Studio 2013 ASP.NET solution, along with the general Git/GitHub info.

### Teaching
If you'd like to use the site to teach, please go ahead! The typical structure is to spend the first few sessions teaching the language (depending on the students' proficiency, this may vary in time), then one session per activity. We typically go for ~60  sessions, with ~5 minutes of presentation before an activity.


It's also a good idea to [email Josh](mailto:joshuakgoldberg@outlook.com) so we can coordinate lessons and customize site if need be.


## Development Structure
This is, first and foremost, an ASP.NET MVC C# project on Visual Studio 2013. SCSS is used for styling, along with vanilla JavaScript. Prism.js is used for code highlighting.

#### Front-end (Theme)
Each page is composed of some colored `<section>` elements followed by the dark `<footer>`. The base page view is located at `/Views/Shared/_Layout.cshtml`, and the homepage body content is located at `/Views/Home/Index.cshtml`.

General SCSS stylings are stored in...
* `/Content/positioning.scss` - Layout and sizing
* `/Content/styling.scss` - Colors and visual appearance

Sections typically follow a reverse rainbow color order: red, purple, blue, green, orange, repeat. There are also steel and brown sections. The sliding effect is implemented in `/Scripts/sliding.js`.

#### Back-end (MVC)

The C# side of the project implements a few classes in `/Models`:
* **Section** - A container for information on how to print a particular `<section>`. The `/Views/Templating/Section.cshtml` view file has this as its model. It also stores some static functions to assist in printing HTML elements.
* **Language** - A container for how a language appears, such as bracket or semicolon behavior (mostly as strings). All the page views for lessons under `/Views/Shared/Pages` (along with individual language lesson pages) have this as their model. 
* **Languages** - A static container for each known language. Right now it stores Python and Javascript as Language instances, which makes it easy to reference the languages.
