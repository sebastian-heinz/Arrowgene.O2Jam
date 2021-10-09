using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class Resalt : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(Resalt));

        public override PacketId Id => PacketId.Resalt1Req;

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res2 = new StreamBuffer();
            res2.WriteByte(0);
            client.Send(res2.GetAllBytes(), PacketId.Resalt1Res);
            //Res_4017_0x0FB1 = 4017, // 0x0FB1 = 0x0055FBA0

            IBuffer buffer = packet.CreateReadBuffer();
            short COOL = buffer.ReadInt16();
            short GOOD = buffer.ReadInt16();
            short BAD = buffer.ReadInt16();
            short MISS = buffer.ReadInt16();
            short MAXCOBMO = buffer.ReadInt16();
            short Unknown1 = buffer.ReadInt16();
            short MAXJAMCOMBO = buffer.ReadInt16();
            int SCORE = buffer.ReadInt32();
            byte Unknown2 = buffer.ReadByte();
            byte SPEED = buffer.ReadByte();
            int LONGNOTESCORE = buffer.ReadInt32();
            Logger.Info($"[COOL:{COOL}][GOOD:{GOOD}][BAD:{BAD}][MISS:{MISS}][MAX COBMO:{MAXCOBMO}][Unknown1:{Unknown1}][MAXJAMCOMBO:{MAXJAMCOMBO}][SCORE:{SCORE}][Unknown2:{Unknown2}][SPEED:{SPEED}][LONGNOTESCORE:{LONGNOTESCORE}]");

            IBuffer res = new StreamBuffer();
            res.WriteInt32(1); //index ?
            res.WriteInt16(0);
            res.WriteInt32(1); //index ?
            res.WriteInt16(COOL);//COOL
            res.WriteInt16(GOOD);//GOOD
            res.WriteInt16(BAD);//BAD
            res.WriteInt16(MISS);//MISS
            res.WriteInt16(MAXCOBMO);//MAX OBMO
            res.WriteInt16(MAXJAMCOMBO);//MAX JAM COMBO
            res.WriteInt32(SCORE);//TOTAL POINT
            res.WriteInt16(0);//+GEM
            res.WriteByte(Unknown2);
            res.WriteInt32(0);
            res.WriteInt32(0);
            res.WriteInt32(99999);//TOTAL GEM
            res.WriteInt32(0);
            res.WriteByte(SPEED);//Speed
            res.WriteInt32(LONGNOTESCORE);
            client.Send(res.GetAllBytes(), PacketId.Resalt2Res);
            //Res_4018_0x0FB2 = 4018, // 0x0FB2 = 0x0055FBE0


            /*
void FUN_0055fbe0(undefined4 param_1)

{
  int **in_FS_OFFSET;
  byte local_21;
  int local_20;
  int local_1c;
  byte local_15;
  int local_14;
  int *local_10;
  undefined *puStack12;
  undefined4 local_8;
  
  local_8 = 0xffffffff;
  puStack12 = &LAB_00634c7b;
  local_10 = *in_FS_OFFSET;
  local_14 = 0x55fbfb;
  *in_FS_OFFSET = (int *)&local_10;

  _memset(&DAT_00778a1e,0,8);
  FUN_00555d20(&local_1c,4);
  FUN_00555d20(&local_21,1);

  if (DAT_0077cd04 == local_21) {
    FUN_005400b0(1);
    for (local_14 = 0; local_14 < local_1c; local_14 = local_14 + 1) {
      if ((&DAT_0077eec0)[local_14 * 0x2190] != '\0') {
        FUN_005400b0(0);
        break;
      }
    }
  }
  else {
    FUN_005400b0(0);
    for (local_14 = 0; local_14 < local_1c; local_14 = local_14 + 1) {
      FUN_005400b0(0);
    }
    FUN_005400b0(1);
  }
  for (local_14 = 0; local_14 < local_1c; local_14 = local_14 + 1) {
    FUN_00555d20(&local_15,1);
    FUN_00555d20(&local_20,4);
    if (local_15 < 8) {
      if (local_20 == 1) {
        if (DAT_0077cd04 == local_15) {
          FUN_005411a0(param_1);
          _memcpy(&DAT_0077ee90 + (uint)local_15 * 0x2190,&DAT_0077cd00,0x2190);
          (&DAT_00778a1d)[DAT_0077cd31] = 1;
          DAT_00768b68 = DAT_0077cd24;
          DAT_00768b44 = (uint)DAT_0077ee64 + DAT_00768b44;
          _DAT_00768b70 = DAT_0077ee74;
        }
        else {
          FUN_005411a0(param_1);
          (&DAT_00778a1d)[(byte)(&DAT_0077eec1)[(uint)local_15 * 0x2190]] = 1;
        }
      }
    }
    else {
      FUN_0053f9e0();
      local_8 = 0;
      FUN_005411a0(param_1);
      local_8 = 0xffffffff;
      FUN_0053fa60();
    }
  }
  for (local_14 = 0; local_14 < 8; local_14 = local_14 + 1) {
    if ((&DAT_00778a1e)[local_14] != '\0') {
      DAT_007789fc = DAT_007789fc + 1;
    }
  }
  FUN_00478d50(0x12,0xfb2,0,0);
  *in_FS_OFFSET = local_10;
  FUN_005f1aa2();
  return;
}
*/


        }
    }
}