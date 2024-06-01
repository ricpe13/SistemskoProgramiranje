using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
    static void Main()
    {
        Cache.cacheCleanupTimer.Elapsed += (sender, e) => Cache.CacheCleanup();
        HttpServer.StartServer();
    }

    public static void ProcessRequest(object state)
    {
        HttpListenerContext context = (HttpListenerContext)state;
        string query = context.Request.RawUrl.Substring(1);
        if (string.IsNullOrEmpty(query))
        {
            byte[] buffer = Encoding.UTF8.GetBytes("<html><body>Unesi parametar.</body></html>");
            context.Response.ContentLength64 = buffer.Length;
            context.Response.ContentType = "text/html";
            Stream output = context.Response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            return;
        }
        string responseString = Artwork.GetArtworks(query);

        byte[] buffer2 = Encoding.UTF8.GetBytes(responseString);
        context.Response.ContentLength64 = buffer2.Length;
        context.Response.ContentType = "text/html";
        Stream output2 = context.Response.OutputStream;
        output2.Write(buffer2, 0, buffer2.Length);
        output2.Close();
    }
}
