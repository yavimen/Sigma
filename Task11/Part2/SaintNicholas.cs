namespace Sigma_SaintNicholas
{
    enum DependenceOnBehavior {yes, no}
    class SaintNicholas
    {
        static private SaintNicholas _instance;

        private SaintNicholas(){}

        static public SaintNicholas GetInstance() 
        {
            if (_instance == null)
                _instance = new SaintNicholas();
            return _instance;
        }

        public Gift ToForm(ChildRequest request, DependenceOnBehavior dependence) 
        {
            GiftBuilder builder;
            if (request.Child == EСhild.girl)
            {
                if (dependence == DependenceOnBehavior.yes)
                    builder = new GiftBuilderGirls();
                else
                    builder = new GiftBuilderIndependentOnBehaviorGirls();
            }
            else
            {
                if (dependence == DependenceOnBehavior.yes)
                    builder = new GiftBuilderBoys();
                else
                    builder = new GiftBuilderIndependentOnBehaviorBoys();
            }
            Construct(request, builder);
            return builder.GetGift();
        }

        private void Construct(ChildRequest request, GiftBuilder builder) 
        {
            builder.TakeChildRequest(request);
            builder.ChooseSweet();
            builder.ChooseGreeting();
            builder.ChooseToys();
        }
    }
}
