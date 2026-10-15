using FlottaApp;
using System.IO;
using System.Linq;

List<Jarmu> jarmuvek = new List<Jarmu>();
int hibasSorokSzama = 0;

string[] sorok = File.ReadAllLines("jarmuvek.csv");

foreach (var sor in sorok.Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibasSorokSzama++;
        continue;
    }
    string[] adatok = sor.Split(';');

    if (adatok.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }
    string tipus = adatok[0].Trim();
    string rendszam = adatok[1].Trim();
    if ((tipus != "J" && tipus != "T") || string.IsNullOrWhiteSpace(rendszam))
    {
        hibasSorokSzama++;
        continue;
    }
    if (!int.TryParse(adatok[2].Trim(), out int alapar) || alapar <= 0)
    {
        hibasSorokSzama++;
        continue;
    }
    double teherbiras = 0;

    if (tipus == "T" && !double.TryParse(adatok[3].Trim(), out teherbiras))
    {
        hibasSorokSzama++;
        continue;
    }
    if (tipus == "J")
    {
        jarmuvek.Add(new Jarmu(rendszam, alapar));
    }
    else if (tipus == "T")
    {
        jarmuvek.Add(new Teherauto(rendszam, alapar, teherbiras));
    }

    Console.WriteLine($"Sikeresen beolvasott jármű: {tipus} | Rendszám: {rendszam} | Alapár: {alapar} Ft | Teherbírás: {teherbiras} kg");
}
    Console.WriteLine($"--- Flotta Elemzés---");
    Console.WriteLine($"Kiszűrt hibás sorok száma: {hibasSorokSzama}");
    Console.WriteLine();
    Console.WriteLine("Járművek Listája");
    int teljesAdo = 0;
    foreach (Jarmu jarmu in jarmuvek)
    {
        teljesAdo += jarmu.Adokalkulacio();
        
    }

    Console.WriteLine();
    Console.WriteLine($"A flotta teljes adóterhe: {teljesAdo} Ft");
    Console.WriteLine($"{Jarmu.OsszesJarmuSzama}");
  

