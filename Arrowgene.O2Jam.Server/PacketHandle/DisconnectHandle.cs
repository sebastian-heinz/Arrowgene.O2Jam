using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class DisconnectHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(DisconnectHandle));

        public override PacketId Id => PacketId.DisconnectReq;

        public override void Handle(Client client, NetPacket packet)
        {
            Logger.Info("Client Disconnected");
            client.Close();
        }
    }
}