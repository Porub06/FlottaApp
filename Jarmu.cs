using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

namespace FlottaApp
{
    internal class Jarmu
    {
        public string Rendszam { get; set; }
        protected int alapar;
        public int Alapar
        {
            get { return alapar; } set
            {
                if (value <= 0)
                {
                    alapar = 10000000;
                };
                
            }
        
        }

        private static int osszesJarmuSzama;
        public static int OsszesJarmuSzama { get; }

        //Konstruktor:
        public Jarmu(string rendszam, int alapar)
        {
            rendszam = Rendszam;
            alapar = Alapar;

        }

        


        //Metódusok:

        
        public virtual int Adokalkulacio()
        {
           
          return Convert.ToInt16(Alapar * 0.05);
        }
        public override string ToString()
        {
            return $"Jármű {Rendszam} | Alapár: {Alapar} Ft | Adó: {Adokalkulacio()} Ft";
        }



    }
}
