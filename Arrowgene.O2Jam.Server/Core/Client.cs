using System;
using System.Collections.Generic;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;
using Arrowgene.Networking.Tcp;

namespace Arrowgene.O2Jam.Server.Core
{
    public class Client
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(Client));

        private readonly ITcpSocket _socket;
        private readonly PacketFactory _packetFactory;

        public Client(ITcpSocket clientSocket)
        {
            _socket = clientSocket;
            _packetFactory = new PacketFactory(this);
            Identity = _socket.Identity;
        }

        public string Identity { get; }

        public List<NetPacket> Receive(byte[] data)
        {
            List<NetPacket> packets;
            try
            {
                packets = _packetFactory.Read(data);
            }
            catch (Exception ex)
            {
                Logger.Exception(this, ex);
                packets = new List<NetPacket>();
            }

            return packets;
        }

        public void Send(NetPacket packet)
        {
            byte[] data;
            try
            {
                data = _packetFactory.Write(packet);
            }
            catch (Exception ex)
            {
                Logger.Exception(this, ex);
                return;
            }

            if (data == null)
            {
                Logger.Error(this, $"No data produced to send for packetId: {packet.Id}");
                return;
            }

            _socket.Send(data);
        }
    }
}