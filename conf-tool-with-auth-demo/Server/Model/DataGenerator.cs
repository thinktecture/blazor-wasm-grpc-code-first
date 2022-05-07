using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfTool.Server.Model
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ConferencesDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ConferencesDbContext>>());
            if (context.Conferences.Any())
            {
                return;
            }

            context.Conferences.AddRange(
                new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "BASTA! Spring 2020",
                    City = "Frankfurt am Main",
                    Country = "Germany",
                    DateFrom = new DateTime(2020, 2, 24),
                    DateTo = new DateTime(2020, 2, 28),
                    DateCreated = new DateTime(2020, 1, 2),
                    Url = "https://www.basta.net/"
                },
                new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "IJS 2020 London",
                    City = "London",
                    Country = "England",
                    DateFrom = new DateTime(2020, 4, 20),
                    DateTo = new DateTime(2020, 4, 22),
                    DateCreated = new DateTime(2020, 3, 1),
                    Url = "https://javascript-conference.com/london/"
                }, 
                new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "Global Azure Bootcamp 2020",
                    City = "Hamburg",
                    Country = "Germany",
                    DateFrom = new DateTime(2020, 4, 25),
                    DateTo = new DateTime(2020, 4, 25),
                    DateCreated = new DateTime(2020, 4, 1),
                    Url = "https://sessionize.com/global-azure-bootcamp-hamburg/"
                },
                new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "DevOpsCon 2020 Berlin",
                    City = "Berlin",
                    Country = "Germany",
                    DateFrom = new DateTime(2020, 6, 8),
                    DateTo = new DateTime(2020, 6, 11),
                    DateCreated = new DateTime(2020, 6, 1),
                    Url = "https://devopscon.io/berlin-de/"
                },
                new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "BASTA! 2020",
                    City = "Mainz",
                    Country = "Germany",
                    DateFrom = new DateTime(2020, 9, 21),
                    DateTo = new DateTime(2020, 9, 25),
                    DateCreated = new DateTime(2020, 9, 1),
                    Url = "https://www.basta.net/"
                },
                new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "IJS 2020 NYC",
                    City = "New York City",
                    Country = "USA",
                    DateFrom = new DateTime(2020, 9, 28),
                    DateTo = new DateTime(2020, 10, 1),
                    DateCreated = new DateTime(2020, 9, 1),
                    Url = "https://javascript-conference.com/new-york/"
                });

            var moreConfs = new List<Conference>();

            for (var i = 0; i < 300; i++)
            {
                var conf = new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "Conf "+ i,
                    City = "City " + i,
                    Country = "Germany",
                    DateFrom = new DateTime(2021, 1, 2),
                    DateTo = new DateTime(2021, 1, 3),
                    DateCreated = new DateTime(2020, 1, 1),
                    Url = "https://someconf.com"
                };

                moreConfs.Add(conf);
            }

            context.Conferences.AddRange(moreConfs);
            context.SaveChanges();
        }
    }
}
