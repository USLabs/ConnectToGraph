using ConnectToGraph.DataAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToGraph
{
    class Program
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        static void Main(string[] args)
        {
            //Console.WriteLine(getEpochDate("04/14/2018"));
            //Console.WriteLine(getStringDate(getEpochDate("04/14/2018")));
            //Console.ReadLine();
            GraphAdapter adapter = new GraphAdapter("bolt://54.191.234.201:7687", "neo4j", "umang");
            String query = "match(n) where n.location=~'(?i).*sjsu main campus.*' return (n)";
            Console.WriteLine(adapter.fire(query));
        }

        //Enter data in mm/dd/yyyy format
        public static Int64 getEpochDate(String iDate)
        {
            //string iDate = "05/14/2005";
            DateTime date = Convert.ToDateTime(iDate);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }

        public static string getStringDate(Int64 epochTime)
        {
            return epoch.AddSeconds(epochTime).ToString("MM/dd/yyyy");
        }

        //Query
        /*
            MATCH (node:event)  
            WHERE node.startDate = '' 
            RETURN emp

            MATCH (node:event)  
            WHERE node.startDate < '' AND node.startDate > '' 
            RETURN emp

            MATCH (node:event)  
            WHERE node.eventName = '' 
            RETURN emp

        */
    }
}