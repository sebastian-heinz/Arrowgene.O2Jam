using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomSongSelectButton1 : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomSongSelectButton1));

        public override PacketId Id => PacketId.RoomSongSelectButton1Req;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteByte(0);
            client.Send(res.GetAllBytes(), PacketId.RoomSongSelectButton1Res);
            //Res_2031_0x07EF = 2031, // 0x07EF = 0x0055B590
        }
    }
}