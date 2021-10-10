using System;
using System.Globalization;
using System.Text;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;

namespace Arrowgene.O2Jam
{
    class Test
    {
        private static string test =
            "00C70200E85000DF8E00E85000CA9300F1A60096B800043E00811000717E0096B80099FC0013FD00CB8300A40C006E4200B96E00B705003F1600BF7500ADFE001B2000C4C100C5F30099F4005BBD00384F00F70800EEB500B9AF00C19100D50B00EEB50086CF00D83B00EBCF00639B00E83600DF6F005FB300192000583200637E001ABB00512000717E001A6800774100A50700A40C0000D800ED6E00C534006F880078BF006C3300ED0200AF02008D8C006EF6003C0900191000ED6E002C47005DC200192000FB5800A40C00CB8300DD38002C4700316A00F70800774100B11800A876006F8800280E00854E00F27600C2AA00AE6F00781200170E006351001B1700A40C0053AF0104BF0087CB004E1700923E00B6A000D83F00FAC700ADFE007205000B8200746300E32E0014D9004DEA00531C00DAD600E812000BB30002CC00CC050028B40097B600012400980A00CEC4004D5F00C2AA00AE6F000029001D99002970003F1600BF7500EFDC";


        public Test()
        {
            //00C702    00E850 00DF8E 00E85 000CA 9300F1A60096B800043E00811000717E0096B80099FC0013FD00CB8300A40C006E4200B96E00B705003F1600BF7500ADFE001B2000C4C100C5F30099F4005BBD00384F00F70800EEB500B9AF00C19100D50B00EEB50086CF00D83B00EBCF00639B00E83600DF6F005FB300192000583200637E001ABB00512000717E001A6800774100A50700A40C0000D800ED6E00C534006F880078BF006C3300ED0200AF02008D8C006EF6003C0900191000ED6E002C47005DC200192000FB5800A40C00CB8300DD38002C4700316A00F70800774100B11800A876006F8800280E00854E00F27600C2AA00AE6F00781200170E006351001B1700A40C0053AF0104BF0087CB004E1700923E00B6A000D83F00FAC700ADFE007205000B8200746300E32E0014D9004DEA00531C00DAD600E812000BB30002CC00CC050028B40097B600012400980A00CEC4004D5F00C2AA00AE6F000029001D99002970 003F16 00BF75 00EFDC
            //32:39-2:9
            int len = test.Length;
            int pairs = len / 6;
            double p3 = 67519.0; // 00 00 00 00 F0 7B F0 40 // param_3
            double p2 = 68711.0; // 00 00 00 00 70 C6 F0 40 // param_2

            for (int i = 0; i < len; i += 6)
            {
                String strVal = test.Substring(i, i + 6);
                int intVal = Int32.Parse(strVal, NumberStyles.AllowHexSpecifier);
                double p1 = (double) intVal;

                float res = fun_585a80(p1, p2, p3);

                int lol = 1;
            }


            int endTEST = 0;
        }

        private float fun_585a80(double p1, double p2, double p3)
        {
            bool bVar2 = false;
            uint local_30 = (uint) (long) Math.Round(p1);
            uint local_20 = local_30;
            int local_14 = 1;
            uint lcoal_40 = (uint) (long) Math.Round(p2);
            uint lcoal_10 = lcoal_40;
            float fVar3;

            while (true)
            {
                if ((bVar2) || (local_20 == 1))
                {
                    break;
                }

                fVar3 = (float) fun_58dc0((double) (ulong) local_20, p3);
                ulong uVar1 = (ulong) Math.Round(fVar3);
                uint local_58 = (uint) uVar1;
                if (local_58 == 0)
                {
                    return (float) -1.0;
                }
            }

            return (float) ((long) Math.Round(fVar3) & 0xFFFFFFFF);
        }


        private float fun_58dc0(double p1, double p2)
        {
            float fVar1;
            if (p1 == 1.0)
            {
                fVar1 = (float) p1;
            }
            else
            {
                if ((ushort) ((ushort) (1.0 < p1 ? 1 : 0) << 8 | (ushort) (p1 == 1.0 ? 1 : 0) << 0xE) == 0)
                {
                    fVar1 = (float) -1.0;
                }
                else
                {
                    double c = 1.0;
                    do
                    {
                        double d = Math.Pow(p1, c);
                        if (p2 == d)
                        {
                            return (float) 0;
                        }

                        if (p2 < d)
                        {
                            return (float) c;
                        }

                        c = c + 1.0;
                    } while (c <= 4096.0);

                    fVar1 = (float) -1.0;
                }
            }

            return fVar1;
        }


        public void mod(byte[] ar)
        {
        }
    }
}