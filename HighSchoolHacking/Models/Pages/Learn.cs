using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighSchoolHacking.Models
{
    public class Learn
    {
        public Learn()
        { }

        public string Language { get; set; }

        public string ArrayName { get; set; }

        public string ArrayNamePlural { get; set; }

        public string DictionaryName { get; set; }

        public string DictionaryNamePlural { get; set; }

        public Section Header { get; set; }
    }
}