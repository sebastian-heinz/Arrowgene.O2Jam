using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomListHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomListHandle));

        public override PacketId Id => PacketId.RoomListReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteInt32(0);
            client.Send(res.GetAllBytes(), PacketId.RoomListRes);
            //Res_2003_0x07D3 = 2003, // 0x07D3 = 0x0055B710

            IBuffer res2 = new StreamBuffer();
            res.WriteInt32(2);
            res.WriteInt32(3);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteUInt16(0);
            client.Send(res2.GetAllBytes(), PacketId.UnkRes);
            //Res_2026_0x07EA = 2026, // 0x07EA = 0x0055A9A0
        }
    }
}