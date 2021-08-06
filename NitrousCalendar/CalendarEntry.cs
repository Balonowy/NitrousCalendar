using System;
using System.Drawing;

namespace NitrousCalendar
{
    [Flags]
    public enum CalendarEntry
    {
        None,
        B12 = 1,
        N2O = 2,
    }

    public static class CalendarEntryExtensions
    {
        public static Color GetForeColor(this CalendarEntry entry)
        {
            return entry switch
            {
                CalendarEntry.None => Color.Black,
                CalendarEntry.B12 => Color.Black,
                CalendarEntry.N2O => Color.Black,
                (CalendarEntry.N2O | CalendarEntry.B12) => Color.Black,
                _ => throw new ArgumentOutOfRangeException(nameof(entry)),
            };
        }

        public static Color GetBackColor(this CalendarEntry entry)
        {
            return entry switch
            {
                CalendarEntry.None => Color.White,
                CalendarEntry.B12 => Color.Green,
                CalendarEntry.N2O => Color.Orange,
                (CalendarEntry.N2O | CalendarEntry.B12) => Color.Yellow,
                _ => throw new ArgumentOutOfRangeException(nameof(entry)),
            };
        }
    }
}
