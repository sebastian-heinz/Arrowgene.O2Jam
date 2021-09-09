using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class UnknownHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(UnknownHandle));

        public override PacketId Id => PacketId.Unknown;

        public override void Handle(Client client, NetPacket packet)
        {
            Logger.Info(client, $"Unhandled PacketId:{packet.IdValue} Hex:{packet.IdValue:X}");
        }
    }
}