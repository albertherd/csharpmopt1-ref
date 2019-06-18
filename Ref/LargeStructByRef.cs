using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [CoreJob]
    [MemoryDiagnoser]
    public class LargeStructByRef
    {
        const int limit = 1000000;

        [Benchmark]
        public void BenchmarkIncrementByRef()
        {
            LargeStruct value = new LargeStruct();
            do
            {
                IncrementByRef(ref value);
            }
            while (limit != value.d0);
        }

        [Benchmark]
        public void BenchmarkIncrementByVal()
        {
            LargeStruct value = new LargeStruct();
            do
            {
                value = IncrementByVal(value);
            }
            while (limit != value.d0);
        }


        private void IncrementByRef(ref LargeStruct toIncrement)
        {
            toIncrement.d0 += 1;
            toIncrement.d1 += 1;
            toIncrement.d2 += 1;
            toIncrement.d3 += 1;
            toIncrement.d4 += 1;
            toIncrement.d5 += 1;
            toIncrement.d6 += 1;
            toIncrement.d7 += 1;
            toIncrement.d8 += 1;
            toIncrement.d9 += 1;
        }

        private LargeStruct IncrementByVal(LargeStruct toIncrement)
        {
            toIncrement.d0 += 1;
            toIncrement.d1 += 1;
            toIncrement.d2 += 1;
            toIncrement.d3 += 1;
            toIncrement.d4 += 1;
            toIncrement.d5 += 1;
            toIncrement.d6 += 1;
            toIncrement.d7 += 1;
            toIncrement.d8 += 1;
            toIncrement.d9 += 1;
            return toIncrement;
        }
    }

    public struct LargeStruct
    {
        public double d0;
        public double d1;
        public double d2;
        public double d3;
        public double d4;
        public double d5;
        public double d6;
        public double d7;
        public double d8;
        public double d9;
    }
}
