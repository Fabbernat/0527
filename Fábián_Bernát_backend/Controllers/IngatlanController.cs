using Fábián_Bernát_backend.DbModels;
using Fábián_Bernát_backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fábián_Bernát_backend.Controllers;

[ApiController]
[Route("api/ingatlan")]
public class IngatlanController : ControllerBase
{
    private readonly IngatlanContext _db;

    public IngatlanController(IngatlanContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await (
            from ingatlan in _db.Set<Ingatlanok>()
            join kategoria in _db.Set<Kategoria>()
                on ingatlan.Kategoria equals kategoria.Id
            select new
            {
                ingatlan.Id,
                Kategoria = kategoria.Nev,
                ingatlan.Leiras,
                ingatlan.HirdetesDatuma,
                ingatlan.Tehermentes,
                ingatlan.Ar,
                ingatlan.KepUrl
            }
        ).ToListAsync();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIngatlanDto dto)
    {
        if (
            dto.Kategoria is null ||
            string.IsNullOrWhiteSpace(dto.Leiras) ||
            dto.Tehermentes is null ||
            dto.Ar is null ||
            string.IsNullOrWhiteSpace(dto.KepUrl)
        )
        {
            return BadRequest("Hiányos adatok.");
        }

        bool categoryExists = await _db.Set<Kategoria>()
            .AnyAsync(k => k.Id == dto.Kategoria.Value);

        if (!categoryExists)
        {
            return BadRequest("Hiányos adatok.");
        }

        var ingatlan = new Ingatlanok
        {
            Kategoria = dto.Kategoria.Value,
            Leiras = dto.Leiras,
            HirdetesDatuma = dto.HirdetesDatuma ?? DateOnly.FromDateTime(DateTime.Today),
            Tehermentes = dto.Tehermentes.Value,
            Ar = dto.Ar.Value,
            KepUrl = dto.KepUrl
        };

        _db.Set<Ingatlanok>().Add(ingatlan);
        await _db.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created, new
        {
            Id = ingatlan.Id
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ingatlan = await _db.Set<Ingatlanok>().FindAsync(id);

        if (ingatlan is null)
        {
            return NotFound("Az ingatlan nem létezik.");
        }

        _db.Set<Ingatlanok>().Remove(ingatlan);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}