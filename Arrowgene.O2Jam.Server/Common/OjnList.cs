using System.Collections.Generic;
using Arrowgene.Buffers;
using Arrowgene.Logging;

namespace Arrowgene.O2Jam.Server.Common
{
    public class OjnList
    {
        private static readonly ILogger Logger = LogProvider.Logger<Logger>(typeof(OjnList));

        private const int BlockSize = 300;
        private const ushort MaxEntries = ushort.MaxValue;

        private readonly Dictionary<int, OjnEntry> _entries;

        public OjnList()
        {
            _entries = new Dictionary<int, OjnEntry>();
        }

        public ushort Count => (ushort) _entries.Count;
        public Dictionary<int, OjnEntry> Entries => new Dictionary<int, OjnEntry>(_entries);

        public void Load(string filePath)
        {
            Logger.Info($"Loading: {filePath}");
            _entries.Clear();

            StreamBuffer buffer = new StreamBuffer(filePath);
            buffer.SetPositionStart();

            int numEntries = buffer.ReadInt32();
            if (numEntries > MaxEntries)
            {
                Logger.Error($"Entries:{numEntries} > MAX_ENTRIES:{MaxEntries}");
                return;
            }

            for (int i = 0; i < numEntries; i++)
            {
                OjnEntry entry = new OjnEntry();
                entry.Id = buffer.ReadInt32();
                entry.Signature = buffer.ReadBytes(4);
                entry.EncodingVersion = buffer.ReadFloat();
                entry.Genre = (GenreType) buffer.ReadInt32();
                entry.Bpm = buffer.ReadFloat();
                entry.LevelEx = buffer.ReadInt16();
                entry.LevelNx = buffer.ReadInt16();
                entry.LevelHx = buffer.ReadInt16();
                entry.Padding = buffer.ReadInt16();
                entry.EventCountEx = buffer.ReadInt32();
                entry.EventCountNx = buffer.ReadInt32();
                entry.EventCountHx = buffer.ReadInt32();
                entry.NoteCountEx = buffer.ReadInt32();
                entry.NoteCountNx = buffer.ReadInt32();
                entry.NoteCountHx = buffer.ReadInt32();
                entry.MeasureCountEx = buffer.ReadInt32();
                entry.MeasureCountNx = buffer.ReadInt32();
                entry.MeasureCountHx = buffer.ReadInt32();
                entry.BlockCountEx = buffer.ReadInt32();
                entry.BlockCountNx = buffer.ReadInt32();
                entry.BlockCountHx = buffer.ReadInt32();
                entry.OldEncodingVersion = buffer.ReadInt16();
                entry.OldSongId = buffer.ReadInt16();
                entry.OldGenre = buffer.ReadBytes(20);
                entry.ThumbnailSize = buffer.ReadInt32();
                entry.FileVersion = buffer.ReadInt32();
                entry.Title = buffer.ReadBytes(64);
                entry.Artist = buffer.ReadBytes(32);
                entry.Pattern = buffer.ReadBytes(32);
                entry.Ojm = buffer.ReadBytes(32);
                entry.CoverSize = buffer.ReadInt32();
                entry.DurationEx = buffer.ReadInt32();
                entry.DurationNx = buffer.ReadInt32();
                entry.DurationHx = buffer.ReadInt32();
                entry.BlockOffsetEx = buffer.ReadInt32();
                entry.BlockOffsetNx = buffer.ReadInt32();
                entry.BlockOffsetHx = buffer.ReadInt32();
                entry.CoverOffset = buffer.ReadInt32();

                if (entry.ThumbnailSize > 0)
                {
                    entry.Thumbnail = buffer.GetBytes(entry.CoverOffset, entry.CoverSize);
                }

                if (_entries.ContainsKey(entry.Id))
                {
                    Logger.Info($"Entry:{entry.Id} already exists");
                    continue;
                }

                _entries.Add(entry.Id, entry);
            }

            Logger.Info($"Loaded:{_entries.Count}");
        }
    }
}