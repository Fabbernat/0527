using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.DbMysqlModels;

namespace RealEstate.Controllers;
public class RealEstateRepoController : Controller
{
    private readonly RealestateContext _db;

    public RealEstateRepoController(RealestateContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _db.Realestates.ToListAsync();
        return View(products);
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ExamResultsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello");
        }
    }
}