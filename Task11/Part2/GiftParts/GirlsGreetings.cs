using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma_SaintNicholas
{
    class GirlsGreetings
    {
        static GirlsGreetings _instance;

        private List<string> _ngreetings;

        private GirlsGreetings() => FillGreetingsFromFile();

        static public GirlsGreetings GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GirlsGreetings();
            }
            return _instance;
        }

        public string this[int index]
        {
            get
            {
                if (_ngreetings.Count > index)
                    return _ngreetings[index];
                throw new Exception("Index out of range!");
            }
        }

        public int Length { get { return _ngreetings.Count; } }

        public void FillGreetingsFromFile()
        {
            string ftext = File.ReadAllText("./GirlsGreetings.txt");
            _ngreetings = new List<string>(ftext.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public void Add(string greeting)
        {
            _ngreetings.Add(greeting);
        }

        public void Delete(string greeting)
        {
            _ngreetings.Remove(greeting);
        }
    }
}
