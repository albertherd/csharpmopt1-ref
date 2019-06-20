using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class OneTwoEightBytesStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            OneTwoEightByteStruct value = new OneTwoEightByteStruct();
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
            OneTwoEightByteStruct value = new OneTwoEightByteStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }


        private void IncrementByRef(ref OneTwoEightByteStruct toIncrement)
        {
            toIncrement.d0++;
        }

        private OneTwoEightByteStruct IncrementByVal(OneTwoEightByteStruct toIncrement)
        {
            toIncrement.d0++;
            return toIncrement;
        }
    }

    public struct OneTwoEightByteStruct
    {
        public long d0, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15;
    }
}
