using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class CharacterHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(CharacterHandle));

        public override PacketId Id => PacketId.CharacterReq;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            //  res.WriteInt32(0);
            //  res.WriteCString("Character");
            //  res.WriteByte(1); // Gender

            //  res.WriteBytes(new byte[]
            //  {
            //      0x7f, 0x96, 0x98, 0x00,
            //      0xFF, 0xFF, 0xFF, 0x00,
            //      0x7F, 0x96, 0x98, 0x00,
            //      0x64, 0x00, 0x00, 0x00,
            //      0x10, 0x00, 0x00, 0x00,
            //      0x0B, 0x00, 0x00, 0x00,
            //      0x05, 0x00, 0x00, 0x00,
            //      0x3A, 0x17, 0x59, 0x00,
            //      0x00, 0x00, 0x00, 0x00,
            //      0x00,
            //  });

            //  res.WriteInt32(0); // 
            //  res.WriteInt32(0); // 1
            //  res.WriteInt32(0); // 2
            //  res.WriteInt32(0); // 3
            //  res.WriteInt32(0); // 4
            //  res.WriteInt32(0); // 5
            //  res.WriteInt32(0); // 6
            //  res.WriteInt32(0); // 7
            //  res.WriteInt32(0); // 8
            //  res.WriteInt32(0); // 9
            //  res.WriteInt32(0); // 10
            //  res.WriteInt32(0x23); // 11 Face
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);
            //  res.WriteInt32(0);

            //  // Begin lazy data, first empty data that I lazy to make parser or it!
            //  // Probably inventory slot that not important in this KREmu.
            //  res.WriteBytes(new byte[]
            //  {
            //      0x00, 0x00, 0x00,
            //  });

            //  res.WriteBytes(new byte[13 * 10]);
            //  res.WriteBytes(new byte[]
            //  {
            //      // Just bunch Inventory slot!
            //      0x00, 0x26, 0x03, 0x00, 0x00, 0x24, 0x03, 0x00,
            //      0x00, 0x22, 0x03, 0x00, 0x00, 0x20, 0x03, 0x00,
            //      0x00, 0x1E, 0x03, 0x00, 0x00, 0x1C, 0x03, 0x00,
            //      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //      0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00,
            //      0x00, 0x1C, 0x03, 0x00, 0x00, 0x99, 0x99, 0x00,
            //      0x00, 0x1E, 0x03, 0x00, 0x00, 0x99, 0x99, 0x00,
            //      0x00, 0x20, 0x03, 0x00, 0x00, 0x99, 0x99, 0x00,
            //      0x00, 0x22, 0x03, 0x00, 0x00, 0x99, 0x99, 0x00,
            //      0x00, 0x24, 0x03, 0x00, 0x00, 0x99, 0x99, 0x00,
            //      0x00, 0x26, 0x03, 0x00, 0x00, 0x99, 0x99, 0x00
            //  });

            //  res.WriteByte(0);


            res.WriteInt32(0);
            res.WriteCString("Character");
            res.WriteByte(0); // Gender

            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);


            res.WriteByte(0);

            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);

            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);

            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);

            res.WriteInt32(0);
            res.WriteInt32(1);

            client.Send(res.GetAllBytes(), PacketId.CharacterRes);
        }
    }
}