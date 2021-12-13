namespace Script.Core.Framework.Compare
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a is set method (parameter)
    /// </summary>
    [Method("issetp", 1)]
    public class IsSetParameter : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var key = parameters[0];

            if (context.Parameters.ContainsKey(key))
                return Cast.ToString(true);

            return Cast.ToString(false);

        }
    }
}