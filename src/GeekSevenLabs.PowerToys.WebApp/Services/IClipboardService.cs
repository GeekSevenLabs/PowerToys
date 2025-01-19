using Microsoft.JSInterop;

namespace GeekSevenLabs.PowerToys.WebApp.Services;

public interface IClipboardService
{
    Task WriteTextAsync(string text);
}

public class ClipboardService(IJSRuntime js) : IClipboardService
{
    public async Task WriteTextAsync(string text)
    {
        await js.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}   