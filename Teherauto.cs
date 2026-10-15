using System;
using System.Collections.Generic;
using System.Text;

namespace FlottaApp
{
    internal class Teherauto : Jarmu
    {
        public double Teherbiras { get; set; }
        public Teherauto(string rendszam,int alapar, double teherbiras): base(rendszam , alapar)
        {
            teherbiras = Teherbiras;
        }
        
        public override int Adokalkulacio()
        {
           return base.Adokalkulacio() + (int)(Teherbiras * 1000);
        }
        public override string ToString()
        {
            return $"Teherautó {Rendszam} | Alapár: {Alapar} Ft | Teherbírás: {Teherbiras} kg | Adó: {Adokalkulacio()} Ft";
        }
    }

}
