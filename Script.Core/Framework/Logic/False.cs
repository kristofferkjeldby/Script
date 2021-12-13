namespace Script.Core.Framework.Logic
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of false method
    /// </summary>
    [Method("false", 0)]
    public class False : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            return Cast.ToString(false);
        }
    }
}