using GeekSevenLabs.PowerToys.WebApp;
using GeekSevenLabs.PowerToys.WebApp.Services;
using GeekSevenLabs.PowerToys.YouTube;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using YoutubeExplode;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<YoutubeClient>(sp => new YoutubeClient(sp.GetRequiredService<HttpClient>()));
builder.Services.AddScoped<YoutubeDownloader>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped<IClipboardService, ClipboardService>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

var app = builder.Build();


await app.RunAsync();
