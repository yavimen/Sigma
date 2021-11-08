using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma_SaintNicholas
{
    class BoysToys
    {
        static BoysToys _instance;

        private List<string> _boystoys;

        private BoysToys()
        {
            MakeToysFromFile();
        }
        static public BoysToys GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BoysToys();
            }
            return _instance;
        }

        public string this[int index]
        {
            get
            {
                if (_boystoys.Count > index)
                    return _boystoys[index];
                throw new Exception("Index out of range!");
            }
        }

        public int Lenght { get { return _boystoys.Count; } }

        public void MakeToysFromFile()
        {
            string ftext = File.ReadAllText("./BoysToys.txt");
            _boystoys = new List<string>(ftext.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public void Add(string toy)
        {
            _boystoys.Add(toy);
        }

        public void Delete(string toy)
        {
            _boystoys.Remove(toy);
        }
    }
}
