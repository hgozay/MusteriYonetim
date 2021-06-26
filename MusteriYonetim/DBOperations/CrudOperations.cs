using MusteriYonetim.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MusteriYonetim.DBOperations
{
    public class CrudOperations
    {
        const string BasePath = @"C:\Users\husey\Documents\MusteriYonetim\";
        private string _DBName = "";
        public CrudOperations(string DBName)
        {
            _DBName = DBName;
        }
        public void Add<T>(T input)
        {
            string tableName = "";
            var jsonData = JsonSerializer.Serialize(input);

            if (input.GetType() == typeof(Customer))
            {
                tableName = @"\Customers.txt";
            }

            if (input.GetType() == typeof(Company))
            {
                tableName = @"\Companies.txt";
            }

            if (!Directory.Exists(BasePath + _DBName))
            {
                Directory.CreateDirectory(BasePath + _DBName);
                using (File.CreateText(BasePath + _DBName + tableName)) ;
            }

            File.AppendAllText(BasePath + _DBName + tableName, jsonData + Environment.NewLine);
        }

        public void Update<T>(T input, Type type) where T : BaseDto
        {
            string tableName = "";
            int index = -1;
            List<Tuple<T, int>> list = new List<Tuple<T, int>>();
            var jsonData = JsonSerializer.Serialize(input);

            if (type == typeof(Customer))
            {
                tableName = @"/Customers.txt";
            }
            if (type == typeof(Company))
            {
                tableName = @"/Companies.txt";
            }
            string[] allLines = File.ReadAllLines(BasePath + _DBName + tableName);
            foreach (var line in allLines)
            {
                list.Add(new Tuple<T, int>(JsonSerializer.Deserialize<T>(line), index));
                index++;
            }

            var item = list.Find(x => x.Item1.Id == input.Id); // devam et

            allLines[index] = jsonData;
            File.WriteAllLines(BasePath + _DBName + tableName, allLines);
        }

        public T Get<T>(string id, Type type) where T : BaseDto
        {
            try
            {
                string destFile = "";
                string tableName = "";
                List<T> dataList = new List<T>();
                if (type == typeof(Customer))
                {
                    destFile = _DBName;
                    tableName = @"\Customers.txt";

                }
                if (type == typeof(Company))
                {
                    destFile = @"Companies\";
                    tableName = "Companies.txt";
                }

                string[] allLines = File.ReadAllLines(BasePath + destFile + tableName);

                foreach (var line in allLines)
                {
                    var data = JsonSerializer.Deserialize<T>(line);
                    dataList.Add(data);
                }

                return dataList.Find(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<T> GetAll<T>(Type type)
        {
            string tableName = "";
            List<T> list = new List<T>();

            if (type == typeof(Customer))
            {
                tableName = @"/Customers.txt";
            }
            if (type == typeof(Company))
            {
                tableName = @"/Companies.txt";
            }
            string[] allLines = File.ReadAllLines(BasePath + _DBName + tableName);
            foreach (var line in allLines)
            {
                list.Add(JsonSerializer.Deserialize<T>(line));
            }
            return list;
        }
    }
}
