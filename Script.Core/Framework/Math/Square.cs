namespace Script.Core.Framework.Math
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a square method
    /// </summary>
    [Method("sq", 1)]
    public class Square : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToDouble(parameters[0]);
            return Cast.ToString(System.Math.Pow(a, 2));
        }
    }
}