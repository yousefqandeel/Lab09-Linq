using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab09_Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("data.json"))
            {
                Console.WriteLine("data.json does not exist");
                return;
            }

            var jsonFile = JsonConvert.DeserializeObject<Root>(File.ReadAllText("data.json"));

            List<Feature> features = jsonFile.Features;

            var neighborhoods = from neighbor
                                in features
                                select neighbor.Properties.Neighborhood;

            var neighborhoodsFiltered = from neighbor
                                           in neighborhoods
                                        where !(neighbor.Equals(""))
                                        select neighbor;

            var neighborhoodsDistinct = neighborhoods
                .Select(n => n)
                .Distinct()
                .Where(n => !(n.Equals("")));

            var allNeighborhoods = neighborhoods
                .Select(n => n)
                .Distinct()
                .Where(n => !(n.Equals("")));

            Console.WriteLine($"Final Total: {neighborhoods.Count()} neighborhoods (All)");
            Console.WriteLine($"Final Total: {neighborhoodsFiltered.Count()} neighborhoods (With Names)");
            Console.WriteLine($"Final Total: {neighborhoodsDistinct.Count()} neighborhoods (Distinct)");

            Console.WriteLine("\n=================\n");

            string input;
            int inn = -1;

            do
            {
                Console.WriteLine("Select Option");
                Console.WriteLine("1. Display All Neighborhoods");
                Console.WriteLine("2. Display All Filtered Neighborhoods");
                Console.WriteLine("3. Display All Distinct Neighborhoods");
                Console.WriteLine("-1. Exit");
                input = Console.ReadLine();

                try
                {
                    inn = Convert.ToInt32(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                switch (inn)
                {
                    case 1:
                        foreach (var e in neighborhoods)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 2:
                        foreach (var e in neighborhoodsFiltered)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 3:
                        foreach (var neighborhood in neighborhoodsDistinct)
                        {
                            Console.WriteLine(neighborhood);
                        }
                        break;

                    case -1:
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("\n=================\n");
            } while (inn != -1);
        }
    }
}
