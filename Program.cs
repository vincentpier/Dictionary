using System;
using RestSharp;
using System.Collections.Generic;
using WordApp.Models;

namespace SideProjectAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word: ");
            string word = Console.ReadLine();

            RestClient client = new RestClient("https://api.dictionaryapi.dev/api/v2/entries/en/");
            RestRequest request = new RestRequest(word);
            IRestResponse<List<WordEntry>> response = client.Get<List<WordEntry>>(request);

            if (response.IsSuccessful)
            {
                List<WordEntry> wordEntries = response.Data;
                if (wordEntries.Count > 0)
                {
                    WordEntry wordEntry = wordEntries[0];
                    Console.WriteLine($"Definition of '{word}':");
                    foreach (Meaning meaning in wordEntry.Meanings)
                    {
                        Console.WriteLine($"- Part of Speech: {meaning.PartOfSpeech}");
                        foreach (Definition definition in meaning.Definitions)
                        {
                            Console.WriteLine($"  - Definition: {definition.DefinitionText}");
                            
                            
                            if (!string.IsNullOrEmpty(definition.Example))
                            {
                                Console.WriteLine($"    Example: {definition.Example}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No definitions found for the word.");
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.ErrorMessage}");
            }
        }
    }
}