using System.Collections.Generic;

namespace HighSchoolHacking.Models.GLS 
{
    static partial class Languages {
        public static Language CSharp = new Language()
            .setName("CSharp")
            .setExtension("cs")
            .setPrintFunction("System.Console.WriteLine")
            .setSemiColon(";")
            .setArrayClass("Array")
            .setArrayInitializationAsNewTyped(true)
            .setArrayLength(".Length")
            .setBreak("break")
            .setCastStarter("(")
            .setCastEnder(")")
            .setClassConstructorName("")
            .setClassConstructorInheritedShorthand(true)
            .setClassEnder("};")
            .setClassExtends("extends")
            .setClassFunctionsTakeThis(false)
            .setClassFunctionsStart("")
            .setClassMemberFunctionGetStart("")
            .setClassMemberFunctionGetEnd("")
            .setClassMemberVariableDefault("")
            .setClassMemberVariablePrivacy(true)
            .setClassMemberVariableStarter("")
            .setClassNewer("new ")
            .setClassParentName("base")
            .setClassPublicAlias("public ")
            .setClassPrivacy(true)
            .setClassStaticLabel("static ")
            .setClassStartLeft("class ")
            .setClassStartRight(" {")
            .setClassTemplates(true)
            .setClassTemplatesBetween(", ")
            .setClassThis("this")
            .setClassThisAccess(".")
            .setCommentorBlockStart("/*")
            .setCommentorBlockEnd("*/")
            .setCommentorInline("//")
            .setConditionStartLeft(" (")
            .setConditionStartRight(") {")
            .setConditionContinueLeft("} ")
            .setConditionContinueRight(" {")
            .setConditionEnd("}")
            .setContinue("continue")
            .setDictionaryInitializeEnder("}")
            .setDictionaryInitializeKeyComma(",")
            .setDictionaryInitializeStarter(" {")
            .setDictionaryClass("Dictionary")
            .setDictionaryInitializationAsNew(true)
            .setDictionaryKeyCheckAsFunction(true)
            .setDictionaryKeyChecker("ContainsKey")
            .setDictionaryKeyLeft("{ ")
            .setDictionaryKeyMiddle(", ")
            .setDictionaryKeyRight(" }")
            .setElif("} else if")
            .setElse("} else")
            .setExceptionCatch("} catch (")
            .setExceptionClass("System.Exception")
            .setExceptionErrorPrefix(" ")
            .setExceptionFinally("} finally")
            .setExceptionThrow("throw")
            .setExceptionTry("try")
            .setFileEndLine("}")
            .setFileStartLeft("public class ")
            .setFileStartRight(" {")
            .setForEachInner(" in ")
            .setForEachKeysGet(".Keys")
            .setForEachPairsGet("")
            .setForEachPairsPairClass("KeyValuePair")
            .setForEachPairsAsPair(true)
            .setForEachPairsRetrieveKey(".Key")
            .setForEachPairsRetrieveValue(".Value")
            .setForEachStarter("foreach (")
            .setFunctionDefine("")
            .setFunctionDefineRight(" {")
            .setFunctionDefineEnd("}")
            .setFunctionReturnsExplicit(true)
            .setFunctionTypeAfterName(false)
            .setIf("if")
            .setIncludeDictionaryType("System.Collections.Generic")
            .setIncludeEnder(";")
            .setIncludeStarter("using ")
            .setLambdaDeclareEnder("")
            .setLambdaDeclareMiddle(") => ")
            .setLambdaDeclareStarter("(")
            .setLambdaTypeDeclarationEnd(new string[] { "", ";" })
            .setLambdaTypeDeclarationMiddle(new string[] { "(", ")" })
            .setLambdaTypeDeclarationRequired(true)
            .setLambdaTypeDeclarationStart(new string[] { "", "delegate"})
            .setMainEndLine("}")
            .setMainStartLine("public static void Main() {")
            .setToString(".ToString()")
            .setUndefined("null")
            .setRangedForLoops(false)
            .setVariableDeclareStart("")
            .setVariableTypesExplicit(true)
            .setVariableTypesAfterName(false)
            .addTypeAliases(
                new Dictionary<string, string>
                {
                    { "number", "int" },
                    { "boolean", "bool" },
                    { "mixed", "object" },
                    { "character", "char" }
                })
            .addNativeFunctionAliases(
                "array",
                new Dictionary<string, Dictionary<string, string>> 
                {
                    { 
                        "length",
                        new Dictionary<string, string>
                        {
                            { "alias", "Length" },
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
                            { "alias", "Length"},
                            { "placement", "member" },
                            { "usage", "variable" }
                        }
                    },
                    {
                        "find",
                        new Dictionary<string, string>
                        {
                            { "alias", "IndexOf" },
                            { "placement", "member" },
                            { "usage", "function" }
                        }
                    },
                    {
                        "substring",
                        new Dictionary<string, string>
                        {
                            { "alias", "Substring" },
                            { "placement", "member" },
                            { "usage", "function" }
                        }
                    }
                });
    }
}