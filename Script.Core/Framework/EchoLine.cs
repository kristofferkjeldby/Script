namespace Script.Core.Framework
{
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a echo line method
    /// </summary>
    [Method("echoln", 1)]
    public class EchoLine : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            context.Console.AppendLine(parameters[0]);
            return parameters[0];
        }
    }
}