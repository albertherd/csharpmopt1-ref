using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class TwoBytesStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            TwoBytesStruct value = new TwoBytesStruct();
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
            TwoBytesStruct value = new TwoBytesStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }

        private void IncrementByRef(ref TwoBytesStruct toIncrement)
        {
            unchecked
            { 
                toIncrement.i1++;
            }
        }

        private TwoBytesStruct IncrementByVal(TwoBytesStruct toIncrement)
        {
            unchecked
            {
                toIncrement.i1++;
            }
            return toIncrement;
        }
    }

    public struct TwoBytesStruct
    {
        public short i1;
    }
}
