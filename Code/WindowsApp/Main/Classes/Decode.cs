using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class DecodeClass
    {

        #region Decode
        // === Decode MD Command ===
        public static bool decodeMD(string get_command, ref long time_stamp, ref List<long> distances)
        {
            distances.Clear();
            string[] split_command = get_command.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (split_command[1].StartsWith("00"))
                return true;
            else if (split_command[1].StartsWith("99")) //valid measurments
            {
                time_stamp = decode(split_command[2], 4);
                distance_data(split_command, 3, ref distances);
                //MessageBox.Show("time stamp: " + time_stamp.ToString() + " distance[100] : " + distances[100].ToString());
                return true;
            }
            else return false;
        }

        // === Decode ===
        private static long decode(string data, int size, int offset = 0)
        {
            long value = 0;

            for (int i = 0; i < size; ++i)
            {
                value <<= 6;
                char debug = data[offset + i];
                value |= (long)data[offset + i] - 0x30;  //Hexa 30 = Decimal 48;
            }

            return value;
        }

        //=== Distance Data ===
        private static bool distance_data(string[] lines, int start_line, ref List<long> distances)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start_line; i < lines.Length; ++i)
            {
                sb.Append(lines[i].Substring(0, lines[i].Length - 1));
            }
            return decode_array(sb.ToString(), 3, ref distances);
        }


        // === Decode Array ===
        private static bool decode_array(string data, int size, ref List<long> decoded_data)
        {
            for (int pos = 0; pos <= data.Length - size; pos += size)
            {
                decoded_data.Add(decode(data, size, pos));
            }
            return true;
        }

        #endregion
    }
}
