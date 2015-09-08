using System.Collections.Generic;

namespace HighSchoolHacking.Models.GLS
{
    static partial class Languages
    {
        public static Language Ruby = new Language()
            .setName("Ruby")
            .setExtension("rb")
            .setPrintFunction("puts")
            .setSemiColon("")
            .setArrayClass("Array")
            .setArrayLength(".length")
            .setArrayInitializationAsNewStatic(true)
            .setArrayNegativeIndices(true)
            .setBreak("break")
            .setClassConstructorAsStatic(true)
            .setClassParentName("super")
            .setClassConstructorName("initialize")
            .setClassConstructorLoose(true)
            .setClassEnder("end")
            .setClassExtends("<")
            .setClassFunctionsStart("def ")
            .setClassFunctionsTakeThis(false)
            .setClassFunctionsThis("")
            .setClassMemberFunctionGetStart("")
            .setClassMemberFunctionGetEnd("")
            .setClassMemberVariableDefault("")
            .setClassMemberVariablePrivacy(false)
            .setClassMemberVariableStarter("@")
            .setClassNewer("new")
            .setClassPrivacy(false)
            .setClassPublicAlias("public ")
            .setClassStaticLabel("")
            .setClassStartLeft("class ")
            .setClassStartRight("")
            .setClassThis("@")
            .setClassThisAccess("")
            .setCommentorBlockStart("=begin")
            .setCommentorBlockEnd("=end")
            .setCommentorInline("#")
            .setConditionStartLeft(" ")
            .setConditionStartRight("")
            .setConditionContinueLeft(" ")
            .setConditionContinueRight("")
            .setConditionEnd("end")
            .setContinue("next")
            .setDictionaryInitializeEnder("}")
            .setDictionaryInitializeKeyComma(",")
            .setDictionaryInitializeStarter(" {")
            .setDictionaryKeyCheckAsFunction(true)
            .setDictionaryKeyChecker("has_key?")
            .setDictionaryKeyLeft("")
            .setDictionaryKeyMiddle(": ")
            .setDictionaryKeyRight("")
            .setElif("elsif")
            .setElse("else")
            .setExceptionCatch("rescue ")
            .setExceptionClass("Exception")
            .setExceptionErrorPrefix(" => ")
            .setExceptionFinally("ensure")
            .setExceptionThrow("raise")
            .setExceptionTry("begin")
            .setFileEndLine("")
            .setFileStartLeft("")
            .setFileStartRight("")
            .setForEachAsMethod(true)
            .setForEachInner("|")
            .setForEachStarter(".each do |")
            .setFunctionDefine("def ")
            .setFunctionDefineRight("")
            .setFunctionDefineEnd("end")
            .setIf("if")
            .setIncludeDictionaryType("")
            .setIncludeEnder("'")
            .setIncludeFileExtension(true)
            .setIncludeStarter("require '")
            .setLambdaDeclareEnder(" }")
            .setLambdaDeclareMiddle("| { ")
            .setLambdaDeclareStarter("lambda do |")
            .setLambdaTypeDeclarationAsInterface(true)
            .setLambdaTypeDeclarationEnd(new string[] { "}" })
            .setLambdaTypeDeclarationMiddle(new string[] { "", ";" })
            .setLambdaTypeDeclarationRequired(true)
            .setLambdaTypeDeclarationStart(new string[] { "interface ", " {" })
            .setMainEndLine("end")
            .setMainStartLine("if __FILE__ == $PROGRAM_NAME")
            .setToString(".to_s")
            .setUndefined("nil")
            .setRangedForLoops(true)
            .setRangedForLoopsStart(" in ")
            .setRangedForLoopsMiddle("..")
            .setRangedForLoopsEnd("")
            .setFunctionReturnsExplicit(false)
            .setVariableTypesExplicit(false)
            .setVariableDeclareStart("")
            .addNativeFunctionAliases(
                "array",
                new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "length",
                        new Dictionary<string, string>
                        {
                            { "alias", "length" },
                            { "placement", "member" },
                            { "usage", "variable" }
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
                            { "alias", "length" },
                            { "placement", "member" },
                            { "usage", "variable" }
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
                            { "alias", "substring" },
                            { "placement", "member" },
                            { "usage", "function" }
                        }
                    }
                });
    }
}