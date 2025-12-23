using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DSA_Assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking the file and processing...");
            string fileName = "mobydick.txt";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found! Please check the path.");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);
            LinkList linkList = new LinkList();

            for (int i = 0; i < lines.Length; i++)
            {
                string clean = Regex.Replace(lines[i].ToLower(), @"[^a-z0-9\s]", "");
                string[] words = clean.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < words.Length; j++)
                {
                    linkList.AddWord(words[j], i + 1);
                }
            }

            int choice;
            do
            {
                Console.WriteLine("\n// ***************** Text Analysis Tool ***************** //");
                Console.WriteLine("1. Store and display all unique words and their count");
                Console.WriteLine("2. Display number of unique words");
                Console.WriteLine("3. Store number of occurrences of each word");
                Console.WriteLine("4. Display all words and occurrences (any order)");
                Console.WriteLine("5. Display all words and occurrences in Descending(Z-A)");
                Console.WriteLine("6. Display longest word and its count");
                Console.WriteLine("7. Display most frequent word and its count");
                Console.WriteLine("8. Search word – show line numbers");
                Console.WriteLine("9. Search word – show frequency");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nUnique words and their counts:\n");
                        Console.WriteLine(linkList.DisplayWords());
                        break;

                    case 2:
                        Console.WriteLine("\nTotal unique words:\n");
                        Console.WriteLine(linkList.UniqueWordCount());
                        break;

                    case 3:
                        Console.WriteLine("\nWord occurrences stored.\nDisplaying all word counts:");
                        Console.WriteLine(linkList.DisplayWords());
                        break;

                    case 4:
                        Console.WriteLine("\nDisplay words and counts (any order):\n");
                        Console.WriteLine(linkList.DisplayWords());
                        break;

                    case 5:
                        Console.WriteLine("\nSorted words (Z-A):\n");
                        Console.WriteLine(linkList.DisplaySortedWords(false));  // false means descending
                        break;

                    case 6:
                        Console.WriteLine("Longest word: " + linkList.LongestWord());
                        break;

                    case 7:
                        
                        Console.WriteLine("Most frequent word: " + linkList.MostFrequentWord());
                        break;

                    case 8:
                        Console.Write("\nEnter word to search (line numbers): ");
                        string searchWord = Console.ReadLine().ToLower();
                        Console.WriteLine(linkList.SearchWord(searchWord));
                        break;

                    case 9:
                        Console.Write("\nEnter word to get frequency: ");
                        string freqWord = Console.ReadLine().ToLower();
                        Console.WriteLine(linkList.WordFrequency(freqWord));
                        break;

                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

            } while (choice != 0);
        }
    }

}
