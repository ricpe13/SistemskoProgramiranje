using System.Collections.Generic;

class Cache
{
    public static int cacheIsEmpty = 0;
    public static readonly Dictionary<string, string> cache = new Dictionary<string, string>();

    public static readonly System.Timers.Timer cacheCleanupTimer = new System.Timers.Timer(TimeSpan.FromMinutes(10).TotalMilliseconds);
    public static void CacheCleanup()
    {
        Console.WriteLine("Brisem kes");
        Cache.cache.Clear();
        cacheIsEmpty = 0; ;

        if (cacheIsEmpty == 0)
        {
            Console.WriteLine("Kes je prazan");
            cacheCleanupTimer.Stop();
            Console.WriteLine("Stopiran je tajmer");
        }
    }

}
