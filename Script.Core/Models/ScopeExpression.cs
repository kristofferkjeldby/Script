namespace Script.Core.Models
{
    using System.Collections.Generic;
    using Script.Core.Interpreter.Models;

    /// <summary>
    /// Scope expression
    /// </summary>
    public class ScopeExpression : Expression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeExpression"/> class.
        /// </summary>
        public ScopeExpression()
        {
            this.Expressions = new List<Expression>();
        }

        /// <summary>
        /// Gets or sets the expressions.
        /// </summary>
        /// <value>
        /// The expressions.
        /// </value>
        public List<Expression> Expressions { get; set; }

        /// <summary>
        /// Adds the expression.
        /// </summary>
        public bool AddExpression(Expression expression)
        {
            this.Expressions.Add(expression);
            return true;
        }

        /// <inheritdoc/>
        public override string Execute(ExecutionContext context)
        {
            context.Scope.Push(this);

            for (int i = 0; i < Expressions.Count; i ++)
            {
                context.Result = Expressions[i].Execute(context);
            }

            context.Scope.Pop();

            return context.Result;
        }
    }
}