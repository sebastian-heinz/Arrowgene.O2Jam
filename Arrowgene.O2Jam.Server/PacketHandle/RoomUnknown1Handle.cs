using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomUnknown1Handle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomUnknown1Handle));

        public override PacketId Id => PacketId.RoomUnknown1Req;

        public override void Handle(Client client, NetPacket packet)
        {
            // potentially player in room
            IBuffer res = new StreamBuffer();
            res.WriteInt32(0);
            client.Send(res.GetAllBytes(), PacketId.RoomUnknown1Res);
            //Res_4024_0x0FB8 = 4024, // 0x0FB8 = 0x005602A0
        }
    }
}