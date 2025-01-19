using Microsoft.AspNetCore.Components;

namespace GeekSevenLabs.PowerToys.WebApp.Components;

public class GslComponentBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = [];

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }
}