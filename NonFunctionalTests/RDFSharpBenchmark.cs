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

        RDFResource monaLisa;
        RDFResource creator;
        RDFResource leonardoDaVinci;
        RDFGraph museumGraph;
        RDFTriple monaLisaCreator;


        public RDFSharpBenchmark() {
            this.monaLisa = new RDFResource("http://www.wikidata.org/entity/Q12418");
            this.creator = new RDFResource("http://www.wikidata.org/entity/Q12418");
            this.leonardoDaVinci = new RDFResource("http://www.wikidata.org/entity/Q12418");
            FileStream fs = File.OpenRead(@"..\..\..\..\..\..\..\\TestData\szepmuveszeti.n3");
            this.museumGraph = RDFGraph.FromStream(RDFModelEnums.RDFFormats.Turtle, fs);
            this.monaLisaCreator = new RDFTriple(this.monaLisa, this.creator, this.leonardoDaVinci);
        }

        [Benchmark]
        public void CreateRDFVariable() {
            RDFVariable actor = new RDFVariable("actor");
        }

        [Benchmark]
        public void CreateRDFResource() {
            RDFResource monaLisa = new RDFResource("http://www.wikidata.org/entity/Q12418");
        }

        [Benchmark]
        public void CreateRDFTriple() {
            RDFTriple monaLisaCreator = new RDFTriple(this.monaLisa, this.creator, this.leonardoDaVinci);
        }

        [Benchmark]
        public void AddRDFTriple() {
            this.museumGraph.AddTriple(monaLisaCreator);
        }
    }
}
