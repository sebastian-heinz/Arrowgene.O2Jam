using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomSongSelectHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomSongSelectHandle));

        public override PacketId Id => PacketId.RoomSongSelectReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer req = packet.CreateReadBuffer();
            ushort songId = req.ReadUInt16();
            ushort unknown = req.ReadUInt16();
            Logger.Info($"songId:{songId} unknown:{unknown}");

            IBuffer res = new StreamBuffer();
            res.WriteUInt16(songId);
            res.WriteUInt16(unknown);
            client.Send(res.GetAllBytes(), PacketId.RoomSongSelectRes);
            //Res_4001_0x0FA1 = 4001, // 0x0FA1 = 0x0055F2D0
        }
    }
}