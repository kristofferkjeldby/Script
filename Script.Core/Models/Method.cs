using Script.Core.Interpreter.Models;

namespace Script.Core.Models
{
    /// <summary>
    /// Represents a abstract method
    /// </summary>
    public abstract class Method
    {
        /// <summary>
        /// Executes the method.
        /// </summary>
        /// <param name="context">The execution context</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public abstract string Execute(ExecutionContext context, params string[] parameters);
    }
}