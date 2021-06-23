using System;
using System.Collections.Generic;
using System.Text;

namespace PrintingProducts.Lib
{
    public class Helpers
    {
        public static string[] GetLineData(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()))
                return new[] { "" };

            return input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
