using Script.Core.Interpreter;
using Script.Core.Interpreter.Models;

namespace Script.Core.Models
{
    /// <summary>
    /// Loop expression
    /// </summary>
    public class LoopExpression : Expression
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
            var hasLabelFlag = context.HasLabelFlag;
                context.Result = Expression.Execute(context);

            // If we have a label flag, we need to run the expression, to see if we can get it removed
            if (context.HasLabelFlag)
                context.Result = Expression.Execute(context);

            while (!context.HasLabelFlag && Cast.ToBool(Predicate.Execute(context)))
            {
                context.Result = Expression.Execute(context);
            }

            return context.Result;
        }
    }
}