using System.Globalization;
using System.Text;

namespace RealEstate.Models;

public class Ad
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Rooms { get; set; }
    public int Area { get; set; }
    public int Floors { get; set; }
    public bool FreeOfCharge { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string LatLong { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; }

    public Category Category { get; set; } = new();
    public Seller Seller { get; set; } = new();

    public static List<Ad> LoadFromCsv(string fileName)
    {
        List<Ad> ads = new();

        foreach (string line in File.ReadLines(fileName, Encoding.UTF8).Skip(1))
        {
            string[] data = line.Split(';');

            ads.Add(new Ad
            {
                Id = int.Parse(data[0]),
                Rooms = int.Parse(data[1]),
                LatLong = data[2],
                Floors = int.Parse(data[3]),
                Area = int.Parse(data[4]),
                Description = data[5],

                // CSV-ben 0/1 van, nem true/false
                FreeOfCharge = data[6] == "1",

                ImageUrl = data[7],
                CreateAt = DateTime.Parse(data[8], CultureInfo.InvariantCulture),

                Seller = new Seller
                {
                    Id = int.Parse(data[9]),
                    Name = data[10],
                    Phone = data[11]
                },

                Category = new Category
                {
                    Id = int.Parse(data[12]),
                    Name = data[13]
                }
            });
        }

        return ads;
    }

    public double DistanceTo(double lat, double lon)
    {
        string[] coordinates = LatLong.Split(',');

        double adLat = double.Parse(coordinates[0], CultureInfo.InvariantCulture);
        double adLon = double.Parse(coordinates[1], CultureInfo.InvariantCulture);

        return Math.Sqrt(
            Math.Pow(adLat - lat, 2) +
            Math.Pow(adLon - lon, 2)
        );
    }
}