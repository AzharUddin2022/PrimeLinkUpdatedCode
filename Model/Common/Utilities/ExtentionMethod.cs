using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Model.Common.Utilities
{
    public static class ExtentionMethod
    {
        public static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetition<T>(
         this IEnumerable<T> items,
         int ofLength)
        {
            return (ofLength == 1) ?
                items.Select(item => new[] { item }) :
                items.SelectMany((item, i) => items.Skip(i + 1)
                                                   .CombinationsWithoutRepetition(ofLength - 1)
                                                   .Select(result => new T[] { item }.Concat(result))).Distinct();
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {

                    if (pro.Name == column.ColumnName && dr[column.ColumnName] != System.DBNull.Value)
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }


        public static IEnumerable<IEnumerable<T>> CombinationsWithoutRepetition<T>(
            this IEnumerable<T> items,
            int ofLength,
            int upToLength)
        {
            return Enumerable.Range(ofLength, Math.Max(0, upToLength - ofLength + 1))
                             .SelectMany(len => items.CombinationsWithoutRepetition(ofLength: len));
        }

        public static object Deserialize(string json)
        {
            return ToObject(JToken.Parse(json));
        }

        private static object ToObject(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    return token.Children<JProperty>()
                                .ToDictionary(prop => prop.Name,
                                              prop => ToObject(prop.Value));

                case JTokenType.Array:
                    return token.Select(ToObject).ToList();

                default:
                    return ((JValue)token).Value;
            }
        }

    }
}
