using System;
using System.Globalization;
using System.Text;

namespace Arrowgene.O2Jam.Server.Common
{
    public class ClientStartupArgFactory
    {
        private RsaCryptoParameter _cryptoParam;
        private Encoding _encoding;

        public ClientStartupArgFactory()
        {
            _encoding = Encoding.UTF8;
            _cryptoParam = new RsaCryptoParameter(251, 269, 54391, 68711);
        }

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
    }
}