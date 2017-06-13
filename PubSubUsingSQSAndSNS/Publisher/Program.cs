using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        public static Random Random = new Random();
        public static List<string> Titles { get; set; }

        static Program()
        {
            Titles = new List<string>
            {
                "ABC Corp 2016 Documentation",
                "ABC Corp 2015 Documentation",
                "ABC Corp 2014 Documentation",
                "Betamax Mercantile Corp 15",
                "Neil Gold Standard FY15",
                "Gold Standard Inc FY 14",
                "Cogswell Corp Global Doc FY16",
                "Cogswell Corp Global Doc FY15",
                "Cogswell Corp Global Doc FY14",
                "Betamax Mercantile Corp 14",
                "Betamax Mercantile Corp 16",
                "Gold Standard Inc FY 15",
                "Neil Gold Standard FY 16"
            };
        }

        static void Main(string[] args)
        {   
            TopicPublisher.Run();
        }

        public static string GetRandomProjects()
        {
            return Titles[Random.Next(0, Titles.Count - 1)];
        }
    }
}
