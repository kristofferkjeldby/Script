namespace Script.Core.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Script.Core.Interpreter.Models;

    /// <summary>
    /// Method expression
    /// </summary>
    public class MethodExpression : Expression
    {
        /// <summary>
        /// Gets or sets the method name.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public List<Expression> Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodExpression"/> class.
        /// </summary>
        /// <param name="name">The method name.</param>
        public MethodExpression(string name)
        {
            Name = name;
            Parameters = new List<Expression>();
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        public bool AddParameter(Expression parameter)
        {
            Parameters.Add(parameter);
            return true;
        }

        /// <inheritdoc/>
        public override string Execute(ExecutionContext context)
        {
            if (context.HasLabelFlag)
                return context.Result;
            var method = context.BindMethod(Name, Parameters.Count);
            context.Result =  method.Execute(context, Parameters.Select(parameter => parameter.Execute(context)).ToArray());

            return context.Result;
        }
    }
}