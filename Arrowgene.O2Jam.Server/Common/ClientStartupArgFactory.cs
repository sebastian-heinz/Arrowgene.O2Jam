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

                double doubleResult = EncryptCycle(floatResult, P2, P3);
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

                double floatResult = DecryptCycle(intVal, P2, P3);
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

        private double EncryptCycle(float result, double p2, double p3)
        {
            int multiplier = 1;
            uint uIntResult = (uint) result;
            
            float p1 = Fmod((ulong) (multiplier * uIntResult), p3);
           
            
          //  var test = RequiredPower(uIntParam1, p3);

            return 0;
        }

        /// <summary>
        /// fun_585a80
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        private double DecryptCycle(double p1, double p2, double p3)
        {
            float result;
            uint uIntParam1 = (uint) p1;
            uint uIntParam2 = (uint) p2;
            int multiplier = 1;
            bool exit = false;

            while (true)
            {
                if (exit || uIntParam1 == 1)
                {
                    result = Fmod(multiplier * uIntParam1, p3);
                    return result;
                }

                result = RequiredPower(uIntParam1, p3);
                uint reqPower = (uint) result;
                if (reqPower == 0)
                {
                    return (float) -1.0;
                }

                result = Fmod(uIntParam2, reqPower);
                uIntParam2 = (uint) ((uIntParam2 - result) / reqPower);
                double dVar4 = Math.Pow(uIntParam1, (long) result);
                result = Fmod((uint) (multiplier * dVar4), p3);
                multiplier = (int) result;
                if (uIntParam2 == 0)
                {
                    break;
                }

                if (uIntParam2 == 1)
                {
                    exit = true;
                }

                dVar4 = Math.Pow(uIntParam1, reqPower);
                result = Fmod(dVar4, p3);
                uIntParam1 = (uint) result;
            }

            uIntParam1 = 1;
            result = Fmod((ulong) (multiplier * uIntParam1), p3);
            return result;
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