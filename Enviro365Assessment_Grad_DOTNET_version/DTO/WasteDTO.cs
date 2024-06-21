using Enviro365Assessment_Grad_DOTNET_version.Model;

namespace Enviro365Assessment_Grad_DOTNET_version.DTO;

public class WasteDTO
{
    public string Category { get; set; }
    public string DisposalGuideline { get; set; }
    public string RecyclingTips { get; set; }

    public WasteDTO()
    {
    }
}