namespace Script.Core.Framework.Logic
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of and not method
    /// </summary>
    [Method("not", 1)]
    public class Not : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToBool(parameters[0]);

            return Cast.ToString(!a);
        }
    }
}