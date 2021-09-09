using Arrowgene.O2Jam.Server.Core;

namespace Arrowgene.O2Jam.Server.Packet
{
    public interface IPacketHandler
    {
        PacketId Id { get; }
        void Handle(Client client, NetPacket packet);
    }
}