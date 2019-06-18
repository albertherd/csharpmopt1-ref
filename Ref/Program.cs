using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Threading;

namespace Ref
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
#if DEBUG
            new IntByRef().BenchmarkIncrementByRef();
            new DoubleByRef().BenchmarkIncrementByRef();
            new SmallStructByRef().BenchmarkIncrementByRef();
            new LargeStructByRef().BenchmarkIncrementByRef();
#else
            BenchmarkRunner.Run<SmallStructByRef>();
            //BenchmarkRunner.Run<LargeStructByRef>();
#endif
        }
    }
}
