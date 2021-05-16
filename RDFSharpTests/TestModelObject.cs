using System;
using System.Collections.Generic;
using System.Text;
using RDFSharp.Model;

namespace RDFSharpTests
{
    static class TestModelObject
    {        
        public static List<RDFResource> subRes = new List<RDFResource>()
        {
            new RDFResource("https://en.wikipedia.org/wiki/Isaac_Newton"),
            new RDFResource("https://en.wikipedia.org/wiki/Viktor_Orb%C3%A1n"),
            new RDFResource("https://en.wikipedia.org/wiki/Antonio_Vivaldi")
        };
        public static List<RDFResource> predRes = new List<RDFResource>()
        {
            new RDFResource("http://xmlns.com/foaf/0.1/age"),
            new RDFResource("http://xmlns.com/foaf/0.1/name"),
            new RDFResource("http://xmlns.com/foaf/0.1/birthday")
        };
        public static List<RDFLiteral> obj = new List<RDFLiteral>()
        {
            new RDFTypedLiteral("84", RDFModelEnums.RDFDatatypes.XSD_INTEGER),
            new RDFPlainLiteral("Isaac newton", "en-US"),
            new RDFPlainLiteral("03-04")
        };
        public static List<RDFTriple> triples = new List<RDFTriple>()
        {
            new RDFTriple(subRes[0], predRes[0], obj[0]),
            new RDFTriple(subRes[1], predRes[1], obj[1]),
            new RDFTriple(subRes[2], predRes[2], obj[2])
        };
    }
}
