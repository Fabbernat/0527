using Fabian_Bernat_backend.Data;
using Fabian_Bernat_backend.Dtos;
using Fabian_Bernat_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabian_Bernat_backend.Controllers;

[ApiController]
[Route("api/flowers")]
public class FlowersController : ControllerBase
{
    private readonly ViragboltContext _db;

    public FlowersController(ViragboltContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var flowers = await _db.Aruk
            .Include(a => a.Kategoria)
            .Select(a => new
            {
                a.Id,
                a.Nev,
                Kategoria = new
                {
                    a.Kategoria!.Id,
                    a.Kategoria.Nev
                },
                a.Leiras,
                a.Keszlet,
                a.Ar,
                a.KepUrl
            })
            .ToListAsync();

        return Ok(flowers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var flower = await _db.Aruk
            .Include(a => a.Kategoria)
            .Where(a => a.Id == id)
            .Select(a => new
            {
                a.Id,
                a.Nev,
                Kategoria = new
                {
                    a.Kategoria!.Id,
                    a.Kategoria.Nev
                },
                a.Leiras,
                a.Keszlet,
                a.Ar,
                a.KepUrl
            })
            .FirstOrDefaultAsync();

        if (flower is null)
        {
            return NotFound(new { error = "A virág nem található!" });
        }

        return Ok(flower);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFlowerDto dto)
    {
        if (
            string.IsNullOrWhiteSpace(dto.Nev) ||
            dto.KategoriaId <= 0 ||
            dto.Ar < 0 ||
            dto.Keszlet < 0
        )
        {
            return BadRequest(new { error = "Hiányos vagy hibás adatok!" });
        }

        bool categoryExists = await _db.Kategoriak
            .AnyAsync(k => k.Id == dto.KategoriaId);

        if (!categoryExists)
        {
            return BadRequest(new { error = "A kategória nem található!" });
        }

        var flower = new Aru
        {
            Nev = dto.Nev,
            Leiras = dto.Leiras,
            Keszlet = dto.Keszlet,
            Ar = dto.Ar,
            KepUrl = dto.KepUrl,
            KategoriaId = dto.KategoriaId
        };

        _db.Aruk.Add(flower);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = flower.Id }, new
        {
            flower.Id,
            flower.Nev,
            flower.Leiras,
            flower.Keszlet,
            flower.Ar,
            flower.KepUrl,
            flower.KategoriaId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateFlowerDto dto)
    {
        var flower = await _db.Aruk.FindAsync(id);

        if (flower is null)
        {
            return NotFound(new { error = "A virág nem található!" });
        }

        if (!string.IsNullOrWhiteSpace(dto.Nev))
        {
            flower.Nev = dto.Nev;
        }

        if (!string.IsNullOrWhiteSpace(dto.Leiras))
        {
            flower.Leiras = dto.Leiras;
        }

        if (dto.Keszlet is not null)
        {
            flower.Keszlet = dto.Keszlet.Value;
        }

        if (dto.Ar is not null)
        {
            flower.Ar = dto.Ar.Value;
        }

        await _db.SaveChangesAsync();

        return Ok(new
        {
            flower.Id,
            flower.Nev,
            flower.Leiras,
            flower.Keszlet,
            flower.Ar,
            flower.KepUrl,
            flower.KategoriaId
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var flower = await _db.Aruk.FindAsync(id);

        if (flower is null)
        {
            return NotFound(new { error = "A virág nem található!" });
        }

        _db.Aruk.Remove(flower);
        await _db.SaveChangesAsync();

        return Ok(new { message = "A virág törölve." });
    }
}