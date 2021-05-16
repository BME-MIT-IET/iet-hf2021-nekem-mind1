using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RDFSharp;
using RDFSharp.Model;
using RDFSharp.Query;

namespace NonFunctionalTests {
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Default)]
    [RankColumn]
    public class RDFSharpBenchmark {

    
        
        [Benchmark]
        public void CreateRDFVariable() {
            RDFVariable actor = new RDFVariable("actor");
        }

        [Benchmark]
        public void CreateRDFResource() {
            RDFResource actor = new RDFResource("http://www.wikidata.org/entity/Q12418");
        }
    }
}
