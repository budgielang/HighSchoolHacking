using System.Collections.Generic;

namespace HighSchoolHacking.Models.GLS
{
    static partial class Languages
    {
        public static Language Python = new Language()
            .setName("Python")
            .setExtension("py")
            .setPrintFunction("print")
            .setSemiColon("")
            .setArrayClass("Array")
            .setArrayInitializationAsNewMultiplied(true)
            .setArrayLength("len")
            .setArrayLengthAsFunction(true)
            .setArrayNegativeIndices(true)
            .setBreak("break")
            .setClassConstructorName("__init__")
            .setClassConstructorLoose(true)
            .setClassEnder("\0")
            .setClassExtendsAsFunction(true)
            .setClassFunctionsStart("def ")
            .setClassFunctionsTakeThis(true)
            .setClassFunctionsThis("self")
            .setClassMemberFunctionGetStart("")
            .setClassMemberFunctionGetEnd("")
            .setClassMemberFunctionGetEnd("")
            .setClassMemberFunctionGetStart("")
            .setClassMemberVariableDefault("None")
            .setClassMemberVariablePrivacy(false)
            .setClassMemberVariableStarter("")
            .setClassNewer("")
            .setClassParentName("")
            .setClassPrivacy(false)
            .setClassPublicAlias("")
            .setClassStaticFunctionDecorator("@staticmethod")
            .setClassStaticFunctionRequiresDecorator(true)
            .setClassStaticLabel("")
            .setClassStartLeft("class ")
            .setClassStartRight(":")
            .setClassThis("self")
            .setClassThisAccess(".")
            .setCommentorBlockStart("\"\"\"")
            .setCommentorBlockEnd("\"\"\"")
            .setCommentorInline("#")
            .setConditionStartLeft(" ")
            .setConditionStartRight(":")
            .setConditionContinueLeft(" ")
            .setConditionContinueRight(":")
            .setConditionEnd("\0")
            .setContinue("continue")
            .setDictionaryInitializeEnder("}")
            .setDictionaryInitializeKeyComma(",")
            .setDictionaryInitializeStarter(" {")
            .setDictionaryKeyChecker(" in ")
            .setDictionaryKeyLeft("")
            .setDictionaryKeyMiddle(": ")
            .setDictionaryKeyRight("")
            .setElif("elif")
            .setElse("else")
            .setExceptionCatch("except ")
            .setExceptionClass("Exception")
            .setExceptionErrorPrefix(", ")
            .setExceptionFinally("finally")
            .setExceptionThrow("throw")
            .setExceptionTry("try")
            .setFileEndLine("")
            .setFileStartLeft("")
            .setFileStartRight("")
            .setForEachInner(" in ")
            .setForEachKeysGet("")
            .setForEachPairsGet("")
            .setForEachStarter("for ")
            .setFunctionDefine("def ")
            .setFunctionDefineRight(":")
            .setFunctionDefineEnd("\0")
            .setIf("if")
            .setIncludeDictionaryType("")
            .setIncludeEnder("import *")
            .setIncludeFileExtension(true)
            .setIncludeStarter("from ")
            .setLambdaDeclareEnder("")
            .setLambdaDeclareMiddle(": ")
            .setLambdaDeclareStarter("lambda ")
            .setMainEndLine("\0")
            .setMainStartLine("if __name__ == '__main__':")
            .setToString("str")
            .setToStringAsFunction(true)
            .setUndefined("None")
            .setRangedForLoops(true)
            .setRangedForLoopsStart(" in range(")
            .setRangedForLoopsMiddle(", ")
            .setRangedForLoopsEnd(")")
            .setFunctionReturnsExplicit(false)
            .setVariableTypesExplicit(false)
            .setVariableDeclareStart("")
            .addValueAliases(
                new Dictionary<string, string>
                {
                    { "false", "False" },
                    { "true", "True" }
                })
            .addNativeFunctionAliases(
                "array",
                new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "length",
                        new Dictionary<string, string>
                        {
                            { "alias", "len" },
                            { "placement", "static" },
                            { "usage", "function" }
                        }
                    }
                })
            .addNativeFunctionAliases(
                "string",
                new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "length",
                        new Dictionary<string, string>
                        {
                            { "alias", "len" },
                            { "placement", "static" },
                            { "usage", "function" }
                        }    
                    },
                    { 
                        "find",
                        new Dictionary<string, string>
                        {
                            { "alias", "index" },
                            { "placement", "member" },
                            { "usage", "function" }
                        }
                    },
                    { 
                        "substring",
                        new Dictionary<string, string>
                        {
                            { "alias", "" },
                            { "placement", "array" },
                            { "usage", "array" },
                            { "separator", ":" }
                        }
                    }
                });
    }
}