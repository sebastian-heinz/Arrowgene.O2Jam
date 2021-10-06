using System;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class GameCheck2Handle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(GameCheck2Handle));

        public override PacketId Id => PacketId.GameCheck2Req;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer req = packet.CreateReadBuffer();
            uint un0 = req.ReadUInt32();
            uint un1 = req.ReadUInt32();
            uint time = req.ReadUInt32();
            uint count = req.ReadUInt32();
            uint un2 = req.ReadUInt32();

            Logger.Info($"un0:{un0} un1:{un1} time:{time} count:{count} un2:{un2}");
            
            IBuffer res = new StreamBuffer();
            res.WriteUInt32(un0);
            res.WriteUInt32(un1);
            res.WriteUInt32(time);
            res.WriteUInt32(count);
            res.WriteUInt32(un2);


            client.Send(res.GetAllBytes(), PacketId.GameCheck2Res);


          // if (un2 == 1)
          // {
          //     IBuffer res1 = new StreamBuffer();
          //     res1.WriteBytes(new byte[20]);
          //     for (ushort i = 4000; i < 4200; i++)
          //     {
          //         NetPacket p = new NetPacket(i, res1.GetAllBytes(), PacketSource.Server);
          //         client.Send(p);
          //     }
          // }
        }
    }
}