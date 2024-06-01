using System.Collections.Generic;

public class ArtworkResponse
{
    public List<Artwork> data { get; set; }

    public ArtworkResponse()
    {
        data = new List<Artwork>();
    }
}
