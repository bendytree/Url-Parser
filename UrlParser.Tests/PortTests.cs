
using NUnit.Framework;

namespace UrlParser.Tests
{
    [TestFixture]
    public class PortTests
    {

        [Test]
        public void Explicit_Port_Is_Parsed()
        {
            Assert.AreEqual(8080, new Url("http://example.com:8080/a/b.html").Port, "Port should be 8080.");
            Assert.AreEqual(123, new Url("tcp://example.com:123").Port, "Port should be 123.");
        }

        [Test]
        public void Implicit_Port_Is_Set_To_Protocol_Default()
        {
            Assert.AreEqual(80, new Url("http://example.com").Port, "Port should be 80.");
            Assert.AreEqual(443, new Url("https://example.com").Port, "Port should be 443.");
            Assert.AreEqual(22, new Url("ssh://example.com").Port, "Port should be 22.");
        }

        [Test]
        public void Implicit_Port_Is_Case_Insensitive()
        {
            Assert.AreEqual(80, new Url("hTtP://example.com").Port, "Port should be 80.");
        }

        [Test]
        public void Unknown_Protocols_Default_To_Port_To_Zero()
        {
            Assert.AreEqual(0, new Url("xyz://example.com").Port, "Port should be 0.");
        }

    }
}
