using Cocona;
using GeekSevenLabs.PowerToys.YouTube;
using Sharprompt;
using YoutubeExplode.Videos.Streams;

namespace GeekSevenLabs.PowerToys.Terminal.YouTube;

internal static class YouTubeVideoDownloadCommand
{
    public const string Name = "d";
    
    public static async Task ExecuteAsync(YouTubeVideoDownloadArgs args, YoutubeDownloader downloader)
    {
        Printer.Print("Getting information about this video...", args.Url, ConsoleColor.Cyan);
        
        var info = await downloader.GetMidiaAsync(args.Url);
        
        Console.WriteLine();
        
        Printer.Print("Title", info.Title, ConsoleColor.Green);
        Printer.Print("Author", info.Author, ConsoleColor.Green);
        
        Console.WriteLine();
        
        var answer = Prompt.Confirm(
            "Do you want to download just the audio?", false
        );
        
        Console.WriteLine();
        
        IStreamInfo streamInfo = answer switch
        {
            false => Prompt.Select(
                "Select a video stream for download:", 
                info.VideoStreams,
                textSelector: v => $"{info.Title} | FORMAT :: {v.Container} | Quality :: {v.VideoQuality} | Size :: {v.Size}"
            ),
            true => Prompt.Select(
                "Select an audio stream for download:", 
                info.AudioStreams,
                textSelector: a => $"{info.Title} | FORMAT :: {a.Container} | Bitrate :: {a.Bitrate} | Size :: {a.Size}"
            )
        };
        
        Console.WriteLine();
        
        var progressBar = new ProgressBar("Downloading");
        
        var stream = await downloader.DownloadAsync(streamInfo, new Progress<double>(progressBar.Update));
        
        Console.WriteLine();
        
        var downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        var specifiedFolder = args.Output;
        
        var folder = specifiedFolder ?? downloadFolder;
        var fileName = $"{info.Title}.{streamInfo.Container}";
        
        var filePath = Path.Combine(folder, fileName);
        
        await File.WriteAllBytesAsync(filePath, stream.ToArray());
        
        Printer.Print("Download completed, file saved at", filePath, ConsoleColor.Green);
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