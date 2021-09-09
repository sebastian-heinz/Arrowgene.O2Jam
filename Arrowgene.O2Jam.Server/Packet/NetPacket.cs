using System;
using System.Text;
using Arrowgene.O2Jam.Server.Common;
using Arrowgene.Buffers;

namespace Arrowgene.O2Jam.Server.Packet
{
    public class NetPacket
    {
        public byte[] Data;
        public PacketId Id { get; }
        public ushort IdValue { get; }
        public PacketSource Source { get; }

        public NetPacket(PacketId id, byte[] data, PacketSource source = PacketSource.Server)
        {
            Id = id;
            Data = data;
            Source = source;
            IdValue = (ushort) id;
        }

        public NetPacket(ushort id, byte[] data, PacketSource source = PacketSource.Server)
        {
            IdValue = id;
            Data = data;
            Source = source;
            if (Enum.IsDefined(typeof(PacketId), id))
            {
                Id = (PacketId) id;
            }
            else
            {
                Id = PacketId.Unknown;
            }
        }

        public IBuffer CreateBuffer()
        {
            IBuffer buffer = new StreamBuffer(Data);
            buffer.SetPositionStart();
            return buffer;
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"==={Environment.NewLine}");
            sb.Append($"Id:{Id} Dec:{IdValue} Hex:{IdValue:X}{Environment.NewLine}");
            sb.Append($"Source:{Source}{Environment.NewLine}");
            sb.Append($"Data:{Environment.NewLine}{Util.HexDump(Data)}");
            sb.Append("===");
            return sb.ToString();
        }
    }
}