using RDFSharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace RDFSharpTests
{
    public class RDFResourceTest
    {
        private string uri = "https://en.wikipedia.org/wiki/Isaac_Newton";

        [Fact]
        public void RDFResourceCtorWithParamTest()
        {
            var resource = new RDFResource(uri);
            var res = resource.ToString();

            Assert.Equal(uri, res);
        }
        
        [Fact]
        public void RDFResourceException()
        {
            Action act = () => new RDFResource("invalid.uri.string");
            Assert.Throws<RDFModelException>(act);
        }
    }
}

