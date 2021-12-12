namespace Script.Core.Models
{
    using Script.Core.Interpreter.Models;

    /// <summary>
    /// Goto expression
    /// </summary>
    public class GotoExpression : Expression
    {
        /// <summary>
        /// Gets or sets the label name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GotoExpression"/> class.
        /// </summary>
        /// <param name="name">The label name.</param>
        public GotoExpression(string name)
        {
            Name = name;
        }

        /// <inheritdoc/>
        public override string Execute(ExecutionContext context)
        {
            if (context.HasLabelFlag)
                return context.Result;

            throw new GotoException(Name);
        }
    }
}