namespace Fabian_Bernat_backend.Dtos;

public class CreateFlowerDto
{
    public string? Nev { get; set; }
    public string? Leiras { get; set; }
    public int Keszlet { get; set; }
    public int Ar { get; set; }
    public string? KepUrl { get; set; }
    public int KategoriaId { get; set; }
}