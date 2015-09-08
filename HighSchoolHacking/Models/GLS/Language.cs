using System.Collections.Generic;

namespace HighSchoolHacking.Models.GLS
{
    public delegate object[] Printer(string[] functionArgs, bool isInline);

    public class Language
    {
        private Dictionary<string, Printer> Printers;
        private Dictionary<string, string> OperationAliases;
        private Dictionary<string, string> TypeAliases;
        private Dictionary<string, string> ValueAliases;
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> NativeFunctionAliases;

        // General information
        private string Name;
        private string Extension;
        private string PrintFunction;
        private string SemiColon;

        // Comments
        private string CommentorBlockStart;
        private string CommentorBlockEnd;
        private string CommentorInline;

        // Conditionals
        private string ConditionStartLeft;
        private string ConditionStartRight;
        private string ConditionContinueLeft;
        private string ConditionContinueRight;
        private string ConditionEnd;
        private string Elif;
        private string Else;
        private string If;

        // Operators
        private string And;
        private string GreaterThan;
        private string GreaterThanOrEqual;
        private string LessThan;
        private string LessThanOrEqual;
        private string Or;

        // Variables
        private string CastEnder;
        private string CastStarter;
        private string Undefined;
        private bool VariableTypesExplicit;
        private bool VariableTypesAfterName;
        private string VariableTypeMarker;
        private string VariableDeclareStart;

        // Booleans

        private string BooleanClass;
        private string True;
        private string False;

        // Numbers
        private string NumberClass;

        // Strings
        private string StringClass;
        private string StringLength;
        private string ToString;
        private bool ToStringAsFunction;

        // Loops
        private string Break;
        private string Continue;
        private bool ForEachAsMethod;
        private string ForEachInner;
        private bool ForEachKeysAsStatic;
        private string ForEachKeysGet;
        private string ForEachPairsGet;
        private string ForEachPairsPairClass;
        private bool ForEachPairsAsPair;
        private string ForEachPairsRetrieveKey;
        private string ForEachPairsRetrieveValue;
        private string ForEachStarter;
        private bool RangedForLoops;
        private string RangedForLoopsStart;
        private string RangedForLoopsMiddle;
        private string RangedForLoopsEnd;

        // Arrays
        private string ArrayClass;
        private bool ArrayInitializationAsNew;
        private bool ArrayInitializationAsNewMultiplied;
        private bool ArrayInitializationAsNewStatic;
        private bool ArrayInitializationAsNewTyped;
        private string ArrayLength;
        private bool ArrayLengthAsFunction;
        private bool ArrayNegativeIndices;

        // Dictionaries
        private string DictionaryClass;
        private bool DictionaryInitializationAsNew;
        private string DictionaryInitializeEnder;
        private string DictionaryInitializeKeyComma;
        private bool DictionaryInitializeKeyWithSemicolon;
        private string DictionaryInitializeStarter;
        private bool DictionaryKeyCheckAsFunction;
        private string DictionaryKeyChecker;
        private string DictionaryKeyLeft;
        private string DictionaryKeyMiddle;
        private string DictionaryKeyRight;

        // Exceptions
        private string ExceptionCatch;
        private string ExceptionClass;
        private string ExceptionErrorPrefix;
        private string ExceptionFinally;
        private string ExceptionThrow;
        private string ExceptionTry;

        // Functions
        private string FunctionDefine;
        private string FunctionDefineRight;
        private string FunctionDefineEnd;
        private bool FunctionReturnsExplicit;
        private bool FunctionTypeAfterName;
        private string FunctionTypeMarker;

        // Lambdas
        private string LambdaDeclareEnder;
        private string LambdaDeclareMiddle;
        private string LambdaDeclareStarter;
        private bool LambdaTypeDeclarationAsInterface;
        private bool LambdaTypeDeclarationRequired;
        private string[] LambdaTypeDeclarationEnd;
        private string[] LambdaTypeDeclarationMiddle;
        private string[] LambdaTypeDeclarationStart;

        // Classes
        private bool ClassConstructorAsStatic;
        private bool ClassConstructorInheritedShorthand;
        private string ClassConstructorName;
        private bool ClassConstructorLoose;
        private string ClassEnder;
        private string ClassExtends;
        private bool ClassExtendsAsFunction;
        private string ClassFunctionsStart;
        private string ClassFunctionsThis;
        private string ClassMemberFunctionGetEnd;
        private string ClassMemberFunctionGetStart;
        private bool ClassMemberFunctionGetBind;
        private bool ClassFunctionsTakeThis;
        private string ClassMemberVariableDefault;
        private bool ClassMemberVariablePrivacy;
        private string ClassMemberVariableStarter;
        private string ClassNewer;
        private string ClassParentName;
        private bool ClassPrivacy;
        private string ClassPublicAlias;
        private string ClassStaticLabel;
        private string ClassStaticFunctionDecorator;
        private bool ClassStaticFunctionRequiresDecorator;
        private string ClassStartLeft;
        private string ClassStartRight;
        private bool ClassTemplates;
        private string ClassTemplatesBetween;
        private string ClassThis;
        private string ClassThisAccess;

        // File
        private string FileEndLine;
        private string FileStartLeft;
        private string FileStartRight;
        private string IncludeDictionaryType;
        private string IncludeEnder;
        private bool IncludeFileExtension;
        private string IncludeStarter;

        // Main
        private string MainEndLine;
        private string MainStartLine;

        // Extra
        public static int INT_MIN = 9001;

        public Language()
        {
            this.Printers = new Dictionary<string, Printer> {
                { "array initialize", this.ArrayInitialize },
                { "array initialize sized", this.ArrayInitializeSized },
                { "array get item", this.ArrayGetItem },
                { "cast", this.Cast },
                { "catch", this.Catch },
                { "class constructor end", this.ClassConstructorEnd },
                { "class constructor inherited call", this.ClassConstructorInheritedCall },
                { "class constructor inherited start", this.ClassConstructorInheritedStart },
                { "class constructor start", this.ClassConstructorStart },
                { "class end", this.ClassEnd },
                { "class member function call", this.ClassMemberFunctionCall },
                { "class member function end", this.ClassMemberFunctionEnd },
                { "class member function get", this.ClassMemberFunctionGet },
                { "class member function start", this.ClassMemberFunctionStart },
                { "class member variable declare", this.ClassMemberVariableDeclare },
                { "class member variable get", this.ClassMemberVariableGet },
                { "class member variable set", this.ClassMemberVariableSet },
                { "class member variable set incomplete", this.ClassMemberVariableSetIncomplete },
                { "class static function call", this.ClassStaticFunctionCall },
                { "class static function end", this.ClassStaticFunctionEnd },
                { "class static function get", this.ClassStaticFunctionGet },
                { "class static function start", this.ClassStaticFunctionStart },
                { "class static variable declare", this.ClassStaticVariableDeclare },
                { "class static variable get", this.ClassStaticVariableGet },
                { "class static variable set", this.ClassStaticVariableSet },
                { "class new", this.ClassNew },
                { "class start", this.ClassStart },
                { "comment block", this.CommentBlock },
                { "comment line", this.CommentLine },
                { "comment inline", this.CommentInline },
                { "comparison", this.Comparison },
                { "concatenate", this.Concatenate },
                { "dictionary key check", this.DictionaryKeyCheck },
                { "dictionary key get", this.DictionaryKeyGet },
                { "dictionary key set", this.DictionaryKeySet },
                { "dictionary initialize", this.DictionaryInitialize },
                { "dictionary initialize end", this.DictionaryInitializeEnd },
                { "dictionary initialize key", this.DictionaryInitializeKey },
                { "dictionary initialize start", this.DictionaryInitializeStart },
                { "dictionary type", this.DictionaryType },
                { "elif start", this.ElifStart },
                { "else start", this.ElseStart },
                { "file end", this.FileEnd },
                { "file start", this.FileStart },
                { "finally", this.Finally },
                { "for each keys start", this.ForEachKeysStart },
                { "for each pairs start", this.ForEachPairsStart },
                { "for end", this.ForEnd },
                { "for numbers start", this.ForNumbersStart },
                { "function call", this.FunctionCall },
                { "function call partial end", this.FunctionCallPartialEnd },
                { "function call partial start", this.FunctionCallPartialStart },
                { "function end", this.FunctionEnd },
                { "function start", this.FunctionStart },
                { "if end", this.IfEnd },
                { "if start", this.IfStart },
                { "include", this.Include },
                { "include dictionary", this.IncludeDictionary },
                { "lambda declare inline", this.LambdaDeclareInline },
                { "lambda type declare", this.LambdaTypeDeclare },
                { "loop break", this.LoopBreak },
                { "loop continue", this.LoopContinue },
                { "main end", this.MainEnd },
                { "main start", this.MainStart },
                { "native call", this.NativeCall },
                { "not", this.Not },
                { "operation", this.Operation },
                { "parenthesis", this.Parenthesis },
                { "print line", this.PrintLine },
                { "return", this.Return },
                { "this", this.This },
                { "throw", this.Throw },
                { "try end", this.TryEnd },
                { "try start", this.TryStart },
                { "type", this.Type },
                { "value", this.Value },
                { "variable declare", this.VariableDeclare },
                { "variable declare incomplete", this.VariableDeclareIncomplete },
                { "variable declare partial", this.VariableDeclarePartial },
                { "while end", this.WhileEnd },
                { "while start", this.WhileStart }
            };

            this.OperationAliases = new Dictionary<string, string> {
                { "equals", "=" },
                { "plus", "+" },
                { "minus", "-" },
                { "times", "*" },
                { "divide", "/" },
                { "increaseby", "+=" },
                { "decreaseby", "-=" },
                { "multiplyby", "*=" },
                { "divideby", "/=" },
                { "lessthan", "<" },
                { "greaterthan", ">" },
                { "lessthanequal", "<=" },
                { "greaterthanequal", ">=" },
                { "equalto", "==" },
                { "notequalto", "!=" },
                { "and", "&&" },
                { "or", "||" },
                { "mod", "%" }
            };

            this.TypeAliases = new Dictionary<string, string>();

            this.ValueAliases = new Dictionary<string, string>();

            this.NativeFunctionAliases = new Dictionary<string, Dictionary<string, Dictionary<string, string>>> {
                { "array", new Dictionary<string, Dictionary<string, string>>() },
                { "dictionary", new Dictionary<string, Dictionary<string, string>>() },
                { "string", new Dictionary<string, Dictionary<string, string>>() },
            };
        }

        /*
        Gets
        */

        public string getName()
        {
            return this.Name;
        }

        public string getExtension()
        {
            return this.Extension;
        }

        public string getPrintFunction()
        {
            return this.PrintFunction;
        }

        public string getSemiColon()
        {
            return this.SemiColon;
        }

        public string getCommentorBlockStart()
        {
            return this.CommentorBlockStart;
        }

        public string getCommentorBlockEnd()
        {
            return this.CommentorBlockEnd;
        }

        public string getCommentorInline()
        {
            return this.CommentorInline;
        }

        public string getConditionStartLeft()
        {
            return this.ConditionStartLeft;
        }

        public string getConditionStartRight()
        {
            return this.ConditionStartRight;
        }

        public string getConditionContinueLeft()
        {
            return this.ConditionContinueLeft;
        }

        public string getConditionContinueRight()
        {
            return this.ConditionContinueRight;
        }

        public string getConditionEnd()
        {
            return this.ConditionEnd;
        }

        public string getElif()
        {
            return this.Elif;
        }

        public string getElse()
        {
            return this.Else;
        }

        public string getIf()
        {
            return this.If;
        }

        public string getAnd()
        {
            return this.And;
        }

        public string getGreaterThan()
        {
            return this.GreaterThan;
        }

        public string getGreaterThanOrEqual()
        {
            return this.GreaterThanOrEqual;
        }

        public string getLessThan()
        {
            return this.LessThan;
        }

        public string getLessThanOrEqual()
        {
            return this.LessThanOrEqual;
        }

        public string getOr()
        {
            return this.Or;
        }

        public string getCastEnder()
        {
            return this.CastEnder;
        }

        public string getCastStarter()
        {
            return this.CastStarter;
        }

        public string getUndefined()
        {
            return this.Undefined;
        }

        public bool getVariableTypesExplicit()
        {
            return this.VariableTypesExplicit;
        }

        public bool getVariableTypesAfterName()
        {
            return this.VariableTypesAfterName;
        }

        public string getVariableTypeMarker()
        {
            return this.VariableTypeMarker;
        }

        public string getVariableDeclareStart()
        {
            return this.VariableDeclareStart;
        }

        public string getBooleanClass()
        {
            return this.BooleanClass;
        }

        public string getTrue()
        {
            return this.True;
        }

        public string getFalse()
        {
            return this.False;
        }

        public string getNumberClass()
        {
            return this.NumberClass;
        }

        public string getStringClass()
        {
            return this.StringClass;
        }

        public string getStringLength()
        {
            return this.StringLength;
        }

        public string getToString()
        {
            return this.ToString;
        }

        public bool getToStringAsFunction()
        {
            return this.ToStringAsFunction;
        }

        public string getBreak()
        {
            return this.Break;
        }

        public string getContinue()
        {
            return this.Continue;
        }

        public bool getForEachAsMethod()
        {
            return this.ForEachAsMethod;
        }

        public string getForEachInner()
        {
            return this.ForEachInner;
        }

        public bool getForEachKeysAsStatic()
        {
            return this.ForEachKeysAsStatic;
        }

        public string getForEachKeysGet()
        {
            return this.ForEachKeysGet;
        }

        public string getForEachPairsGet()
        {
            return this.ForEachPairsGet;
        }

        public string getForEachPairsPairClass()
        {
            return this.ForEachPairsPairClass;
        }

        public bool getForEachPairsAsPair()
        {
            return this.ForEachPairsAsPair;
        }

        public string getForEachPairsRetrieveKey()
        {
            return this.ForEachPairsRetrieveKey;
        }

        public string getForEachPairsRetrieveValue()
        {
            return this.ForEachPairsRetrieveValue;
        }

        public string getForEachStarter()
        {
            return this.ForEachStarter;
        }

        public bool getRangedForLoops()
        {
            return this.RangedForLoops;
        }

        public string getRangedForLoopsStart()
        {
            return this.RangedForLoopsStart;
        }

        public string getRangedForLoopsMiddle()
        {
            return this.RangedForLoopsMiddle;
        }

        public string getRangedForLoopsEnd()
        {
            return this.RangedForLoopsEnd;
        }

        public string getArrayClass()
        {
            return this.ArrayClass;
        }

        public bool getArrayInitializationAsNew()
        {
            return this.ArrayInitializationAsNew;
        }

        public bool getArrayInitializationAsNewMultiplied()
        {
            return this.ArrayInitializationAsNewMultiplied;
        }

        public bool getArrayInitializationAsNewStatic()
        {
            return this.ArrayInitializationAsNewStatic;
        }

        public bool getArrayInitializationAsNewTyped()
        {
            return this.ArrayInitializationAsNewTyped;
        }

        public string getArrayLength()
        {
            return this.ArrayLength;
        }

        public bool getArrayLengthAsFunction()
        {
            return this.ArrayLengthAsFunction;
        }

        public bool getArrayNegativeIndices()
        {
            return this.ArrayNegativeIndices;
        }

        public string getDictionaryClass()
        {
            return this.DictionaryClass;
        }

        public bool getDictionaryInitializationAsNew()
        {
            return this.DictionaryInitializationAsNew;
        }

        public string getDictionaryInitializeStarter()
        {
            return this.DictionaryInitializeStarter;
        }

        public string getDictionaryInitializeEnder()
        {
            return this.DictionaryInitializeEnder;
        }

        public string getDictionaryInitializeKeyComma()
        {
            return this.DictionaryInitializeKeyComma;
        }

        public bool getDictionaryInitializeKeyWithSemicolon()
        {
            return this.DictionaryInitializeKeyWithSemicolon;
        }

        public bool getDictionaryKeyCheckAsFunction()
        {
            return this.DictionaryKeyCheckAsFunction;
        }

        public string getDictionaryKeyChecker()
        {
            return this.DictionaryKeyChecker;
        }

        public string getDictionaryKeyLeft()
        {
            return this.DictionaryKeyLeft;
        }

        public string getDictionaryKeyMiddle()
        {
            return this.DictionaryKeyMiddle;
        }

        public string getDictionaryKeyRight()
        {
            return this.DictionaryKeyRight;
        }

        public string getExceptionCatch()
        {
            return this.ExceptionCatch;
        }

        public string getExceptionClass()
        {
            return this.ExceptionClass;
        }

        public string getExceptionErrorPrefix()
        {
            return this.ExceptionErrorPrefix;
        }

        public string getExceptionFinally()
        {
            return this.ExceptionFinally;
        }

        public string getExceptionThrow()
        {
            return this.ExceptionThrow;
        }

        public string getExceptionTry()
        {
            return this.ExceptionTry;
        }

        public string getFunctionDefine()
        {
            return this.FunctionDefine;
        }

        public string getFunctionDefineRight()
        {
            return this.FunctionDefineRight;
        }

        public string getFunctionDefineEnd()
        {
            return this.FunctionDefineEnd;
        }

        public bool getFunctionReturnsExplicit()
        {
            return this.FunctionReturnsExplicit;
        }

        public bool getFunctionTypeAfterName()
        {
            return this.FunctionTypeAfterName;
        }

        public string getFunctionTypeMarker()
        {
            return this.FunctionTypeMarker;
        }

        public string getLambdaDeclareEnder()
        {
            return this.LambdaDeclareEnder;
        }

        public string getLambdaDeclareMiddle()
        {
            return this.LambdaDeclareMiddle;
        }

        public string getLambdaDeclareStarter()
        {
            return this.LambdaDeclareStarter;
        }

        public bool getLambdaTypeDeclarationAsInterface()
        {
            return this.LambdaTypeDeclarationAsInterface;
        }

        public bool getLambdaTypeDeclarationRequired()
        {
            return this.LambdaTypeDeclarationRequired;
        }

        public string[] getLambdaTypeDeclarationEnd()
        {
            return this.LambdaTypeDeclarationEnd;
        }

        public string[] getLambdaTypeDeclarationMiddle()
        {
            return this.LambdaTypeDeclarationMiddle;
        }

        public string[] getLambdaTypeDeclarationStart()
        {
            return this.LambdaTypeDeclarationStart;
        }

        public bool getClassConstructorAsStatic()
        {
            return this.ClassConstructorAsStatic;
        }

        public bool getClassConstructorInheritedShorthand()
        {
            return this.ClassConstructorInheritedShorthand;
        }

        public string getClassConstructorName()
        {
            return this.ClassConstructorName;
        }

        public bool getClassConstructorLoose()
        {
            return this.ClassConstructorLoose;
        }

        public string getClassEnder()
        {
            return this.ClassEnder;
        }

        public string getClassExtends()
        {
            return this.ClassExtends;
        }

        public bool getClassExtendsAsFunction()
        {
            return this.ClassExtendsAsFunction;
        }

        public bool getClassFunctionsTakeThis()
        {
            return this.ClassFunctionsTakeThis;
        }

        public string getClassFunctionsStart()
        {
            return this.ClassFunctionsStart;
        }

        public string getClassFunctionsThis()
        {
            return this.ClassFunctionsThis;
        }

        public bool getClassMemberFunctionGetBind()
        {
            return this.ClassMemberFunctionGetBind;
        }

        public string getClassMemberFunctionGetEnd()
        {
            return this.ClassMemberFunctionGetEnd;
        }

        public string getClassMemberFunctionGetStart()
        {
            return this.ClassMemberFunctionGetStart;
        }

        public string getClassMemberVariableDefault()
        {
            return this.ClassMemberVariableDefault;
        }

        public bool getClassMemberVariablePrivacy()
        {
            return this.ClassMemberVariablePrivacy;
        }

        public string getClassMemberVariableStarter()
        {
            return this.ClassMemberVariableStarter;
        }

        public string getClassNewer()
        {
            return this.ClassNewer;
        }

        public string getClassParentName()
        {
            return this.ClassParentName;
        }

        public bool getClassPrivacy()
        {
            return this.ClassPrivacy;
        }

        public string getClassPublicAlias()
        {
            return this.ClassPublicAlias;
        }

        public string getClassStaticLabel()
        {
            return this.ClassStaticLabel;
        }

        public string getClassStaticFunctionDecorator()
        {
            return this.ClassStaticFunctionDecorator;
        }

        public bool getClassStaticFunctionRequiresDecorator()
        {
            return this.ClassStaticFunctionRequiresDecorator;
        }

        public string getClassStartLeft()
        {
            return this.ClassStartLeft;
        }

        public string getClassStartRight()
        {
            return this.ClassStartRight;
        }

        public bool getClassTemplates()
        {
            return this.ClassTemplates;
        }

        public string getClassTemplatesBetween()
        {
            return this.ClassTemplatesBetween;
        }

        public string getClassThis()
        {
            return this.ClassThis;
        }

        public string getClassThisAccess()
        {
            return this.ClassThisAccess;
        }

        public string getFileEndLine()
        {
            return this.FileEndLine;
        }

        public string getFileStartLeft()
        {
            return this.FileStartLeft;
        }

        public string getFileStartRight()
        {
            return this.FileStartRight;
        }

        public string getIncludeDictionaryType()
        {
            return this.IncludeDictionaryType;
        }

        public string getIncludeEnder()
        {
            return this.IncludeEnder;
        }

        public bool getIncludeFileExtension()
        {
            return this.IncludeFileExtension;
        }

        public string getIncludeStarter()
        {
            return this.IncludeStarter;
        }

        public string getMainEndLine()
        {
            return this.MainEndLine;
        }

        public string getMainStartLine()
        {
            return this.MainStartLine;
        }


        /*
        Sets
        */

        public Language setName(string value)
        {
            this.Name = value;
            return this;
        }

        public Language setExtension(string value)
        {
            this.Extension = value;
            return this;
        }

        public Language setPrintFunction(string value)
        {
            this.PrintFunction = value;
            return this;
        }

        public Language setSemiColon(string value)
        {
            this.SemiColon = value;
            return this;
        }

        public Language setCommentorBlockStart(string value)
        {
            this.CommentorBlockStart = value;
            return this;
        }

        public Language setCommentorBlockEnd(string value)
        {
            this.CommentorBlockEnd = value;
            return this;
        }

        public Language setCommentorInline(string value)
        {
            this.CommentorInline = value;
            return this;
        }

        public Language setConditionStartLeft(string value)
        {
            this.ConditionStartLeft = value;
            return this;
        }

        public Language setConditionStartRight(string value)
        {
            this.ConditionStartRight = value;
            return this;
        }

        public Language setConditionContinueLeft(string value)
        {
            this.ConditionContinueLeft = value;
            return this;
        }

        public Language setConditionContinueRight(string value)
        {
            this.ConditionContinueRight = value;
            return this;
        }

        public Language setConditionEnd(string value)
        {
            this.ConditionEnd = value;
            return this;
        }

        public Language setElif(string value)
        {
            this.Elif = value;
            return this;
        }

        public Language setElse(string value)
        {
            this.Else = value;
            return this;
        }

        public Language setIf(string value)
        {
            this.If = value;
            return this;
        }

        public Language setAnd(string value)
        {
            this.And = value;
            return this;
        }

        public Language setGreaterThan(string value)
        {
            this.GreaterThan = value;
            return this;
        }

        public Language setGreaterThanOrEqual(string value)
        {
            this.GreaterThanOrEqual = value;
            return this;
        }

        public Language setLessThan(string value)
        {
            this.LessThan = value;
            return this;
        }

        public Language setLessThanOrEqual(string value)
        {
            this.LessThanOrEqual = value;
            return this;
        }

        public Language setOr(string value)
        {
            this.Or = value;
            return this;
        }

        public Language setCastEnder(string value)
        {
            this.CastEnder = value;
            return this;
        }

        public Language setCastStarter(string value)
        {
            this.CastStarter = value;
            return this;
        }

        public Language setUndefined(string value)
        {
            this.Undefined = value;
            return this;
        }

        public Language setVariableTypesExplicit(bool value)
        {
            this.VariableTypesExplicit = value;
            return this;
        }

        public Language setVariableTypesAfterName(bool value)
        {
            this.VariableTypesAfterName = value;
            return this;
        }

        public Language setVariableTypeMarker(string value)
        {
            this.VariableTypeMarker = value;
            return this;
        }

        public Language setVariableDeclareStart(string value)
        {
            this.VariableDeclareStart = value;
            return this;
        }

        public Language setBooleanClass(string value)
        {
            this.BooleanClass = value;
            return this;
        }

        public Language setTrue(string value)
        {
            this.True = value;
            return this;
        }

        public Language setFalse(string value)
        {
            this.False = value;
            return this;
        }

        public Language setNumberClass(string value)
        {
            this.NumberClass = value;
            return this;
        }

        public Language setStringClass(string value)
        {
            this.StringClass = value;
            return this;
        }

        public Language setStringLength(string value)
        {
            this.StringLength = value;
            return this;
        }

        public Language setBreak(string value)
        {
            this.Break = value;
            return this;
        }

        public Language setContinue(string value)
        {
            this.Continue = value;
            return this;
        }

        public Language setForEachAsMethod(bool value)
        {
            this.ForEachAsMethod = value;
            return this;
        }

        public Language setForEachInner(string value)
        {
            this.ForEachInner = value;
            return this;
        }

        public Language setForEachKeysAsStatic(bool value)
        {
            this.ForEachKeysAsStatic = value;
            return this;
        }

        public Language setForEachKeysGet(string value)
        {
            this.ForEachKeysGet = value;
            return this;
        }

        public Language setForEachPairsGet(string value)
        {
            this.ForEachPairsGet = value;
            return this;
        }

        public Language setForEachPairsPairClass(string value)
        {
            this.ForEachPairsPairClass = value;
            return this;
        }

        public Language setForEachPairsAsPair(bool value)
        {
            this.ForEachPairsAsPair = value;
            return this;
        }

        public Language setForEachPairsRetrieveKey(string value)
        {
            this.ForEachPairsRetrieveKey = value;
            return this;
        }

        public Language setForEachPairsRetrieveValue(string value)
        {
            this.ForEachPairsRetrieveValue = value;
            return this;
        }

        public Language setForEachStarter(string value)
        {
            this.ForEachStarter = value;
            return this;
        }

        public Language setRangedForLoops(bool value)
        {
            this.RangedForLoops = value;
            return this;
        }

        public Language setRangedForLoopsStart(string value)
        {
            this.RangedForLoopsStart = value;
            return this;
        }

        public Language setRangedForLoopsMiddle(string value)
        {
            this.RangedForLoopsMiddle = value;
            return this;
        }

        public Language setRangedForLoopsEnd(string value)
        {
            this.RangedForLoopsEnd = value;
            return this;
        }

        public Language setToString(string value)
        {
            this.ToString = value;
            return this;
        }

        public Language setToStringAsFunction(bool value)
        {
            this.ToStringAsFunction = value;
            return this;
        }

        public Language setArrayClass(string value)
        {
            this.ArrayClass = value;
            return this;
        }

        public Language setArrayInitializationAsNew(bool value)
        {
            this.ArrayInitializationAsNew = value;
            return this;
        }

        public Language setArrayInitializationAsNewMultiplied(bool value)
        {
            this.ArrayInitializationAsNewMultiplied = value;
            return this;
        }

        public Language setArrayInitializationAsNewTyped(bool value)
        {
            this.ArrayInitializationAsNewTyped = value;
            return this;
        }

        public Language setArrayInitializationAsNewStatic(bool value)
        {
            this.ArrayInitializationAsNewStatic = value;
            return this;
        }

        public Language setArrayLength(string value)
        {
            this.ArrayLength = value;
            return this;
        }

        public Language setArrayLengthAsFunction(bool value)
        {
            this.ArrayLengthAsFunction = value;
            return this;
        }

        public Language setArrayNegativeIndices(bool value)
        {
            this.ArrayNegativeIndices = value;
            return this;
        }

        public Language setExceptionCatch(string value)
        {
            this.ExceptionCatch = value;
            return this;
        }

        public Language setExceptionClass(string value)
        {
            this.ExceptionClass = value;
            return this;
        }

        public Language setExceptionErrorPrefix(string value)
        {
            this.ExceptionErrorPrefix = value;
            return this;
        }

        public Language setExceptionFinally(string value)
        {
            this.ExceptionFinally = value;
            return this;
        }

        public Language setExceptionThrow(string value)
        {
            this.ExceptionThrow = value;
            return this;
        }

        public Language setExceptionTry(string value)
        {
            this.ExceptionTry = value;
            return this;
        }

        public Language setFunctionDefine(string value)
        {
            this.FunctionDefine = value;
            return this;
        }

        public Language setFunctionDefineRight(string value)
        {
            this.FunctionDefineRight = value;
            return this;
        }

        public Language setFunctionDefineEnd(string value)
        {
            this.FunctionDefineEnd = value;
            return this;
        }

        public Language setFunctionReturnsExplicit(bool value)
        {
            this.FunctionReturnsExplicit = value;
            return this;
        }

        public Language setFunctionTypeAfterName(bool value)
        {
            this.FunctionTypeAfterName = value;
            return this;
        }

        public Language setFunctionTypeMarker(string value)
        {
            this.FunctionTypeMarker = value;
            return this;
        }

        public Language setLambdaDeclareEnder(string value)
        {
            this.LambdaDeclareEnder = value;
            return this;
        }

        public Language setLambdaDeclareMiddle(string value)
        {
            this.LambdaDeclareMiddle = value;
            return this;
        }

        public Language setLambdaDeclareStarter(string value)
        {
            this.LambdaDeclareStarter = value;
            return this;
        }

        public Language setLambdaTypeDeclarationAsInterface(bool value)
        {
            this.LambdaTypeDeclarationAsInterface = value;
            return this;
        }

        public Language setLambdaTypeDeclarationRequired(bool value)
        {
            this.LambdaTypeDeclarationRequired = value;
            return this;
        }

        public Language setLambdaTypeDeclarationEnd(string[] value)
        {
            this.LambdaTypeDeclarationEnd = value;
            return this;
        }

        public Language setLambdaTypeDeclarationMiddle(string[] value)
        {
            this.LambdaTypeDeclarationMiddle = value;
            return this;
        }

        public Language setLambdaTypeDeclarationStart(string[] value)
        {
            this.LambdaTypeDeclarationStart = value;
            return this;
        }

        public Language setDictionaryClass(string value)
        {
            this.DictionaryClass = value;
            return this;
        }

        public Language setDictionaryKeyCheckAsFunction(bool value)
        {
            this.DictionaryKeyCheckAsFunction = value;
            return this;
        }

        public Language setDictionaryKeyChecker(string value)
        {
            this.DictionaryKeyChecker = value;
            return this;
        }

        public Language setDictionaryKeyLeft(string value)
        {
            this.DictionaryKeyLeft = value;
            return this;
        }

        public Language setDictionaryKeyMiddle(string value)
        {
            this.DictionaryKeyMiddle = value;
            return this;
        }

        public Language setDictionaryKeyRight(string value)
        {
            this.DictionaryKeyRight = value;
            return this;
        }

        public Language setDictionaryInitializationAsNew(bool value)
        {
            this.DictionaryInitializationAsNew = value;
            return this;
        }

        public Language setDictionaryInitializeStarter(string value)
        {
            this.DictionaryInitializeStarter = value;
            return this;
        }

        public Language setDictionaryInitializeEnder(string value)
        {
            this.DictionaryInitializeEnder = value;
            return this;
        }

        public Language setDictionaryInitializeKeyComma(string value)
        {
            this.DictionaryInitializeKeyComma = value;
            return this;
        }

        public Language setDictionaryInitializeKeyWithSemicolon(bool value)
        {
            this.DictionaryInitializeKeyWithSemicolon = value;
            return this;
        }

        public Language setClassConstructorAsStatic(bool value)
        {
            this.ClassConstructorAsStatic = value;
            return this;
        }

        public Language setClassConstructorInheritedShorthand(bool value)
        {
            this.ClassConstructorInheritedShorthand = value;
            return this;
        }

        public Language setClassConstructorName(string value)
        {
            this.ClassConstructorName = value;
            return this;
        }

        public Language setClassConstructorLoose(bool value)
        {
            this.ClassConstructorLoose = value;
            return this;
        }

        public Language setClassEnder(string value)
        {
            this.ClassEnder = value;
            return this;
        }

        public Language setClassExtends(string value)
        {
            this.ClassExtends = value;
            return this;
        }

        public Language setClassExtendsAsFunction(bool value)
        {
            this.ClassExtendsAsFunction = value;
            return this;
        }

        public Language setClassFunctionsTakeThis(bool value)
        {
            this.ClassFunctionsTakeThis = value;
            return this;
        }

        public Language setClassFunctionsStart(string value)
        {
            this.ClassFunctionsStart = value;
            return this;
        }

        public Language setClassFunctionsThis(string value)
        {
            this.ClassFunctionsThis = value;
            return this;
        }

        public Language setClassMemberFunctionGetBind(bool value)
        {
            this.ClassMemberFunctionGetBind = value;
            return this;
        }

        public Language setClassMemberFunctionGetEnd(string value)
        {
            this.ClassMemberFunctionGetEnd = value;
            return this;
        }

        public Language setClassMemberFunctionGetStart(string value)
        {
            this.ClassMemberFunctionGetStart = value;
            return this;
        }

        public Language setClassMemberVariableDefault(string value)
        {
            this.ClassMemberVariableDefault = value;
            return this;
        }

        public Language setClassMemberVariablePrivacy(bool value)
        {
            this.ClassMemberVariablePrivacy = value;
            return this;
        }

        public Language setClassMemberVariableStarter(string value)
        {
            this.ClassMemberVariableStarter = value;
            return this;
        }

        public Language setClassNewer(string value)
        {
            this.ClassNewer = value;
            return this;
        }

        public Language setClassParentName(string value)
        {
            this.ClassParentName = value;
            return this;
        }

        public Language setClassPrivacy(bool value)
        {
            this.ClassPrivacy = value;
            return this;
        }

        public Language setClassPublicAlias(string value)
        {
            this.ClassPublicAlias = value;
            return this;
        }

        public Language setClassStaticLabel(string value)
        {
            this.ClassStaticLabel = value;
            return this;
        }

        public Language setClassStaticFunctionDecorator(string value)
        {
            this.ClassStaticFunctionDecorator = value;
            return this;
        }

        public Language setClassStaticFunctionRequiresDecorator(bool value)
        {
            this.ClassStaticFunctionRequiresDecorator = value;
            return this;
        }

        public Language setClassStartLeft(string value)
        {
            this.ClassStartLeft = value;
            return this;
        }

        public Language setClassStartRight(string value)
        {
            this.ClassStartRight = value;
            return this;
        }

        public Language setClassTemplates(bool value)
        {
            this.ClassTemplates = value;
            return this;
        }

        public Language setClassTemplatesBetween(string value)
        {
            this.ClassTemplatesBetween = value;
            return this;
        }

        public Language setClassThis(string value)
        {
            this.ClassThis = value;
            return this;
        }

        public Language setClassThisAccess(string value)
        {
            this.ClassThisAccess = value;
            return this;
        }

        public Language setFileEndLine(string value)
        {
            this.FileEndLine = value;
            return this;
        }

        public Language setFileStartLeft(string value)
        {
            this.FileStartLeft = value;
            return this;
        }

        public Language setFileStartRight(string value)
        {
            this.FileStartRight = value;
            return this;
        }

        public Language setIncludeDictionaryType(string value)
        {
            this.IncludeDictionaryType = value;
            return this;
        }

        public Language setIncludeEnder(string value)
        {
            this.IncludeEnder = value;
            return this;
        }

        public Language setIncludeFileExtension(bool value)
        {
            this.IncludeFileExtension = value;
            return this;
        }

        public Language setIncludeStarter(string value)
        {
            this.IncludeStarter = value;
            return this;
        }

        public Language setMainEndLine(string value)
        {
            this.MainEndLine = value;
            return this;
        }

        public Language setMainStartLine(string value)
        {
            this.MainStartLine = value;
            return this;
        }


        /*
        Array & Template parsing
        */

        public string parseType(string text)
        {
            if (this.typeContainsArray(text))
            {
                return this.parseTypeWithArray(text);
            }

            if (this.typeContainsTemplate(text))
            {
                return this.parseTypeWithTemplate(text);
            }

            return this.getTypeAlias(text);
        }

        public bool typeContainsArray(string text)
        {
            return text.IndexOf("[") != -1;
        }

        public bool typeContainsTemplate(string text)
        {
            return text.IndexOf("<") != -1;
        }

        public string parseTypeWithArray(string text)
        {
            int bracketIndex = text.IndexOf("[");
            string name = text.Substring(0, bracketIndex);
            string remainder = text.Substring(bracketIndex);

            return this.parseType(name).ToString() + remainder.ToString();
        }

        public string parseTypeWithTemplate(string text)
        {
            if (text.IndexOf('>') == -1)
            {
                return text;
            }

            int ltIndex = text.IndexOf("<");
            string output = text.Substring(0, ltIndex);

            if (!this.getClassTemplates())
            {
                return output;
            }

            char typeCheck = ' ';
            int typeStart = ltIndex;
            int typeEnd;

            while (typeStart < text.Length)
            {
                for (typeEnd = typeStart; typeEnd < text.Length; typeEnd += 1)
                {
                    typeCheck = text[typeEnd];
                    if (typeCheck == ',' || typeCheck == '<' || typeCheck == '>' || typeCheck == ' ')
                    {
                        break;
                    }
                }

                if (typeEnd == text.Length)
                {
                    break;
                }

                if (typeStart == typeEnd)
                {
                    output += typeCheck;
                    typeStart += 1;
                    continue;
                }

                output += this.parseType(text.Substring(typeStart, typeEnd));
                output += typeCheck;

                typeStart = typeEnd + 1;
            }

            return output;
        }


        /*
        Miscellaneous
        */

        public string getAliasOrDefault(Dictionary<string, string> aliases, string key)
        {
            if (aliases.ContainsKey(key))
            {
                return aliases[key];
            }
            else
            {
                return key;
            }
        }

        public string getTypeAlias(string key)
        {
            return this.getAliasOrDefault(this.TypeAliases, key);
        }

        public string getOperationAlias(string key)
        {
            return this.getAliasOrDefault(this.OperationAliases, key);
        }

        public string getValueAlias(string key)
        {
            return this.getAliasOrDefault(this.ValueAliases, key);
        }

        public Language addTypeAlias(string key, string alias)
        {
            this.TypeAliases[key] = alias;
            return this;
        }

        public Language addTypeAliases(Dictionary<string, string> aliases)
        {
            string key;
            string alias;
            foreach (KeyValuePair<string, string> pair in aliases)
            {
                key = pair.Key;
                alias = pair.Value;
                this.addTypeAlias(key, aliases[key]);
            }

            return this;
        }

        public Language addOperationAlias(string key, string alias)
        {
            this.OperationAliases[key] = alias;
            return this;
        }

        public Language addOperationAliases(Dictionary<string, string> aliases)
        {
            string key;
            string alias;
            foreach (KeyValuePair<string, string> pair in aliases)
            {
                key = pair.Key;
                alias = pair.Value;
                this.addOperationAlias(key, aliases[key]);
            }

            return this;
        }

        public Language addValueAlias(string key, string alias)
        {
            this.ValueAliases[key] = alias;
            return this;
        }

        public Language addValueAliases(Dictionary<string, string> aliases)
        {
            string key;
            string alias;
            foreach (KeyValuePair<string, string> pair in aliases)
            {
                key = pair.Key;
                alias = pair.Value;
                this.addValueAlias(key, aliases[key]);
            }

            return this;
        }

        public Dictionary<string, string> getNativeFunctionAlias(string className, string memberName)
        {
            return this.NativeFunctionAliases[className][memberName];
        }

        public Language addNativeFunctionAlias(string className, string memberName, Dictionary<string, string> aliasInfo)
        {
            this.NativeFunctionAliases[className][memberName] = aliasInfo;
            return this;
        }

        public Language addNativeFunctionAliases(string className, Dictionary<string, Dictionary<string, string>> aliasInfos)
        {
            string key;
            Dictionary<string, string> alias;
            foreach (KeyValuePair<string, Dictionary<string, string>> pair in aliasInfos)
            {
                key = pair.Key;
                alias = pair.Value;
                this.addNativeFunctionAlias(className, key, alias);
            }

            return this;
        }

        public object[] print(string functionName, string[] functionArgs, bool isInline)
        {
            if (!this.Printers.ContainsKey(functionName))
            {
                throw new System.Exception("Function not found: " + functionName);
            }

            return this.Printers[functionName](functionArgs, isInline);
        }


        /*
        Printers
        */

        // string type[, string key, ...]
        public object[] ArrayInitialize(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ArrayInitialize", functionArgs, 1);

            string arrayType = this.parseType(functionArgs[0]);
            string output;
            int i;

            if (this.getArrayInitializationAsNewTyped())
            {
                output = "new " + arrayType + "[] { ";
            }
            else
            {
                output = "[";
            }

            if (functionArgs.Length > 1)
            {
                for (i = 1; i < functionArgs.Length - 1; i += 1)
                {
                    output += functionArgs[i] + ", ";
                }

                output += functionArgs[i];
            }

            if (this.getArrayInitializationAsNewTyped())
            {
                output += " }";
            }
            else
            {
                output += "]";
            }

            return new object[] { output, 0 };
        }

        // string type, string size
        public object[] ArrayInitializeSized(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ArrayInitialize", functionArgs, 2);

            string arrayType = this.parseType(functionArgs[0]);
            string arraySize = functionArgs[1];
            string output;

            if (this.getArrayInitializationAsNewMultiplied())
            {
                output = "[" + this.getUndefined() + "]";
                return this.Operation(new string[] { output, "times", arraySize }, isInline);
            }

            if (this.getArrayInitializationAsNewStatic())
            {
                output = this.getArrayClass() + ".new";
            }
            else
            {
                output = "new ";
            }

            if (this.getArrayInitializationAsNewTyped())
            {
                output += arrayType + "[" + arraySize + "]";
            }
            else
            {
                if (!this.getArrayInitializationAsNewStatic())
                {
                    output += this.getArrayClass();
                }
                output += "(" + arraySize + ")";
            }

            return new object[] { output, 0 };
        }

        // string name, string index
        public object[] ArrayGetItem(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ArrayGetItem", functionArgs, 1);

            string name = functionArgs[0];
            string output = name + "[";
            string index = functionArgs[1];

            if (index[0] != '-' || this.getArrayNegativeIndices())
            {
                output += index;
            }
            else
            {
                string nativePart = (string)this.NativeCall(new string[] { "array", "length", name }, true)[0];
                output += this.Operation(new string[] { nativePart, "minus", "1" }, true)[0];
            }

            output += "]";
            return new object[] { output, 0 };
        }

        // string type, string value
        public object[] Cast(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Cast", functionArgs, 2);

            if (!this.getVariableTypesExplicit())
            {
                return new object[] { functionArgs[1], 0 };
            }

            string output = this.getCastStarter();
            output += this.parseType(functionArgs[0]);
            output += this.getCastEnder();
            output += functionArgs[1];

            return new object[] { output, 0 };
        }

        // [string name]
        public object[] Catch(string[] functionArgs, bool isInline)
        {
            string output = this.getExceptionCatch() + this.getExceptionClass();

            if (functionArgs.Length > 0)
            {
                output += this.getExceptionErrorPrefix() + functionArgs[0];
            }

            output += this.getConditionStartRight();

            return new object[] { "\0", -1, output, 1 };
        }

        public object[] ClassConstructorEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getFunctionDefineEnd(), -1 };
        }

        // string super, [string argumentName, string argumentType, ...]
        public object[] ClassConstructorInheritedCall(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassConstructorInheritedCall", functionArgs, 1);

            string parentName = this.getClassParentName();
            int callingArgsLength = functionArgs.Length;
            int loopStart = 0;
            string[] callingArgs;
            int i;

            // Blank parentName indicates the super's class name should be used
            if (parentName.Length == 0)
            {
                parentName = this.parseType(functionArgs[0]);
            }

            // Taking a reference to `this` as a paremeter increases the number of parameters
            if (this.getClassFunctionsTakeThis())
            {
                callingArgsLength += 1;
                loopStart += 1;
            }

            callingArgs = new string[callingArgsLength];
            callingArgs[0] = parentName;

            if (this.getClassExtendsAsFunction())
            {
                callingArgs[0] += "." + this.getClassConstructorName();
            }

            if (this.getClassFunctionsTakeThis())
            {
                callingArgs[1] = this.getClassThis();
            }

            for (i = loopStart; i < functionArgs.Length; i += 1)
            {
                callingArgs[i + 1] = functionArgs[i];
            }

            return this.FunctionCall(callingArgs, isInline);
        }

        // string name[, string superCall[, string argumentName, string argumentType, ...]]
        public object[] ClassConstructorInheritedStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassConstructorInheritedStart", functionArgs, 1);

            if (functionArgs.Length == 1)
            {
                return this.ClassConstructorStart(functionArgs, isInline);
            }

            object[] generalCall;
            string[] callingArgs;
            object[] output;
            int i;

            // Populate the arguments that will be passed to the actual method
            if (functionArgs.Length > 2)
            {
                callingArgs = new string[functionArgs.Length - 1];

                for (i = 2; i < functionArgs.Length; i += 1)
                {
                    callingArgs[i - 1] = functionArgs[i];
                }

                callingArgs[0] = functionArgs[0];
            }
            else
            {
                callingArgs = new string[] { functionArgs[0] };
            }

            generalCall = this.ClassConstructorStart(callingArgs, isInline);

            if (this.getClassConstructorInheritedShorthand())
            {
                // "Shorthand" usage, like in C#, comes before FunctionDefineRight
                output = new string[generalCall.Length];
                output[0] = ((string)generalCall[0]).Substring(0, ((string)generalCall[0]).Length - this.getFunctionDefineRight().Length);
                output[0] += functionArgs[1] + this.getFunctionDefineRight();

                for (i = 1; i < generalCall.Length; i += 1)
                {
                    output[i] = generalCall[i];
                }
            }
            else
            {
                // In-function usage, like in Python, comes within the function
                output = new string[generalCall.Length + 2];
                output[output.Length - 1] = 0;
                output[output.Length - 2] = functionArgs[1];
                output[generalCall.Length - 1] = generalCall[generalCall.Length - 1];

                if (!isInline)
                {
                    output[output.Length - 2] += this.getSemiColon();
                }

                for (i = 0; i < generalCall.Length - 1; i += 1)
                {
                    output[i] = generalCall[i];
                }
            }

            return output;
        }

        // string name[, string argumentName, string argumentType, ...]
        public object[] ClassConstructorStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassConstructorStart", functionArgs, 1);

            string output = this.getClassConstructorName();
            string[] variableDeclarationArgs = new string[] { };
            int i;

            if (this.getClassConstructorLoose())
            {
                output = this.getClassFunctionsStart() + output;
            }

            if (output.Length == 0)
            {
                output = functionArgs[0];
            }

            output += "(";

            // Languages like Python take a "self" or "this" equivalent first
            if (this.getClassFunctionsTakeThis())
            {
                if (this.getClassFunctionsTakeThis())
                {
                    output += ", ";
                }

                for (i = 1; i < functionArgs.Length; i += 2)
                {
                    variableDeclarationArgs[0] = functionArgs[i];
                    variableDeclarationArgs[1] = functionArgs[i];

                    output += this.VariableDeclarePartial(variableDeclarationArgs, true)[0] + ", ";
                }

                // The last argument does not have the last ", " at the end
                output = output.Substring(0, output.Length - 2);
            }

            output += ")" + this.getFunctionDefineRight();
            return new object[] { output, 1 };
        }

        public object[] ClassEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getClassEnder(), -1 };
        }

        // string variable, string function[, string argumentName, ...]
        public object[] ClassMemberFunctionCall(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassMemberFunctionCall", functionArgs, 2);

            string output = functionArgs[0] + "." + functionArgs[1] + "(";
            int i;

            if (functionArgs.Length > 2)
            {
                for (i = 2; i < functionArgs.Length - 1; i += 1)
                {
                    output += functionArgs[i] + ", ";
                }
                output += functionArgs[i];
            }

            output += ")";

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        public object[] ClassMemberFunctionEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getFunctionDefineEnd(), -1 };
        }

        // string variable, string function
        public object[] ClassMemberFunctionGet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassMemberFunctionStart", functionArgs, 2);

            string output = "";

            output += this.getClassMemberFunctionGetStart() + functionArgs[0];
            output += "." + functionArgs[1] + this.getClassMemberFunctionGetEnd();

            if (this.getClassMemberFunctionGetBind())
            {
                output += "(" + functionArgs[0] + ")";
            }

            return new object[] { output, 0 };
        }

        // string class, string visibility, string name, string return[, string argumentName, string argumentType, ...]
        public object[] ClassMemberFunctionStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassMemberFunctionStart", functionArgs, 4);

            string output = this.getClassFunctionsStart();
            string[] variableDeclarationArgs = new string[] { };
            int i;

            if (this.getFunctionReturnsExplicit() && !this.getFunctionTypeAfterName())
            {
                output += this.parseType(functionArgs[3]) + " ";
            }

            if (this.getClassPrivacy())
            {
                output = functionArgs[1] + " " + output;
            }

            output += functionArgs[2] + "(";

            if (this.getClassFunctionsTakeThis())
            {
                variableDeclarationArgs[0] = this.getClassFunctionsThis();
                variableDeclarationArgs[1] = functionArgs[0];

                output += this.VariableDeclarePartial(variableDeclarationArgs, true)[0];
            }

            // All arguments are added using VariableDeclarePartial
            if (functionArgs.Length > 4)
            {
                if (this.getClassFunctionsTakeThis())
                {
                    output += ", ";
                }

                for (i = 4; i < functionArgs.Length; i += 2)
                {
                    variableDeclarationArgs[0] = functionArgs[i];
                    variableDeclarationArgs[1] = functionArgs[i + 1];

                    output += this.VariableDeclarePartial(variableDeclarationArgs, true)[0] + ", ";
                }

                // The last argument does not have the last ", " at the end
                output = output.Substring(0, output.Length - 2);
            }

            output += ")";

            if (this.getFunctionReturnsExplicit() && this.getFunctionTypeAfterName())
            {
                output += this.getFunctionTypeMarker() + this.parseType(functionArgs[3]);
            }

            output += this.getFunctionDefineRight();
            return new object[] { output, 1 };
        }

        // string name, string visibility, string type
        public object[] ClassMemberVariableDeclare(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassMemberVariableDeclare", functionArgs, 3);

            string variableType = this.parseType(functionArgs[2]);
            string[] variableDeclarationArgs;
            object[] variableDeclared;

            if (this.getClassMemberVariableDefault() != "")
            {
                variableDeclarationArgs = new string[] { functionArgs[0], variableType, this.getClassMemberVariableDefault() };
            }
            else
            {
                variableDeclarationArgs = new string[] { functionArgs[0], variableType };
            }

            variableDeclared = this.VariableDeclarePartial(variableDeclarationArgs, isInline);
            variableDeclared[1] = 0;

            if (!isInline)
            {
                variableDeclared[0] = variableDeclared[0] + this.getSemiColon();
            }

            if (this.getClassMemberVariablePrivacy())
            {
                variableDeclared[0] = functionArgs[1] + " " + variableDeclared[0];
            }

            variableDeclared[0] = this.getClassMemberVariableStarter() + variableDeclared[0];

            return variableDeclared;
        }

        // string name, string variable
        public object[] ClassMemberVariableGet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassMemberVariableGet", functionArgs, 2);

            return new object[] { functionArgs[0] + this.getClassThisAccess() + functionArgs[1], 0 };
        }

        // string variable, string name, string value
        public object[] ClassMemberVariableSet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassMemberVariableSet", functionArgs, 3);

            object[] output = this.ClassMemberVariableSetIncomplete(functionArgs, isInline);

            output[0] += this.getSemiColon();
            output[1] = 0;

            return output;
        }

        // string name, string variable, string value
        public object[] ClassMemberVariableSetIncomplete(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassMemberVariableSetIncomplete", functionArgs, 3);

            string output = functionArgs[0] + this.getClassThisAccess();

            output += functionArgs[1] + " " + this.getOperationAlias("equals") + " " + functionArgs[2];

            return new object[] { output, 1 };
        }

        // string class, string function[, string argumentName, ...]
        public object[] ClassStaticFunctionCall(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassStaticFunctionCall", functionArgs, 2);

            string output = functionArgs[0] + "." + functionArgs[1] + "(";
            int i;

            if (functionArgs.Length > 2)
            {
                for (i = 2; i < functionArgs.Length - 1; i += 1)
                {
                    output += functionArgs[i] + ", ";
                }

                output += functionArgs[i];
            }

            output += ")";

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        public object[] ClassStaticFunctionEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getFunctionDefineEnd(), -1 };
        }

        // string class, string function
        public object[] ClassStaticFunctionGet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassStaticFunctionGet", functionArgs, 2);

            string output = "";

            output += this.getClassMemberFunctionGetStart() + functionArgs[0];
            output += "." + functionArgs[1] + this.getClassMemberFunctionGetEnd();

            if (this.getClassMemberFunctionGetBind())
            {
                output += "(" + functionArgs[0] + ")";
            }

            return new object[] { output, 0 };
        }

        // string class, string visibility, string name, string return[, string argumentName, string argumentType, ...]
        public object[] ClassStaticFunctionStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassStaticFunctionStart", functionArgs, 4);

            string output = this.getClassFunctionsStart();
            string[] variableDeclarationArgs = new string[] { };
            int i;

            if (this.getFunctionReturnsExplicit() && !this.getFunctionTypeAfterName())
            {
                output += this.parseType(functionArgs[3]) + " ";
            }

            output = this.getClassStaticLabel() + output;

            if (this.getClassPrivacy())
            {
                output = functionArgs[1] + " " + output;
            }

            output += functionArgs[2] + "(";

            // All arguments are added using VariableDeclarePartial
            if (functionArgs.Length > 4)
            {
                if (this.getClassFunctionsTakeThis())
                {
                    output += ", ";
                }

                for (i = 4; i < functionArgs.Length; i += 2)
                {
                    variableDeclarationArgs[0] = functionArgs[i];
                    variableDeclarationArgs[1] = functionArgs[i + 1];

                    output += this.VariableDeclarePartial(variableDeclarationArgs, true)[0] + ", ";
                }

                // The last argument does not have the last ", " at the end
                output = output.Substring(0, output.Length - 2);
            }

            output += ")";

            if (this.getFunctionReturnsExplicit() && this.getFunctionTypeAfterName())
            {
                output += this.getFunctionTypeMarker() + this.parseType(functionArgs[3]);
            }

            if (this.getClassStaticFunctionRequiresDecorator())
            {
                return new object[] { this.getClassStaticFunctionDecorator(), 0, output, 1 };
            }
            else
            {
                return new object[] { output, 1 };
            }
        }

        // string class, string visibility, string type[, string value]
        public object[] ClassStaticVariableDeclare(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassStaticVariableDeclare", functionArgs, 3);

            string variableType = this.parseType(functionArgs[2]);
            string[] variableDeclarationArgs;
            object[] variableDeclared;

            if (functionArgs.Length > 3)
            {
                variableDeclarationArgs = new string[] { functionArgs[0], variableType, functionArgs[3] };
            }
            else if (this.getClassMemberVariableDefault() != "")
            {
                variableDeclarationArgs = new string[] { functionArgs[0], variableType, this.getClassMemberVariableDefault() };
            }
            else
            {
                variableDeclarationArgs = new string[] { functionArgs[0], variableType };
            }

            variableDeclared = this.VariableDeclarePartial(variableDeclarationArgs, isInline);
            variableDeclared[0] = this.getClassStaticLabel() + variableDeclared[0];
            variableDeclared[1] = 0;

            if (!isInline)
            {
                variableDeclared[0] = variableDeclared[0] + this.getSemiColon();
            }

            if (this.getClassMemberVariablePrivacy())
            {
                variableDeclared[0] = functionArgs[1] + " " + variableDeclared[0];
            }

            variableDeclared[0] = this.getClassMemberVariableStarter() + variableDeclared[0];

            return variableDeclared;
        }

        // string class, string name
        public object[] ClassStaticVariableGet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassStaticVariableGet", functionArgs, 2);

            return new object[] { functionArgs[0] + "." + functionArgs[1], 0 };
        }

        // string class, string name, string value
        public object[] ClassStaticVariableSet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassStaticVariableSet", functionArgs, 3);

            string output = functionArgs[0] + "." + functionArgs[1] + " ";

            output += this.getOperationAlias("equals") + " " + functionArgs[2];
            output += this.getSemiColon();

            return new object[] { output, 0 };
        }

        // string name[, string parentClass]
        public object[] ClassStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassStart", functionArgs, 1);

            string output = this.getClassStartLeft();
            output += this.parseType(functionArgs[0]);

            if (functionArgs.Length > 1)
            {
                if (this.getClassExtendsAsFunction())
                {
                    output += "(" + this.parseType(functionArgs[1]) + ")";
                }
                else
                {
                    output += " " + this.getClassExtends() + " " + this.parseType(functionArgs[1]) + " ";
                }
            }

            output += this.getClassStartRight();

            if (this.getClassPrivacy())
            {
                output = this.getClassPublicAlias() + output;
            }

            return new object[] { output, 1 };
        }

        // string class[, string argumentName, string argumentType, ...]
        public object[] ClassNew(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ClassNew", functionArgs, 1);

            string output;
            int i;

            if (this.getClassConstructorAsStatic())
            {
                output = this.parseType(functionArgs[0]) + "." + this.getClassNewer() + "(";
            }
            else
            {
                output = this.getClassNewer() + this.parseType(functionArgs[0]) + "(";
            }

            if (functionArgs.Length > 1)
            {
                for (i = 1; i < functionArgs.Length; i += 1)
                {
                    output += functionArgs[i] + ", ";
                }

                // The last argument does not have the last ", " at the end
                output = output.Substring(0, output.Length - 2);
            }

            output += ")";

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        // [string message, ...]
        public object[] CommentBlock(string[] functionArgs, bool isInline)
        {
            object[] output = new object[(functionArgs.Length + 2) * 2];
            int i;

            output[0] = this.getCommentorBlockStart();
            output[1] = 0;

            for (i = 0; i < functionArgs.Length; i += 1)
            {
                output[i * 1 + 2] = functionArgs[i];
                output[i * 2 + 3] = 0;
            }

            output[i * 2 + 2] = this.getCommentorBlockEnd();
            output[i * 2 + 3] = 0;

            return output;
        }

        // [string message, ...]
        public object[] CommentLine(string[] functionArgs, bool isInline)
        {
            string output = this.getCommentorInline() + " ";
            int i;

            for (i = 0; i < functionArgs.Length - 1; i += 1)
            {
                output += functionArgs[i] + " ";
            }
            output += functionArgs[i];

            return new object[] { output, 0 };
        }

        // [string message, ...]
        public object[] CommentInline(string[] functionArgs, bool isInline)
        {
            object[] result = this.CommentLine(functionArgs, isInline);

            result[1] = Language.INT_MIN;

            return result;
        }

        // string left, string comparison, string right
        public object[] Comparison(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Comparison", functionArgs, 3);

            return new object[] { functionArgs[0] + " " + this.getOperationAlias(functionArgs[1]) + " " + functionArgs[2], 0 };
        }

        // string left, string right
        public object[] Concatenate(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Comparison", functionArgs, 2);

            string output;

            if (this.getToStringAsFunction())
            {
                output = this.getToString() + "(" + functionArgs[0] + ")";
                output += " " + this.getOperationAlias("plus") + " ";
                output += this.getToString() + "(" + functionArgs[1] + ")";
            }
            else
            {
                output = functionArgs[0] + this.getToString();
                output += " " + this.getOperationAlias("plus") + " ";
                output += functionArgs[1] + this.getToString();
            }

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        // string name, string key
        public object[] DictionaryKeyCheck(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("DictionaryKeyCheck", functionArgs, 2);

            string output;

            if (this.getDictionaryKeyCheckAsFunction())
            {
                output = functionArgs[0] + "." + this.getDictionaryKeyChecker() + "(" + functionArgs[1] + ")";
            }
            else
            {
                output = functionArgs[1] + this.getDictionaryKeyChecker() + functionArgs[0];
            }

            return new object[] { output, 0 };
        }

        // string name, string key
        public object[] DictionaryKeyGet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("DictionaryKeyGet", functionArgs, 2);

            return new object[] { functionArgs[0] + "[" + functionArgs[1] + "]", 0 };
        }

        // string name, string key, string value
        public object[] DictionaryKeySet(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("DictionaryKeySet", functionArgs, 3);

            string output = functionArgs[0] + "[" + functionArgs[1] + "] = " + functionArgs[2];

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        // string key, string value
        public object[] DictionaryInitialize(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("DictionaryInitialize", functionArgs, 2);

            string dictionaryType = (string)this.DictionaryType(functionArgs, true)[0];
            string output;

            if (this.getDictionaryInitializationAsNew())
            {
                output = "new " + dictionaryType + "()";
            }
            else
            {
                output = "{}";
            }

            return new object[] { output, 0 };
        }

        public object[] DictionaryInitializeEnd(string[] functionArgs, bool isInline)
        {
            string output = this.getDictionaryInitializeEnder();

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, -1 };
        }

        // string key, string value[, string comma]
        public object[] DictionaryInitializeKey(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("DictionaryInitializeKey", functionArgs, 2);

            string output = this.getDictionaryKeyLeft();
            output += functionArgs[0];
            output += this.getDictionaryKeyMiddle();
            output += functionArgs[1];
            output += this.getDictionaryKeyRight();

            if (functionArgs.Length > 2 || this.getDictionaryInitializeKeyWithSemicolon())
            {
                output += this.getDictionaryInitializeKeyComma();
            }

            return new object[] { output, 0 };
        }

        // string keyType, string valueType
        public object[] DictionaryInitializeStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("DictionaryInitializeStart", functionArgs, 2);

            string dictionaryType;
            string output;

            if (this.getDictionaryInitializationAsNew())
            {
                dictionaryType = (string)this.DictionaryType(functionArgs, true)[0];
            }
            else
            {
                dictionaryType = "";
            }

            if (this.getDictionaryInitializationAsNew())
            {
                output = "new ";
            }
            else
            {
                output = "";
            }

            output += dictionaryType;
            output += this.getDictionaryInitializeStarter();

            return new object[] { output, 0 };
        }

        // string keyType[, ...], string valueType
        public object[] DictionaryType(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("DictionaryType", functionArgs, 2);

            if (!this.getVariableTypesExplicit())
            {
                return new object[] { "", 0 };
            }

            if (!this.getDictionaryInitializationAsNew())
            {
                return new object[] { this.getDictionaryClass(), 0 };
            }

            string output = this.getDictionaryClass();
            int numKeys = functionArgs.Length - 1;
            int i;

            output += "<" + this.parseType(functionArgs[0]);
            output += this.getClassTemplatesBetween();

            for (i = 1; i < numKeys; i += 1)
            {
                output += this.getDictionaryClass() + "<";
                output += this.parseType(functionArgs[i]);
                output += this.getClassTemplatesBetween();
            }

            output += this.parseType(functionArgs[i]);

            for (i = 0; i < numKeys; i += 1)
            {
                output += ">";
            }

            return new object[] { output, 0 };
        }

        // string value
        public object[] ElifStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ElifStart", functionArgs, 1);

            string output = this.getElif() + this.getConditionStartLeft();

            output += functionArgs[0] + this.getConditionStartRight();

            return new object[] { "\0", -1, output, 1 };
        }

        public object[] ElseStart(string[] functionArgs, bool isInline)
        {
            return new object[] { "\0", -1, this.getElse() + this.getConditionContinueRight(), 1 };
        }

        public object[] FileEnd(string[] functionArgs, bool isInline)
        {
            string output = this.getFileEndLine();

            if (output.Length == 0)
            {
                return new object[] { output, Language.INT_MIN };
            }

            return new object[] { output, -1 };
        }

        // name
        public object[] FileStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("FileStart", functionArgs, 1);

            string left = this.getFileStartLeft();
            string right = this.getFileStartRight();

            if (left.Length == 0 && right.Length == 0)
            {
                return new object[] { "", Language.INT_MIN };
            }

            return new object[] { left + functionArgs[0] + right, 1 };
        }

        public object[] Finally(string[] functionArgs, bool isInline)
        {
            string output = this.getExceptionFinally();

            output += this.getConditionContinueRight();

            return new object[] { "\0", -1, output, 1 };
        }

        // string keyName, string keyType, string container
        // E.x. for each keys start : i string names
        public object[] ForEachKeysStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ForEachKeysStart", functionArgs, 3);

            string[] variableDeclareArgs = new string[] { functionArgs[0], functionArgs[1] };
            string output;

            if (this.getForEachAsMethod())
            {
                output = functionArgs[2];
                output += this.getForEachStarter();
                output += this.VariableDeclarePartial(variableDeclareArgs, true)[0];
                output += this.getForEachInner();
            }
            else
            {
                output = this.getForEachStarter();
                output += this.VariableDeclarePartial(variableDeclareArgs, true)[0];
                output += this.getForEachInner();

                if (this.getForEachKeysAsStatic())
                {
                    output += this.getForEachKeysGet() + "(" + functionArgs[2] + ")";
                }
                else
                {
                    output += functionArgs[2] + this.getForEachKeysGet();
                }

                output += this.getConditionStartRight();
            }

            return new object[] { output, 1 };
        }

        // Assume keyName and valueName exist, while pairName is created some languages won't use pairName
        // Ex. for each pairs start : pair name string count int names
        // string pairName, string keyName, string keyType, string valueName, string valueType, string container
        public object[] ForEachPairsStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ForEachPairsStart", functionArgs, 6);

            string pairName = functionArgs[0];
            string keyName = functionArgs[1];
            string keyType = functionArgs[2];
            string valueName = functionArgs[3];
            string valueType = functionArgs[4];
            string container = functionArgs[5];
            string[] variableDeclareArgs;
            string line;
            object[] output;

            if (this.getForEachAsMethod())
            {
                // container.each do |keyName, valueName|
                output = new string[4];
                variableDeclareArgs = new string[2];

                // container.each do |
                line = container;
                line += this.getForEachStarter();

                //                     keyName
                variableDeclareArgs[0] = keyName;
                variableDeclareArgs[1] = keyType;
                line += this.VariableDeclarePartial(variableDeclareArgs, true)[0];

                //                            , valueName|
                variableDeclareArgs[0] = valueName;
                variableDeclareArgs[1] = valueType;
                line += ", " + this.VariableDeclarePartial(variableDeclareArgs, true)[0];
                line += this.getForEachInner();

                output = new object[] { line, 1 };
            }
            else if (this.getForEachPairsAsPair())
            {
                // foreach KeyValuePair<string, int> pairName in container 
                //     keyName = pairName.Key;
                //     valueName = pairName.Value;
                output = new string[6];

                // forEach KeyValuePair<string, int> pairName
                line = this.getForEachStarter();
                variableDeclareArgs = new string[2];
                variableDeclareArgs[0] = pairName;
                variableDeclareArgs[1] = this.getForEachPairsPairClass() + "<" + keyType + ", " + valueType + ">";
                line += this.VariableDeclarePartial(variableDeclareArgs, true)[0];

                // (                                            in container) {
                line += this.getForEachInner();
                line += container;
                line += this.getConditionStartRight();

                output[0] = line;
                output[1] = 1;

                //     keyName = pairName.Key
                variableDeclareArgs = new string[3];
                variableDeclareArgs[0] = keyName;
                variableDeclareArgs[1] = "equals";
                variableDeclareArgs[2] = pairName + this.getForEachPairsRetrieveKey();
                line = (string)this.Operation(variableDeclareArgs, false)[0];
                output[2] = line;
                output[3] = 0;

                //     valueName = pairName.Value
                variableDeclareArgs = new string[3];
                variableDeclareArgs[0] = valueName;
                variableDeclareArgs[1] = "equals";
                variableDeclareArgs[2] = pairName + this.getForEachPairsRetrieveValue();
                line = (string)this.Operation(variableDeclareArgs, false)[0];
                output[4] = line;
                output[5] = 0;
            }
            else
            {
                // for keyName in container 
                //     valueName = container[keyName]
                output = new object[4];

                // for keyName in container 
                line = this.getForEachStarter();
                line += keyName;
                line += this.getForEachInner();
                line += container;
                line += this.getConditionStartRight();
                output[0] = line;
                output[1] = 1;

                //     valueName = container[keyName]
                variableDeclareArgs = new string[3];
                variableDeclareArgs[0] = valueName;
                variableDeclareArgs[1] = "equals";
                variableDeclareArgs[2] = container + "[" + keyName + "]";
                line = (string)this.Operation(variableDeclareArgs, false)[0];
                output[2] = line;
                output[3] = 0;
            }

            return output;
        }

        public object[] ForEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getConditionEnd(), -1 };
        }

        // string i, string initial, string comparison, string boundary[, string change]
        // e.x. i int 0 lessthan 7
        public object[] ForNumbersStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("ForNumbersStart", functionArgs, 4);

            string output = "for" + this.getConditionStartLeft();
            string i = functionArgs[0];
            string initial = functionArgs[1];
            string comparison = functionArgs[2];
            string boundary = functionArgs[3];
            string direction = "increaseby";
            string[] generalArgs;
            string change;

            if (functionArgs.Length > 4)
            {
                change = functionArgs[4];
            }
            else
            {
                change = "1";
            }

            if (this.getRangedForLoops())
            {
                output += i;
                output += this.getRangedForLoopsStart();
                output += initial + this.getRangedForLoopsMiddle() + change;

                if (change != "1")
                {
                    output += this.getRangedForLoopsMiddle() + change;
                }

                output += this.getRangedForLoopsEnd();
            }
            else
            {
                generalArgs = new string[] { i, "equals", initial };
                output += this.Operation(generalArgs, true)[0] + this.getSemiColon() + " ";

                generalArgs = new string[] { i, comparison, boundary };
                output += this.Comparison(generalArgs, true)[0] + this.getSemiColon() + " ";

                generalArgs = new string[] { i, direction, change };
                output += this.Operation(generalArgs, true)[0];
            }

            output += this.getConditionStartRight();

            return new object[] { output, 1 };
        }

        // string name[, string parameter, ...]
        public object[] FunctionCall(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("FunctionCall", functionArgs, 1);

            string output = functionArgs[0] + "(";
            int i;

            if (functionArgs.Length > 1)
            {
                for (i = 1; i < functionArgs.Length - 1; i += 1)
                {
                    output += functionArgs[i] + ", ";
                }

                output += functionArgs[i];
            }

            output += ")";

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        public object[] FunctionCallPartialEnd(string[] functionArgs, bool isInline)
        {
            string output = ")";

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, -1 };
        }

        // string name
        public object[] FunctionCallPartialStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("FunctionCallPartialStart", functionArgs, 1);

            return new object[] { functionArgs[0] + "(", 1 };
        }

        public object[] FunctionEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getFunctionDefineEnd(), -1 };
        }

        // string name, string return[, string argumentName, string argumentType, ...]
        public object[] FunctionStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("FunctionStart", functionArgs, 2);

            string output = "";
            string[] variableDeclarationArgs = new string[] { };
            int i;

            if (this.getFunctionReturnsExplicit() && !this.getFunctionTypeAfterName())
            {
                output += this.parseType(functionArgs[1]) + " ";
            }

            output += this.getFunctionDefine() + functionArgs[0] + "(";

            // All arguments are added using VariableDeclarePartial
            if (functionArgs.Length > 2)
            {
                for (i = 2; i < functionArgs.Length; i += 2)
                {
                    variableDeclarationArgs[0] = functionArgs[i];
                    variableDeclarationArgs[1] = functionArgs[i + 1];

                    output += this.VariableDeclarePartial(variableDeclarationArgs, true)[0] + ", ";
                }

                // The last argument does not have the last ", " at the end
                output = output.Substring(0, output.Length - 2);
            }

            output += ")";

            if (this.getFunctionReturnsExplicit() && this.getFunctionTypeAfterName())
            {
                output += this.getFunctionTypeMarker() + this.parseType(functionArgs[1]);
            }

            output += this.getFunctionDefineRight();
            return new object[] { output, 1 };
        }

        public object[] IfEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getConditionEnd(), -1 };
        }

        // string value
        public object[] IfStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("IfStart", functionArgs, 1);

            string output = this.getIf() + this.getConditionStartLeft();

            output += functionArgs[0] + this.getConditionStartRight();

            return new object[] { output, 1 };
        }

        // string file
        public object[] Include(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Include", functionArgs, 1);

            string output = this.getIncludeStarter();
            output += functionArgs[0];

            if (this.getIncludeFileExtension())
            {
                output += "." + this.getExtension();
            }

            output += this.getIncludeEnder();

            return new object[] { output, 0 };
        }

        public object[] IncludeDictionary(string[] functionArgs, bool isInline)
        {
            string dictionaryType = this.getIncludeDictionaryType();

            if (dictionaryType.Length == 0)
            {
                return new object[] { "", Language.INT_MIN };
            }

            return this.Include(new string[] { dictionaryType }, isInline);
        }

        // [, string param, ...], statement
        public object[] LambdaDeclareInline(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("LambdaDeclareInline", functionArgs, 3);

            string output = this.getLambdaDeclareStarter();
            int i;

            for (i = 0; i < functionArgs.Length - 1; i += 1)
            {
                output += functionArgs[i] + ", ";
            }

            output = output.Substring(0, output.Length - 2);
            output += this.getLambdaDeclareMiddle();

            output += functionArgs[functionArgs.Length - 1] + this.getLambdaDeclareEnder();

            return new object[] { output, 0 };
        }

        // string visibility, string name, string return type[, string paramName, string paramType, ...]
        public object[] LambdaTypeDeclare(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("LambdaTypeDeclare", functionArgs, 3);

            if (!this.getLambdaTypeDeclarationRequired())
            {
                return new object[] { "", Language.INT_MIN };
            }

            string[] start = this.getLambdaTypeDeclarationStart();
            string[] middle = this.getLambdaTypeDeclarationMiddle();
            string[] end = this.getLambdaTypeDeclarationEnd();
            string[] variableDeclarationArgs = new string[2];
            string line = "";
            int i;

            if (this.getLambdaTypeDeclarationAsInterface())
            {
                object[] output = new object[6];

                // public interface TestInterface 
                line = this.getClassPublicAlias();
                line += start[0];
                line += functionArgs[0];
                line += start[1];

                output[0] = line;
                output[1] = 1;

                // a: string, b: int : boolean;
                line = middle[0] + "(";

                if (functionArgs.Length > 2)
                {
                    // All arguments are added using VariableDeclarePartial
                    for (i = 2; i < functionArgs.Length; i += 2)
                    {
                        variableDeclarationArgs[0] = functionArgs[i];
                        variableDeclarationArgs[1] = functionArgs[i + 1];

                        line += this.VariableDeclarePartial(variableDeclarationArgs, true)[0] + ", ";
                    }

                    // The last argument does not have the last ", " at the end
                    line = line.Substring(0, line.Length - 2);
                }

                line += ")";

                if (this.getFunctionReturnsExplicit() && this.getFunctionTypeAfterName())
                {
                    line += this.getFunctionTypeMarker() + this.parseType(functionArgs[1]);
                }

                line += middle[1];
                output[2] = line;
                output[3] = 0;

                // }
                output[4] = end[0];
                output[5] = -1;

                return output;
            }
            else
            {
                line += start[0] + this.getClassPublicAlias() + start[1];
                line += " " + this.parseType(functionArgs[1]);
                line += " " + functionArgs[0];

                if (functionArgs.Length > 2)
                {
                    line += middle[0];

                    // All arguments are added using VariableDeclarePartial
                    for (i = 2; i < functionArgs.Length; i += 2)
                    {
                        variableDeclarationArgs[0] = functionArgs[i];
                        variableDeclarationArgs[1] = functionArgs[i + 1];

                        line += this.VariableDeclarePartial(variableDeclarationArgs, true)[0] + ", ";
                    }

                    // The last argument does not have the last ", " at the end
                    line = line.Substring(0, line.Length - 2);
                    line += middle[1];
                }

                line = end[0] + line + end[1];
                return new object[] { line, 0 };
            }
        }

        public object[] LoopBreak(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getBreak() + this.getSemiColon(), 0 };
        }

        public object[] LoopContinue(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getContinue() + this.getSemiColon(), 0 };
        }

        public object[] MainEnd(string[] functionArgs, bool isInline)
        {
            string start = this.getMainStartLine();

            if (start.Length == 0)
            {
                return new object[] { this.getMainEndLine(), 0 };
            }

            return new object[] { this.getMainEndLine(), -1 };
        }

        public object[] MainStart(string[] functionArgs, bool isInline)
        {
            string output = this.getMainStartLine();

            if (output.Length == 0)
            {
                return new object[] { output, 0 };
            }
            return new object[] { output, 1 };
        }

        // string class, string function, string instance[, string parameter, ...]
        public object[] NativeCall(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("NativeFunction", functionArgs, 3);

            string className = this.getTypeAlias(functionArgs[0]);
            Dictionary<string, string> aliasInfo = this.getNativeFunctionAlias(functionArgs[0], functionArgs[1]);
            string placement = aliasInfo["placement"];
            string usage = aliasInfo["usage"];
            string caller = "";
            string output = "";
            int numArgs = 0;
            int start = 0;
            int i;

            if (placement == "member")
            {
                caller = functionArgs[2] + "." + aliasInfo["alias"];
                numArgs = functionArgs.Length - 3;
                start = 2;
            }
            else if (placement == "array")
            {
                caller = functionArgs[2];
                numArgs = functionArgs.Length - 3;
                start = 2;
            }
            else if (placement == "static")
            {
                caller = aliasInfo["alias"];
                numArgs = functionArgs.Length - 2;
                start = 1;
            }

            if (usage == "function")
            {
                string[] functionCallArgs = new string[numArgs];

                functionCallArgs[0] = caller;

                for (i = 1; i < functionArgs.Length - start; i += 1)
                {
                    functionCallArgs[i] = functionArgs[i + start];
                }

                output = (string)this.FunctionCall(functionCallArgs, isInline)[0];
            }
            else if (usage == "variable")
            {
                output = caller;
            }
            else if (usage == "array")
            {
                output = caller + "[";

                // Default to just the separator if there are no arguments
                if (functionArgs.Length - 1 == start)
                {
                    output += aliasInfo["separator"];
                }
                else
                {
                    for (i = 1; i < functionArgs.Length - start; i += 1)
                    {
                        output += functionArgs[i + start] + aliasInfo["separator"];
                    }

                    // Remove the last separator if more than one argument is added
                    if (functionArgs.Length - start > 2)
                    {
                        output = output.Substring(0, output.Length - aliasInfo["separator"].Length);
                    }
                }

                output += "]";
            }

            return new object[] { output, 0 };
        }

        // string value
        public object[] Not(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Operation", functionArgs, 1);

            return new object[] { "!" + functionArgs[0], 0 };
        }

        // string left, string operator, string right[, string operator, string right, ...]
        public object[] Operation(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Operation", functionArgs, 3);

            string output = functionArgs[0] + " ";
            int i;

            for (i = 1; i < functionArgs.Length; i += 2)
            {
                output += this.getOperationAlias(functionArgs[i]) + " ";
                output += this.getValueAlias(functionArgs[i + 1]) + " ";
            }

            output = output.Substring(0, output.Length - 1);

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        // string inside[, ...]
        public object[] Parenthesis(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Parenthesis", functionArgs, 1);

            string output = "(";
            int i;

            for (i = 0; i < functionArgs.Length - 1; i += 1)
            {
                output += functionArgs[i] + ", ";
            }

            output += functionArgs[i];
            output += ")";

            return new object[] { output, 0 };
        }

        // [string message, ...]
        public object[] PrintLine(string[] functionArgs, bool isInline)
        {
            string output = this.getPrintFunction() + "(";
            int i;

            for (i = 0; i < functionArgs.Length - 1; i += 1)
            {
                output += functionArgs[i] + ", ";
            }

            output += functionArgs[i];
            output += ")";

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        // string value
        public object[] Return(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("FunctionReturn", functionArgs, 1);

            return new object[] { "return " + functionArgs[0] + this.getSemiColon(), 0 };
        }

        public object[] This(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getClassThis(), 0 };
        }

        // [string message]
        public object[] Throw(string[] functionArgs, bool isInline)
        {
            string output = this.getExceptionThrow() + " ";

            if (functionArgs.Length > 0)
            {
                output += this.ClassNew(new string[] { this.getExceptionClass(), functionArgs[0] }, true)[0];
            }
            else
            {
                output += this.ClassNew(new string[] { this.getExceptionClass() }, true)[0];
            }

            if (!isInline)
            {
                output += this.getSemiColon();
            }

            return new object[] { output, 0 };
        }

        public object[] TryStart(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getExceptionTry() + this.getConditionContinueRight(), 1 };
        }

        public object[] TryEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getConditionEnd(), -1 };
        }

        // string type
        public object[] Type(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("Type", functionArgs, 1);
            return new object[] { this.getTypeAlias(functionArgs[0]), 0 };
        }

        // string value
        public object[] Value(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("VariableDeclare", functionArgs, 1);

            return new object[] { this.getValueAlias(functionArgs[0]), 0 };
        }

        // string name, string type[, string value]
        // Ex. var x: number;
        // Ex. var x: number = 7;
        public object[] VariableDeclare(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("VariableDeclare", functionArgs, 2);

            object[] output = this.VariableDeclareIncomplete(functionArgs, isInline);

            if (!isInline)
            {
                output[0] = output[0] + this.getSemiColon();
            }

            output[1] = 0;

            return output;
        }

        // string name, string type[, string value]
        // Ex. var x: number
        // Ex. var x: number = 7
        public object[] VariableDeclareIncomplete(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("VariableDeclareIncomplete", functionArgs, 2);

            string variableType = this.parseType(functionArgs[1]);
            string[] variableDeclarationArgs;
            object[] variableDeclared;

            if (functionArgs.Length == 2)
            {
                variableDeclarationArgs = new string[] { functionArgs[0], variableType };
            }
            else
            {
                variableDeclarationArgs = new string[] { functionArgs[0], variableType, functionArgs[2] };
            }

            variableDeclared = this.VariableDeclarePartial(functionArgs, isInline);
            variableDeclared[0] = this.getVariableDeclareStart() + variableDeclared[0];
            variableDeclared[1] = 1;

            return variableDeclared;
        }

        // string name, string type[, string value]
        // Ex. x: number
        // Ex. x: number = 7
        public object[] VariableDeclarePartial(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("VariableDeclarePartial", functionArgs, 2);

            string variableType = this.parseType(functionArgs[1]);
            string output = "";

            if (this.getVariableTypesExplicit())
            {
                if (this.getVariableTypesAfterName())
                {
                    output += functionArgs[0] + this.getVariableTypeMarker() + this.parseType(functionArgs[1]);
                }
                else
                {
                    output += this.parseType(variableType) + " " + functionArgs[0];
                }
            }
            else
            {
                output += functionArgs[0];
            }

            if (functionArgs.Length > 2)
            {
                output += " " + this.getOperationAlias("equals") + " " + this.getValueAlias(functionArgs[2]);
            }

            return new object[] { output, 1 };
        }

        public object[] WhileEnd(string[] functionArgs, bool isInline)
        {
            return new object[] { this.getConditionEnd(), -1 };
        }

        // string value
        public object[] WhileStart(string[] functionArgs, bool isInline)
        {
            this.requireArgumentsLength("WhileVariableStart", functionArgs, 1);

            string output = "while" + this.getConditionStartLeft();

            output += this.getOperationAlias(functionArgs[0]) + this.getConditionStartRight();

            return new object[] { output, 1 };
        }


        /*
        Utilities
        */

        private void requireArgumentsLength(string functionName, string[] functionArgs, int amount)
        {
            if (functionArgs.Length < amount)
            {
                throw new System.Exception("Not enough arguments given to " + functionName + ". Required: " + amount + ".");
            }
        }

    };
}
