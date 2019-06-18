using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ref
{
    [MemoryDiagnoser]
    [CoreJob]
    public class DoubleByRef
    {
        const double limit = 1000000;

        [Benchmark]
        public void BenchmarkIncrementByRef()
        {
            double value = 0;
            do
            {
                IncrementByRef(ref value);
            }
            while (limit != value);
        }

        [Benchmark]
        public void BenchmarkIncrementByVal()
        {
            double value = 0;
            do
            {
                value = IncrementByVal(value);
            }
            while (limit != value);
        }


        private void IncrementByRef(ref double toIncrement)
        {
            toIncrement = 5;
        }

        private double IncrementByVal(double toIncrement)
        {
            return ++toIncrement;
        }
    }
}
