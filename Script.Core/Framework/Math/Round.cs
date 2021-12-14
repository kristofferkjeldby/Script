namespace Script.Core.Framework.Math
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a round method
    /// </summary>
    [Method("round", 1)]
    public class Round : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToDouble(parameters[0]);
            return Cast.ToString(System.Math.Round(a));
        }
    }
}