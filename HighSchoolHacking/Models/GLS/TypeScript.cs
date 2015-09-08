using System.Collections.Generic;

namespace HighSchoolHacking.Models.GLS
{
    static partial class Languages
    {
        public static Language TypeScript = new Language()
            .setName("TypeScript")
            .setExtension("ts")
            .setPrintFunction("console.log")
            .setSemiColon(";")
            .setArrayClass("Array")
            .setArrayLength(".length")
            .setBreak("break")
            .setCastStarter("<")
            .setCastEnder(">")
            .setClassConstructorName("constructor")
            .setClassEnder("}")
            .setClassExtends("extends")
            .setClassFunctionsTakeThis(false)
            .setClassFunctionsStart("")
            .setClassMemberFunctionGetBind(true)
            .setClassMemberFunctionGetStart("")
            .setClassMemberFunctionGetEnd(".bind")
            .setClassMemberVariableDefault("")
            .setClassMemberVariablePrivacy(true)
            .setClassMemberVariableStarter("")
            .setClassNewer("new ")
            .setClassParentName("super")
            .setClassPublicAlias("export ")
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
            .setDictionaryClass("any")
            .setDictionaryInitializeEnder("}")
            .setDictionaryInitializeKeyComma(",")
            .setDictionaryInitializeStarter("{")
            .setDictionaryKeyCheckAsFunction(true)
            .setDictionaryKeyChecker("hasOwnProperty")
            .setDictionaryKeyLeft("")
            .setDictionaryKeyMiddle(": ")
            .setDictionaryKeyRight("")
            .setElif("} else if")
            .setElse("} else")
            .setExceptionCatch("} catch (")
            .setExceptionClass("Error")
            .setExceptionErrorPrefix(" ")
            .setExceptionFinally("} finally")
            .setExceptionThrow("throw")
            .setExceptionTry("try")
            .setFileEndLine("}")
            .setFileStartLeft("module ")
            .setFileStartRight(" {")
            .setForEachInner(" in ")
            .setForEachKeysGet("")
            .setForEachPairsGet("")
            .setForEachStarter("for (")
            .setFunctionDefine("function ")
            .setFunctionDefineRight(" {")
            .setFunctionDefineEnd("}")
            .setFunctionReturnsExplicit(true)
            .setFunctionTypeMarker(": ")
            .setFunctionTypeAfterName(true)
            .setIf("if")
            .setIncludeDictionaryType("")
            .setIncludeEnder("' />")
            .setIncludeFileExtension(true)
            .setIncludeStarter("/// <reference path='")
            .setLambdaDeclareEnder("")
            .setLambdaDeclareMiddle(") => ")
            .setLambdaDeclareStarter("(")
            .setLambdaTypeDeclarationAsInterface(true)
            .setLambdaTypeDeclarationEnd(new string[] { "}" })
            .setLambdaTypeDeclarationMiddle(new string[] { "", ";" })
            .setLambdaTypeDeclarationRequired(true)
            .setLambdaTypeDeclarationStart(new string[] { "interface ", " {" })
            .setMainEndLine("}")
            .setMainStartLine("export function Main(): void {")
            .setToString("")
            .setUndefined("undefined")
            .setRangedForLoops(false)
            .setVariableTypesExplicit(true)
            .setVariableTypesAfterName(true)
            .setVariableTypeMarker(": ")
            .setVariableDeclareStart("var ")
            .addTypeAliases(
                new Dictionary<string, string>
                {
                    { "int", "number" },
                    { "double", "number" },
                    { "float", "number" },
                    { "bool", "boolean" },
                    { "mixed", "any" },
                    { "character", "string" }
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
                            { "usage", "variable" }
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