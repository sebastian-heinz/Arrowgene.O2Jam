using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class PingHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(PingHandle));

        public override PacketId Id => PacketId.PingReq;

        public override void Handle(Client client, NetPacket packet)
        {
            client.Send(PacketId.PingRes);
        }
    }
}