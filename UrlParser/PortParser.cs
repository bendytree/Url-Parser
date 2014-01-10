
using System;
using System.Collections.Generic;

namespace UrlParser
{
    public class PortParser
    {
        //more default ports listed at: http://en.wikipedia.org/wiki/Port_(computer_networking)
        private static readonly Dictionary<string, int> protocols = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"ssh", 22},
                {"http", 80},
                {"https", 443}
            }; 

        private static int? GetPortForProtocol(string protocol)
        {
            //look for a default port according to the protocol
            if (protocols.ContainsKey(protocol))
                return protocols[protocol];

            //no default found, so return null
            return null;
        }

        public static int ParsePortOrGetDefault(string portString, string protocol)
        {
            //try to parse the port string
            int port;
            if (int.TryParse(portString, out port))
            {
                return port;
            }

            //unable to parse, so look for a default
            return GetPortForProtocol(protocol) ?? 0;
        }
    }
}
