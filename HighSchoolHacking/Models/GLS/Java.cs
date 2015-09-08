using System.Collections.Generic;

namespace HighSchoolHacking.Models.GLS
{
    static partial class Languages
    {
        public static Language Java = new Language()
            .setName("Java")
            .setExtension("java")
            .setPrintFunction("System.out.println")
            .setSemiColon(";")
            .setArrayClass("Array")
            .setArrayInitializationAsNewTyped(true)
            .setArrayLength(".length")
            .setBreak("break")
            .setCastStarter("(")
            .setCastEnder(")")
            .setClassConstructorName("")
            .setClassEnder("};")
            .setClassExtends("extends")
            .setClassFunctionsStart("")
            .setClassMemberFunctionGetStart("")
            .setClassMemberFunctionGetEnd("")
            .setClassMemberVariableDefault("")
            .setClassMemberVariablePrivacy(true)
            .setClassMemberVariableStarter("")
            .setClassNewer("new ")
            .setClassParentName("super")
            .setClassPrivacy(true)
            .setClassStaticLabel("static ")
            .setClassStartLeft("class ")
            .setClassStartRight(" {")
            .setClassPublicAlias("public ")
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
            .setDictionaryInitializeEnder("}}")
            .setDictionaryInitializeKeyComma(";")
            .setDictionaryInitializeKeyWithSemicolon(true)
            .setDictionaryInitializeStarter("() {{")
            .setDictionaryClass("HashMap")
            .setDictionaryInitializationAsNew(true)
            .setDictionaryKeyCheckAsFunction(true)
            .setDictionaryKeyChecker("containsKey")
            .setDictionaryKeyLeft("add(")
            .setDictionaryKeyMiddle(", ")
            .setDictionaryKeyRight(")")
            .setElif("} else if")
            .setElse("} else")
            .setExceptionCatch("} catch (")
            .setExceptionClass("Exception")
            .setExceptionErrorPrefix(" ")
            .setExceptionFinally("} finally")
            .setExceptionThrow("throw")
            .setExceptionTry("try")
            .setFileEndLine("}")
            .setFileStartLeft("public class ")
            .setFileStartRight(" {")
            .setForEachInner(" in ")
            .setForEachKeysGet(".KeySet()")
            .setForEachPairsGet(".EntrySet()")
            .setForEachPairsPairClass("MapEntry")
            .setForEachPairsAsPair(true)
            .setForEachPairsRetrieveKey(".getKey()")
            .setForEachPairsRetrieveValue(".getValue()")
            .setForEachStarter("for (")
            .setFunctionDefine("")
            .setFunctionDefineRight(" {")
            .setFunctionDefineEnd("}")
            .setFunctionReturnsExplicit(true)
            .setFunctionTypeAfterName(false)
            .setIf("if")
            .setIncludeDictionaryType("java.util.*")
            .setIncludeEnder("")
            .setIncludeStarter("import ")
            .setLambdaDeclareEnder("")
            .setLambdaDeclareMiddle(") -> ")
            .setLambdaDeclareStarter("(")
            .setLambdaTypeDeclarationAsInterface(true)
            .setLambdaTypeDeclarationEnd(new string[] { "}" })
            .setLambdaTypeDeclarationMiddle(new string[] { "run", ";" })
            .setLambdaTypeDeclarationRequired(true)
            .setLambdaTypeDeclarationStart(new string[] { "interface ", " {" })
            .setMainEndLine("}")
            .setMainStartLine("public void main() {")
            .setToString("String.valueOf")
            .setToStringAsFunction(true)
            .setUndefined("null")
            .setRangedForLoops(false)
            .setVariableDeclareStart("")
            .setVariableTypesExplicit(true)
            .setVariableTypesAfterName(false)
            .addTypeAliases(
                new Dictionary<string, string>
                {
                    { "number", "int" },
                    { "string", "String" },
                    { "mixed", "Object" },
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
                            { "usage", "function" }
                        }
                    },
                    {
                        "find",
                        new Dictionary<string, string>
                        {
                            { "alias", "indexOf" },
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