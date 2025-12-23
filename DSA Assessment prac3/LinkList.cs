using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assessment
{
    internal class LinkList
    {
        private Link list = null;

        public void AddWord(string word, int line)
        {
            Link temp = list;

            while (temp != null)
            {
                if (temp.Data == word)
                {
                    if (!temp.Lines.Contains(line))
                        temp.Lines.Add(line);
                    return;
                }
                temp = temp.Next;
            }

            list = new Link(word, line, list);
        }

        public string DisplayWords()
        {
            string buffer = "";
            Link temp = list;
            while (temp != null)
            {
                buffer += $"{temp.Data} - {temp.Lines.Count}\n";
                temp = temp.Next;
            }
            return buffer;
        }

        public int UniqueWordCount()
        {
            int count = 0;
            Link temp = list;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }

        public string DisplaySortedWords(bool ascending)
        {
            List<Link> words = new List<Link>();      //list to hold all the Link nodes
            Link temp = list;
            while (temp != null)
            {
                words.Add(temp);
                temp = temp.Next;
            }

            // Always sorting in descending order
            List<Link> sorted = words.OrderByDescending(w => w.Data).ToList();

            string output = "";
            for (int i = 0; i < sorted.Count; i++)
            {
                output += $"{sorted[i].Data} - {sorted[i].Lines.Count}\n";
            }

            return output;
        }


        public string LongestWord()
        {
            Link temp = list;
            Link longest = null;
            while (temp != null)
            {
                if (longest == null || temp.Data.Length > longest.Data.Length)
                    longest = temp;
                temp = temp.Next;
            }
            return $"{longest.Data} - {longest.Lines.Count}";
        }

        public string MostFrequentWord()
        {
            Link temp = list;
            Link most = null;
            while (temp != null)
            {
                if (most == null || temp.Lines.Count > most.Lines.Count)
                    most = temp;
                temp = temp.Next;
            }
            return $"{most.Data} - {most.Lines.Count}";
        }

        public string SearchWord(string word)
        {
            Link temp = list;
            while (temp != null)
            {
                if (temp.Data == word)
                    return $"{word} appears on lines: {string.Join(", ", temp.Lines)}";
                temp = temp.Next;
            }
            return "Word not found.";
        }

        public string WordFrequency(string word)
        {
            Link temp = list;
            while (temp != null)
            {
                if (temp.Data == word)
                    return $"{word} occurs {temp.Lines.Count} times.";
                temp = temp.Next;
            }
            return "Word not found.";
        }
    }
}
