using System;
using System.Collections.Generic;

namespace Script.Core.Settings
{
    /// <summary>
    /// Execution Settings
    /// </summary>
    public class ExecutionSettings
    {
        public ExecutionSettings(Dictionary<string, string> parameters = null)
        {
            Parameters = parameters ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// The parameters
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
    }
}