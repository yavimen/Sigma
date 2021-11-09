using System;

namespace Sigma_SaintNicholas
{
    class Program
    {
        static void Main()
        {
            ChildRequest request = new ChildRequest(badbehaviors:1, child: EСhild.boy);
            SaintNicholas nicholas = SaintNicholas.GetInstance();
            Console.WriteLine(nicholas.ToForm(request, DependenceOnBehavior.no));
            Console.WriteLine();
            Console.WriteLine(nicholas.ToForm(request, DependenceOnBehavior.yes));
        }
    }
}
