using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class OneByteStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            OneByteStruct value = new OneByteStruct();
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
            OneByteStruct value = new OneByteStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }

        private void IncrementByRef(ref OneByteStruct toIncrement)
        {
            unchecked
            {
                toIncrement.i1++;
            }
        }

        private OneByteStruct IncrementByVal(OneByteStruct toIncrement)
        {
            unchecked
            {
                toIncrement.i1++;
            }
            return toIncrement;
        }
    }

    public struct OneByteStruct
    {
        public byte i1;
    }
}
