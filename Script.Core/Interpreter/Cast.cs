namespace Script.Core.Interpreter
{

    using Script.Core.Interpreter.Models;
    using System.Globalization;

    /// <summary>
    /// Implementation of cast operations for scripting language
    /// </summary>
    public static class Cast
    {
        /// <summary>
        /// Converts the string representation of a number to an integer.
        /// </summary>
        /// <param name="value">The value.</param>
        public static int ToInt(string value)
        {
            if (!int.TryParse(value, out var castedValue))
                throw new InterpreterException($"Cannot cast {value} to integer");

            return castedValue;
        }

        /// <summary>
        /// Converts to double.
        /// </summary>
        public static double ToDouble(string value)
        {
            if (!double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var castedValue))
                throw new InterpreterException($"Cannot cast {value} to double");

            return castedValue;
        }

        /// <summary>
        /// Converts the string representation of a number to an boolean.
        /// </summary>
        public static bool ToBool(string value, bool? defaultValue = null)
        {
            if (!bool.TryParse(value, out var castedValue))
            {
                if (defaultValue.HasValue)
                    return defaultValue.Value;
                
                throw new InterpreterException($"Cannot cast {value} to boolean");
            }


            return castedValue;
        }

        /// <summary>
        /// Converts the boolean to a string representation.
        /// </summary>
        /// <param name="value">The value.</param>
        public static string ToString(bool value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Converts the integer to a string representation.
        /// </summary>
        /// <param name="value">The value.</param>
        public static string ToString(int value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Converts the double to a string representation.
        /// </summary>
        /// <param name="value">The value.</param>
        public static string ToString(double value)
        {
            return value.ToString("0.00", CultureInfo.InvariantCulture).TrimEnd('0').Trim('.');
        }
    }
}