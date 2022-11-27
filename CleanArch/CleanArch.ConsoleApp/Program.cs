using CleanArch.Data;
using CleanArch.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

// await AddNewRecords();
// QueryStreaming();
//await QueryFilter();
await MultipleEntitiesQuery();

async Task MultipleEntitiesQuery()
{
    var videoWithActors = await dbContext!.Videos!.Include(v => v.Actors).FirstOrDefaultAsync(v => v.Id == 1);
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Name = "Lorenzo",
        Surname = "Basteri",
        VideoId = 1
    };

    await dbContext.AddRangeAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task QueryFilter()
{
    var streamers = await dbContext!.Streamers!
        .Where(s => s.Name!.Contains("Net"))
        .ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

void QueryStreaming()
{
    var streamers = dbContext.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Name}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Name = "Disney +",
        Url = "https://www.disneyplus.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
{
    new Video
    {
        Name = "La cenicienta",
        StreamerId = streamer.Id
    },
    new Video
    {
        Name = "101 Dalmatas",
        StreamerId = streamer.Id
    },
    new Video
    {
        Name = "Blancanieves",
        StreamerId = streamer.Id
    },
    new Video
    {
        Name = "Star Wars",
        StreamerId = streamer.Id
    }
};

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}
    

