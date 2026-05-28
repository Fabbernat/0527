namespace Fabian_Bernat_backend.Models;

public class Kategoria
{
    public int Id { get; set; }
    public string Nev { get; set; } = string.Empty;

    public ICollection<Aru> Aruk { get; set; } = new List<Aru>();
}