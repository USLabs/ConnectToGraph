using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToGraph.DataAdapter
{
    using Neo4j.Driver.V1;

    public class GraphAdapter : IDisposable
    {
        private readonly IDriver _driver;

        public GraphAdapter(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        public String fire(string message)
        {
            var session = _driver.Session();
            var result = session.Run(message);
            String resultStr = "";
            foreach (
                var record in result)
            {
                var node = record["n"].As<INode>();
                foreach (var p in node.Properties)
                {
                    resultStr += p.Key + "\t" + p.Value + "\n";
                }
            }

            return resultStr;
            /*
            var greeting = session.WriteTransaction(tx =>
            {
                var result = tx.Run("CREATE (a:Greeting) " +
                                    "SET a.message = $message " +
                                    "RETURN a.message + ', from node ' + id(a)",
                    new { message });
                return result.Single()[0].As<string>();
            });
            */
            Console.WriteLine("Retrieved");
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}

//https://stackoverflow.com/questions/36692425/how-can-i-access-the-data-in-the-result-of-a-call-to-a-neo4j-database-using-the?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa