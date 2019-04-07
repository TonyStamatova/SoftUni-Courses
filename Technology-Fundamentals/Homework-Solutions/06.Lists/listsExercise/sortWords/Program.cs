using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string words = Console.ReadLine();
        string[] wordsStr = words.Split(' ');
        List<string> sameFirstLetter = new List<string>();

        for (int letter = 'a'; letter < 'z'; letter++)
        {
            for (int i = 0; i < wordsStr.Length; i++)
            {
                if ((wordsStr[i][0]) == letter)
                {

                }
            }
        }        
    }
}
