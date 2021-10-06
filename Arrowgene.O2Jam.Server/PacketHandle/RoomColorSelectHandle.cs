using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomColorSelectHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomColorSelectHandle));

        public override PacketId Id => PacketId.RoomColorSelectReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer req = packet.CreateReadBuffer();
            ushort unknown1 = req.ReadUInt16();
            ushort unknown2 = req.ReadUInt16();
            Logger.Info($"unknown1:{unknown1} unknown2:{unknown2}");

            IBuffer res = new StreamBuffer();
            res.WriteUInt16(unknown1);
            res.WriteUInt16(unknown2);
            client.Send(res.GetAllBytes(), PacketId.RoomColorSelectRes);
        }
    }
}