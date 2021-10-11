using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Arrowgene.Logging;

namespace Arrowgene.O2Jam.Server.Common
{
    public class ClientStartupArguments
    {
        private static readonly ILogger Logger = LogProvider.Logger<Logger>(typeof(ClientStartupArguments));

        private const int NumArguments = 19;

        private readonly RsaCryptoParameter _cryptoParam;
        private readonly Encoding _encoding;

        public ClientStartupArguments()
        {
            _encoding = Encoding.UTF8;
            _cryptoParam = new RsaCryptoParameter(251, 269, 54391, 68711);
            P1 = new List<string>();
            P2 = 0;
            P3 = "";
            P4 = "";
            P5 = 0;
            P6 = "";
            AccountName = "";
            P8 = "";
            P9 = "";
            P10 = "";
            P11 = "";
            Email = "";
            P13 = "";
            P14 = "";
            P15 = "";
            P16 = "";
            P17 = "";
            P18 = "";
        }

        public ClientStartupArguments(string arguments) : this()
        {
            string[] args = ParseArguments(arguments);
            P1 = SplitArgs(args[0]);
            P2 = uint.Parse(args[1]);
            P3 = args[2];
            P4 = args[3];
            P5 = float.Parse(args[4]);
            P6 = args[5];
            AccountName = args[6];
            P8 = args[7];
            P9 = args[8];
            P10 = args[9];
            P11 = args[10];
            Email = args[11];
            P13 = args[12];
            P14 = args[13];
            P15 = args[14];
            P16 = args[15];
            P17 = args[16];
            P18 = args[17];
            P19 = args[18];
        }

        public List<string> P1 { get; set; }
        public uint P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public float P5 { get; set; }
        public string P6 { get; set; }
        public string AccountName { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        public string P10 { get; set; }
        public string P11 { get; set; }
        public string Email { get; set; }
        public string P13 { get; set; }
        public string P14 { get; set; }
        public string P15 { get; set; }
        public string P16 { get; set; }
        public string P17 { get; set; }
        public string P18 { get; set; }
        public string P19 { get; set; }


        public string Encrypt(string decrypted)
        {
            int decryptedLength = decrypted.Length;
            if (decryptedLength % 2 != 0)
            {
                // todo add a space ?
                return null;
            }

            StringBuilder encrypted = new StringBuilder();
            byte[] decryptedBytes = _encoding.GetBytes(decrypted);
            for (int i = 0; i < decryptedLength; i += 2)
            {
                byte[] bytesResult = new byte[2];
                bytesResult[1] = decryptedBytes[i];
                bytesResult[0] = decryptedBytes[i + 1];
                ushort intResult = BitConverter.ToUInt16(bytesResult);
                uint ret = (uint) _cryptoParam.Encrypt(intResult);
                string hexResult = $"{ret:X6}";
                encrypted.Append(hexResult);
            }

            return encrypted.ToString();
        }

        public string Decrypt(string encrypted)
        {
            int encryptedLength = encrypted.Length;
            if (encryptedLength % 6 != 0)
            {
                return null;
            }

            int numDecryptedCharPairs = encryptedLength / 6;
            int decryptedLength = numDecryptedCharPairs * 2;
            byte[] decrypted = new byte[decryptedLength];
            int decryptedIndex = 0;
            for (int i = 0; i < encryptedLength; i += 6)
            {
                string strVal = encrypted.Substring(i, 6);
                int intVal = int.Parse(strVal, NumberStyles.AllowHexSpecifier);
                if (intVal < 0)
                {
                    return null;
                }

                uint intResult = (uint) _cryptoParam.Decrypt(intVal);
                byte[] bytesResult = BitConverter.GetBytes(intResult);
                decrypted[decryptedIndex++] = bytesResult[1];
                decrypted[decryptedIndex++] = bytesResult[0];
            }

            string decryptedString = _encoding.GetString(decrypted);
            return decryptedString;
        }

        public string GetArgumentString()
        {
            StringBuilder sb = new StringBuilder();
            WritePrefix(sb, JoinArgs(P1));
            WritePrefix(sb, P2.ToString());
            WritePrefix(sb, P3);
            WritePrefix(sb, P4);
            WritePrefix(sb, $"{P5:0.00}");
            WritePrefix(sb, P6);
            WritePrefix(sb, AccountName);
            WritePrefix(sb, P8);
            WritePrefix(sb, P9);
            WritePrefix(sb, P10);
            WritePrefix(sb, P11);
            WritePrefix(sb, Email);
            WritePrefix(sb, P13);
            WritePrefix(sb, P14);
            WritePrefix(sb, P15);
            WritePrefix(sb, P16);
            WritePrefix(sb, P17);
            WritePrefix(sb, P18);
            WritePrefix(sb, P19);
            return sb.ToString();
        }

        public string GetEncryptedArgumentString()
        {
            string argumentString = GetArgumentString();
            return Encrypt(argumentString);
        }

        private void WritePrefix(StringBuilder sb, string value)
        {
            sb.Append($"{value.Length:00}");
            sb.Append(value);
        }

        private List<string> SplitArgs(string argument)
        {
            string[] args = argument.Split("|");
            return new List<string>(args);
        }

        private string JoinArgs(List<string> arguments)
        {
            return string.Join("|", arguments);
        }

        private string[] ParseArguments(string arguments)
        {
            string[] result = new string[NumArguments];
            int index = 0;
            for (int i = 0; i < NumArguments; i++)
            {
                if (index + 2 > arguments.Length)
                {
                    // err
                }

                string argumentLengthStr = arguments.Substring(index, 2);
                index += 2;
                int argumentLength = int.Parse(argumentLengthStr, NumberStyles.Integer);
                if (index + argumentLength > arguments.Length)
                {
                    // err
                }

                string argument = arguments.Substring(index, argumentLength);
                result[i] = argument;
                index += argumentLength;
            }

            return result;
        }
    }
}