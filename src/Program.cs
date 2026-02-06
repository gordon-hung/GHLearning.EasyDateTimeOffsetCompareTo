using System;
using System.Globalization;


var expiry = ParseOffset("2025-11-28T12:00:00+08:00");

Console.WriteLine($"Expiry Time: {expiry}");
Console.WriteLine();

Compare("Time1", "2025-11-28T11:59:59+08:00", expiry, -1);
Compare("Time2", "2025-11-28T12:00:00+08:00", expiry, 0);
Compare("Time3", "2025-11-28T12:00:59+08:00", expiry, 1);

Console.WriteLine("\n=== 跨時區比較 ===");

Compare("Time4", "2025-11-28T04:00:00+00:00", expiry, 0);
Compare("Time5", "2025-11-28T21:00:00+09:00", expiry, 1);
Compare("Time6", "2025-11-28T00:00:00-05:00", expiry, 1);
Compare("Time7", "2025-11-28T03:00:00+00:00", expiry, -1);

ShowCompareExplanation();

static DateTimeOffset ParseOffset(string value)
{
    return DateTimeOffset.Parse(
        value,
        CultureInfo.InvariantCulture,
        DateTimeStyles.AssumeUniversal);
}

static void Compare(
    string label,
    string timeString,
    DateTimeOffset expiry,
    int expectedSign)
{
    var time = ParseOffset(timeString);

    int result = Math.Sign(time.CompareTo(expiry));

    Console.WriteLine($"{label}: {time}");
    Console.WriteLine($"Result: {result} (Expected: {expectedSign})");
    Console.WriteLine();
}

static void ShowCompareExplanation()
{
    Console.WriteLine("CompareTo 說明：");
    Console.WriteLine("< 0 表示尚未到期");
    Console.WriteLine("= 0 表示剛好到期");
    Console.WriteLine("> 0 表示已過期");
}