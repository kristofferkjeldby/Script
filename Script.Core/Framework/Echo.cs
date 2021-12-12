namespace Script.Core.Framework
{
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a echo method
    /// </summary>
    [Method("echo", 1)]
    public class Echo : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            context.Console.Append(parameters[0]);
            return parameters[0];
        }
    }
}