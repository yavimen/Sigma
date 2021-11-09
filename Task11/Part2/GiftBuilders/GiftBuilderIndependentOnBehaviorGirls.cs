using System;
using System.Collections.Generic;
using System.Text;

namespace Sigma_SaintNicholas
{
    class GiftBuilderIndependentOnBehaviorGirls : GiftBuilderGirls
    {
        static int toyscounter = 0;
        static int greetingscounter = 0;
        static int sweetscounter = 0;

        public override void ChooseGreeting()
        {
            if (greetingscounter >= GirlsGreetings.GetInstance().Length)
                greetingscounter = 0;
            gift.Greeting = GirlsGreetings.GetInstance()[greetingscounter];
            greetingscounter++;
        }

        public override void ChooseSweet()
        {
            if (sweetscounter >= GirlsSweets.GetInstance().Length)
                sweetscounter = 0;
            gift.Sweet = GirlsSweets.GetInstance()[sweetscounter];
            sweetscounter++;
        }

        public override void ChooseToys()
        {
            if (toyscounter >= GirlsToys.GetInstance().Length)
                toyscounter = 0;
            gift.Toy = GirlsToys.GetInstance()[toyscounter];
            toyscounter++;
        }
    }
}
