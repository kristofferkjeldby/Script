﻿namespace Script.Core.Framework.Variables
{
    using Script.Core.Interpreter.Models;
    using Script.Core.Models;

    /// <summary>
    /// Implementation of a set method
    /// </summary>
    [Method("set", 2)]
    public class Set : Method
    {
        /// <inheritdoc/>
        public override string Execute(ExecutionContext context, params string[] parameters)
        {
            var key = parameters[0];
            var value = parameters[1];

            if (context.Heap.ContainsKey(key))
                context.Heap[key] = value;
            else
                context.Heap.Add(key, value);

            return value;
        }
    }
}