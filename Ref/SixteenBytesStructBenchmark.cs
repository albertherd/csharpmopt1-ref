using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class SixteenBytesStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            SixteenBytesStruct value = new SixteenBytesStruct();
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
            SixteenBytesStruct value = new SixteenBytesStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }


        private void IncrementByRef(ref SixteenBytesStruct toIncrement)
        {
            toIncrement.d0++;
        }

        private SixteenBytesStruct IncrementByVal(SixteenBytesStruct toIncrement)
        {
            toIncrement.d0++;
            return toIncrement;
        }
    }

    public struct SixteenBytesStruct
    {
        public long d0, d1;
    }
}
