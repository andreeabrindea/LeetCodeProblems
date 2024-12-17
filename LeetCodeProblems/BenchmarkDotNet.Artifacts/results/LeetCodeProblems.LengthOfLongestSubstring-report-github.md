```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4 (23E214) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 7.0.310
  [Host]     : .NET 7.0.13 (7.0.1323.51816), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 7.0.13 (7.0.1323.51816), Arm64 RyuJIT AdvSIMD


```
| Method                           | Mean       | Error     | StdDev    |
|--------------------------------- |-----------:|----------:|----------:|
| FindLengthOfLongestSubstring     |   113.3 ns |   0.80 ns |   0.67 ns |
| FindLengthOfLongestSubstringLINQ | 7,702.7 ns | 141.29 ns | 251.14 ns |
