using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace Codility
{
    internal class Concordance
    {
        public string input = "Given an arbitrary text document written in English, write a program that will generate a concordance, i.e. an alphabetical list of all word occurrences, labeled with word frequencies.\n Bonus: label each word with the sentence numbers in which each occurrence appeared.";

        public class Freq
        {
            public string Text;
            public int Count;
            public string Lines;

            public Freq(string word, int line)
            {
                Text = word;
                Count = 1;
                Lines = Lines + line.ToString() + ",";
            }
        }

        public void TestMe()
        {
            input = System.IO.File.ReadAllText(@"C:\Users\dankur\Desktop\ConC1.txt");

            List<Freq> output = CreateConcordance(input);

            foreach (Freq f in output)
            {
                Console.WriteLine(f.Text + " {" + f.Count + ":" + f.Lines.TrimEnd(',') + "}");
            }
        }


        public List<Freq> CreateConcordance(string str)
        {
            List<Freq> output = new List<Freq>();
            Hashtable ht = new Hashtable();

            int lnCount = 0;
            foreach (string line in Regex.Split(str, "\r\n|\r|\n"))
            {
                if (line.Length == 0)
                    continue;

                lnCount++;
                foreach (string wordCase in line.Split(' '))
                {
                    if (wordCase.Length > 0)
                    {
                        string word = wordCase.ToLower(); // In example all words are lower case.
                        Freq tempFreq;
                        if (ht.ContainsKey(word))
                        {
                            tempFreq = (Freq)ht[word];
                            tempFreq.Count++;
                            tempFreq.Lines = tempFreq.Lines + lnCount + ",";
                        }
                        else
                        {
                            tempFreq = new Freq(word, lnCount);
                            ht.Add(word, tempFreq);
                            output.Add(tempFreq);
                        }
                    }
                }
            }
            output.Sort(delegate(Freq c1, Freq c2) { return c1.Text.CompareTo(c2.Text); });

            return output;
        }




        public class Trie
        {
            public Dictionary<char, Trie> Childs;
            public char Ch;
            public int Count;
            public string Lines;

            public Trie(char newCh)
            {
                Ch = newCh;
                Childs = new Dictionary<char, Trie>();
                Lines = "";
            }
        }

        public void Solution2()
        {
            var lines = System.IO.File.ReadLines(@"C:\Users\dankur\Desktop\ConC2.txt");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\dankur\Desktop\output.txt", false))
            {
                file.Write("");
            }

            var root = new Trie(' ');

            try
            {
                int lineNum = 0;
                foreach (string line in lines)
                {
                    lineNum++;
                    if (line.Length == 0)
                        continue;

                    ConcordLine(line, root, lineNum);
                }

                SortAndPrintTrie(root, "");

                //Console.Read();
            }
            catch (OutOfMemoryException)
            {
                throw new Exception("Out of Memory. Check input file.");
            }
        }
        public void ConcordLine(string line, Trie t, int lineNum)
        {
            foreach (string word in line.Split())
            {
                Regex regex = new Regex(@"[^\w@-]"); // No special chars. E.g. ':' in Bonus: is removed.
                string newWord = regex.Replace(word.ToLower(), ""); // All words are in lower case in output.

                if (newWord.Length > 0)
                {
                    AddWordToTrie(newWord, t, 0, lineNum);
                }
            }
        }
        public void AddWordToTrie(string word, Trie t, int index, int lineNum)
        {
            if (index < word.Length)
            {
                if (t.Childs.ContainsKey(word[index]))
                {
                    Trie temp = t.Childs[word[index]];
                    AddWordToTrie(word, temp, index + 1, lineNum);
                }
                else
                {
                    Trie temp = new Trie(word[index]);
                    t.Childs.Add(word[index], temp);
                    AddWordToTrie(word, temp, index + 1, lineNum);
                }
            }
            else
            {
                t.Count++;
                t.Lines = t.Lines + lineNum + ",";
            }
        }
        public void SortAndPrintTrie(Trie t, string word)
        {
            List<Trie> cList = t.Childs.Values.ToList();
            cList.Sort((c1, c2) => c1.Ch.CompareTo(c2.Ch));
            
            foreach(Trie child in cList)
            {
                if (child.Count > 0)
                {
                    string txt = word + child.Ch + " {" + child.Count + ":" + child.Lines.TrimEnd(',') + "}";
                    Console.WriteLine(txt);
                    //System.IO.File.WriteLine(@"C:\Users\dankur\Desktop\output.txt", txt);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\dankur\Desktop\output.txt", true))
                    {
                        file.WriteLine(txt);
                    }
                    
                }
                if(child.Childs.Count>0)
                {
                    SortAndPrintTrie(child, word + child.Ch);
                }
            }
        }
    }
}
