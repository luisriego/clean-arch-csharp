using CleanArch.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamers());

                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamers()
        {
            return new List<Streamer>()
            {
                new Streamer() { CreatedBy = "pepelu", Name = "Streamer1", Url = "https://www.twitch.tv/streamer1" },
                new Streamer() { CreatedBy = "pepelu", Name = "Streamer2", Url = "https://www.twitch.tv/streamer2" }
            };
        }
    }
}
