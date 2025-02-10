using Cocona;

namespace GeekSevenLabs.PowerToys.Terminal.YouTube;

public static class YouTubeCommandsExtensions
{
    public static void AddYouTubeCommands(this CoconaApp app)
    {
        app.AddSubCommand("youtube", builder =>
            {
                builder.AddCommand(YouTubeVideoDownloadCommand.Name, YouTubeVideoDownloadCommand.ExecuteAsync).WithDescription("Download a YouTube video");
            })
            .WithDescription("YouTube Downloader commands");
    }
}