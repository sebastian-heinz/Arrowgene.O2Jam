using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class RoomUnknown2Handle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(RoomUnknown2Handle));

        public override PacketId Id => PacketId.RoomUnknown2Req;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            res.WriteUInt16(0);
            res.WriteByte(0);
            client.Send(res.GetAllBytes(), PacketId.RoomUnknown2Res);
        }
    }
}