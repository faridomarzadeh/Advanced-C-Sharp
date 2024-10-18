using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.WithGenerics
{
    public static class GenericTextFileProcessor
    {
        public static void SaveToTextFile<T>(List<T> list, string fileName) where T: class, new()
        {
            List<string> lines = new List<string>();
            T entry = new T();
            var properties = entry.GetType().GetProperties();


            List<string> headers = new List<string>();
            foreach ( var property in properties )
            {
                headers.Add( property.Name );
            }
            lines.Add( string.Join(",",headers) );


            foreach( var item in list )
            {
                List<string> values = new List<string>();
                foreach( var property in properties )
                {
                   values.Add(item.GetType().GetProperty(property.Name).GetValue(item).ToString());
                }
                lines.Add(string.Join(",", values));
            }

            File.WriteAllLines(fileName, lines);
        }

        public static List<T> LoadFromFile<T>(string fileName) where T: class, new()
        {
            List <T> list = new List<T>();
            var lines = File.ReadAllLines(fileName).ToList();
            T entry = new T();
            var properties = entry.GetType().GetProperties();

            if (lines.Count < 2)
                throw new Exception("Empty File");


            var header = lines[0].Split(',');
            lines.RemoveAt(0);

            foreach ( var line in lines)
            {
                entry = new T();
                var values = line.Split(',');
                for ( var i = 0; i< header.Length; i++)
                {
                    if (properties[i].Name == header[i])
                    {
                        var property = properties[i];
                        entry.GetType().GetProperty(property.Name).SetValue(entry, Convert.ChangeType(values[i], property.PropertyType));
                    }
                }
                list.Add(entry);
            }
            return list;
        }
    }
}
