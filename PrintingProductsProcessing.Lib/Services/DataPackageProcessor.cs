using System;
using System.Collections.Generic;
using System.IO;

namespace PrintingProducts.Lib
{
    public class DataPackageProcessor : IDataPackageProcessor
    {
        public string BaseDataDir { get; set; }
        public string DataFileName { get; set; }
        public string DataFilePath => Path.Combine(BaseDataDir, DataFileName);
        public List<Carton> CartonsPackage { get; set; }
        public CartonValidator CartonValidator { get; set; }
        public BookValidator BookValidator { get; set; }

        public DataPackageProcessor()
        {
            CartonValidator = new CartonValidator();
            BookValidator = new BookValidator();
            CartonsPackage = new List<Carton>();
        }

        public bool IsDataFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string[] GetLineData(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()))
                return new[] { "" };

            return input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public Carton GetCartonInfo(string input)
        {
            var carton = new Carton();
            var data = GetLineData(input);
            carton.Identifier = data[2];
            carton.SupplierIdentifier = data[1];

            return carton;
        }

        public Carton.BookContent GetContentInfo(string input)
        {
            var contentInfo = new Carton.BookContent();
            var data = GetLineData(input);
            contentInfo.PoNumber = data[1];
            contentInfo.Isbn = data[2];
            contentInfo.Quantity = Convert.ToInt32(data[3]);

            return contentInfo;
        }

        public void GenerateDataPackage()
        {
            using (var sr = new StreamReader(new BufferedStream(File.OpenRead(DataFilePath), 1024 * 1024)))
            {
                var dataLine = "";
                var currentCarton = new Carton();
                while ((dataLine = sr.ReadLine()) != null)
                {
                    if (dataLine.ToUpper().StartsWith(DataLineType.HDR.ToValue()))
                    {
                        if (CartonValidator.IsInputLineValid(dataLine))
                        {
                            currentCarton = GetCartonInfo(dataLine);
                            CartonsPackage.Add(currentCarton);
                        }
                        else
                        {
                            throw new Exception("Carton data is invalid.");
                        }
                    }
                    else if (dataLine.ToUpper().StartsWith(DataLineType.LINE.ToValue()))
                    {
                        if (BookValidator.IsInputLineValid(dataLine))
                        {
                            currentCarton.AddContent(GetContentInfo(dataLine));
                        }
                        else
                        {
                            throw new Exception($"Carton '{currentCarton.Identifier}' content data is invalid.");
                        }
                    }
                }
            }
        }
    }
}
