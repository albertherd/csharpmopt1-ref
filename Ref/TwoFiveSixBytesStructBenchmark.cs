using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class TwoFiveSixBytesStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            TwoFiveSixBytesStruct value = new TwoFiveSixBytesStruct();
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
            TwoFiveSixBytesStruct value = new TwoFiveSixBytesStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }


        private void IncrementByRef(ref TwoFiveSixBytesStruct toIncrement)
        {
            toIncrement.d0++;
        }

        private TwoFiveSixBytesStruct IncrementByVal(TwoFiveSixBytesStruct toIncrement)
        {
            toIncrement.d0++;
            return toIncrement;
        }
    }

    public struct TwoFiveSixBytesStruct
    {
        public long d0, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15,
                        d16, d17, d18, d19, d20, d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31;

    }
}
