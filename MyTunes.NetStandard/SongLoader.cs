#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

#endregion

namespace MyTunes
{
    public static class SongLoader
    {
        #region Consts

        const string Filename = "songs.json";

        const string ResourceName = "MyTunes.NetStandard.songs.json";

        #endregion

        #region Properties

        public static IStreamLoader Loader { get; set; }

        #endregion

        #region Private methods

        private static Stream OpenData()
        {
            if (Loader == null)
                throw new Exception("Must set platform Loader before calling Load.");

            return Loader.GetStreamForFilename(Filename);
        }

        #endregion

        #region Public methods

        public static async Task<IEnumerable<Song>> Load()
        {
            using (var reader = new StreamReader(OpenData()))
            {
                List<Song> songs = JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
                foreach (var song in songs)
                {
                    song.Name = song.Name.RuinSongName();
                }

                return songs;
            }
        }

        public static async Task<IEnumerable<Song>> ImprovedLoad()
        {
            var assembly = typeof(SongLoader).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream(ResourceName))
                using (var reader = new StreamReader(stream))
                {
                List<Song> songs = JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
                    foreach (var song in songs)
                    {
                        song.Name = song.Name.RuinSongName();
                    }

                    return songs;
            }
        }

        #endregion
    }
}