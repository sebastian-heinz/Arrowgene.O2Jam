using Arrowgene.O2Jam.Server.Core;

namespace Arrowgene.O2Jam.Server.Packet
{
    public abstract class PacketHandler : IPacketHandler
    {
        protected PacketHandler() 
        {
        }

        public abstract PacketId Id { get; }
        public abstract void Handle(Client client, NetPacket packet);
    }
}