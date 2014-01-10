
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UrlParser
{
    public class Url
    {
        private static readonly Regex urlRegex = new Regex(@"^(?<protocol>[^:]*)://(?<host>[^:/?]*)(:(?<port>\d*))?(?<path>[^?]*)([?](?<query>.*))?$");

        public string Protocol { get; private set; }
        public string Host { get; private set; }
        public int Port { get; private set; }
        public string Path { get; set; }
        public Dictionary<string, string> Query { get; private set; }

        public Url(string url)
        {
            //parse the url with a regular expression
            var matches = urlRegex.Match(url);

            //assign properties from matched values
            Protocol = matches.Groups["protocol"].Value;
            Host = matches.Groups["host"].Value;
            Port = PortParser.ParsePortOrGetDefault(matches.Groups["port"].Value, Protocol);
            Path = matches.Groups["path"].Value;
            Query = QueryStringParser.Parse(matches.Groups["query"].Value);
        }
    }
}
