using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class SixtyFourByteStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            SixtyFourByteStruct value = new SixtyFourByteStruct();
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
            SixtyFourByteStruct value = new SixtyFourByteStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }


        private void IncrementByRef(ref SixtyFourByteStruct toIncrement)
        {
            toIncrement.d0++;
        }

        private SixtyFourByteStruct IncrementByVal(SixtyFourByteStruct toIncrement)
        {
            toIncrement.d0++;
            return toIncrement;
        }
    }

    public struct SixtyFourByteStruct
    {
        public long d0, d1, d2, d3, d4, d5, d6, d7;
    }
}
