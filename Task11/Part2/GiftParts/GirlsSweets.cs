using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma_SaintNicholas
{
    class GirlsSweets
    {
        static GirlsSweets _instance;

        private List<string> _sweets;

        private GirlsSweets() => FillSweetsFromFile();

        static public GirlsSweets GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GirlsSweets();
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

        public void FillSweetsFromFile() =>
            _sweets = new List<string>(File.ReadAllText("./GirlsSweets.txt").Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));

        public void Add(string sweets) => _sweets.Add(sweets);

        public void Delete(string sweets) => _sweets.Remove(sweets);
    }
}
