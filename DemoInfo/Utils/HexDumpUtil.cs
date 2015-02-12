using System;
using System.Text;
using System.Linq;

namespace EHVAG.DemoInfo.Utils
{
    public static partial class Util
    {
        const string allowedChars = "^°!\"§$%&/()=?qwertzuiopasdfghjkl<yxcvbnm1234567890?QWERTZUIOPASDFGHJKLYXCVBNM ,.>;:-_#'+*~{}[]\\";

        public static string GenerateHexdump(byte[] data, int rowSize)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < data.Length; i += rowSize)
            {
                output.AppendLine(GetHexdumpLine(i, data, rowSize));
            }

            return output.ToString();
        }

        public static string GenerateHexdump(byte[] data)
        {
            return GenerateHexdump(data, 8);
        }

        public static void WriteHexdump(byte[] data, int rowSize)
        {
            for (int i = 0; i < data.Length; i += rowSize)
            {
                Console.WriteLine(GetHexdumpLine(i, data, rowSize));
            }
        }

        public static void WriteHexdump(byte[] data)
        {
            WriteHexdump(data, 8);
        }

        /// <summary>
        /// Gets a hexdump line.
        /// </summary>
        /// <returns>The hexdump line.</returns>
        /// <param name="i">The index of the first byte of the row.</param>
        /// <param name="data">Data.</param>
        /// <param name="rowSize">Row size.</param>
        private static string GetHexdumpLine(int i, byte[] data, int rowSize)
        {
            StringBuilder output = new StringBuilder();
            output.Append(Convert.ToString(i, 16).PadLeft(8, '0'));
            output.Append(" | ");

            if (rowSize % 2 == 0)
            {
                output.Append(BitConverter.ToString(data, i, Math.Min(rowSize / 2, data.Length - i)).PadRight(3 * (rowSize / 2) - 1, ' '));
                output.Append("  ");
                if(Math.Max(0, Math.Min(rowSize / 2, data.Length - (i + rowSize))) > 0)
                {
                    output.Append(BitConverter.ToString(data, i + rowSize / 2, Math.Max(0, Math.Min(rowSize / 2, data.Length - (i + rowSize)))).PadRight(3 * (rowSize / 2) - 1, ' '));
                }
                else
                {
                    output.Append("".PadRight(3 * (rowSize / 2) - 1, ' '));
                }
            }
            else
            {
                output.Append(BitConverter.ToString(data, i, Math.Min(rowSize, data.Length - i)).PadRight(3 * rowSize - 1, ' '));
            }

            output.Append(" | ");

            for (int j = i; j < Math.Min(data.Length, i + rowSize); j++)
            {
                char chr = (char)data[j];

                if (allowedChars.Contains(chr))
                    output.Append(chr);
                else
                    output.Append('·');

                if (rowSize % 2 == 0 && (j - (i - 1)) == rowSize / 2)
                    output.Append(' ');
            }

            return output.ToString();
        }
    }
}

