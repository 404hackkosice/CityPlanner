using CityPlanner.Internal.Data;
using CsvHelper;
using CsvHelper.Configuration;
using System.Net;

namespace CityPlanner.Internal.Services.Hosted;

public class PopulateDbHostedService : AbstractHostedService<PopulateDbHostedService>
{
    public PopulateDbHostedService(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory, TimeSpan.FromDays(2), TimeSpan.FromDays(1))
    {

    }

    protected override async void OnRun()
    {
        if (!Directory.Exists(Constants.DATA_PATH))
            Directory.CreateDirectory(Constants.DATA_PATH);

        foreach(var file in Directory.GetFiles(Constants.DATA_PATH).Where(x => x.EndsWith(".csv")))
        {
            Console.WriteLine(file);

            if(file.Contains(Constants.CsvFiles.ADDRESSES))
            {
                using var reader = new StreamReader(file);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                });
                using var scope = ServiceScopeFactory.CreateScope();

                var records = csv.GetRecords<BuildingDTO>().ToList();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>()!;

                db.Addresses.AddRange(records.Select(x => new Building
                {
                    Street = x.Street,
                    District = x.District,
                    HousingCount = Convert.ToInt32(x.HousingCount),
                    OrientationNumber = x.OrientationNumber,
                    Type = x.Type,
                    X = x.X,
                    Y = x.Y
                }));

                await db.SaveChangesAsync();
            }
            else if (file.Contains(Constants.CsvFiles.POINTS_OF_INTEREST))
            {
                using var reader = new StreamReader(file);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "\t"
                });
                using var scope = ServiceScopeFactory.CreateScope();

                var records = csv.GetRecords<InterestPointsDTO>().ToList();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>()!;

                db.InterestPoints.AddRange(records.Select(x => new InterestPoint
                {
                    X = x.X,
                    Y = x.Y,
                    Name = x.Name,
                    TypeOne = x.TypeOne,
                    TypeTwo = x.TypeTwo,
                    Poly15 = x.Poly15
                }));

                await db.SaveChangesAsync();
            }
        }
    }
}