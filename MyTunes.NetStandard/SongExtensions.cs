//using System.Net.Http;

namespace MyTunes
{
    public static class SongExtensions
    {
        //public static HttpClient httpClient = new HttpClient();

        public static string RuinSongName(this string str)
        {
            return str.Replace("Crocodile", "Alligator");
        }
    }
}