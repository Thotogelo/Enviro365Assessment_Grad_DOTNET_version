using Enviro365Assessment_Grad_DOTNET_version.DTO;
using Enviro365Assessment_Grad_DOTNET_version.Model;
using Enviro365Assessment_Grad_DOTNET_version.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Enviro365Assessment_Grad_DOTNET_version.Controller;

[ApiController]
[Route("/v1/api/[controller]")]
public class WasteController : ControllerBase
{
    private readonly WasteRepository _wasteRepository;

    public WasteController(WasteRepository wasteRepository)
        => _wasteRepository = wasteRepository;

    [HttpGet("{id}")]
    public ActionResult<Waste> GetWasteById(Guid id)
    {
        Waste? waste = _wasteRepository.GetWasteById(id);
        if (waste != null)
            return Ok(waste);
        else
            return NotFound();
    }

    [HttpGet("category/{category}")]
    public ActionResult<IEnumerator<Waste>> GetWasteListByCategory(string category)
    {
        return Ok(_wasteRepository.GetWasteListByCategory(category));
    }

    [HttpGet("data")]
    public ActionResult<IEnumerable<Waste>> GetAllWaste()
    {
        return Ok(_wasteRepository.GetAllWaste());
    }

    [HttpPost("save")]
    public IActionResult SaveWaste([FromBody] WasteDTO waste)
    {
        return Ok(_wasteRepository.SaveWaste(_wasteRepository.ToWaste(waste)));
    }

    [HttpPut("update")]
    public IActionResult UpdateWaste(WasteDTO waste)
    {
        _wasteRepository.UpdateWaste(_wasteRepository.ToWaste(waste));
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWasteById(Guid id)
    {
        _wasteRepository.DeleteWasteById(id);
        return NoContent();
    }

    [HttpDelete("category/{category}")]
    public IActionResult DeleteWasteListByCategory(string category)
    {
        _wasteRepository.DeleteWasteListByCategory(category);
        return NoContent();
    }
}