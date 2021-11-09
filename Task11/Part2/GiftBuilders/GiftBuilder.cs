using System;
using System.Collections.Generic;
using System.Text;

namespace Sigma_SaintNicholas
{
    abstract class GiftBuilder
    {
        protected ChildRequest request;
        protected Gift gift;
        abstract public void TakeChildRequest(ChildRequest request);
        abstract public void ChooseToys();
        abstract public void ChooseSweet();
        abstract public void ChooseGreeting();
        abstract public Gift GetGift();
    }
}
