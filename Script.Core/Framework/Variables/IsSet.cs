namespace Script.Core.Framework.Compare
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a is set method
    /// </summary>
    [Method("isset", 1)]
    public class IsSet : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var key = parameters[0];

            foreach(var scope in context.Scope.ToArray())
            {
                if (scope.Item2.ContainsKey(key))
                    return Cast.ToString(true);
            }

            return Cast.ToString(false);
        }
    }
}