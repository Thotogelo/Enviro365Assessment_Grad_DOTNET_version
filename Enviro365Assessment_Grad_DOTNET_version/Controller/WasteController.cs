using System.Net;
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
    [Produces("application/json")]
    public ActionResult<Waste> GetWasteById(long id)
    {
        Waste? waste = _wasteRepository.GetWasteById(id);
        return (waste != null)
            ? Ok(waste)
            : NotFound(new ProblemDetails
            {
                Title = "Waste not found.",
                Status = (int)HttpStatusCode.NotFound,
                Instance = Request.Path.Value,
            });
    }

    [HttpGet("category/{category}")]
    [Produces("application/json")]
    public ActionResult<IEnumerator<Waste>> GetWasteListByCategory(string category)
    {
        return Ok(_wasteRepository.GetWasteListByCategory(category));
    }

    [HttpGet("data")]
    [Produces("application/json")]
    public ActionResult<IEnumerator<Waste>> GetAllWaste()
    {
        return Ok(_wasteRepository.GetAllWaste());
    }

    [HttpPost("save")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public IActionResult SaveWaste(Waste waste)
    {
        int rowsAffected = _wasteRepository.SaveWaste(waste);
        return (rowsAffected > 0)
            ? Ok(new ProblemDetails
            {
                Title = "Waste saved successfully.",
                Status = (int)HttpStatusCode.Created,
                Instance = Request.Path.Value
            })
            : BadRequest(new ProblemDetails
            {
                Title = "Waste not saved.",
                Status = (int)HttpStatusCode.NotFound,
                Instance = Request.Path.Value
            });
    }

    [HttpPut("update")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public IActionResult UpdateWaste(Waste waste)
    {
        int rowsAffected = _wasteRepository.UpdateWaste(waste);
        return (rowsAffected > 0)
            ? Ok(new ProblemDetails
            {
                Title = "Waste updated successfully.",
                Status = (int)HttpStatusCode.OK,
                Instance = Request.Path.Value
            })
            : BadRequest(new ProblemDetails
            {
                Title = "Waste not updated.",
                Status = (int)HttpStatusCode.BadRequest,
                Instance = Request.Path.Value
            });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWasteById(long id)
    {
        int rowsAffected = _wasteRepository.DeleteWasteById(id);
        if (rowsAffected > 0)
        {
            return Ok(new ProblemDetails
            {
                Title = "Waste removed successfuly.",
                Status = (int)HttpStatusCode.OK,
                Instance = Request.Path.Value
            });
        }
        else
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Waste not removed.",
                Status = (int)HttpStatusCode.NotFound,
                Instance = Request.Path.Value
            });
        }
    }

    [HttpDelete("category/{category}")]
    public IActionResult DeleteWasteListByCategory(string category)
    {
        int rowsAffected = _wasteRepository.DeleteWasteListByCategory(category);
        if (rowsAffected > 0)
        {
            return Ok(new ProblemDetails
            {
                Title = "Waste list removed successfuly.",
                Status = (int)HttpStatusCode.OK,
                Instance = Request.Path.Value
            });
        }
        else
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Waste list not removed.",
                Status = (int)HttpStatusCode.NotFound,
                Instance = Request.Path.Value
            });
        }
    }
}