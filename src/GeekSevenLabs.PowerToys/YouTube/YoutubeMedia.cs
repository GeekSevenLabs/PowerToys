using YoutubeExplode.Videos.Streams;

namespace GeekSevenLabs.PowerToys.YouTube;

public class YoutubeMedia
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Author { get; init; }
    public required string Thumbnail { get; init; }
    
    public required VideoOnlyStreamInfo[] VideoStreams { get; init; }
    public required AudioOnlyStreamInfo[] AudioStreams { get; init; }
    
}