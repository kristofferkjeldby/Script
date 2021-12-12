namespace Script.Core.Framework.String
{
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a concat method
    /// </summary>
    [Method("concat", 2)]
    public class Concat : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = parameters[0];
            var b = parameters[1];

            return string.Concat(a, b);
        }
    }
}