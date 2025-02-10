using Cocona;
using GeekSevenLabs.PowerToys.Terminal.Generators;
using GeekSevenLabs.PowerToys.Terminal.Validators;
using GeekSevenLabs.PowerToys.Terminal.YouTube;
using GeekSevenLabs.PowerToys.YouTube;
using Microsoft.Extensions.DependencyInjection;
using YoutubeExplode;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddScoped<YoutubeClient>();
builder.Services.AddScoped<YoutubeDownloader>();

var app = builder.Build();

app.AddGeneratorsCommands();
app.AddValidatorsCommands();
app.AddYouTubeCommands();

await app.RunAsync();