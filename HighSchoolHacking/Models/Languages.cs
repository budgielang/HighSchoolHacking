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

        public static Language Python = new Language
        {
            Name = "Python",
            NameLower = "python",
            Color = "green",
            ParenthesisLeft = "(",
            ParenthesisRight = ")",
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
            Equals = "=",
            And = "and",
            Or = "or",
            ArrayName = "List",
            ArrayNamePlural = "Lists",
            DictionaryName = "Dictionary",
            DictionaryNamePlural = "Dictionaries",
            FunctionDefine = "def ",
            FunctionRight = ":",
            FunctionEnd = null,
            LengthName = "len",
            LengthIsProperty = false,
            NativeExponents = true,
            DictionaryKeyInCheck = true,
            DictionaryKeyCheckName = " in ",
            DictionaryIterator = ".items()",
            DictionaryIterateAsPair = true,
            DirectArrayLoops = true,
            FunctionsFirstClass = true,
            PrintFunction = "print",
            AppendFunction = "append",
            VariableDeclare = "",
            UndefinedError = "NameError: name ",
            CustomPages = new HashSet<string> { "ForLoops", "Dictionaries", "WingIDE", "FileIO", "Simplebot", "WordSpam" },
            PageAliases = new Dictionary<string, string>
            {
                { "Arrays", "Lists" }
            }
        };

        public static Language JavaScript = new Language
        {
            Name = "JavaScript",
            NameLower = "javascript",
            Color = "blue",
            ParenthesisLeft = "(",
            ParenthesisRight = ")",
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
            Equals = "=",
            And = "&&",
            Or = "||",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Object",
            DictionaryNamePlural = "Objects",
            FunctionDefine = "function ",
            FunctionRight = " {",
            FunctionEnd = "}",
            LengthName = "length",
            CanConcatenateNumbers = true,
            LengthIsProperty = true,
            DictionaryKeyInCheck = false,
            DictionaryKeyCheckName = "hasOwnProperty",
            FunctionsFirstClass = true,
            FunctionsAsVariables = true,
            PrintFunction = "console.log",
            AppendFunction = "push",
            VariableDeclare = "var ",
            UndefinedError = "Uncaught ReferenceError:",
            CustomPages = new HashSet<string> { "DeveloperTools", "NameTypos", "CookieClicker", "BouncingElements", "RandomExclamations", "ChromeExtensions" },
            PageAliases = new Dictionary<string, string>
            {
                { "Dictionaries", "Objects" }
            }
        };

        public static Language LOLCODE = new Language
        {
            Name = "LOLCODE",
            NameLower = "lolcode",
            Color = "red",
            ParenthesisLeft = " ",
            ParenthesisRight = " ",
            ConditionalLeft = " (",
            ConditionalRight = ") {",
            ConditionalContinueLeft = "} ",
            ConditionalContinueRight = " { ",
            ConditionalEnd = "}",
            BooleanTrue = "true",
            BooleanFalse = "false",
            Semicolon = "",
            Commentor = "  BTW",
            Elif = "else if",
            Equals = "ITZ",
            And = "&&",
            Or = "||",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Object",
            DictionaryNamePlural = "Objects",
            FunctionDefine = "function ",
            FunctionRight = " {",
            FunctionEnd = "}",
            LengthName = "length",
            CanConcatenateNumbers = true,
            LengthIsProperty = true,
            DictionaryKeyInCheck = false,
            DictionaryKeyCheckName = "hasOwnProperty",
            FunctionsFirstClass = true,
            FunctionsAsVariables = true,
            PrintFunction = "VISIBLE",
            AppendFunction = "push",
            VariableDeclare = "I HAS A ",
            UndefinedError = "MachineError: Reference to undefined variable:",
            CustomPages = new HashSet<string> { },
            PageAliases = new Dictionary<string, string> { }
        };

        public static Dictionary<string, Language> LanguagesByName = new Dictionary<string, Language>
        {
            { "Python", Python },
            { "JavaScript", JavaScript },
            { "LOLCODE", LOLCODE }
        };

        public static string[] LessonPages = { "Learn", "Hello World", "Variables", "Comments", "Strings", "Numbers", "Conditionals", "While Loops", "Arrays", "For Loops", "Dictionaries", "Functions", "Recursion" };

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