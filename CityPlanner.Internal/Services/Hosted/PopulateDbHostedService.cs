﻿using CityPlanner.Entities.Entities;
using CityPlanner.Internal.Data;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace CityPlanner.Internal.Services.Hosted;

public class PopulateDbHostedService : AbstractHostedService<PopulateDbHostedService>
{
    private readonly IDbContextFactory<DataContext> _dbContextFactory;
    
    public PopulateDbHostedService(IServiceScopeFactory serviceScopeFactory, IDbContextFactory<DataContext> dbContextFactory) :
        base(serviceScopeFactory, TimeSpan.FromDays(Constants.Limits.MINIMUM_SECOND_HOSTED_SERVICE_DELAY), TimeSpan.FromDays(1))
    {
        _dbContextFactory = dbContextFactory;
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
                using var reader = new StreamReader(file, Encoding.UTF8);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    Encoding = Encoding.UTF8
                });

                var records = csv.GetRecords<BuildingDTO>().ToList();
                using var db = _dbContextFactory.CreateDbContext();

                db.Addresses.AddRange(records.Select(x => new Building
                {
                    Street = x.Street,
                    District = x.District,
                    SearchableAddress = $"{x.Street} {x.OrientationNumber}, {x.District}".NormalizeForSearch(),
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
                    Delimiter = ";",
                    Encoding = Encoding.UTF8
                });

                var records = csv.GetRecords<InterestPointsDTO>().ToList();
                using var db = _dbContextFactory.CreateDbContext();

                db.InterestPoints.AddRange(records.Select(x => new InterestPoint
                {
                    X = x.X,
                    Y = x.Y,
                    Type = x.Type,
                    Name = x.Name
                }));

                await db.SaveChangesAsync();
            }
        }

        await CalculateNears();

        Logger.LogInformation("Done.");
    }

    private async Task CalculateNears()
    {
        using var db = _dbContextFactory.CreateDbContext();

        var buildings = await db.Addresses
            .Include(x => x.NearInterestPoints)
        .ToListAsync();

        var allPoints = await db.InterestPoints.ToListAsync();

        foreach (var building in buildings)
        {
            Console.WriteLine($"building {building.Street} {building.OrientationNumber}");
            var nearPoints = allPoints.Where(x => DistanceHelper.CalculateDistance(x.X, x.Y, building.X, building.Y) < 900);
            building.NearInterestPoints.AddRange(nearPoints);
        }

        await db.SaveChangesAsync();
    }
}