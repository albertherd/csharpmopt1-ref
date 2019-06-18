using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [CoreJob]
    [MemoryDiagnoser]
    public class IntByRef
    {
        const int limit = 1000000;

        [Benchmark]
        public void BenchmarkIncrementByRef()
        {
            int value = 0;
            do
            {
                IncrementByRef(ref value);
            }
            while (limit != value);
        }

        [Benchmark]
        public void BenchmarkIncrementByVal()
        {
            int value = 0;
            do
            {
                value = IncrementByVal(value);
            }
            while (limit != value);
        }


        private void IncrementByRef(ref int toIncrement)
        {
            toIncrement = 5;
        }

        private int IncrementByVal(int toIncrement)
        {
            return ++toIncrement;
        }
    }
}
