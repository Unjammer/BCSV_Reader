using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCSV_Reader
{
    class Hex
    {
        public static string StringToHex(String text_value)
        {
            byte[] ba = Encoding.Default.GetBytes(text_value);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            return hexString;

        }


        /* Convert Hex to Float */
        public static float HexStringToFloat(string hex)
        {
            try
            {
                uint num = uint.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte[] bytes = BitConverter.GetBytes(num);
                /*if (BitConverter.IsLittleEndian)
                {
                    bytes = bytes.Reverse().ToArray();
                }*/
                float myFloat = BitConverter.ToSingle(bytes, 0);
                return myFloat;
            }
            catch
            {
                return 0;
            }
        }

        public static string IntToHex(int num)
        {
            
            // Convert integer 182 as a hex in a string variable
            string hexValue = num.ToString("X4");
            return hexValue;
        }

        /*Convert Float to Hex */
        public static string FloatToHexString(float f)
        {
            var bytes = BitConverter.GetBytes(f);
            var i = BitConverter.ToInt32(bytes, 0);
            return "0x" + i.ToString("X8");
        }

        public static string FromHexToString(string hexString)
        {
            string result;
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            result = Encoding.Default.GetString(bytes);

            return Snippet.InvertString(result);
        }

        public static string FromHexToString_JP(string hexString)
        {
            string result;
            var bytes = new byte[hexString.Length/2];
            for (var i = 0; i < bytes.Length ; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            result = Encoding.UTF8.GetString(bytes);

            return result;
        }


        /* Convert String to Hex */
        public static string StringToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.ASCII.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool IsHexString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
