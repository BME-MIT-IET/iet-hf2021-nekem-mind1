using RDFSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RDFSharpTests
{
    public class RDFTripleTest
    {
        [Fact]
        public void RDFTripleEmptyTest()
        {
            Action act = () => new RDFTriple(TestModelObject.subRes[0], new RDFResource(), TestModelObject.obj[0]);
            Assert.Throws<RDFModelException>(act);
        }
    }
}
