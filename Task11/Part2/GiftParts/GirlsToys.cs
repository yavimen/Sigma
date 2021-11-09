using System;
using System.Collections.Generic;
using System.IO;

namespace Sigma_SaintNicholas
{
    class GirlsToys
    {
        static GirlsToys _instance;

        private List<string> _girlstoys;

        private GirlsToys() => FillToysFromFile();

        static public GirlsToys GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GirlsToys();
            }
            return _instance;
        }

        public string this[int index]
        {
            get
            {
                if (_girlstoys.Count > index)
                    return _girlstoys[index];
                throw new Exception("Index out of range!");
            }
        }

        public int Length { get { return _girlstoys.Count; } }

        public void FillToysFromFile()
        {
            string ftext = File.ReadAllText("./GirlsToys.txt");
            _girlstoys = new List<string>(ftext.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public void Add(string toy)
        {
            _girlstoys.Add(toy);
        }

        public void Delete(string toy)
        {
            _girlstoys.Remove(toy);
        }
    }
}
