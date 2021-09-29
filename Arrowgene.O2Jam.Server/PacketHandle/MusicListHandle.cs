using System;
using System.Collections.Generic;
using System.IO;
using Arrowgene.Buffers;
using Arrowgene.Logging;
using Arrowgene.O2Jam.Server.Common;
using Arrowgene.O2Jam.Server.Core;
using Arrowgene.O2Jam.Server.Logging;
using Arrowgene.O2Jam.Server.Packet;

namespace Arrowgene.O2Jam.Server.PacketHandle
{
    public class MusicListHandle : PacketHandler
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(MusicListHandle));

        private const ushort MaxSongs = 510;

        public override PacketId Id => PacketId.MusicListReq;

        private readonly OjnEntry[] _ojnEntries;

        public MusicListHandle(NetServer server)
        {
            OjnList ojnList = new OjnList();
            ojnList.Load(Path.Combine(server.Setting.DataPath, "OJNList.dat"));
            Dictionary<int, OjnEntry> entries = ojnList.Entries;
            int songCount = Math.Min(entries.Count, MaxSongs);
            _ojnEntries = new OjnEntry[songCount];
            int idx = 0;
            foreach (OjnEntry entry in entries.Values)
            {
                _ojnEntries[idx] = entry;
                idx++;
                if (idx >= songCount)
                {
                    break;
                }
            }

            Logger.Info($"Registered:{_ojnEntries.Length} entries");
        }

        public override void Handle(Client client, NetPacket packet)
        {
            IBuffer res = new StreamBuffer();
            ushort numEntries = (ushort) _ojnEntries.Length;
            res.WriteUInt16(numEntries);
            for (int i = 0; i < numEntries; i++)
            {
                OjnEntry entry = _ojnEntries[i];
                res.WriteUInt16((ushort) entry.Id);
                res.WriteUInt16((ushort) entry.NoteCountEx);
                res.WriteUInt16((ushort) entry.NoteCountNx);
                res.WriteUInt16((ushort) entry.NoteCountHx);
            }

            res.WriteByte(0);
            client.Send(res.GetAllBytes(), PacketId.MusicListRes);
        }
    }
}