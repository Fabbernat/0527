namespace Fabian_Bernat_backend.Models;

public class Aru
{
    public int Id { get; set; }
    public string Nev { get; set; } = string.Empty;
    public string? Leiras { get; set; }
    public int Keszlet { get; set; }
    public int Ar { get; set; }
    public string? KepUrl { get; set; }

    public int KategoriaId { get; set; }
    public Kategoria? Kategoria { get; set; }
}