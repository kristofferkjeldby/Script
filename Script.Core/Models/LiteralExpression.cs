using Script.Core.Interpreter.Models;

namespace Script.Core.Models
{
    /// <summary>
    /// Literal expression
    /// </summary>
    public class LiteralExpression : Expression
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralExpression"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public LiteralExpression(string value)
        {
            Value = value;
        }

        /// <inheritdoc/>
        public override string Execute(ExecutionContext context)
        {
            if (context.HasLabelFlag)
                return context.Result;
            return Value;
        }
    }
}