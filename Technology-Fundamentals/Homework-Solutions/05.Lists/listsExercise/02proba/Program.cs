using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02proba
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            List<string> wordList = new List<string>(words.Split(' '));
            wordList.Sort((a, b) => a.CompareTo(b));
            for (int i = 0; i < wordList.Count; i++)
            {
                Console.Write(wordList[i] + " ");
            }
        }
    }
}
