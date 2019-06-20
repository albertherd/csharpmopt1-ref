using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ref
{
    [CoreJob]
    public class EightBytesStructBenchmark
    {
        [Benchmark]
        [Arguments(1000000)]
        public void BenchmarkIncrementByRef(int limit)
        {
            EightBytesStruct value = new EightBytesStruct();
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
            EightBytesStruct value = new EightBytesStruct();
            int counter = 0;
            do
            {
                value = IncrementByVal(value);
                counter++;
            }
            while (limit != counter);
        }

        private void IncrementByRef(ref EightBytesStruct toIncrement)
        {
            toIncrement.i1++;            
        }

        private EightBytesStruct IncrementByVal(EightBytesStruct toIncrement)
        {
            toIncrement.i1++;
            return toIncrement;
        }
    }

    public struct EightBytesStruct
    {
        public long i1;
    }
}
