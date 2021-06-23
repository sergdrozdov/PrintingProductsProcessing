using System;
using System.Linq;
using PrintingProducts.Lib;

namespace PrintingProductsProcessing.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Practice test by Sergey Drozdov");
            Console.WriteLine("**********************************");
            Console.WriteLine("Email:\t\tsergey.drozdov.1980@gmail.com");
            Console.WriteLine("Website:\thttp://sd.blackball.lv/sergey-drozdov");
            Console.WriteLine("GitHub:\t\thttps://github.com/sergdrozdov/PrintingProductsProcessing");
            Console.WriteLine();

            var dataProcessor = new DataPackageProcessor();
            dataProcessor.BaseDataDir = @"D:\Tests\PrintingProductsProcessing\Data";
            dataProcessor.DataFileName = "data.txt";
            Console.WriteLine($"Check data file: '{dataProcessor.DataFilePath}'");
            if (!dataProcessor.IsDataFileExists(dataProcessor.DataFilePath))
            {
                Console.WriteLine($"Data file '{dataProcessor.DataFilePath}' does not exists.");
                DisplayWaitForExit();
                Console.ReadKey();

                return;
            }

            Console.WriteLine("Process data file...");
            dataProcessor.GenerateDataPackage();

            Console.WriteLine("Data file processing is completed successfully.");
            Console.WriteLine($"Cartons count: {dataProcessor.CartonsPackage.Count}");
            var booksCount = dataProcessor.CartonsPackage.Sum(carton => carton.Contents.Count);
            Console.WriteLine($"Books count: {booksCount}");

            DisplayWaitForExit();
            Console.ReadKey();
        }

        private static void DisplayWaitForExit()
        {
            Console.WriteLine("");
            Console.Write("Press any key to exit...");
        }
    }
}
