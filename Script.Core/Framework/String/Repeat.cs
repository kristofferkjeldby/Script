namespace Script.Core.Framework.String
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;
    using System.Linq;

    /// <summary>
    /// Implementation of a repeat method
    /// </summary>
    [Method("rep", 2)]
    public class Repeat : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = parameters[0];
            var b = Cast.ToInt(parameters[1]);

            return string.Concat(Enumerable.Repeat(a, b));
        }
    }
}