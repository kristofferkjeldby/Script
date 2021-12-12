namespace Script.Core.Models
{
    using Script.Core.Interpreter.Models;

    /// <summary>
    /// Represents a abstract expression
    /// </summary>
    public abstract class Expression
    {
        /// <summary>
        /// Executes this expression.
        /// </summary>
        /// <returns>The result</returns>
        public abstract string Execute(ExecutionContext context);
    }
}