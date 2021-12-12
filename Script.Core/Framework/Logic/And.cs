namespace Script.Core.Framework.Logic
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of an and method
    /// </summary>
    [Method("and", 2)]
    public class And : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToBool(parameters[0]);
            var b = Cast.ToBool(parameters[1]);

            return Cast.ToString(a && b);
        }
    }
}