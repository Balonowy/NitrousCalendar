using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NitrousCalendar
{
    public class CalendarManager : IEnumerable<KeyValuePair<long, CalendarEntry>>
    {
        private readonly Dictionary<long, CalendarEntry> Entries = new();
        private readonly string FilePath;

        public CalendarManager(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public void Load()
        {
            if (File.Exists(FilePath))
            {
                lock (Entries)
                {
                    Entries.Clear();

                    var data = File.ReadAllText(FilePath);
                    var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim());
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        var parts = line.Split('=');
                        if (parts.Length == 0)
                            continue;

                        var datePart = parts.First();
                        var entryPart = parts.Last();
                        if (DateTime.TryParse(datePart, out DateTime date) && int.TryParse(entryPart, out int entryInt))
                            Entries[new DateTime(date.Year, date.Month, date.Day).Ticks] = (CalendarEntry)entryInt;
                    }
                }
            }
        }

        public void Write()
        {
            lock (Entries)
            {
                File.WriteAllText(FilePath, string.Join(Environment.NewLine, Entries.Select(e => $"{new DateTime(e.Key):dd.MM.yyyy}={(int)e.Value}")));
            }
        }

        public CalendarEntry this[DateTime date]
        {
            get
            {
                if (Entries.TryGetValue(new DateTime(date.Year, date.Month, date.Day).Ticks, out var entry))
                    return entry;
                else
                    return CalendarEntry.None;
            }
            set
            {
                Entries[new DateTime(date.Year, date.Month, date.Day).Ticks] = value;
            }
        }

        public IEnumerator<KeyValuePair<long, CalendarEntry>> GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Entries.GetEnumerator();
        }
    }
}
