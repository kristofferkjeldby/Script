namespace Script.Core.Models
{
    using Script.Core.Interpreter.Models;

    /// <summary>
    /// Label expression
    /// </summary>
    public class LabelExpression : Expression
    {
        /// <summary>
        /// Gets or sets the label name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelExpression"/> class.
        /// </summary>
        /// <param name="name">The label name.</param>
        public LabelExpression(string name)
        {
            Name = name;
        }

        /// <inheritdoc/>
        public override string Execute(ExecutionContext context)
        {
            if (context.LabelFlag.Equals(Name))
                context.LabelFlag = string.Empty;
            return context.Result;
        }
    }
}