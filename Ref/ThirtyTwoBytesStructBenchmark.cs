using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class ThirtyTwoBytesStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            ThirtyTwoBytesStruct value = new ThirtyTwoBytesStruct();
            int counter = 0;
            do
            {
                IncrementByRef(ref value);
                counter++;
            }
            while (limit != counter);
        }

        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByVal(int limit)
        {
            ThirtyTwoBytesStruct value = new ThirtyTwoBytesStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }


        private void IncrementByRef(ref ThirtyTwoBytesStruct toIncrement)
        {
            toIncrement.d0++;
        }

        private ThirtyTwoBytesStruct IncrementByVal(ThirtyTwoBytesStruct toIncrement)
        {
            toIncrement.d0++;
            return toIncrement;
        }
    }

    public struct ThirtyTwoBytesStruct
    {
        public long d0, d1, d2, d3;
    }
}
