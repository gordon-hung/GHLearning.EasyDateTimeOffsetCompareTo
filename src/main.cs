using System;


var expiry = DateTimeOffset.Parse("2025-11-28 12:00:00 +08:00");

Console.WriteLine($"Expiry Time: {expiry}");


// 2. 比對 2025-11-28 11:59:59 +08:00
// → 差 1 秒就到期（還沒到）
DateTimeOffset time1 = DateTimeOffset.Parse("2025-11-28 11:59:59+08:00");
int result1 = time1.CompareTo(expiry);
Console.WriteLine($"Compare Time1: {time1}");
Console.WriteLine($"Compare time1 < expiry: {result1}  (預期 -1)");


// 3. 比對 2025-11-28 12:00:00 +08:00
// → 剛好到期時間（完全相同）
DateTimeOffset time2 = DateTimeOffset.Parse("2025-11-28 12:00:00+08:00");
int result2 = time2.CompareTo(expiry);
Console.WriteLine($"Compare Time2: {time2}");
Console.WriteLine($"Compare time2 = expiry: {result2}  (預期 0)");


// 4. 比對 2025-11-28 12:00:59 +08:00
// → 超過到期 59 秒（已經過期）
DateTimeOffset time3 = DateTimeOffset.Parse("2025-11-28 12:00:59+08:00");
int result3 = time3.CompareTo(expiry);
Console.WriteLine($"Compare Time3: {time3}");
Console.WriteLine($"Compare time3 > expiry: {result3}  (預期 1)");


Console.WriteLine("\n=== 跨時區比較 ===");


// 5. 比對 2025-11-28 04:00:00 +00:00
// → 換算成 UTC 剛好跟到期時間一樣
DateTimeOffset time4 = DateTimeOffset.Parse("2025-11-28 04:00:00+00:00");
Console.WriteLine($"Compare Time4: {time4}");
Console.WriteLine($"Compare time4 vs expiry: {time4.CompareTo(expiry)}  (預期 0)");


// 6. 比對 2025-11-28 21:00:00 +09:00
// → 換算 UTC 後比到期晚 1 小時（已經過期）
DateTimeOffset time5 = DateTimeOffset.Parse("2025-11-28 21:00:00+09:00");
Console.WriteLine($"Compare Time5: {time5}");
Console.WriteLine($"Compare time5 vs expiry: {time5.CompareTo(expiry)}  (預期 1)");


// 7. 比對 2025-11-28 00:00:00 -05:00
// → 換算 UTC 後比 expiry 晚一點點（已過期）
DateTimeOffset time6 = DateTimeOffset.Parse("2025-11-28 00:00:00-05:00");
Console.WriteLine($"Compare Time6: {time6}");
Console.WriteLine($"Compare time6 vs expiry: {time6.CompareTo(expiry)}  (預期 1)");


// 8. 比對 2025-11-28 03:00:00 +00:00
// → 換算成 UTC 後比到期時間早一小時（還沒到）
DateTimeOffset time7 = DateTimeOffset.Parse("2025-11-28 03:00:00+00:00");
Console.WriteLine($"Compare Time7: {time7}");
Console.WriteLine($"Compare time7 vs expiry: {time7.CompareTo(expiry)}  (預期 -1)");


// CompareTo 說明
Console.WriteLine("\nCompareTo 說明：");
Console.WriteLine("time.CompareTo(expiry) 回傳值：");
Console.WriteLine(" < 0 表示 time < expiry（還沒到）");
Console.WriteLine(" = 0 表示 time == expiry（剛好到期）");
Console.WriteLine(" > 0 表示 time > expiry（已經過期）");