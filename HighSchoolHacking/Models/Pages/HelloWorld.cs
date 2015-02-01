using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighSchoolHacking.Models.Pages
{
    public class HelloWorld
    {
        public HelloWorld()
        { }

        public string Color { get; set; }

        public string Language { get; set; }

        public string LanguageLower
        {
            get
            {
                return Language.ToLower();
            }
        }

        public string LanguageDescription { get; set; }

        public string PrintFunction { get; set; }
    }
}