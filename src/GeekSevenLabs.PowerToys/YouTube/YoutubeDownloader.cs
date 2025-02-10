using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace GeekSevenLabs.PowerToys.YouTube;

public class YoutubeDownloader(YoutubeClient youtube)
{
    public async Task<YoutubeMedia> GetMidiaAsync(string videoUrl)
    {
        var info = await youtube.Videos.GetAsync(videoUrl);
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(info.Id);
        
        var videos = streamManifest.GetVideoOnlyStreams().ToArray();
        var audios = streamManifest.GetAudioOnlyStreams().ToArray();

        return new YoutubeMedia
        {
            Title = info.Title,
            Author = info.Author.ChannelTitle,
            Description = info.Description,
            Thumbnail = info.Thumbnails.MaxBy(e => e.Resolution.Area)?.Url ?? string.Empty,
            AudioStreams = audios,
            VideoStreams = videos
        };
    }

    public async Task<MemoryStream> DownloadAsync(IStreamInfo streamInfo, IProgress<double> progress)
    {
        var memoryStream = new MemoryStream();
        await youtube.Videos.Streams.CopyToAsync(streamInfo, memoryStream, progress);
        memoryStream.Position = 0;
        return memoryStream;
    }
}