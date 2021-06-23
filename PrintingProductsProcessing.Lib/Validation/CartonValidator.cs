using PrintingProducts.Lib;

namespace PrintingProducts.Lib
{
    public class CartonValidator : IDataLineValidator
    {
        public bool IsInputLineValid(string input)
        {
            var isValid = true;
            var data = Helpers.GetLineData(input);
            if (data.Length < 3)
                isValid = false;
            else if (string.IsNullOrEmpty(data[1]) || string.IsNullOrEmpty(data[2]))
                isValid = false;

            return isValid;
        }
    }
}
