namespace Script.Core.Framework.Math
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a pi method
    /// </summary>
    [Method("pi", 0)]
    public class Pi : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            return Cast.ToString(System.Math.PI);
        }
    }
}