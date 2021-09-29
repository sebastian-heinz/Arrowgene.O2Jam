using System;
using System.IO;
using System.Reflection;
using System.Text;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;

namespace Arrowgene.O2Jam.Server.Common
{
    public static class Util
    {
        private static readonly ILogger Logger = LogProvider.Logger<Logger>(typeof(Util));
        
        public static readonly Encoding KoreanEncoding;
        
        static Util()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            KoreanEncoding = Encoding.GetEncoding("EUC-KR");
        }

        /// <summary>
        /// The directory of the executing assembly.
        /// This might not be the location where the .dll files are located.
        /// </summary>
        /// <returns></returns>
        public static string ExecutingDirectory()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly == null)
            {
                Logger.Error("Assembly.GetEntryAssembly() == null");
                return null;
            }
            string path = assembly.CodeBase;
            Uri uri = new Uri(path);
            string directory = Path.GetDirectoryName(uri.LocalPath);
            return directory;
        }
        
        /// <summary>
        /// Directory of a c# dll
        /// </summary>
        /// <param name="typeContainedInLibrary">a type contained in the library to identify it</param>
        /// <returns></returns>
        public static string LibraryDirectory(Type typeContainedInLibrary)
        {
            string location = typeContainedInLibrary.GetTypeInfo().Assembly.Location;
            Uri uri = new Uri(location);
            string directory = Path.GetDirectoryName(uri.LocalPath);
            return directory;
        }
        
        public static byte[] FromHexString(string hexString)
        {
            if ((hexString.Length & 1) != 0)
            {
                throw new ArgumentException("Input must have even number of characters");
            }

            byte[] ret = new byte[hexString.Length / 2];
            for (int i = 0; i < ret.Length; i++)
            {
                int high = hexString[i * 2];
                int low = hexString[i * 2 + 1];
                high = (high & 0xf) + ((high & 0x40) >> 6) * 9;
                low = (low & 0xf) + ((low & 0x40) >> 6) * 9;

                ret[i] = (byte) ((high << 4) | low);
            }

            return ret;
        }

        public static string ToHexString(byte[] data, char? seperator = null)
        {
            StringBuilder sb = new StringBuilder();
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                sb.Append(data[i].ToString("X2"));
                if (seperator != null && i < len - 1)
                {
                    sb.Append(seperator);
                }
            }

            return sb.ToString();
        }

        public static string ToAsciiString(byte[] data, bool spaced)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                char c = '.';
                if (data[i] >= 'A' && data[i] <= 'Z') c = (char) data[i];
                if (data[i] >= 'a' && data[i] <= 'z') c = (char) data[i];
                if (data[i] >= '0' && data[i] <= '9') c = (char) data[i];
                if (spaced && i != 0)
                {
                    sb.Append("  ");
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

        public static void DumpBuffer(IBuffer buffer)
        {
            int pos = buffer.Position;
            buffer.SetPositionStart();
            Console.WriteLine(ToAsciiString(buffer.GetAllBytes(), true));
            while (buffer.Size > buffer.Position)
            {
                byte[] row = buffer.ReadBytes(16);
                Console.WriteLine(ToHexString(row, ' '));
            }

            buffer.Position = pos;
        }

        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                8 // 8 characters for the address
                + 3; // 3 spaces

            int firstCharColumn = firstHexColumn
                                  + bytesPerLine * 3 // - 2 digit for the hexadecimal value and 1 space
                                  + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                                  + 2; // 2 spaces 

            int lineLength = firstCharColumn
                             + bytesPerLine // - characters to show the ascii value
                             + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - Environment.NewLine.Length) + Environment.NewLine)
                .ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char) b);
                    }

                    hexColumn += 3;
                    charColumn++;
                }

                result.Append(line);
            }

            return result.ToString();
        }
    }
}