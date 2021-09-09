using System;
using Arrowgene.Buffers;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Common;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class LoginHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(LoginHandle));

        public override PacketId Id => PacketId.Login;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer buffer = packet.CreateBuffer();
            buffer.Position = 15;
            ushort a = buffer.ReadUInt16();
            if (a > 2)
            {
                byte[] aa = buffer.ReadBytes(a - 2);
                Logger.Info($"aa:{Util.HexDump(aa)}");
            }

            string b = buffer.ReadCString();
            string c = buffer.ReadCString();
            string d = buffer.ReadCString();
            string e = buffer.ReadCString();

            Logger.Info($"b:{b} c:{c} d:{d} e:{e}");
        }
    }
}