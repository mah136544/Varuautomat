using System;
using System.Collections.Generic;
using System.Text;

namespace Varuautomat.Model
{
    interface IVending
    {
        string[] ShowAll();                      // alla produkter
        void InsertMoney(string namn);           // mata in sedel eller mynt
        Produkt Purchase(string namn);           // kort instruktion return"
        Dictionary<string, int> EndTransaction(); // vilka Mynt och sedlar samt  hur många får man i växel
    }
}
