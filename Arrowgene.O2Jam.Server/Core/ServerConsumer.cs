using System;
using System.Collections.Generic;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;
using Arrowgene.Networking.Tcp;
using Arrowgene.Networking.Tcp.Consumer.BlockingQueueConsumption;
using Arrowgene.Networking.Tcp.Server.AsyncEvent;

namespace Arrowgene.O2Jam.Server.Core
{
    public class ServerConsumer : ThreadedBlockingQueueConsumer
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(ServerConsumer));

        private readonly Dictionary<PacketId, IPacketHandler> _packetHandlers;
        private readonly Dictionary<ITcpSocket, Client>[] _clients;

        public ServerConsumer(AsyncEventSettings socketSetting) : base(socketSetting, "ServerConsumer")
        {
            _clients = new Dictionary<ITcpSocket, Client>[socketSetting.MaxUnitOfOrder];
            _packetHandlers = new Dictionary<PacketId, IPacketHandler>();
        }

        public void AddHandler(IPacketHandler packetHandler, bool overwrite = false)
        {
            if (_packetHandlers.ContainsKey(packetHandler.Id))
            {
                if (overwrite)
                {
                    _packetHandlers[packetHandler.Id] = packetHandler;
                    Logger.Info($"Packet Handler: {packetHandler.Id} got reassigned");
                }

                return;
            }

            _packetHandlers.Add(packetHandler.Id, packetHandler);
        }

        public override void OnStart()
        {
            base.OnStart();
            for (int i = 0; i < _clients.Length; i++)
            {
                _clients[i] = new Dictionary<ITcpSocket, Client>();
            }
        }

        protected override void HandleReceived(ITcpSocket socket, byte[] data)
        {
            if (!socket.IsAlive)
            {
                return;
            }

            if (!_clients[socket.UnitOfOrder].ContainsKey(socket))
            {
                return;
            }

            Client client = _clients[socket.UnitOfOrder][socket];
            List<NetPacket> packets = client.Receive(data);
            foreach (NetPacket packet in packets)
            {
                if (!_packetHandlers.ContainsKey(packet.Id))
                {
                    Logger.Error(client, $"HandleReceived: no packet handler registered for: {packet.Id}");
                    continue;
                }

                IPacketHandler packetHandler = _packetHandlers[packet.Id];
                try
                {
                    packetHandler.Handle(client, packet);
                }
                catch (Exception ex)
                {
                    Logger.Exception(client, ex);
                }
            }
        }

        protected override void HandleDisconnected(ITcpSocket socket)
        {
            if (!_clients[socket.UnitOfOrder].ContainsKey(socket))
            {
                Logger.Error(socket,"HandleDisconnected: client not found");
                return;
            }

            Client client = _clients[socket.UnitOfOrder][socket];
            _clients[socket.UnitOfOrder].Remove(socket);
            Logger.Info(client, "Disconnected");
        }

        protected override void HandleConnected(ITcpSocket socket)
        {
            if (_clients[socket.UnitOfOrder].ContainsKey(socket))
            {
                Logger.Error(socket,"HandleConnected: client already connected");
                return;
            }

            Client client = new Client(socket);
            _clients[socket.UnitOfOrder].Add(socket, client);
            Logger.Info(client, "Connected");
        }
    }
}