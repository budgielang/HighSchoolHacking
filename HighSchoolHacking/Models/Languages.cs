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
            Continue = "continue",
            Break = "break",
            If = "if",
            Else = "else",
            Elif = "elif",
            Equals = "=",
            And = "and",
            Or = "or",
            StringAnyApostrophes = true,
            StringConcatenationBetween = "+",
            ArrayName = "List",
            ArrayNamePlural = "Lists",
            DictionaryName = "Dictionary",
            DictionaryNamePlural = "Dictionaries",
            FunctionDefine = "def ",
            FunctionRight = ":",
            FunctionEnd = null,
            ClassStart = "class ",
            ClassConstructor = "__init__",
            ClassFunctionsTakeThis = true,
            ClassThis = "self",
            LengthName = "len",
            LengthIsProperty = false,
            NativeExponents = false,
            DictionaryKeyInCheck = true,
            DictionaryKeyCheckName = " in ",
            DictionaryIterator = ".items()",
            DictionaryIterateAsPair = true,
            DictionaryValueDefinition = ":",
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
            Continue = "continue",
            Break = "break",
            Semicolon = ";",
            Commentor = "//",
            If = "if",
            Else = "else",
            Elif = "else if",
            Equals = "=",
            And = "&&",
            Or = "||",
            StringAnyApostrophes = true,
            StringConcatenationBetween = "+",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Object",
            DictionaryValueDefinition = ":",
            DictionaryNamePlural = "Objects",
            FunctionDefine = "function ",
            FunctionRight = " {",
            FunctionEnd = "}",
            ClassEnd = "}",
            ClassThis = "this",
            LengthName = "length",
            StrictIntegers = false,
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

        public static Language CSharp = new Language
        {
            Name = "C#",
            NameLower = "csharp",
            Color = "purple",
            Start = "class Program\n{\n    static void Main()\n    {",
            End = "    }\n}",
            ParenthesisLeft = "(",
            ParenthesisRight = ")",
            ConditionalLeft = " (",
            ConditionalRight = ") {",
            ConditionalContinueLeft = "} ",
            ConditionalContinueRight = " { ",
            ConditionalEnd = "}",
            BooleanTrue = "true",
            BooleanFalse = "false",
            Continue = "continue",
            Break = "break",
            Semicolon = ";",
            Commentor = "//",
            If = "if",
            Else = "else",
            Elif = "else if",
            Equals = "==",
            And = "&&",
            Or = "||",
            StringAnyApostrophes = false,
            StringConcatenationBetween = "+",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Hashtable",
            DictionaryValueDefinition = ":",
            DictionaryNamePlural = "Hash Tables",
            DictionaryKeyInCheck = false,
            DictionaryKeyCheckName = "hasOwnProperty",
            FunctionDefine = "function ",
            FunctionRight = " {",
            FunctionEnd = "}",
            ClassEnd = "}",
            ClassThis = "this",
            LengthName = "Length",
            StrictIntegers = false,
            CanConcatenateNumbers = true,
            LengthIsProperty = true,
            FunctionsFirstClass = true,
            FunctionsAsVariables = true,
            PrintFunction = "Console.WriteLine",
            AppendFunction = "Add",
            UndefinedError = "Uncaught ReferenceError:",
            CustomPages = new HashSet<string> {
                "Learn", "HelloWorld", "Variables", "Comments", "Strings",
                "Numbers", "Conditionals", "WhileLoops", "Arrays", "ForLoops",
                "VariousCollections", "Functions", "Recursion",
                "DelegatesLambdas", "LINQ", "Async"
            },
            PageAliases = new Dictionary<string, string> {
                { "Recursion", "Functions" }
            }
        };

        public static Language LOLCODE = new Language
        {
            Name = "LOLCODE",
            NameLower = "lolcode",
            Color = "red",
            ParenthesisLeft = " ",
            ParenthesisRight = " ",
            ConditionalAfter = true,
            ConditionalLeft = "",
            ConditionalRight = "",
            ConditionalContinueLeft = null,
            ConditionalContinueRight = null,
            BooleanTrue = "WIN",
            BooleanFalse = "FAIL",
            Semicolon = "",
            Commentor = "  BTW",
            If = ", O RLY?",
            Else = "",
            Elif = "MEBBE ",
            WhenTrue = "YA RLY, ",
            WhenFalse = "NO WAI, ",
            EndIf = "OIC",
            Equals = "ITZ",
            And = "",
            Or = "",
            StringAnyApostrophes = false,
            StringConcatenationStart = "SMOOSH ",
            StringConcatenationBetween = "AN",
            StringConcatenationEnd = " MKAY",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Object",
            DictionaryNamePlural = "Objects",
            DictionaryValueDefinition = ":",
            FunctionDefine = "function ",
            FunctionRight = " {",
            FunctionEnd = "}",
            LengthName = "length",
            StrictIntegers = true,
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
            FancyNumberMath = (string left, string operation, string right) =>
            {
                string before = "";

                switch (operation)
                {
                    case "+":
                        before = "SUM OF";
                        break;
                    case "-":
                        before = "DIFF OF";
                        break;
                    case "*":
                        before = "PRODUKT OF";
                        break;
                    case "/":
                        before = "QUOSHUNT OF";
                        break;
                    case "%":
                        before = "MOD OF";
                        break;
                    case ">":
                        before = "BIGGR OF";
                        break;
                    case "<":
                        before = "SMALLR OF";
                        break;
                    case "<=":
                        before = "BOTH SAEM " + left + " AN BIGGR OF";
                        break;
                    case ">=":
                        before = "BOTH SAEM " + left + " AN SMALLR OF";
                        break;
                    case "==":
                        before = "BOTH SAEM";
                        break;
                    case "!=":
                        before = "DIFFRINT";
                        break;
                }

                return before + " " + left + " AN " + right;
            },
            CustomPages = new HashSet<string> { "Learn" },
            PageAliases = new Dictionary<string, string> { }
        };

        public static Language Ruby = new Language
        {
            Name = "Ruby",
            NameLower = "ruby",
            Color = "red",
            ParenthesisLeft = " ",
            ParenthesisRight = " ",
            ConditionalLeft = " ",
            ConditionalRight = "",
            ConditionalContinueLeft = " ",
            ConditionalContinueRight = "",
            ConditionalEnd = "end",
            BooleanTrue = "true",
            BooleanFalse = "false",
            Continue = "next",
            Break = "break",
            Semicolon = "",
            Commentor = "#",
            If = "if",
            Else = "else",
            Elif = "elsif",
            Equals = "=",
            And = "and",
            Or = "or",
            StringAnyApostrophes = true,
            StringConcatenationBetween = "+",
            ArrayName = "Array",
            ArrayNamePlural = "Arrays",
            DictionaryName = "Hash",
            DictionaryNamePlural = "Hashes",
            FunctionDefine = "def ",
            FunctionRight = "",
            FunctionEnd = "end",
            ClassEnd = "end",
            ClassThis = "@", 
            LengthName = "length",
            StrictIntegers = false,
            CanConcatenateNumbers = false,
            LengthIsProperty = true,
            DictionaryKeyInCheck = false,
            DictionaryKeyCheckName = "has_key?",
            DictionaryValueDefinition = "=>",
            FunctionsFirstClass = false,
            FunctionsAsVariables = false,
            PrintFunction = "puts",
            AppendFunction = "push",
            VariableDeclare = "",
            UndefinedError = "undefined local variable or method:",
            PageAliases = new Dictionary<string, string> {
                { "Dictionaries", "Hashes" }
            },
            CustomPages = new HashSet<string> { "ForLoops", "Recursion", "Koans", "Goal" }, 
        };

        public static Dictionary<string, Language> LanguagesByName = new Dictionary<string, Language>
        {
            { "C#", CSharp },
            { "JavaScript", JavaScript },
            { "Python", Python },
            { "Ruby", Ruby }
        };

        public static Dictionary<string, GLS.Language> GlsLanguagesByName = new Dictionary<string, GLS.Language>
        {
            { "csharp", GLS.Languages.CSharp },
            { "java", GLS.Languages.Java },
            { "python", GLS.Languages.Python },
            { "ruby", GLS.Languages.Ruby },
            { "typeScript", GLS.Languages.TypeScript }
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
