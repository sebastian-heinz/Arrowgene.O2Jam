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
            // RVA: otwo:base+0x15A396
            res.WriteInt32(0); // if not 0 skip 
            res.WriteCString("Character");
            res.WriteByte(1); // gender
            res.WriteInt32(0x98967F);
            res.WriteInt32(0xFFFFFF);
            res.WriteInt32(0x98967F); 
            // otwo.540C50
            res.WriteInt32(100); // level

            res.WriteInt32(0x10);
            res.WriteInt32(0xB);
            res.WriteInt32(0x5);
            res.WriteInt32(0x59173A);
            res.WriteInt32(0);
            res.WriteByte(0);

            int val2 = 0x23;
            res.WriteInt32(0);
            // loop start
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
            res.WriteInt32(val2);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(0);
            // end

            if (val2 == 0x23)
            {
                int count = 3;
                res.WriteInt32(count);
                for (int i = 0; i < count; i++)
                {
                    res.WriteInt32(0);
                }

                res.WriteInt32(0);

                byte count2 = 3;
                res.WriteUInt16(count2); // only byte used / max 255
                for (int i = 0; i < count2; i++)
                {
                    res.WriteInt32(0);
                    res.WriteInt32(0);
                    res.WriteCString("Test" + i);
                }

                byte count3 = 3;
                res.WriteUInt16(count3); // only byte used / max 255
                for (int i = 0; i < count3; i++)
                {
                    res.WriteInt32(0);
                    res.WriteInt32(0);
                    res.WriteCString("Test" + i);
                }

                res.WriteInt32(0);
                res.WriteInt32(0);
                res.WriteInt32(0);

                int count1 = 3;
                res.WriteInt32(count1);
                for (int i = 0; i < count1; i++)
                {
                    res.WriteInt32(0);
                    res.WriteInt32(0);
                }

                res.WriteInt16(0);
                res.WriteInt16(0);
            }

            client.Send(res.GetAllBytes(), PacketId.CharacterRes);
        }
    }
}