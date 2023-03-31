using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperAndJson
{
    internal class CSVHandler
    {
        public static void ImplementCSVHandling()
        {
            string importFilePath = "D:C:\\Users\\Basha\\Documents\\BridgeLabz\\CSVHelperAndJson\\CSVHelperAndJson\\Utility\\Addresses.csv";
            string exportFilePath = "C:\\Users\\Basha\\Documents\\BridgeLabz\\CSVHelperAndJson\\CSVHelperAndJson\\Utility\\export.csv";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.firstname);
                    Console.WriteLine("\t" + addressData.lastname);
                    Console.WriteLine("\t" + addressData.address);
                    Console.WriteLine("\t" + addressData.city);
                    Console.WriteLine("\t" + addressData.state);
                    Console.WriteLine("\t" + addressData.code);
                    Console.WriteLine();
                }
                Console.WriteLine("Reading from csv file and write to csv file");

                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
