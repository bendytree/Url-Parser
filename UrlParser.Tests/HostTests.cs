
using NUnit.Framework;

namespace UrlParser.Tests
{
    [TestFixture]
    public class HostTests
    {

        [Test]
        public void Various_Hosts_Are_Parsed()
        {
            Assert.AreEqual("example.com", new Url("http://example.com").Host, "Host should be example.com.");
            Assert.AreEqual("thunder.nba.com", new Url("http://thunder.nba.com").Host, "Host should be thunder.nba.com.");
            Assert.AreEqual("127.0.0.1", new Url("http://127.0.0.1").Host, "Host should be 127.0.0.1.");
            Assert.AreEqual("intranet", new Url("http://intranet").Host, "Host should be intranet.");
        }

        [Test]
        public void Host_Should_Stop_At_Slash()
        {
            Assert.AreEqual("example.com", new Url("http://example.com/a/b.html").Host, "Host should stop at forward slash.");
        }

        [Test]
        public void Host_Should_Stop_At_Colon()
        {
            Assert.AreEqual("example.com", new Url("http://example.com:8080/a/b.html").Host, "Host should stop at colon.");
        }

        [Test]
        public void Host_Should_Stop_At_Query_String()
        {
            Assert.AreEqual("example.com", new Url("http://example.com?a=b").Host, "Host should stop at query string.");
        }

    }
}
