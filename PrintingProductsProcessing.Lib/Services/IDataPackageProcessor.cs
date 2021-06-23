namespace PrintingProducts.Lib
{
    public interface IDataPackageProcessor
    {
        bool IsDataFileExists(string filePath);
        Carton GetCartonInfo(string input);
        Carton.BookContent GetContentInfo(string input);
        void GenerateDataPackage();
    }
}
