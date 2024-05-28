using System;
using System.Net;
using Newtonsoft.Json;

public class Artwork
{
    public string title { get; set; }
    public string api_link { get; set; }

    public static string GetArtworks(string query)
    {
        query = query.Replace('_', ' ');

        if (Cache.cache.ContainsKey(query))
        {
            return Cache.cache[query];
        }

        try
        {
            string url = $"https://api.artic.edu/api/v1/artworks/search?q={query}&limit=100";
            string responseBody;
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                responseBody = client.DownloadString(url);
            }
            var artworkResponse = JsonConvert.DeserializeObject<ArtworkResponse>(responseBody);
            if (artworkResponse.data.Count == 0)
            {
                return "<html><body>Greska: Nema umetnickih dela koja zadovoljavaju vasu pretragu.</body></html>";
            }
            string result = "<html><body>";
            foreach (var artwork in artworkResponse.data)
            {
                result += $"<p>{artwork.title}</p>";
            }
            result += "</body></html>";

            Cache.cache.Add(query, result);

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "<html><body>Error.</body></html>";
        }
    }
}
