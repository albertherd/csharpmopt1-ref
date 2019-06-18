using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ref
{
    [MemoryDiagnoser]
    [CoreJob]
    public class SmallStructByRef
    {
        const int limit = 1000000;

        [Benchmark]
        public void BenchmarkIncrementByRef()
        {
            SmallStruct value = new SmallStruct();
            do
            {
                IncrementByRef(ref value);
            }
            while (limit != value.i1);
        }

        [Benchmark]
        public void BenchmarkIncrementByVal()
        {
            SmallStruct value = new SmallStruct();
            do
            {
                value = IncrementByVal(value);
            }
            while (limit != value.i1);
        }


        private void IncrementByRef(ref SmallStruct toIncrement)
        {
            toIncrement.i1 += 1;
            toIncrement.i2 += 1;
        }

        private SmallStruct IncrementByVal(SmallStruct toIncrement)
        {
            toIncrement.i1 += 1;
            toIncrement.i2 += 1;
            return toIncrement;
        }
    }

    public struct SmallStruct
    {
        public int i1, i2;
    }
}
