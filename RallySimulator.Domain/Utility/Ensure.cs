using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Utility
{
    public static class Ensure
    {
        public static void NotLessThanOrEqualToZero(int value, string message, string argumentName)
        {
            if (value < 0)
            {
                throw new ArgumentException(message, argumentName);
            }
        }
        public static void NotEmpty(string value, string message, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message, argumentName);
            }
        }
        public static void NotEmpty(DateTime value, string message, string argumentName)
        {
            if (value == default)
            {
                throw new ArgumentException(message, argumentName);
            }
        }
        public static void NotNull(object value, string message, string argumentName)
        {
            if (value is null)
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}
