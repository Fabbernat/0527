using autoapp.Models;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

List<Auto> autok = Auto.Beolvas("autok.csv");

Console.WriteLine($"5. feladat: {autok.Count} autó található a listában");

double atlag = autok.Average(auto => auto.EladottDarab);

Console.WriteLine($"6. feladat: Az autók esetében az átlagosan eladott darabszám {atlag:F1}");

Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók:");

foreach (Auto auto in autok.Where(auto => auto.GyartasiEv >= 2019))
{
    Console.WriteLine($"\t- {auto.Marka} {auto.Modell}: {auto.GyartasiEv}");
}

Console.WriteLine("8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");

var markak = autok
    .GroupBy(auto => auto.Marka)
    .Select(csoport => new
    {
        Marka = csoport.Key,
        EladottDarab = csoport.Sum(auto => auto.EladottDarab)
    })
    .OrderByDescending(x => x.EladottDarab)
    .ThenBy(x => x.Marka);

foreach (var marka in markak)
{
    Console.WriteLine($"\t- {marka.Marka}: {marka.EladottDarab} darab");
}