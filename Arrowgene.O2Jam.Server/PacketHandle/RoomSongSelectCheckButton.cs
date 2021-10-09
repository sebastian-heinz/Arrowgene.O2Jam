using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomSongSelectCheckButton : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomSongSelectCheckButton));

        public override PacketId Id => PacketId.RoomSongSelectCheckButtonReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteByte(0);
            client.Send(res.GetAllBytes(), PacketId.RoomSongSelectCheckButtonRes);
            //Res_4054_0x0FD6 = 4054, // 0x0FD6 = 0x00563D30
        }
    }
}