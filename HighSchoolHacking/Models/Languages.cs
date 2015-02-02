using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HighSchoolHacking.Models;

namespace HighSchoolHacking.Models
{
    public static class Languages
    {
        public static string SharedViewStart = "~/Views/Shared/Pages/";

        public static string[] Names = new string[] { "Python", "JavaScript" };

        public static Dictionary<string, Language> LanguagesByName = new Dictionary<string, Language>
        {
            { "Python", Python },
            { "JavaScript", JavaScript }
        };

        public static Language Python = new Language
        {
            Name = "Python",
            NameLower = "python",
            Color = "green",
            Description = "a bit different (and a lot simpler) than Java, so you want to get used to the syntax",
            Semicolon = "",
            Commentor = "#",
            ConditionalLeft = " ",
            ConditionalRight = ":",
            ConditionalContinueLeft = "",
            ConditionalContinueRight = ": ",
            ConditionalEnd = null,
            BooleanTrue = "True",
            BooleanFalse = "False",
            ArrayName = "List",
            ArrayNamePlural = "Lists",
            DictionaryName = "Dictionary",
            DictionaryNamePlural = "Dictionaries",
            PrintFunction = "print",
            VariableDeclare = "",
            UndefinedError = "NameError: name "
        };

        public static Language JavaScript = new Language
        {
            Name = "JavaScript",
            NameLower = "javascript",
            Color = "blue",
            Description = "a bit simpler than Java or C++ but a little trickier than Python, so you want to get used to the syntax",
            ConditionalLeft = " (",
            ConditionalRight = ") {",
            ConditionalContinueLeft = "} ",
            ConditionalContinueRight = " { ",
            ConditionalEnd = "}",
            BooleanTrue = "true",
            BooleanFalse = "false",
            Semicolon = ";",
            Commentor = "//",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Object",
            DictionaryNamePlural = "Objects",
            PrintFunction = "console.log",
            VariableDeclare = "var ",
            UndefinedError = "Uncaught ReferenceError:"
        };

        public static string GetSharedPage(string section)
        {
            return SharedViewStart + section + ".cshtml";
        }
    }
}