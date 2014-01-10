
using NUnit.Framework;

namespace UrlParser.Tests
{
    [TestFixture]
    public class QueryStringTests
    {

        [Test]
        public void Missing_Query_String_Results_In_Empty_Dictionary()
        {
            Assert.AreEqual(0, new Url("http://example.com").Query.Count, "Query should be empty.");
        }

        [Test]
        public void Query_String_Populates_Dictionary()
        {
            var query = new Url("http://example.com?a=b&c=d").Query;
            Assert.AreEqual(2, query.Count, "Query should have 2 entries.");
            Assert.AreEqual("b", query["a"], "Query should have a=b.");
            Assert.AreEqual("d", query["c"], "Query should have c=d.");
        }

        [Test]
        public void Query_String_Key_With_No_Value_Has_Empty_String()
        {
            Assert.AreEqual("", new Url("http://example.com?a").Query["a"], "Value for key a should be blank.");
            Assert.AreEqual("", new Url("http://example.com?a=").Query["a"], "Value for key a should be blank.");
        }

        [Test]
        public void Query_String_Decodes_Keys_And_Values()
        {
            Assert.AreEqual("#1", new Url("http://example.com?%5Bkd%5D=%231").Query["[kd]"], "Value for key [kd] should be #1.");
        }

        [Test]
        public void Query_String_Decodes_Key_With_Blank_Value()
        {
            Assert.AreEqual("", new Url("http://example.com?%5Bkd%5D").Query["[kd]"], "Value for key [kd] should be blank.");
            Assert.AreEqual("", new Url("http://example.com?%5Bkd%5D=").Query["[kd]"], "Value for key [kd] should be blank.");
        }

    }
}
