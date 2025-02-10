// See https://aka.ms/new-console-template for more information

using GeekSevenLabs.PowerToys.YouTube;
using YoutubeExplode;

Console.WriteLine("Hello, World!");


var youtube = new YoutubeClient();
var downloader = new YoutubeDownloader(youtube);

// https://www.youtube.com/watch?v=6riEEfFmtFg&list=RDfhyaIJNyR_w&index=27
const string neemias = "https://www.youtube.com/watch?v=wFvYrXtXQAQ";

var info = await downloader.GetMidiaAsync(neemias);

