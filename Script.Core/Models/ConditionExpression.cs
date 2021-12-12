namespace Script.Core.Models
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;

    /// <summary>
    /// Conditional expression
    /// </summary>
    public class ConditionalExpression : Expression
    {
        /// <summary>
        /// Gets or sets the predicate.
        /// </summary>
        /// <value>
        /// The predicate.
        /// </value>
        public Expression Predicate { get; set; }

        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        public Expression Expression { get; set; }

        /// <summary>
        /// Adds the predicate.
        /// </summary>
        public bool AddPredicate(Expression predicate)
        {
            this.Predicate = predicate;
            return true;
        }

        /// <summary>
        /// Adds the expression.
        /// </summary>
        public bool AddExpression(Expression expression)
        {
            this.Expression = expression;
            return true;
        }

        /// <inheritdoc/>
        public override string Execute(ExecutionContext context)
        {
            if (context.HasLabelFlag || Cast.ToBool(Predicate.Execute(context)))
                context.Result = Expression.Execute(context);
            return context.Result;
        }
    }
}