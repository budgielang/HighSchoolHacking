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
            Elif = "elif",
            And = "and",
            Or = "or",
            ArrayName = "List",
            ArrayNamePlural = "Lists",
            DictionaryName = "Dictionary",
            DictionaryNamePlural = "Dictionaries",
            LengthName = "len",
            LengthIsProperty = false,
            PrintFunction = "print",
            AppendFunction = "append",
            VariableDeclare = "",
            UndefinedError = "NameError: name ",
            CustomPages = new HashSet<string> { "ForLoops" }
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
            Elif = "else if",
            And = "&&",
            Or = "||",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Object",
            DictionaryNamePlural = "Objects",
            LengthName = "length",
            LengthIsProperty = true,
            PrintFunction = "console.log",
            AppendFunction = "push",
            VariableDeclare = "var ",
            UndefinedError = "Uncaught ReferenceError:",
            CustomPages = new HashSet<string> { "DeveloperTools" }
        };

        public static string GetSharedPage(string lesson)
        {
            return SharedViewStart + lesson + ".cshtml";
        }

        public static string GetSectionPage(string section, string lesson)
        {
            return "~/Views/" + section + "/" + lesson + ".cshtml";
        }
    }
}