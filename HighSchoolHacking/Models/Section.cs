using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighSchoolHacking.Models
{
    public class Section
    {
        public Section()
        {

        }

        /// <summary>
        /// Background color for this section, to be used as a CSS class.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The h2 title used as the large, primary label for the section.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// An optional domain extension to place next to the title, smaller.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Any slogans that may be randomly chosen from as the h3 sub-title.
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
        /// Whether the section is "large" (h1 instead of h2 for the title).
        /// </summary>
        public bool Large { get; set; }

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