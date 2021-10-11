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

        public const int NumArguments = 19;

        public static List<string> SplitArgs(string argument)
        {
            string[] args = argument.Split("|");
            return new List<string>(args);
        }

        public static string JoinArgs(List<string> arguments)
        {
            return string.Join("|", arguments);
        }

        public static string[] ParseArguments(string arguments)
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

        public ClientStartupArguments()
        {
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

        public ClientStartupArguments(string arguments)
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

        public override string ToString()
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


        private void WritePrefix(StringBuilder sb, string value)
        {
            sb.Append(value.Length);
            sb.Append(value);
        }
    }
}