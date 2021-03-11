using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ConsoleApp3
{
    class FilePersistence<T> where T : new()
    {
        public List<T> Values { get; private set; }
        private System.Reflection.PropertyInfo[] _props = typeof(T).GetProperties();

        public FilePersistence()
        {
            Values = new List<T>();
        }

        public FilePersistence(string FilePath)
        {
            Values = new List<T>();
            try
            {
                Values = File.ReadAllLines(FilePath)
                   .Skip(1)
                   .Select((a) =>
                   {
                       T t = new T();

                       var values = a.Split(',');

                       for (int i = 0; i < _props.Length; i++)
                       {
                           switch (Type.GetTypeCode(_props[i].PropertyType))
                           {
                               case TypeCode.Int32:
                                   _props[i].SetValue(t, Int32.Parse(values[i]));
                                   break;

                               case TypeCode.String:
                                   _props[i].SetValue(t, values[i]);
                                   break;

                               case TypeCode.Boolean:
                                   _props[i].SetValue(t, Boolean.Parse(values[i]));
                                   break;

                               case TypeCode.Char:
                                   _props[i].SetValue(t, values[i][0]);
                                   break;

                               case TypeCode.Double:
                                   _props[i].SetValue(t, Double.Parse(values[i]));
                                   break;

                               case TypeCode.DateTime:
                                   _props[i].SetValue(t, DateTime.Parse(values[i]));
                                   break;

                               default:
                                   break;
                           }
                       }

                       return t;
                   }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SaveToFile(string FilePath)
        {
            var lines = Values
                .Select((x) =>
                {
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < _props.Length; i++)
                    {
                        str.Append($"{ _props[i].GetValue(x).ToString() },");
                    };
                    return str.ToString(0, str.Length - 1);
                }).ToList();

            lines.Insert(0, String.Join(',', _props.Select(x => x.Name)));

            File.WriteAllLines(FilePath, lines);
        }

        public void PrintValues()
        {
            foreach (T item in Values)
            {
                StringBuilder line = new StringBuilder();
                foreach (var prop in _props)
                {
                    line.Append($"{prop.GetValue(item) },");
                }

                Console.WriteLine(line.ToString());
            }
        }
    }
}
