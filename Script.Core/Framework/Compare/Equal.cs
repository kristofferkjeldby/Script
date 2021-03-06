namespace Script.Core.Framework.Compare
{
    using Script.Core.Interpreter;
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a equal method
    /// </summary>
    [Method("eq", 2)]
    public class StringEqual : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var a = Cast.ToDouble(parameters[0]);
            var b = Cast.ToDouble(parameters[1]);

            return Cast.ToString(a == b);
        }
    }
}