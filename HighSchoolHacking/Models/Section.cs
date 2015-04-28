using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighSchoolHacking.Models
{
    /// <summary>
    /// Container for a single "section" (HTML block) of display. Info on 
    /// everything to printed in HTML is stored here, such as the color, title,
    /// text image, goto link, and so on.
    /// Static methods are also available for common tasks, mainly printing
    /// lists and code
    /// </summary>
    public class Section
    {
        public Section() { }

        /// <summary>
        /// Background color for this section, to be used as a CSS class.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The h2 text used as the large, primary label for the section.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// An optional URI for an image to display.
        /// </summary>
        public string Image { get; set; }

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
        /// The directory where View files for generic pages are stored.
        /// </summary>
        public static string ViewFileShare = "~/Views/Shared/Pages/";

        /// <summary>
        /// The location o fthe View file to Html.RenderPartial a bottom list 
        /// of other available pages.
        /// </summary>
        public static string SwitcherFile = "~/Views/Templating/Switchers.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public static string[] Colors = new string[] 
        {
            "purple", "blue", "green", "orange", "red"
        };

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<string, int> ColorIndices = Colors.ToDictionary(
            color => color,
            color => Array.IndexOf(Colors, color)
        );

        public static string GetSharedView(string name)
        {
            return Section.ViewFileShare + name + ".cshtml";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetColorAt(int index)
        {
            return Colors[index % Colors.Length];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="increase"></param>
        /// <returns></returns>
        public static string GetNextColor(string color, int increase = 0)
        {
            return GetColorAt(ColorIndices[color] + increase);
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
                "<pre class=\"language-" + language + "\">",
                "<code class=\"language-" + language + "\">",
                 HttpUtility.HtmlEncode(code),
                "</code>",
                "</pre>"
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
                "<pre class=\"language-" + language + "\">",
                "<code class=\"language-" + language + "\">",
                 HttpUtility.HtmlEncode(Section.CombineCodeLines(code)),
                "</code>",
                "</pre>"
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CombineCodeLines(string[] code)
        {
            return String.Join(Environment.NewLine, code.Where(line => line != null));
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

        public static string WrapQuote(string quote)
        {
            return "<blockquote>" + quote + "</blockquote>";
        }

        public static string WrapImage(string img)
        {
            string src = System.IO.Path.Combine("/Content/Images/", img);
            long length = new System.IO.FileInfo(HttpContext.Current.Server.MapPath(src)).Length;

            return String.Join(Environment.NewLine, new string[]
            {
                "<a href=\"" + src + "\" target=\"_blank\">",
                "<span class=\"imager\">",
                "<img src=\"" + src + "\" />",
                "Download ",
                "<span class=\"linker\">" +  img.Trim('/') + "</span>",
                " <span class=\"sizer\">(" + GetSizeReadable(length) + ")</a>",
                "</span>",
                "</a>"
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <source>http://www.somacon.com/p576.php</source>
        /// <returns></returns>
        public static string GetSizeReadable(long i)
        {
            string sign = (i < 0 ? "-" : "");
            double readable = (i < 0 ? -i : i);
            string suffix;
            if (i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (double)(i >> 50);
            }
            else if (i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (double)(i >> 40);
            }
            else if (i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (double)(i >> 30);
            }
            else if (i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (double)(i >> 20);
            }
            else if (i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (double)(i >> 10);
            }
            else if (i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = (double)i;
            }
            else
            {
                return i.ToString(sign + "0 B"); // Byte
            }
            readable = readable / 1024;

            return sign + readable.ToString("0.# ") + suffix;
        }

    }
}