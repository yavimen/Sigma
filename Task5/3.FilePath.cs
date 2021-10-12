using System;
using System.Collections.Generic;
using System.Text;

namespace StartingCSharp
{
    class FilePath
    {
        private string path;

        public string Path 
        {
            get { return Path; }
        }

        public FilePath(string filepath) 
        {
            this.path = filepath;
        }

        public string GetFileName() 
        {
            string []temp = path.Split('\\',' ', StringSplitOptions.RemoveEmptyEntries);

            string[] namewithextension = temp[temp.Length - 1].Split('.', StringSplitOptions.RemoveEmptyEntries);

            if (namewithextension.Length > 2)
                throw new Exception("Wrong filename!");
            return namewithextension[0];
        }

        public string GetRootFolderName() 
        {
            string[] temp = path.Split('\\', ' ', StringSplitOptions.RemoveEmptyEntries);
            return temp[temp.Length-2];
        }
    }
}
