using System.ComponentModel.DataAnnotations;
using Cocona;
using GeekSevenLabs.PowerToys.YouTube;
using Sharprompt;
using TextCopy;
using YoutubeExplode.Videos.Streams;

namespace GeekSevenLabs.PowerToys.Terminal.YouTube;

internal static class YouTubeVideoDownloadCommand
{
    public const string Name = "d";
    
    public static async Task ExecuteAsync(YouTubeVideoDownloadArgs args, YoutubeDownloader downloader, IClipboard clipboard)
    {
        Console.WriteLine();
        Console.WriteLine();
        
        Printer.Print("Getting information about this video...", args.Url, ConsoleColor.Cyan);
        
        var info = await downloader.GetMidiaAsync(args.Url);
        
        Console.WriteLine();
        
        Printer.Print("Title", info.Title, ConsoleColor.Green);
        Printer.Print("Author", info.Author, ConsoleColor.Green);
        
        Console.WriteLine();
        
        var downloadType = Prompt.Select<DownloadType>("Select the download type");
        
        Console.WriteLine();

        var streams = downloadType switch
        {
            DownloadType.Audio => SelectAudioOnly(info.AudioStreams),
            DownloadType.Video => SelectVideoOnly(info.VideoStreams),
            DownloadType.Both => SelectBoth(info.AudioStreams, info.VideoStreams),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        Console.WriteLine();

        await DownloadAsync(args, downloader, info, streams);
        
    }

    private static IStreamInfo[] SelectAudioOnly(AudioOnlyStreamInfo[] streams)
    {
        var streamInfo = Prompt.Select(
            "Select an audio stream for download:",
            streams,
            textSelector: a =>  $"AUDIO ONLY | FORMAT :: {a.Container} | Bitrate :: {a.Bitrate} | Size :: {a.Size}");
        
        return [streamInfo];
    }
    
    private static IStreamInfo[] SelectVideoOnly(VideoOnlyStreamInfo[] streams)
    {
        var streamInfo = Prompt.Select(
            "Select a video stream for download:",
            streams,
            textSelector: v => $"VIDEO ONLY | FORMAT :: {v.Container} | Quality :: {v.VideoQuality} | Size :: {v.Size}");
        
        return [streamInfo];
    }
    
    private static IStreamInfo[] SelectBoth(AudioOnlyStreamInfo[] audioStreams, VideoOnlyStreamInfo[] videoStreams)
    {
        var audioStreamInfo = Prompt.Select(
            "Select an audio stream for combined download:",
            audioStreams,
            textSelector: a =>  $"AUDIO ONLY | FORMAT :: {a.Container} | Bitrate :: {a.Bitrate} | Size :: {a.Size}");
        
        var videoStreamInfo = Prompt.Select(
            "Select a video stream for combined download:",
            videoStreams,
            textSelector: v => $"VIDEO ONLY | FORMAT :: {v.Container} | Quality :: {v.VideoQuality} | Size :: {v.Size}");
        
        return [audioStreamInfo, videoStreamInfo];
    }
    
    private static async Task DownloadAsync(
        YouTubeVideoDownloadArgs args,
        YoutubeDownloader downloader,
        YoutubeMedia info,
        IStreamInfo[] streams)
    {
        Console.WriteLine();
        
        var downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        var specifiedFolder = args.Output;
        
        var folder = specifiedFolder ?? downloadFolder;
        var format = streams.Length is 1 ? streams[0].Container.Name : "mp4";
        var fileName = $"{FileNameCleaner(info.Title)}.{format}";
        
        var filePath = Path.Combine(folder, fileName);
        Printer.Print("Name:", fileName, ConsoleColor.Green);

        using (var progressBar = new ProgressBar("Downloading"))
        {
            await downloader.DownloadAsync(streams, filePath, new Progress<double>(progressBar.Update));
        }
        
        Printer.Print("Download completed, file saved at", filePath, ConsoleColor.Green);
    }
    
    private static string FileNameCleaner(string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        return string.Concat(fileName.Split(invalidChars));
    }
}

internal record YouTubeVideoDownloadArgs : ICommandParameterSet
{
    [Option(name: "url", shortNames: ['u'], Description = "URL of the video")]
    public required string Url { get; init; }
    
    [Option(name: "output", shortNames: ['o'], Description = "Output file")]
    [HasDefaultValue]
    public string? Output { get; init; }
}

internal enum DownloadType
{
    [Display(Name = "Audio Only")]
    Audio,
    
    [Display(Name = "Video Only")]
    Video,
    
    [Display(Name = "Combined")]
    Both
}