namespace Sigma_SaintNicholas
{
    class Gift
    {
        private string _toy;

        public string Toy
        {
            get { return _toy; }
            set { _toy = value; }
        }

        private string _sweet;

        public string Sweet
        {
            get { return _sweet; }
            set { _sweet = value; }
        }

        private string _greeting;

        public string Greeting
        {
            get { return _greeting; }
            set { _greeting = value; }
        }
        public override string ToString()
        {
            return "Greeting: "+Greeting + "\nToy: " + Toy + "\nSweets:" + Sweet;
        }
    }
}