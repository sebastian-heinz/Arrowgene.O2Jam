using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;

namespace Arrowgene.O2Jam.Server.Common
{
    public class ClientStartupArgFactory
    {
        private const double P3 = 67519.0;
        private const double P2 = 68711.0;
        private const bool Perf1 = true;

        private Encoding _encoding;

        public ClientStartupArgFactory()
        {
            _encoding = Encoding.UTF8;
        }

        public string Encrypt(string decrypted)
        {
            int decryptedLength = decrypted.Length;
            if (decryptedLength % 2 != 0)
            {
                // todo add a space ?
                return null;
            }

            int numDecryptedCharPairs = decryptedLength / 2;
            int encryptedLength = numDecryptedCharPairs * 6;
            byte[] encrypted = new byte[encryptedLength];
            byte[] decryptedBytes = _encoding.GetBytes(decrypted);
            int encryptedIndex = 0;
            for (int i = 0; i < decryptedLength; i += 2)
            {
                byte[] bytesResult = new byte[4];
                bytesResult[0] = decryptedBytes[encryptedIndex++];
                bytesResult[1] = decryptedBytes[encryptedIndex++];
                int intResult = BitConverter.ToInt32(bytesResult);
                float floatResult = (float) intResult;
                if (floatResult < 0)
                {
                    return null;
                }
                
         
                
                

                bool end = true;
            }

            return "";
        }

        /// <summary>
        /// fun_0x585ed0
        /// </summary>
        /// <param name="encrypted"></param>
        /// <returns></returns>
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
                int intVal = int.Parse(strVal, NumberStyles.AllowHexSpecifier); // fun_5859A0
                if (intVal < 0)
                {
                    return null;
                }

                float floatResult = fun_585a80((double) intVal, P2, P3);
                if (floatResult < 0)
                {
                    return null;
                }

                int intResult = (int) floatResult; // fun_5f7260
                if (Perf1)
                {
                    byte[] bytesResult = BitConverter.GetBytes(intResult);
                    decrypted[decryptedIndex++] = bytesResult[1];
                    decrypted[decryptedIndex++] = bytesResult[0];
                }
                else
                {
                    string hexResult = $"{intResult:X}";
                    byte[] bytesResult = Encoding.UTF8.GetBytes(hexResult);

                    char[] charResultA = new char[2];
                    charResultA[0] = (char) bytesResult[0];
                    charResultA[1] = (char) bytesResult[1];
                    int intResultA = Int32.Parse(charResultA, NumberStyles.AllowHexSpecifier); // fun_5859A0
                    if (intResultA < 0)
                    {
                        return null;
                    }

                    decrypted[decryptedIndex++] = (byte) intResultA;

                    char[] charResultB = new char[2];
                    charResultB[0] = (char) bytesResult[2];
                    charResultB[1] = (char) bytesResult[3];
                    int intResultB = Int32.Parse(charResultB, NumberStyles.AllowHexSpecifier); // fun_5859A0
                    if (intResultB < 0)
                    {
                        return null;
                    }

                    decrypted[decryptedIndex++] = (byte) intResultB;
                }
            }

            string decryptedString = _encoding.GetString(decrypted);
            return decryptedString;
        }

        private float fun_585a80(double p1, double p2, double p3)
        {
            bool bVar2 = false;
            uint local_30 = (uint) (long) Math.Round(p1);
            uint local_20 = local_30;
            int local_14 = 1;
            uint local_40 = (uint) (long) Math.Round(p2);
            uint local_10 = local_40;
            float fVar3;

            while (true)
            {
                if ((bVar2) || (local_20 == 1))
                {
                    // LABEl
                    fVar3 = (float) fun_5fa5c0((double) (ulong) (local_14 * local_20), p3);
                    return (float) ((long) Math.Round(fVar3) & 0xFFFFFFFF);
                }

                fVar3 = (float) fun_585dc0((double) (ulong) local_20, p3);
                ulong uVar1 = (ulong) Math.Round(fVar3);
                uint local_58 = (uint) uVar1;
                if (local_58 == 0)
                {
                    return (float) -1.0;
                }

                fVar3 = (float) fun_5fa5c0((double) (ulong) local_10, (double) (uVar1 & 0xFFFFFFFF));
                int local_78 = (int) (long) Math.Round(fVar3);
                local_10 = (uint) ((local_10 - local_78) / local_58);
                double dVar4 = Math.Pow((double) (ulong) local_20, (double) ((long) Math.Round(fVar3) & 0xFFFFFFFF));
                int local_98 = (int) (long) Math.Round(dVar4);
                fVar3 = (float) fun_5fa5c0((double) (ulong) (uint) (local_98 * local_14), p3);
                int local_b0 = (int) (long) Math.Round(fVar3);
                local_14 = local_b0;
                if (local_10 == 0)
                {
                    break;
                }

                if (local_10 == 1)
                {
                    bVar2 = true;
                }

                double uVar5 = p3;
                dVar4 = Math.Pow((double) (long) local_20, (double) (uVar1 & 0xFFFFFFFF));
                fVar3 = (float) fun_5fa5c0(dVar4, uVar5);
                uint local_d0 = (uint) (long) Math.Round(fVar3);
                local_20 = local_d0;
            }

            local_20 = 1;
            // LABEl
            fVar3 = (float) fun_5fa5c0((double) (ulong) (local_14 * local_20), p3);
            return (float) ((long) Math.Round(fVar3) & 0xFFFFFFFF);
        }

        private float fun_5fa5c0(double p1, double p2)
        {
            return (float) (p1 % p2);
        }

        private float fun_585dc0(double p1, double p2)
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
    }
}