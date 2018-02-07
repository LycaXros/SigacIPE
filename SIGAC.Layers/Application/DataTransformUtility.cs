using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGAC.Layers.Application
{
    public static class DataTransformUtility
    {
        
        public static byte[] StringToByte(string value, Encoding encoding)
        {
            return encoding.GetBytes(value);
        }

        public static string  StringFromByte(byte[] values, Encoding encoding)
        {
            var reader = new StreamReader(new MemoryStream(values), encoding);

            return reader.ReadToEnd().ToString();
        }
    }
}
