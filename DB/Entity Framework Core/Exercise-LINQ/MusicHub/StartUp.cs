using System.Globalization;
using System.Linq;
using System.Text;
using MusicHub.Data.Models;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Producers
                .FirstOrDefault(p => p.Id == producerId)
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriter)
                        .ToArray(),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
           var songs = context.Songs.ToList()
               .Where(s => s.Duration.TotalSeconds > duration)
               .Select(s => new
               {
                   SongName = s.Name,
                   SongPerformer = s.SongPerformers
                       .Select(p => new
                       {
                           FullName = $"{p.Performer.FirstName} {p.Performer.LastName}"
                       })
                       .OrderBy(n => n.FullName.ToString())
                       .ToArray(),
                   SongWriter = s.Writer.Name,
                   AlbumProducer = s.Album.Producer.Name,
                   SongDuration = s.Duration.ToString("c")

               })
               .OrderBy(s => s.SongName)
               .ThenBy(s => s.SongWriter)
               .ToList();

            int counter = 1;
            StringBuilder sb = new StringBuilder();

           foreach (var song in songs)
           {

               sb.AppendLine($"-Song #{counter++}");
               sb.AppendLine($"---SongName: {song.SongName}");
               sb.AppendLine($"---Writer: {song.SongWriter}");

               foreach (var performer in song.SongPerformer)
               {
                   sb.AppendLine($"---Performer: {performer.FullName}");
               }

               sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
               sb.AppendLine($"---Duration: {song.SongDuration}");
           }

           return sb.ToString().TrimEnd();
        }
    }
}
