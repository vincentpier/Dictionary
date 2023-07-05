using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace SideProjectAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word: ");
            string word = Console.ReadLine();

            var client = new RestClient("https://api.dictionaryapi.dev/api/v2/entries/en/");
            var request = new RestRequest(word);
            IRestResponse<List<Root>> response = client.Get<List<Root>>(request);

            List<Root> roots = response.Data;
            

            foreach (Root root in roots)
            {
                Console.WriteLine($"Word: {root.Word}");

                foreach (Meaning meaning in root.Meanings)
                {
                    Console.WriteLine($"Part of speech: {meaning.PartOfSpeech}");


                    foreach (Definition definition in meaning.Definitions)
                    {
                        
                     Console.WriteLine($"definition: {definition.definition}");
                     Console.WriteLine($"example: {definition.Example}");
                    }

            }
            }
        }
    }
}