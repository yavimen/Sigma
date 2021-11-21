using SigmaShop.StoragesSystem;
using SigmaShop.PromoSystem;
using SigmaShop.OrderSystem;
using SigmaShop.Users;
using SigmaShop.ShopSystem;

namespace SigmaShop
{
    class Program
    {
        static void Main(string[] args)
        {
            CStoreSystem storeSystem = new CStoreSystem(CStorageBase.GetInstance(), CPromoBase.GetInstance(), 
                CAuthUserBase.GetInstance(), COrderBase.GetInstance(), CShop.GetInstance(), new CUIBridge());

            storeSystem.ShowMainPage();
        }
    }
}
