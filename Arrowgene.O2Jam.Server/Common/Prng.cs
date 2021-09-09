namespace Arrowgene.O2Jam.Server.Common
{
    public class Prng
    {
        private uint _seed;
        
        public Prng(uint seed)
        {
            _seed = seed;
        }
        
        public uint Next()
        {
            _seed = _seed * 0x343fd + 0x269EC3;
            return (_seed >> 0x10) & 0x7FFF;
        }
    }
}