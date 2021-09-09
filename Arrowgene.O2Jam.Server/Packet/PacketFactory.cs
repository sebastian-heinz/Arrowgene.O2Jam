using System;
using System.Collections;
using System.Collections.Generic;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Common;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;

namespace Arrowgene.O2Jam.Server.Packet
{
    public class PacketFactory
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(PacketFactory));

        private const int PacketLengthSize = 2;
        private const int PacketIdSize = 2;
        private const int PacketHeaderSize = PacketLengthSize + PacketIdSize;

        private IBuffer _buffer;
        private ushort _dataSize;
        private PacketId _packetId;
        private int _position;
        private bool _readPacketLength;
        private readonly Client _client;

        public PacketFactory(Client client)
        {
            _client = client;
            Reset();
        }

        public byte[] Write(NetPacket packet)
        {
            int packetSize = packet.Data.Length + PacketLengthSize + PacketIdSize;
            if (packetSize > ushort.MaxValue)
            {
                Logger.Error(_client, $"Write: packetSize({packetSize}) > ushort.MaxValue({ushort.MaxValue})");
                return null;
            }

            if (packetSize < 0)
            {
                Logger.Error(_client, $"Write: packetSize({packetSize}) < 0");
                return null;
            }

            ushort size = (ushort) packetSize;
            IBuffer buffer = new StreamBuffer();
            buffer.WriteUInt16(size);
            buffer.WriteUInt16((ushort) packet.Id);
            buffer.WriteBytes(packet.Data);
            byte[] packetData = buffer.GetAllBytes();
            return packetData;
        }

        public List<NetPacket> Read(byte[] data)
        {
            Logger.Debug(_client, Util.HexDump(data));

            List<NetPacket> packets = new List<NetPacket>();
            if (_buffer == null)
            {
                _buffer = new StreamBuffer(data);
            }
            else
            {
                _buffer.SetPositionEnd();
                _buffer.WriteBytes(data);
            }

            _buffer.Position = _position;

            bool read = true;
            while (read)
            {
                read = false;
                if (!_readPacketLength && _buffer.Size - _buffer.Position > PacketHeaderSize)
                {
                    ushort dataSize = _buffer.ReadUInt16();
                    ushort packetId = _buffer.ReadUInt16();

                    int iDataSize = dataSize - PacketHeaderSize;
                    if (iDataSize < 0)
                    {
                        Logger.Error(_client, $"Read: iDataSize({iDataSize}) < 0");
                        Reset();
                        return packets;
                    }

                    if (iDataSize > ushort.MaxValue)
                    {
                        Logger.Error(_client, $"Read: iDataSize({iDataSize}) > ushort.MaxValue({ushort.MaxValue})");
                        Reset();
                        return packets;
                    }

                    if (!Enum.IsDefined(typeof(PacketId), packetId))
                    {
                        _packetId = PacketId.Unknown;
                        Logger.Error($"PacketId: '{packetId}' not found");
                        // Reset();
                        // return packets;
                    }
                    else
                    {
                        _packetId = (PacketId) packetId;
                    }

                    _dataSize = (ushort) iDataSize;
                    _readPacketLength = true;
                }

                if (_readPacketLength && _buffer.Size - _buffer.Position >= _dataSize)
                {
                    byte[] packetData = _buffer.ReadBytes(_dataSize);
                    NetPacket packet = new NetPacket(_packetId, packetData, PacketSource.Client);
                    Logger.Packet(_client, packet);
                    packets.Add(packet);

                    _readPacketLength = false;
                    read = _buffer.Position != _buffer.Size;
                }
            }

            if (_buffer.Position == _buffer.Size)
            {
                // TODO reuse buffer, avoid new allocation
                Reset();
            }
            else
            {
                _position = _buffer.Position;
            }

            return packets;
        }

        private void Reset()
        {
            _readPacketLength = false;
            _dataSize = 0;
            _position = 0;
            _packetId = 0;
            _buffer = null;
        }
    }
}