using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighSchoolHacking.Models
{
    public class Section
    {
        public Section()
        { }

        /// <summary>
        /// Background color for this section, to be used as a CSS class.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The h2 text used as the large, primary label for the section.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// An optional domain extension to place next to the text, smaller.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Whether the section is "large" (h1 instead of h2 for the text).
        /// </summary>
        public bool Large { get; set; }

        /// <summary>
        /// Whether the section is initially contracted.
        /// </summary>
        public bool Contracted { get; set; }

        /// <summary>
        /// Any slogans that may be randomly chosen from as the h3 sub-text.
        /// </summary>
        public string[] Slogans { get; set; }

        /// <summary>
        /// The text content in the section, each of which will be wrapped in
        /// a paragraph tag.
        /// </summary>
        public string[] Paragraphs { get; set; }

        /// <summary>
        /// Any URI links to be listed below the section paragraphs.
        /// </summary>
        public Dictionary<string, string> Links { get; set; }

        /// <summary>
        /// An optional URI link to emphasize after Links. Typically null.
        /// </summary>
        public string Goto { get; set; }

        /// <summary>
        /// An optional URI link to have the extenion link to. Typically null.
        /// </summary>
        public string Back { get; set; }

        /// <summary>
        /// The location of the View file to Html.RenderPartial with a Section
        /// as the model.
        /// </summary>
        public static string ViewFile = "~/Views/Templating/Section.cshtml";

        /// <summary>
        /// The location of the View file to Html.RenderPartial the contents of
        /// a Learn page after the first, large section.
        /// </summary>
        public static string ViewFileLearn = "~/Views/Shared/Pages/Learn.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public static string[] Colors = new string[] 
        {
            "red", "orange", "green", "blue", "purple"
        };

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string, int> ColorIndices = Colors.ToDictionary(
            color => color,
            color => Array.IndexOf(Colors, color)
        );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetColorAt(int index) {
            return Colors[index % Colors.Length];
        }

        /// <summary>
        /// Creates a header element (normally h3) with the text as its title
        /// and text content.
        /// </summary>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="tag">The HTML tag to be used (by default, h3).</param>
        /// <returns>The text for an HTML head element with the text.</returns>
        public static string WrapHead(string text, string tag = "h3")
        {
            return String.Join("", new string[]
            {
                "<" + tag + " id='" + text + "'>",
                text,
                "</" + tag + ">"
            });
        }

        /// <summary>
        /// HTML wrapper to print out code surrounded by pre and code tags. The
        /// correct class is given to make this become an outlined box
        /// highlighted by prism.js.
        /// </summary>
        /// <param name="language">
        /// The language to highlight, typically "python" or "javascript".
        /// </param>
        /// <param name="code">A chunk of code to print.</param>
        /// <returns>
        /// HTML code formatted to display the given chunk of code in the
        /// given language.
        /// </returns>
        public static string WrapCode(string language, string code)
        {
            return String.Join("", new string[] 
            {
                "<pre><code class=\"language-" + language + "\">",
                 HttpUtility.HtmlEncode(code),
                "</code></pre>"
            });
        }

        /// <summary>
        /// HTML wrapper to print out lines of code surrounded by pre and code
        /// tags. The correct class is given to make this become an outlined
        /// box highlighted by prism.js.
        /// </summary>
        /// <param name="language">
        /// The language to highlight, typically "python" or "javascript".
        /// </param>
        /// <param name="code">Individual lines of code to print.</param>
        /// <returns>
        /// HTML code formatted to display the given lines of code in the
        /// given language.
        /// </returns>
        public static string WrapCode(string language, string[] code)
        {
            return String.Join("", new string[] 
            {
                "<pre><code class=\"language-" + language + "\">",
                 HttpUtility.HtmlEncode(String.Join(Environment.NewLine, code)),
                "</code></pre>"
            });
        }

        /// <summary>
        /// HTML wrapper to print a list with its list elements.
        /// </summary>
        /// <param name="lines">The HTML contents of the list elements.</param>
        /// <param name="ordered">
        /// Whether this should be an ordered ("ol" or unordered "ul") list.
        /// </param>
        /// <returns></returns>
        public static string WrapList(string[] lines, bool ordered = true)
        {
            string tag = ordered ? "ol" : "ul";

            return String.Join(Environment.NewLine, new string[]
            {
                "<" + tag + ">",
                "<li>",
                String.Join("</li><li>", lines),
                "</li>",
                "</" + tag + ">"
            });
        }

        /// <summary>
        /// HTML wrapper to print a list with its list elements.
        /// </summary>
        /// <param name="ordered">
        /// Whether this should be an ordered ("ol" or unordered "ul") list.
        /// </param>
        /// <param name="lines">The HTML contents of the list elements.</param>
        /// <returns></returns>
        public static string WrapList(bool ordered, string[] lines)
        {
            string tag = ordered ? "ol" : "ul";

            return String.Join(Environment.NewLine, new string[]
            {
                "<" + tag + ">",
                "<li>",
                String.Join("</li><li>", lines),
                "</li>",
                "</" + tag + ">"
            });
        }
    }
}