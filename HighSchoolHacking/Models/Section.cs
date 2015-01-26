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
    }
}