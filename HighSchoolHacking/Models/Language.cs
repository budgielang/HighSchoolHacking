using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighSchoolHacking.Models
{
    public class Language
    {
        public Language()
        { }

        public string Name { get; set; }

        public string NameLower { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }

        public string Commentor { get; set; }

        public string Semicolon { get; set; }

        public string ConditionalLeft { get; set; }

        public string ConditionalRight { get; set; }

        public string ConditionalContinueLeft { get; set; }

        public string ConditionalContinueRight { get; set; }

        public string ConditionalEnd { get; set; }

        public string BooleanTrue { get; set; }

        public string BooleanFalse { get; set; }

        public string Elif { get; set; }

        public string And { get; set; }

        public string Or { get; set; }

        public string ArrayName { get; set; }

        public string ArrayNamePlural { get; set; }

        public string DictionaryName { get; set; }

        public string DictionaryNamePlural { get; set; }

        public string LengthName { get; set; }

        public bool CanConcatenateNumbers { get; set; }

        public bool LengthIsProperty { get; set; }

        public bool NativeExponents { get; set; }

        public string VariableDeclare { get; set; }

        public string PrintFunction { get; set; }

        public string AppendFunction { get; set; }

        public string UndefinedError { get; set; }

        public HashSet<string> CustomPages { get; set; }


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
    }
}