using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma
{
    class Sentences
    {
        private List<string> _sentences;

        public Sentences() => _sentences = new List<string>();

        public void Add(string sentence) => _sentences.Add(sentence);

        public void Sort(Comparison<string> comparer) 
        {
            _sentences.Sort(comparer);
        }

        public void FindAllSentencesInFile(string path) 
        {
            StreamReader file = new StreamReader(@path);
            if (file == null)
                throw new FileNotFoundException();
            string line = "";
            string[] templines;
            string buf = "";
            bool mustbeappended = false;
            while (!file.EndOfStream)
            {
                line = file.ReadLine();

                templines = line.Split('.');

                if (templines.Length == 1){
                    if (mustbeappended)
                        buf += line;
                    else
                        buf = line;
                    mustbeappended = true;
                }
                else{
                    if (mustbeappended)
                    {
                        if(buf[buf.Length-1]==' ')
                            buf +=templines[0];
                        else
                            buf +=" "+templines[0];
                        mustbeappended = false;

                        _sentences.Add(buf);

                        if (templines[templines.Length - 1] == String.Empty)
                            for (int i = 1; i < templines.Length - 1; i++)
                            {
                                _sentences.Add(templines[i]);
                            }
                        else
                        {
                            for (int i = 1; i < templines.Length - 1; i++)
                            {
                                _sentences.Add(templines[i]);
                            }
                            buf = templines[templines.Length - 1];
                            mustbeappended = true;
                        }
                    }
                    else{
                        if (templines[templines.Length - 1] == String.Empty)
                            for (int i = 0; i < templines.Length - 1; i++)
                                _sentences.Add(templines[i]);
                        else
                        {
                            for (int i = 0; i < templines.Length - 1; i++)
                                _sentences.Add(templines[i]);

                            buf = templines[templines.Length - 1];
                            mustbeappended = true;
                        }
                    }
                }
            }

            for (int i = 0; i < _sentences.Count; i++)
            {
                _sentences[i] += "."; 
            }
        }

        public string FindHighestLevelOfBrackets() 
        {
            int maxlevel = 0; int counter = 0;
            string str = "";
            for (int i = 0; i < _sentences.Count; i++)
            {
                for (int j = 0; j < _sentences[i].Length; j++)
                {
                    if (_sentences[i][j] == '(') 
                    {
                        counter++;
                    }
                }
                if (counter > maxlevel) 
                {
                    maxlevel = counter;
                    str = _sentences[i];
                }
                counter = 0;
            }

            if (maxlevel == 0)
                return null;

            return str;
        } 
        
        public override string ToString() 
        {
            string str = "";
            foreach (var item in _sentences)
            {
                if (item[0] == ' ')
                    str += item;
                else 
                    str += " " + item;
            }
            return str;
        }
    }
}
