﻿using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperAndJson
{
    internal class ReadCSV_And_WriteJSON
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = "C:\\Users\\Basha\\Documents\\BridgeLabz\\CSVHelperAndJson\\CSVHelperAndJson\\Utility\\Addresses.csv";
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
                Console.WriteLine("Reading from csv file and write to Json file");

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}
