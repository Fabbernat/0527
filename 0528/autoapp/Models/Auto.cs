namespace autoapp.Models;

public class Auto
{
    public int Sorszam { get; set; }
    public string Marka { get; set; }
    public string Modell { get; set; }
    public int GyartasiEv { get; set; }
    public string Szin { get; set; }
    public int EladottDarab { get; set; }
    public int AtlagosEladasiAr { get; set; }

    public Auto(string sor)
    {
        string[] data = sor.Split(';', StringSplitOptions.RemoveEmptyEntries);

        Sorszam = int.Parse(data[0]);
        Marka = data[1];
        Modell = data[2];
        GyartasiEv = int.Parse(data[3]);
        Szin = data[4];
        EladottDarab = int.Parse(data[5]);
        AtlagosEladasiAr = int.Parse(data[6]);
    }

    public static List<Auto> Beolvas(string fajlNev)
    {
        return [.. File.ReadAllLines(fajlNev)
            .Skip(1)
            .Select(sor => new Auto(sor))];
    }
}