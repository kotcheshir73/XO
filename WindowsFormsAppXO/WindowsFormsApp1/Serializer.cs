using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    static class Serializer
    {
        public static List<Statistic> GetData(string filePath)
        {
            var xs = new XmlSerializer(typeof(List<Statistic>));

            using (var sr = new StreamReader(filePath))
            {
                return xs.Deserialize(sr) as List<Statistic>;
            }
        }

        public static void SetData(string filePath, List<Statistic> data)
        {
            var xs = new XmlSerializer(typeof(List<Statistic>));

            using (var sw = new StreamWriter(filePath))
            {
                xs.Serialize(sw, data);
            }
        }

    }
}
