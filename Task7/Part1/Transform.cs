using System.Collections.Generic;
using System;

namespace SentenceTransformation.Classes
{
    class Transform
    {
        private Dictionary<string, string> mydict;
        private Dictionary<string,string> MyDict 
        {
            get;
            set;
        }

        private string inputstr;
        private string InputStr 
        {
            get;
            set;
        }

        public Transform(string inputstr = "Hello")
        {
            mydict = new Dictionary<string, string>();
            mydict.Add("Hello", "Hi");
            mydict.Add("I", "Boy");
            mydict.Add("go", "run");
            mydict.Add("to", "to");
            mydict.Add("school", "bar");
            this.inputstr = inputstr;
        }

        private void AddNewWord(string word) 
        {
            string meaning;
            Console.Write($"I don't know word - '{word}'. Please, enter a meaning for this one: ");
            meaning = Console.ReadLine();
            mydict.Add(word, meaning);
        }

        private string SentencePunctuationRecovery(string[] array) 
        {
            string retstr = "";
            bool addword = true;
            int wordscounter = 0;
            bool brk = false;
            for (int i = 0; i < inputstr.Length; i++)
            {
                while (Char.IsLetterOrDigit(inputstr[i])|| inputstr[i]=='\'') 
                {
                    if (addword && wordscounter <= array.Length)
                    {
                        retstr += array[wordscounter];
                        wordscounter++;
                    }
                    addword = false;
                    i++;
                    if (!(i < inputstr.Length))
                    {
                        brk = true;
                        break;
                    }    
                        
                }
                if (brk)
                    break;
                addword = true;
                retstr += inputstr[i];
            }
            return retstr;
        }

        public string TransformStr() 
        {
            char[] delim = new char[] { ' ', '.', ',', ':', ';', '-', '?', '!' };
            string[] words = inputstr.Split(delim, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (!mydict.ContainsKey(words[i]))
                    AddNewWord(words[i]);             
                words[i] = mydict[words[i]];
            }

            return SentencePunctuationRecovery(words);
        }
    }
}
