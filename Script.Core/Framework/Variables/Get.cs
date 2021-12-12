namespace Script.Core.Framework.Compare
{
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a get method
    /// </summary>
    [Method("get", 1)]
    public class Get : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var key = parameters[0];

            if (context.Heap.ContainsKey(key))
                return context.Heap[key];

            throw new InterpreterException($"Undeclared variable: {key}");

        }
    }
}