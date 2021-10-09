using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class PlanetHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(PlanetHandle));

        public override PacketId Id => PacketId.PlanetReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            uint count = 10;
            res.WriteUInt32(count); // no of channels (max 10)
            for (uint i = 0; i < count; i++)
            {
                res.WriteUInt16(0); // Planet No (0=1-10, 1=31-40, 2=61-70, 3=91-99+90)
                res.WriteUInt16((ushort) i); // Channel No
                res.WriteUInt32(0);
                res.WriteUInt32(0); // % full 0-100
                bool isOpen = true;
                res.WriteByte(isOpen ? (byte) 1 : (byte) 0); // 0 = closed | 1 = open
            }

            client.Send(res.GetAllBytes(), PacketId.PlanetRes);
            //Res_1003_0x03EB = 1003, // 0x03EB = 0x00559FF0
        }
    }
}