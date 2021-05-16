using System;
using BenchmarkDotNet.Running;

namespace NonFunctionalTests {
    class Program {
        static void Main(string[] args) {
            BenchmarkRunner.Run<RDFSharpBenchmark>();
        }
    }
}
