using System;
using System.Collections.Generic;
using System.Text;

namespace Sigma_SaintNicholas
{
    class GiftBuilderIndependentOnBehaviorBoys:GiftBuilderBoys
    {
        static int toyscounter = 0;
        static int greetingscounter = 0;
        static int sweetscounter = 0;

        public override void ChooseGreeting()
        {
            if (greetingscounter >= BoysGreetings.GetInstance().Length)
                greetingscounter = 0;
            gift.Greeting = BoysGreetings.GetInstance()[greetingscounter];
            greetingscounter++;
        }

        public override void ChooseSweet()
        {
            if (sweetscounter >= BoysSweets.GetInstance().Length)
                sweetscounter = 0;
            gift.Sweet = BoysSweets.GetInstance()[sweetscounter];
            sweetscounter++;
        }

        public override void ChooseToys()
        {
            if (toyscounter >= BoysToys.GetInstance().Length)
                toyscounter = 0;
            gift.Toy = BoysToys.GetInstance()[toyscounter];
            toyscounter++;
        }
    }
}
