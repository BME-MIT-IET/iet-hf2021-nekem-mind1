using TechTalk.SpecFlow;
using FluentAssertions;
using RDFSharp.Model;
using System.Collections.Generic;

namespace SpecFlowRDFSharp.Steps
{
    [Binding]
    public sealed class RDFTriplesStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        private readonly List<RDFResource> _resources = new List<RDFResource>();
        private RDFTypedLiteral _typedLiteral;
        private RDFPlainLiteral _plainLiteral;
        private RDFTriple _triple;
        private RDFTriple[] _triples;
        private RDFGraph[] _graphs;

        public RDFTriplesStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("a resource (.*)")]
        public void GivenAResource(string p0)
        {
            _resources.Add(new RDFResource(p0));
        }

        [Given("an integer literal (.*)")]
        public void GivenAnIntegerLiteral(string p0)
        {
            _typedLiteral = new RDFTypedLiteral(p0, RDFModelEnums.RDFDatatypes.XSD_INTEGER);
        }

        [Given("a string literal (.*)")]
        public void GivenAStringLiteral(string p0)
        {
            _plainLiteral = new RDFPlainLiteral(p0, "en-US");
        }

        private int _case = -1;

        [Given("they form a triple")]
        public void GivenTheyFormATriple()
        {
            if (_typedLiteral != null)
            {
                _triple = new RDFTriple(_resources[0], _resources[1], _typedLiteral);
                _case = 0;
            }
            else if (_plainLiteral != null)
            {
                _triple = new RDFTriple(_resources[0], _resources[1], _plainLiteral);
                _case = 1;
            }
            else
            {
                _triple = new RDFTriple(_resources[0], _resources[1], _resources[2]);
                _case = 2;
            }
        }

        [Then(@"the triple will be created")]
        public void ThenTheTripleWillBeCreated()
        {
            _triple.Should().NotBeNull();
            _triple.Subject.Should().Be(_resources[0]);
            _triple.Predicate.Should().Be(_resources[1]);
            switch (_case)
            {
                case 0:
                    _triple.Object.Should().Be(_typedLiteral);
                    break;
                case 1:
                    _triple.Object.Should().Be(_plainLiteral);
                    break;
                case 2:
                    _triple.Object.Should().Be(_resources[2]);
                    break;
            }

        }

        [Given("there are (.*) triples filled with test data")]
        public void GivenThereAreTriplesFilledWithTestData(int p0)
        {
            _triples = new RDFTriple[p0];
            for (var i = 0; i < _triples.Length; i++)
                _triples[i] = new RDFTriple(
                    new RDFResource("http://example.com/subject_" + (i + 1)),
                    new RDFResource("http://example.com/predicate_" + (i + 1)),
                    new RDFResource("http://example.com/object_" + (i + 1))
                );
        }
        
        [Given("there are (.*) graphs")]
        public void GivenThereAreGraphs(int p0)
        {
            _graphs = new RDFGraph[p0];
            for (var i = 0; i < _graphs.Length; i++)
                _graphs[i] = new RDFGraph();
        }
        
        [Given("graph (.*) contains triples (.*) to (.*)")]
        public void GivenGraphContainsTriplesTo(int p0, int p1, int p2)
        {
            for (var i = p1 - 1; i < p2; i++)
                _graphs[p0 - 1].AddTriple(_triples[i]);
        }
        
        [Then("graph (.*) contains triple (.*)")]
        public void ThenGraphContainsTriple(int p0, int p1)
        {
            _graphs[p0 - 1].ContainsTriple(_triples[p1 - 1]).Should().BeTrue();
        }
        
        [Given("there are (.*) triples")]
        public void GivenThereAreTriples(int p0)
        {
            _triples = new RDFTriple[p0];
            for (var i = 0; i < _triples.Length; i++)
                _triples[i] = null;
        }
        
        [Given(@"triple (.*) is \(R:(.*) R:(.*) R:(.*)\)")]
        public void GivenTripleIsRrr(int p0, string p1, string p2, string p3)
        {
            _triples[p0 - 1] = new RDFTriple(
                new RDFResource(p1),
                new RDFResource(p2),
                new RDFResource(p3)
            );
        }

        [Given(@"triple (.*) is \(R:(.*) R:(.*) N:(.*)\)")]
        public void GivenTripleIsRrn(int p0, string p1, string p2, string p3)
        {
            _triples[p0 - 1] = new RDFTriple(
                new RDFResource(p1),
                new RDFResource(p2),
                new RDFTypedLiteral(p3, RDFModelEnums.RDFDatatypes.XSD_INTEGER)
            );
        }

        [Given(@"triple (.*) is \(R:(.*) R:(.*) T:(.*):(.*)\)")]
        public void GivenTripleIsRrt(int p0, string p1, string p2, string p3, string p4)
        {
            _triples[p0 - 1] = new RDFTriple(
                new RDFResource(p1),
                new RDFResource(p2),
                new RDFPlainLiteral(p3, p4)
            );
        }
        
        [When("literal N:(.*) is removed from graph (.*)")]
        public void WhenLiteralNIsRemovedFromGraph(string p0, int p1)
        {
            _graphs[p1 - 1].RemoveTriplesByLiteral(new RDFTypedLiteral(p0, RDFModelEnums.RDFDatatypes.XSD_INTEGER));
        }

        [When("literal T:(.*):(.*) is removed from graph (.*)")]
        public void WhenLiteralTIsRemovedFromGraph(string p0, string p1, int p2)
        {
            _graphs[p2 - 1].RemoveTriplesByLiteral(new RDFPlainLiteral(p0, p1));
        }
        
        [Then("graph (.*) size is (.*)")]
        public void ThenGraphSizeIs(int p0, int p1)
        {
            _graphs[p0 - 1].TriplesCount.Should().Be(p1);
        }
        
        [Then("graph (.*) does not contain triple (.*)")]
        public void ThenGraphDoesNotContainTriple(int p0, int p1)
        {
            _graphs[p0 - 1].ContainsTriple(_triples[p1 - 1]).Should().BeFalse();
        }

        [When(@"graph (.*) is cleared")]
        public void WhenGraphIsCleared(int p0)
        {
            _graphs[p0 - 1].ClearTriples();
        }

        [When("graph (.*) is the result of selecting subject R:(.*) from graph (.*)")]
        public void WhenGraphIsTheResultOfSelectingSubjectRFromGraph(int p0, string p1, int p2)
        {
            _graphs[p0-1] = _graphs[p2 - 1].SelectTriplesBySubject(new RDFResource(p1));
        }

        [When("graph (.*) is the result of selecting predicate R:(.*) from graph (.*)")]
        public void WhenGraphIsTheResultOfSelectingPredicateRFromGraph(int p0, string p1, int p2)
        {
            _graphs[p0-1] = _graphs[p2 - 1].SelectTriplesByPredicate(new RDFResource(p1));
        }

        [When("graph (.*) is the result of selecting object R:(.*) from graph (.*)")]
        public void WhenGraphIsTheResultOfSelectingObjectRFromGraph(int p0, string p1, int p2)
        {
            _graphs[p0-1] = _graphs[p2 - 1].SelectTriplesByObject(new RDFResource(p1));
        }

        [When(@"graph (.*) is the difference of graph (.*) and graph (.*)")]
        public void WhenGraphIsTheDifferenceOfGraphAndGraph(int p0, int p1, int p2)
        {
            _graphs[p0 - 1] = _graphs[p1 - 1].DifferenceWith(_graphs[p2 - 1]);
        }
    }
}