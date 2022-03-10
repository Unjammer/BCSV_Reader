using System;
using System.Linq;
using System.Text;

namespace BCSV_Reader
{
    class Snippet
    {
        public static string InvertString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string InvertHexString(string InputText)
        {
            String s = InputText;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i <= s.Length - 2; i = i + 2)
            {
                result.Append(new StringBuilder(s.Substring(i, i + 2)).ToString().Reverse());
            }
            return result.ToString();
        }

        public static string crc32b_Hash(string text_to_hash)
        {
            string result;
            var arrayOfBytes = Encoding.UTF8.GetBytes(text_to_hash);

            var crc32 = new Crc32();
            byte[] bytes = crc32.ComputeHash(arrayOfBytes);
            result = BitConverter.ToString(bytes).ToLower();
            result = result.Replace("-", "");
            return result;

        }

        public static string InvertHex(string Hex_Str)
        {

            string output = "";
            for (int i = 0; i < Hex_Str.Length - 1; i += 2)
            {
                output += Hex_Str[i + 1];
                output += Hex_Str[i];
            }
            return output;
        }

    }
}
