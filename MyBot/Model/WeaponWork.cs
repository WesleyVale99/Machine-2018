using System.Collections.Generic;

namespace AsyncRun.Model
{
    public class WeaponWork
    {
        public List<int> Weapons = new List<int>();

        static readonly WeaponWork INTs = new WeaponWork();
        public static WeaponWork INTS() => INTs;
        public WeaponWork()
        {
            Weapons.Add(100003214);//1
            Weapons.Add(1200065000);//2
            Weapons.Add(100003216);//3
            Weapons.Add(200004205);//4
            Weapons.Add(100003243);//5
            Weapons.Add(300005114);//6
            Weapons.Add(100003241);//7
            Weapons.Add(400006053);//8
            Weapons.Add(100003142);//9
            Weapons.Add(400006054);//10
            Weapons.Add(300005034);//11
            Weapons.Add(300005035);//12
            Weapons.Add(1001002008);//13
            Weapons.Add(1104003018);//14
            Weapons.Add(1104003019);//15
            Weapons.Add(1300035001);//16
            Weapons.Add(1300038001);//17
            Weapons.Add(1300119001);//18
            Weapons.Add(1300004001);//19
            Weapons.Add(400006037);//20
            Weapons.Add(200004600);//21
         // Weapons.Clear();
        }
    }
}
