using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Threading;

namespace Ref
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<OneByteStructBenchmark>();
            BenchmarkRunner.Run<TwoBytesStructBenchmark>();
            BenchmarkRunner.Run<FourBytesStructBenchmark>();
            BenchmarkRunner.Run<EightBytesStructBenchmark>();
            BenchmarkRunner.Run<SixteenBytesStructBenchmark>();
            BenchmarkRunner.Run<ThirtyTwoBytesStructBenchmark>();
            BenchmarkRunner.Run<SixtyFourByteStructBenchmark>();
            BenchmarkRunner.Run<OneTwoEightBytesStructBenchmark>();
            BenchmarkRunner.Run<TwoFiveSixBytesStructBenchmark>();
            BenchmarkRunner.Run<FiveOneTwoByteStructBenchmark>();
            BenchmarkRunner.Run<OneNoughtTwoFourByteStructBenchmark>();
        }
    }
}
