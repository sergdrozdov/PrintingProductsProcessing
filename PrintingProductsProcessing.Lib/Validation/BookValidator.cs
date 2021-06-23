using System;

namespace PrintingProducts.Lib
{
    public class BookValidator : IDataLineValidator, IProductValidator
    {
        public bool IsInputLineValid(string input)
        {
            var data = Helpers.GetLineData(input);

            var isValid = true;
            if (data.Length < 4)
                isValid = false;
            else if (string.IsNullOrEmpty(data[1]))
                isValid = false;
            else if (string.IsNullOrEmpty(data[2]))
                isValid = false;

            var qty = 0;
            isValid = int.TryParse(data[3], out qty);

            return isValid;
        }

        public bool IsIsbnValid(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()))
                throw new ArgumentException("ISBN value is not specified.");

            return input.Trim().Length == 13;
        }
    }
}
