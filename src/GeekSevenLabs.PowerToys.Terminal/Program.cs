using Cocona;
using GeekSevenLabs.PowerToys.Terminal.Generators;
using GeekSevenLabs.PowerToys.Terminal.Validators;

var builder = CoconaApp.CreateBuilder();
var app = builder.Build();

app.AddGeneratorsCommands();
app.AddValidatorsCommands();

await app.RunAsync();