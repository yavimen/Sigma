using System;
using System.Collections.Generic;
using System.Text;

namespace Sigma_SaintNicholas
{
    class GiftBuilderGirls : GiftBuilder
    {
        public override void ChooseGreeting()
        {
            if (request.BadBehaviors > request.GoodBehaviors)
                gift.Greeting = "Dear "+request.FullName+", be more polite in the New Year!";
            else 
            {
                Random random = new Random();
                gift.Greeting = "Dear " + request.FullName +". "+GirlsGreetings.GetInstance()[random.Next(0, GirlsGreetings.GetInstance().Lenght - 1)];
            } 
        }

        public override void ChooseSweet()
        {
            if (request.BadBehaviors > request.GoodBehaviors)
                gift.Sweet = "Nothing";
            else
            {
                Random random = new Random();
                gift.Sweet = GirlsSweets.GetInstance()[random.Next(0, GirlsSweets.GetInstance().Lenght - 1)];
            }
        }

        public override void ChooseToys()
        {
            if (request.BadBehaviors > request.GoodBehaviors)
                gift.Toy = "Birch";
            else
            {
                Random random = new Random();
                gift.Toy = GirlsToys.GetInstance()[random.Next(0, GirlsToys.GetInstance().Lenght - 1)];
            }
        }

        public override Gift GetGift()
        {
            if (gift != null && gift.Greeting != null && gift.Toy != null && gift.Sweet != null) 
            {
                return gift;
            }
            throw new Exception("Gift is not ready");
        }

        public override void TakeChildRequest(ChildRequest request)
        {
            gift = new Gift();
            this.request = request;
        }
    }
}
