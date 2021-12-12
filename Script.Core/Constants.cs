namespace Script.Core
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// The definition Script language
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Definition of a token
        /// </summary>
        public static Regex Tokens = new Regex(@"(\()|(\))|(""[^""]*"")|('[^']*')|(;)|\s|(})|({)|(,)", RegexOptions.Singleline);

        /// <summary>
        /// Definition of a comment
        /// </summary>
        public static Regex Comment = new Regex(@"^\s*(\/\/.*)?$", RegexOptions.Multiline);

        /// <summary>
        /// Definition of a method name
        /// </summary>
        public static Regex MethodName = new Regex(@"^[A-Za-z][A-Za-z0-9]*$");

        /// <summary>
        /// Definition of a literal quote formats
        /// </summary>
        public static Regex[] LiteralQuotes = new Regex[] { new Regex(@"^(?:""([^""]*)"")$"), new Regex(@"^(?:'([^']*)')$") };

        /// <summary>
        /// Definition of a parameter seperator
        /// </summary>
        public static string ParameterSeparator = ",";

        /// <summary>
        /// Definition of a scope start
        /// </summary>
        public static string ScopeStart = "{";

        /// <summary>
        /// Definition of a scope end
        /// </summary>
        public static string ScopeEnd = "}";

        /// <summary>
        /// Definition of a parameter start
        /// </summary>
        public static string ParameterStart = "(";

        /// <summary>
        /// Definition of a parameter end
        /// </summary>
        public static string ParameterEnd = ")";

        /// <summary>
        /// Definition of a conditional predicate start
        /// </summary>
        public static string ConditionalPredicateStart = "(";

        /// <summary>
        /// Definition of a conditional predicate end
        /// </summary>
        public static string ConditionalPredicateEnd = ")";

        /// <summary>
        /// Definition of a conditional keyword
        /// </summary>
        public static string ConditionalKeyword = "if";

        /// <summary>
        /// Definition of a loop predicate start
        /// </summary>
        public static string LoopPredicateStart = "(";

        /// <summary>
        /// Definition of a loop predicate end
        /// </summary>
        public static string LoopPredicateEnd = ")";

        /// <summary>
        /// Definition of a loop keyword
        /// </summary>
        public static string LoopKeyword = "while";

        /// <summary>
        /// Definition of a expression separator
        /// </summary>
        public static string ExpressionSeparator = ";";

        /// <summary>
        /// Definition of a label keyword
        /// </summary>
        public static string LabelKeyword = "label";

        /// <summary>
        /// Definition of a label keyword
        /// </summary>
        public static string GotoKeyword = "goto";

        /// <summary>
        /// Definition of a label name
        /// </summary>
        public static Regex LabelName = new Regex(@"^[A-Za-z0-9]*$");

        /// <summary>
        /// Definition of EOF token
        /// </summary>
        public static string EOF = "<end>";
    }
}