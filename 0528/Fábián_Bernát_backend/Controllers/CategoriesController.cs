using Fabian_Bernat_backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabian_Bernat_backend.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ViragboltContext _db;

    public CategoriesController(ViragboltContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _db.Kategoriak
            .Select(k => new
            {
                k.Id,
                k.Nev
            })
            .ToListAsync();

        return Ok(categories);
    }
}