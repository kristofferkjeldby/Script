namespace Script.Core.Framework.Math
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a multiply method
    /// </summary>
    [Method("mul", 2)]
    public class Multiply : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToDouble(parameters[0]);
            var b = Cast.ToDouble(parameters[1]);

            return Cast.ToString(a * b);
        }
    }
}