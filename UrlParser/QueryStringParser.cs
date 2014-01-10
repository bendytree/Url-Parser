using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UrlParser
{
    internal class QueryStringParser
    {
        public static Dictionary<string, string> Parse(string queryString)
        {
            //prepare an empty query string collection
            var query = new Dictionary<string, string>();

            //split the string by `&`
            var queryStringSets = queryString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            //assign each set to the query collection
            foreach (var set in queryStringSets)
            {
                //look for the equals key/value delimiter
                var equalsIndex = set.IndexOf("=");

                //if no equals is found, the entire set is the key
                if (equalsIndex == -1)
                {
                    query[HttpUtility.UrlDecode(set)] = String.Empty;
                    continue;
                }

                //add the key/value pair to the collection
                var key = HttpUtility.UrlDecode(set.Substring(0, equalsIndex));
                var value = HttpUtility.UrlDecode(set.Substring(equalsIndex + 1));
                query[key] = value;
            }

            //return the resulting collection
            return query;
        }
    }
}
