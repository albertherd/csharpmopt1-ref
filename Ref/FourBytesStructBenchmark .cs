using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class FourBytesStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            FourBytesStruct value = new FourBytesStruct();
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
            FourBytesStruct value = new FourBytesStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }

        private void IncrementByRef(ref FourBytesStruct toIncrement)
        {
            unchecked
            {
                toIncrement.i1++;
            }
        }

        private FourBytesStruct IncrementByVal(FourBytesStruct toIncrement)
        {
            unchecked
            {
                toIncrement.i1++;
            }
            return toIncrement;
        }
    }

    public struct FourBytesStruct
    {
        public int i1;
    }
}
