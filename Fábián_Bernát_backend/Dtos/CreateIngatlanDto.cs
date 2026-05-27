namespace Fábián_Bernát_backend.Dtos;

public class CreateIngatlanDto
{
    public int? Kategoria { get; set; }
    public string? Leiras { get; set; }
    public DateOnly? HirdetesDatuma { get; set; }
    public bool? Tehermentes { get; set; }
    public int? Ar { get; set; }
    public string? KepUrl { get; set; }
}