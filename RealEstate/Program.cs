using RealEstate.DbMysqlModels;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();

//builder.Services.AddDbContext<RealestateContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
//    ));

//var app = builder.Build();

//app.MapControllers();

//app.Run();

Console.Title = "Ingatlanok";

var ads = Ad.LoadFromCsv("realestates.csv");

Console.WriteLine("6. feladat:");

var avgArea = ads
    .Where(ad => ad.Floors == 0)
    .Average(ad => ad.Area);

Console.WriteLine($"A földszinti ingatlanok átlagos alapterülete: {avgArea:F2} m2");

Console.WriteLine("8. feladat:");

double mesevarLat = 47.4164220114023;
double mesevarLong = 19.066342425796986;

var nearest = ads
    .Where(ad => ad.FreeOfCharge)
    .OrderBy(ad => ad.DistanceTo(mesevarLat, mesevarLong))
    .First();

Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
Console.WriteLine($"Eladó neve: {nearest.Seller.Name}");
Console.WriteLine($"Eladó telefonja: {nearest.Seller.Phone}");
Console.WriteLine($"Alapterület: {nearest.Area}");
Console.WriteLine($"Szobák száma: {nearest.Rooms}");