namespace Script.Core.Framework.Compare
{
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a get method (parameter)
    /// </summary>
    [Method("getp", 1)]
    public class GetParameter : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var key = parameters[0];

            if (context.Parameters.ContainsKey(key))
                return context.Parameters[key];

            throw new InterpreterException($"Undeclared parameter: {key}");

        }
    }
}