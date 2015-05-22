using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighSchoolHacking.Models
{
    public delegate string MathComputer(string left, string operation, string right);

    public class Language
    {
        public Language()
        { }

        public string Name { get; set; }

        public string NameLower { get; set; }

        public string Color { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string ParenthesisLeft { get; set; }

        public string ParenthesisRight { get; set; }

        public string Commentor { get; set; }

        public string Semicolon { get; set; }

        public bool ConditionalAfter { get; set; }

        public string ConditionalLeft { get; set; }

        public string ConditionalRight { get; set; }

        public string ConditionalContinueLeft { get; set; }

        public string ConditionalContinueRight { get; set; }

        public string ConditionalEnd { get; set; }

        public string BooleanTrue { get; set; }

        public string BooleanFalse { get; set; }

        public string If { get; set; }

        public string Else { get; set; }

        public string Elif { get; set; }

        public string Equals { get; set; }

        public string WhenTrue { get; set; }

        public string WhenFalse { get; set; }

        public string EndIf { get; set; }

        public bool StringAnyApostrophes { get; set; }

        public string StringConcatenationStart { get; set; }

        public string StringConcatenationBetween { get; set; }

        public string StringConcatenationEnd { get; set; }

        public string And { get; set; }

        public string Or { get; set; }

        public string ArrayName { get; set; }

        public string ArrayNamePlural { get; set; }

        public string DictionaryName { get; set; }

        public string DictionaryNamePlural { get; set; }

        public string FunctionDefine { get; set; }

        public string FunctionRight { get; set; }

        public string FunctionEnd { get; set; }

        public string ClassStart { get; set; }

        public string ClassEnd { get; set; }

        /// <summary>
        /// The name of the constructor Function for a class. If null, the class
        /// name will be used instead.
        /// </summary>
        public string ClassConstructor { get; set; }

        /// <summary>
        /// Whether class member Functions take in their "this" as an argment.
        /// </summary>
        public Boolean ClassFunctionsTakeThis { get; set; }

        public string ClassThis { get; set; }

        public string LengthName { get; set; }

        public bool StrictIntegers { get; set; }

        public bool CanConcatenateNumbers { get; set; }

        public bool LengthIsProperty { get; set; }

        public bool DirectArrayLoops { get; set; }

        public bool NativeExponents { get; set; }

        public bool DictionaryKeyInCheck { get; set; }

        public string DictionaryKeyCheckName { get; set; }

        public string DictionaryIterator { get; set; }

        public bool DictionaryIterateAsPair { get; set; }

        public bool FunctionsFirstClass { get; set; }

        public bool FunctionsAsVariables { get; set; }

        public string VariableDeclare { get; set; }

        public string PrintFunction { get; set; }

        public string AppendFunction { get; set; }

        public string UndefinedError { get; set; }

        public MathComputer FancyNumberMath { get; set; }

        public HashSet<string> CustomPages { get; set; }

        public Dictionary<string, string> PageAliases { get; set; }

        public string MakeConditional(string operation, string value)
        {
            bool isAfter = this.ConditionalAfter && operation != this.Elif;
            string output = "";

            if (!isAfter)
            {
                output += operation;
            }

            output += this.ConditionalLeft + value;

            if (isAfter)
            {
                output += operation;
            }

            output += this.ConditionalRight;

            return output;
        }

        public string MakeElse()
        {
            string output = this.ConditionalContinueLeft + this.Else + this.ConditionalContinueRight;

            return output.Length > 0 ? output : null;
        }

        public string CallFunction(string name, params string[] args)
        {
            string output = name + this.ParenthesisLeft;
            int i;

            if (args != null && args.Length > 0)
            {
                for (i = 0; i < args.Length - 1; i += 1)
                {
                    output += args[i] + ", ";
                }

                output += args[args.Length - 1];
            }

            output += this.ParenthesisRight;

            return output;
        }

        public string ConcatenateStrings(params string[] args)
        {
            string output = this.StringConcatenationStart;
            int i;

            if (args != null && args.Length > 0)
            {
                for (i = 0; i < args.Length - 1; i += 1)
                {
                    output += args[i] + " " + this.StringConcatenationBetween + " ";
                }

                output += args[args.Length - 1];
            }

            output += this.StringConcatenationEnd;

            return output;
        }

        public string ComputeMath(string left, string operation, string right)
        {
            if (this.FancyNumberMath != null)
            {
                return this.FancyNumberMath(left, operation, right);
            }

            return left + " " + operation + " " + right;
        }

        public string ClassMemberFunction(string name, string[] arguments = null)
        {
            string output = name + "(";
            int i;

            if (this.ClassFunctionsTakeThis)
            {
                output += this.ClassThis;
            }

            if (arguments != null)
            {
                if (arguments.Length > 0)
                {
                    output += ", ";
                }

                for (i = 0; i < arguments.Length - 1; i += 1)
                {
                    output += arguments[i] + ", ";
                }

                output += arguments[i];
            }

            return output + ")" + this.FunctionRight;
        }

        public string UseLength(string variable)
        {
            if (this.LengthIsProperty)
            {
                return variable + "." + this.LengthName;
            }
            else
            {
                return this.LengthName + "(" + variable + ")";
            }
        }

        public string StartLengthLoop(string keyIterator, string keyValue, string container, string before = "")
        {
            if (this.DirectArrayLoops)
            {
                return String.Join("", new string[]
                {
                    before + "for" + this.ConditionalLeft + this.VariableDeclare,
                    before + keyValue + " in " + container,
                    before + this.ConditionalRight
                });
            }
            else
            {
                return String.Join("", new string[]
                {
                    before + "for" + this.ConditionalLeft + this.VariableDeclare,
                    before + keyIterator + " = 0; ",
                    before + keyIterator + " < " + this.UseLength(container) + "; ",
                    before + keyIterator + " = " + keyIterator + " + 1",
                    before + this.ConditionalRight,
                    before + "\n",
                    before + "    " + this.VariableDeclare + keyValue + " = " + container + "[" + keyIterator + "]" + this.Semicolon
                });
            }
        }

        public string CheckDictionaryKey(string key, string container)
        {
            if (DictionaryKeyInCheck)
            {
                return key + DictionaryKeyCheckName + container;
            }

            return container + "." + DictionaryKeyCheckName + "(" + key + ")";
        }
    }
}