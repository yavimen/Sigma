using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma_SaintNicholas
{
    class BoysGreetings
    {
        static BoysGreetings _instance;

        private List<string> _ngreetings;

        private BoysGreetings() => MakeGreetingsFromFile();

        static public BoysGreetings GetInstance() 
        {
            if (_instance == null)
            {
                _instance = new BoysGreetings();
            }
            return _instance;
        }

        public string this[int index]
        {
            get { 
                if(_ngreetings.Count > index)
                    return _ngreetings[index];
                throw new Exception("Index out of range!");
            }
        }

        public int Lenght { get { return _ngreetings.Count; } }

        public void MakeGreetingsFromFile() 
        {
            string ftext = File.ReadAllText("./BoysGreetings.txt");
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
