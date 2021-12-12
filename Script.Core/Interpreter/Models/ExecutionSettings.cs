using System;
using System.Collections.Generic;

namespace Script.Core.Settings
{
    /// <summary>
    /// Execution Settings
    /// </summary>
    public class ExecutionSettings
    {
        public ExecutionSettings(Dictionary<string, string> enviroment = null)
        {
            EnviromentHeap = enviroment ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// The enviroment variable to prefill into the heap
        /// </summary>
        public Dictionary<string, string> EnviromentHeap { get; set; }
    }
}