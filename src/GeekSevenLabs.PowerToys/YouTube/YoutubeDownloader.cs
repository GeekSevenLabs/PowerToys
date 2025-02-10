using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace GeekSevenLabs.PowerToys.YouTube;

public class YoutubeDownloader(YoutubeClient youtube)
{
    public async Task<YoutubeMedia> GetMidiaAsync(string videoUrl)
    {
        var info = await youtube.Videos.GetAsync(videoUrl);
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(info.Id);

        var videosOnly = streamManifest.GetVideoOnlyStreams().ToArray();
        var audiosOnly = streamManifest.GetAudioOnlyStreams().ToArray();
        
        return new YoutubeMedia
        {
            Title = info.Title,
            Author = info.Author.ChannelTitle,
            Description = info.Description,
            Thumbnail = info.Thumbnails.MaxBy(e => e.Resolution.Area)?.Url ?? string.Empty,
            AudioStreams = audiosOnly,
            VideoStreams = videosOnly,
        };
    }

    public async Task DownloadAsync(IStreamInfo[] streams, string output, IProgress<double> progress)
    {
        await youtube.Videos.DownloadAsync(
            streams, 
            new ConversionRequestBuilder(output).Build(),
            progress
        );
    }
}