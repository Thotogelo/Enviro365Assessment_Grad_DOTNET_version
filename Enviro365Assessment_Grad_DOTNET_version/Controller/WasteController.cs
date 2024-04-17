using System.Net;
using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.Model;
using Microsoft.AspNetCore.Mvc;

namespace Enviro365Assessment_Grad_DOTNET_version.Controller;

[ApiController]
[Route("/api/[controller]")]
public class WasteController : ControllerBase
{
    private readonly DataContext _dataContext;

    public WasteController(DataContext dataContext) =>
        _dataContext = dataContext;

    [HttpGet("{id}")]
    [Produces("application/json")]
    public ActionResult<Waste> GetWasteById(long id)
    {
        try
        {
            var waste = _dataContext.Wastes.Find(id);
            return (waste != null) ? Ok(waste) :
                NotFound(new ProblemDetails
                {
                    Title = "Waste not found.",
                    Status = (int)HttpStatusCode.NotFound
                });
        }
        catch (Exception e)
        {
            return BadRequest(new ProblemDetails
            {
                Title = e.Message,
                Status = (int)HttpStatusCode.InternalServerError
            });
        }
    }

    [HttpGet]
    [Produces("application/json")]
    public ActionResult<List<Waste>> GetAllWaste()
    {
        try
        {
            return _dataContext.Wastes.ToList<Waste>();
        }
        catch (Exception e)
        {
            return BadRequest(new ProblemDetails
            {
                Title = e.Message,
                Status = (int)HttpStatusCode.InternalServerError
            });
        }
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public IActionResult SaveWaste(Waste waste)
    {
        try
        {
            _dataContext.Add(waste);
            int rowsAffected = _dataContext.SaveChanges();
            return (rowsAffected > 0)
                ? Ok(new ProblemDetails { Title = "Waste saved successfully.", Status = (int)HttpStatusCode.Created })
                : BadRequest(new ProblemDetails
                { Title = "Waste not saved.", Status = (int)HttpStatusCode.InternalServerError });
        }
        catch (Exception e)
        {
            return BadRequest(new ProblemDetails
            {
                Title = e.Message,
                Status = (int)HttpStatusCode.InternalServerError
            });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteWasteById(long id)
    {
        try
        {
            Waste? dbwaste = _dataContext.Wastes.Find(id);
            if (dbwaste == null)
                return NotFound();

            _dataContext.Wastes.Remove(dbwaste);
            int rowsAffected = _dataContext.SaveChanges();
            if (rowsAffected > 0)
            {
                return Ok(new ProblemDetails
                {
                    Title = "Waste removed successfuly.",
                });
            }
            else
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Waste not removed.",
                });
            }
        }
        catch (Exception e)
        {
            return BadRequest(new ProblemDetails
            {
                Title = e.Message,
                Status = (int)HttpStatusCode.InternalServerError
            });
        }
    }
}