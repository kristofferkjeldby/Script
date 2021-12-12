namespace Script.Core.Framework
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a eval method
    /// </summary>
    [Method("eval", 1)]
    public class Eval : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            return Interpreter.Execute(parameters[0]).Console.ToString();
        }
    }
}