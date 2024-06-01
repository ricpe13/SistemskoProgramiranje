using System;
using System.Net;
using System.Threading;

class HttpServer
{
    public static WebClient client = new WebClient();


    public static void StartServer()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:5000/");
        listener.Start();
        Console.WriteLine("Server je pokrenut");
        Console.WriteLine("http://localhost:5000/");
       

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Program.ProcessRequest), context);
        }
    }
}
