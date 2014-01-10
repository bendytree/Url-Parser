
using NUnit.Framework;

namespace UrlParser.Tests
{
    [TestFixture]
    public class PathTests
    {

        [Test]
        public void Empty_Path_Should_Be_Empty()
        {
            Assert.AreEqual("", new Url("http://example.com").Path, "Path should be empty.");
        }

        [Test]
        public void Paths_Should_Be_Parsed()
        {
            Assert.AreEqual("/", new Url("http://example.com/").Path, "Path should be /.");
            Assert.AreEqual("/a.html", new Url("http://example.com/a.html").Path, "Path should be /a.");
            Assert.AreEqual("/a/b.html", new Url("http://example.com/a/b.html").Path, "Path should be /a/b.html.");
        }

        [Test]
        public void Query_String_Should_Not_Be_Part_Of_Path()
        {
            Assert.AreEqual("", new Url("http://example.com").Path, "Path should be empty.");
            Assert.AreEqual("/", new Url("http://example.com/").Path, "Path should be /.");
            Assert.AreEqual("/a/b.html", new Url("http://example.com/a/b.html").Path, "Path should be /a/b.html.");
        }

    }
}
