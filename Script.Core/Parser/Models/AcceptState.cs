namespace Script.Core.Parser.Models
{
    /// <summary>
    /// Represents the accept state
    /// </summary>
    public enum AcceptState
    {
        /// <summary>
        /// Expression
        /// </summary>
        Expression,

        /// <summary>
        /// Conditional predicate
        /// </summary>
        ConditionalPredicate,

        /// <summary>
        /// Conditional expression
        /// </summary>
        ConditionalExpression,

        /// <summary>
        /// Loop predicate
        /// </summary>
        LoopPredicate,

        /// <summary>
        /// Loop expression
        /// </summary>
        LoopExpression,

        /// <summary>
        /// Parameters
        /// </summary>
        Parameter
    }
}