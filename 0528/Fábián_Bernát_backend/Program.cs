using Fabian_Bernat_backend.Data;
using Fabian_Bernat_backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ViragboltContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ViragboltContext>();

    db.Database.EnsureCreated();

    if (!db.Kategoriak.Any())
    {
        db.Kategoriak.AddRange(
            new Kategoria { Id = 1, Nev = "Virágok" },
            new Kategoria { Id = 2, Nev = "Szobanövények" },
            new Kategoria { Id = 3, Nev = "Szabadtéri növények" }
        );

        db.SaveChanges();
    }

    if (!db.Aruk.Any())
    {
        db.Aruk.AddRange(
            new Aru
            {
                Nev = "Rózsa",
                KategoriaId = 1,
                Leiras = "A rózsa a rózsafélék családjába tartozó növény.",
                Keszlet = 10,
                Ar = 1000,
                KepUrl = "https://example.com/rozsa.jpg"
            },
            new Aru
            {
                Nev = "Tulipán",
                KategoriaId = 1,
                Leiras = "A tulipán a liliomfélék családjába tartozó növény.",
                Keszlet = 20,
                Ar = 800,
                KepUrl = "https://example.com/tulipan.jpg"
            }
        );

        db.SaveChanges();
    }
}

app.MapControllers();

app.Run();