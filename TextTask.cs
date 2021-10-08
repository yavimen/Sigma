using System;
using System.IO;

namespace StartingCSharp
{
    class ChangeText
    {
        private string[] text;
        private string[] Text 
        {
            get;
            set;
        }

        public ChangeText(string filepath) 
        {
            
            StreamReader file = new StreamReader(@filepath);

            if (file == null) 
            {
                throw new FileNotFoundException();
            }

            string temp = file.ReadToEnd();

            char[] del = { '\n' };

            text = temp.Split(del);

            file.Close();
        }

        private void ChangeSharp() 
        {
            int nallsharps = 0;

            for (int i = 0; i < text.GetLength(0); i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (text[i][j] == '#') 
                    {
                        nallsharps++;
                    }
                }
            }

            int nopensharps = nallsharps / 2;

            string[] str = new string[text.GetLength(0)];

            for (int i = 0; i < str.GetLength(0); i++)
            {
                str[i] = String.Empty;
            }

            for (int i = 0; i < text.GetLength(0); i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (text[i][j] == '#') 
                    {
                        if (nopensharps > 0) 
                        {
                            str[i] += '<';
                            nopensharps--;
                        }
                        else
                            str[i] += '>';
                    }
                    else
                        str[i] += text[i][j];
                }
            }

            text = str;
        }

        public string ReturnText() 
        {
            ChangeSharp();
            string t = "";
            for (int i = 0; i < text.GetLength(0); i++)
            {
                t += text[i];
                t += "\n";
            }

            return t;
        }
    }
}
