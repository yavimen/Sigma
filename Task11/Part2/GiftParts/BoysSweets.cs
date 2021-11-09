using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma_SaintNicholas
{
    class BoysSweets
    {
        static BoysSweets _instance;

        private List<string> _sweets;

        private BoysSweets() => FillSweetsFromFile();

        static public BoysSweets GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BoysSweets();
            }
            return _instance;
        }

        public string this[int index]
        {
            get
            {
                if (_sweets.Count > index)
                    return _sweets[index];
                throw new Exception("Index out of range!");
            }
        }

        public int Length { get { return _sweets.Count; } }

        public void FillSweetsFromFile()=>
            _sweets = new List<string>(File.ReadAllText("./BoysSweets.txt").Split(new char[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries));
        
        public void Add(string sweets)=>_sweets.Add(sweets);

        public void Delete(string sweets)=>_sweets.Remove(sweets);
    }
}
