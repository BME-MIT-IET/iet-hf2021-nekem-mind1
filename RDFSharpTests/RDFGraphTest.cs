using RDFSharp.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace RDFSharpTests
{
    public class RDFGraphTest
    {
        private List<RDFTriple> defaultTriples = TestModelObject.triples.GetRange(0, 2);
        [Fact]
        public void AddTripleTest()
        {
            var testGraph = new RDFGraph(defaultTriples);
            var old = new List<RDFTriple>(defaultTriples);
            var newTriple = TestModelObject.triples[2];
            old.Add(newTriple);
            testGraph.AddTriple(newTriple);
            var newList = new List<RDFTriple>();

            foreach (var triple in testGraph)
            {
                newList.Add(triple);
            }

            Assert.Equal(old, newList);
        }

        [Fact]
        public void RemoveTripleTest()
        {
            var testGraph = new RDFGraph(defaultTriples);
            var old = new List<RDFTriple>(defaultTriples);
            old.Remove(defaultTriples[0]);
            testGraph.RemoveTriple(defaultTriples[0]);
            var newList = new List<RDFTriple>();

            foreach (var triple in testGraph)
            {
                newList.Add(triple);
            }

            Assert.Equal(old, newList);
        }

        [Fact]
        public void RemoveTripleBySubjectTest()
        {
            var testGraph = new RDFGraph(defaultTriples);
            var old = new List<RDFTriple>(defaultTriples);
            old.Remove(defaultTriples[0]);
            testGraph.RemoveTriplesBySubject(TestModelObject.subRes[0]);
            var newList = new List<RDFTriple>();

            foreach (var triple in testGraph)
            {
                newList.Add(triple);
            }

            Assert.Equal(old, newList);
        }

        [Fact]
        public void RemoveTripleByPredicateTest()
        {
            var testGraph = new RDFGraph(defaultTriples);
            var old = new List<RDFTriple>(defaultTriples);
            old.Remove(defaultTriples[0]);
            testGraph.RemoveTriplesByPredicate(TestModelObject.predRes[0]);
            var newList = new List<RDFTriple>();

            foreach (var triple in testGraph)
            {
                newList.Add(triple);
            }

            Assert.Equal(old, newList);
        }

        [Fact]
        public void ClearTriplesTest()
        {
            var testGraph = new RDFGraph(defaultTriples);
            var old = new List<RDFTriple>(defaultTriples);
            old.Clear();
            testGraph.ClearTriples();
            var newList = new List<RDFTriple>();

            Assert.Equal(old, newList);
        }

        [Fact]
        public void SelectTriplesBySubjectTest()
        {
            var testGraph = new RDFGraph(defaultTriples);
            var old = new List<RDFTriple>() { defaultTriples[0] };
            var res = testGraph.SelectTriplesBySubject(TestModelObject.subRes[0]);
            var newList = new List<RDFTriple>();

            foreach (var triple in res)
            {
                newList.Add(triple);
            }

            Assert.Equal(old, newList);
        }

        [Fact]
        public void ContainsTest()
        {
            var testGraph = new RDFGraph(defaultTriples);
            var old = new List<RDFTriple>(defaultTriples);
            var res = testGraph.ContainsTriple(defaultTriples[0]);

            Assert.True(res);
        }

    }
}
