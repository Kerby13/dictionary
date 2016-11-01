using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LectionDictionary
{
    class Dictionary
    {
        private static Dictionary<string, int> dict = new Dictionary<string, int>();
        private static List<string> begincons = new List<string>();
        private static List<string> beginvow = new List<string>();
        private static StreamReader sr = new StreamReader("text.txt");
        private static StreamWriter sw = new StreamWriter("result.txt", false);
        private static string word = "";
        private static char firstletter;
        private static int codeofletter;


        private static void Read()
        {
            do
            {
                firstletter = Convert.ToChar(sr.Read());
                codeofletter = Convert.ToInt32(firstletter);
                if ((codeofletter >= 65) && (codeofletter <= 90) || (codeofletter >= 97) && (codeofletter <= 122))
                    word += firstletter;
                else
                {
                    InDictionary();
                }
                if (sr.Peek() == -1)
                    InDictionary();
            }
            while (sr.Peek() != -1);
        }

        private static bool PublicityCheck(char ch)
        {
            char[] vow = new char[6] { 'a', 'e', 'i', 'o', 'u', 'y' };
            foreach (char item in vow)
                if (ch == item)
                    return true;
            return false;
        }

        private static void InDictionary()
        {
            if (!String.IsNullOrEmpty(word))
            {
                word = word.ToLower();
                if (!dict.ContainsKey(word))
                    dict[word] = 0;
                dict[word]++;
            }
            word = "";
        }



        private static void Sorting()
        {
            foreach (var item in dict)
            {
                if (item.Value == 1)
                    if (PublicityCheck(item.Key[0]))
                        beginvow.Add(item.Key);
                    else
                        begincons.Add(item.Key);
            }

            beginvow.Sort();
            begincons.Sort();
        }

        private static void Print(string s)
        {
            sw.WriteLine(s);
        }

        private static void Result()
        {
            sr.Close();
            beginvow.ForEach(Print);
            begincons.ForEach(Print);
            sw.Close();
        }

        public static void Work()
        {
            Read();
            Sorting();
            Result();
        }
    }
}
