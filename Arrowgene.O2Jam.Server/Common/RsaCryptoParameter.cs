using System.Collections.Generic;
using System.Numerics;

namespace Arrowgene.O2Jam.Server.Common
{
    public class RsaCryptoParameter
    {
        public RsaCryptoParameter(BigInteger p, BigInteger q, BigInteger e)
        {
            P = p;
            Q = q;
            N = P * Q;
            Phi = (P - 1) * (Q - 1);
            E = e;
        }

        public RsaCryptoParameter(BigInteger p, BigInteger q) : this(p, q, BigInteger.Zero)
        {
        }

        public BigInteger P { get; }
        public BigInteger Q { get; }
        public BigInteger N { get; }
        public BigInteger Phi { get; }

        /// <summary>
        /// Public Key
        /// </summary>
        public BigInteger E { get; set; }

        /// <summary>
        /// Private Key
        /// </summary>
        public BigInteger D { get; set; }

        public void SetEAndDeriveD(BigInteger e)
        {
            E = e;
            D = DeriveD(e);
        }

        public BigInteger DeriveD(BigInteger e)
        {
            BigInteger d = new BigInteger();
            for (BigInteger i = 1; i < Phi; i = BigInteger.Add(i, 1))
            {
                d = BigInteger.DivRem(BigInteger.Add(BigInteger.Multiply(i, Phi), 1), e, out BigInteger remainder);
                if (remainder == 0)
                {
                    break;
                }
            }

            return d;
        }

        public List<int> FindPotentialE(BigInteger m, BigInteger expected)
        {
            List<int> potential = new List<int>();
            for (int j = 1; j < Phi; j++)
            {
                BigInteger crypted = BigInteger.ModPow(m, j, N);
                if (crypted == expected)
                {
                    potential.Add(j);
                }
            }

            return potential;
        }

        /// <summary>
        /// Encrypts message to cipher text
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public BigInteger Encrypt(BigInteger m)
        {
            return BigInteger.ModPow(m, E, N);
        }

        /// <summary>
        /// Decrypts cipher text to message
        /// </summary>
        /// <param name="c">cipher</param>
        /// <returns></returns>
        public BigInteger Decrypt(BigInteger c)
        {
            return BigInteger.ModPow(c, D, N);
        }
    }
}