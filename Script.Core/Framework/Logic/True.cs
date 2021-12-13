namespace Script.Core.Framework.Logic
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of true method
    /// </summary>
    [Method("true", 0)]
    public class True : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            return Cast.ToString(true);
        }
    }
}