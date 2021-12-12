namespace Script.Core.Framework.Math
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a equal method
    /// </summary>
    [Method("lt", 2)]
    public class LessThan : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToInt(parameters[0]);
            var b = Cast.ToInt(parameters[1]);

            return Cast.ToString(a < b);
        }
    }
}