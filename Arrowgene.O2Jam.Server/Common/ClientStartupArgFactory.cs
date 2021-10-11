using System;
using System.Globalization;
using System.Text;

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
            StringBuilder encrypted = new StringBuilder();
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

                double doubleResult = fun_585a80_rev(floatResult, P3, P2);
                int intR = (int) doubleResult;
                if (intR < 0)
                {
                    return null;
                }

                string hexResult = $"{intR:X6}";
                encrypted.Append(hexResult);
            }

            return encrypted.ToString();
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
                    string hexResult = $"{intResult:X4}";
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

        private double fun_585a80_rev(float p1, double p2, double p3)
        {
            return 0;
        }

        private float fun_585a80(double p1, double p2, double p3)
        {
            bool exit = false;
            int local_14 = 1;
            float result;
            uint local_20 = (uint) (long) Math.Round(p1);
            uint local_10 = (uint) (long) Math.Round(p2);

            while (true)
            {
                if (exit || local_20 == 1)
                {
                    // LABEl
                    result = (float) Fmod((double) (ulong) (local_14 * local_20), p3);
                    return (float) ((long) Math.Round(result) & 0xFFFFFFFF);
                }

                result = (float) RequiredPower(local_20, p3);
                ulong uVar1 = (ulong) Math.Round(result);
                uint local_58 = (uint) uVar1;
                if (local_58 == 0)
                {
                    return (float) -1.0;
                }

                result = (float) Fmod((double) (ulong) local_10, (double) (uVar1 & 0xFFFFFFFF));
                int local_78 = (int) (long) Math.Round(result);
                local_10 = (uint) ((local_10 - local_78) / local_58);
                double dVar4 = Math.Pow((double) (ulong) local_20, (double) ((long) Math.Round(result) & 0xFFFFFFFF));
                int local_98 = (int) (long) Math.Round(dVar4);
                result = (float) Fmod((double) (ulong) (uint) (local_98 * local_14), p3);
                int local_b0 = (int) (long) Math.Round(result);
                local_14 = local_b0;
                if (local_10 == 0)
                {
                    break;
                }

                if (local_10 == 1)
                {
                    exit = true;
                }

                double uVar5 = p3;
                dVar4 = Math.Pow((double) (long) local_20, (double) (uVar1 & 0xFFFFFFFF));
                result = (float) Fmod(dVar4, uVar5);
                uint local_d0 = (uint) (long) Math.Round(result);
                local_20 = local_d0;
            }

            local_20 = 1;
            // LABEl
            result = (float) Fmod((double) (ulong) (local_14 * local_20), p3);
            return (float) ((long) Math.Round(result) & 0xFFFFFFFF);
        }

        private float Fmod(double p1, double p2)
        {
            return (float) (p1 % p2);
        }
        
        /// <summary>
        /// Calculates smallest exponent of x that exceeds min
        /// </summary>
        /// <param name="x"></param>
        /// <param name="min"></param>
        /// <returns>smallest power of x that exceeds min</returns>
        private int RequiredPower(uint x, double min)
        {
            if (x == 1)
            {
                return 1;
            }
            if (x < 1)
            {
                return -1;
            }
            int count = 1; 
            do
            {
                double result = Math.Pow(x, count);
                if (min == result)
                {
                    return 0;
                }

                if (min < result)
                {
                    return count;
                }

                count++;
            } while (count <= 4096);
            return -1;
        }
    }
}