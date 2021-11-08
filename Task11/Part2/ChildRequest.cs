namespace Sigma_SaintNicholas
{
    enum EСhild { boy, girl }
    class ChildRequest
    {
        private string _fullname;
        public string FullName { get {return _fullname; } set { _fullname = value; } }

        private int _badb;
        public int BadBehaviors { get { return _badb; } set { _badb = value; } }

        private int _goodb;
        public int GoodBehaviors { get { return _goodb; } set { _goodb = value; } }
        
        private EСhild _child;
        public EСhild Child { get {return _child; } set { _child = value; } }

        public ChildRequest(string fullname = "Child", int badbehaviors = 0, int goodbehaviors = 0, EСhild child = EСhild.girl)
        {
            FullName = fullname;
            BadBehaviors = badbehaviors;
            GoodBehaviors = goodbehaviors;
            Child = child;
        }
    }
}
