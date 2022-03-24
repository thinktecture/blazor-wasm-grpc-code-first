using System;
using System.Collections.Generic;
using System.Linq;

namespace GrpcCodeFirst.Api.Model
{
    public static class DataGenerator
    {
        public static void Initialize(ConferencesDbContext context)
        {
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
                    Url = "https://javascript-conference.com/new-york/"
                });

            var moreConfs = new List<Conference>();

            for (int i = 0; i < 300; i++)
            {
                var conf = new Conference
                {
                    Id = Guid.NewGuid(),
                    Title = "Conf " + i,
                    City = "City " + i,
                    Country = "Germany",
                    DateFrom = new DateTime(2020, 9, 28),
                    DateTo = new DateTime(2020, 10, 1),
                    Url = "https://someconf.com"
                };

                moreConfs.Add(conf);
            }

            context.Conferences.AddRange(moreConfs);

            context.SaveChanges();
        }
    }
}
