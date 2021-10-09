using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class CreateRoomHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(CreateRoomHandle));

        public override PacketId Id => PacketId.CreateRoomReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer announce = new StreamBuffer();
            announce.WriteInt32(1);
            announce.WriteCString("Room");
            announce.WriteByte(0);
            announce.WriteByte(0);
            announce.WriteByte(0);
            announce.WriteByte(0);
            announce.WriteByte(0);
            announce.WriteInt16(0);
            announce.WriteByte(0);
            client.Send(announce.GetAllBytes(), PacketId.AnnounceRoomRes);
            //Res_2005_0x07D5 = 2005, // 0x07D5 = 0x0055B9A0
            
            IBuffer res = new StreamBuffer();
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt16(0);
            client.Send(res.GetAllBytes(), PacketId.CreateRoomRes);
            //Res_2006_0x07D6 = 2006, // 0x07D6 = 0x0055BB40
        }
    }
}