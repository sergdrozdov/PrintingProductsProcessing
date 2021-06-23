namespace PrintingProducts.Lib
{
    public enum DataLineType
    {
        /// <summary>
        /// Package carton header.
        /// </summary>
        HDR,

        /// <summary>
        /// Carton product data.
        /// </summary>
        LINE
    }

    /// <summary>
    /// The values may differ from the members of the enumeration.
    /// </summary>
    public static class DataLineTypeHelper
    {
        public static string ToValue(this DataLineType option)
        {
            switch (option)
            {
                default:
                    return option.ToString();
                case DataLineType.HDR:
                    return "HDR";
                case DataLineType.LINE:
                    return "LINE";
            }
        }
    }
}
