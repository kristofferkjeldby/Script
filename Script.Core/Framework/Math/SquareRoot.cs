namespace Script.Core.Framework.Math
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a square root method
    /// </summary>
    [Method("sqrt", 1)]
    public class SquareRoot : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToDouble(parameters[0]);
            return Cast.ToString(System.Math.Pow(a, 0.5));
        }
    }
}