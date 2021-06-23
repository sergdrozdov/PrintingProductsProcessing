using System.Collections.Generic;

namespace PrintingProducts.Lib
{
    public class Carton
    {
        public string SupplierIdentifier { get; set; }

        public string Identifier { get; set; }

        private readonly List<BookContent> _contents = new List<BookContent>();
        public IReadOnlyCollection<BookContent> Contents => _contents.AsReadOnly();

        /// <summary>
        /// Information about book item.
        /// </summary>
        public class BookContent
        {
            public string PoNumber { get; set; }
            public string Isbn { get; set; }
            public int Quantity { get; set; }
        }

        public void AddContent(BookContent content)
        {
            _contents.Add(content);
        }
    }
}
