using System;
using RestSharp;

namespace SidePrjoectAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter a word: ");
            string word = Console.ReadLine();

            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://api.dictionaryapi.dev/api/v2/entries/en/{word}");
            RestResponse response = client.Get(request);
            Console.WriteLine(response.Content);
        }
    }
}
