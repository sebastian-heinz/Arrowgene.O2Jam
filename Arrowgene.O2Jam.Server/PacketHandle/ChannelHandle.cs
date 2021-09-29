using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class ChannelHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(ChannelHandle));

        public override PacketId Id => PacketId.ChannelReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer buffer = packet.CreateReadBuffer();
            ushort selectedPlanet = buffer.ReadUInt16();
            ushort selectedChannel = buffer.ReadUInt16();
            Logger.Info($"Selected Planet:{selectedPlanet} Channel:{selectedChannel}");

            IBuffer res = new StreamBuffer();
            res.WriteUInt32(0);
            res.WriteUInt32(1); // Player rank

            client.Send(res.GetAllBytes(), PacketId.ChannelRes);
        }
    }
}