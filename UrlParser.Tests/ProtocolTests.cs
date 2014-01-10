
using NUnit.Framework;

namespace UrlParser.Tests
{
    [TestFixture]
    public class ProtocolTests
    {

        [Test]
        public void Various_Protocols_Are_Parsed()
        {
            Assert.AreEqual("http", new Url("http://example.com").Protocol, "Protocol should be http.");
            Assert.AreEqual("https", new Url("https://example.com").Protocol, "Protocol should be https.");
            Assert.AreEqual("tcp", new Url("tcp://example.com").Protocol, "Protocol should be tcp.");
            Assert.AreEqual("ws", new Url("ws://example.com").Protocol, "Protocol should be ws.");
        }

        [Test]
        public void Protocols_Retain_Their_Casing()
        {
            Assert.AreEqual("hTtP", new Url("hTtP://example.com").Protocol, "Protocol should retain their casing.");
        }

    }
}
