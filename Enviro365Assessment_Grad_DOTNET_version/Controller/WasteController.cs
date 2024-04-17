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
                : BadRequest(new ProblemDetails { Title = "Waste not saved.", Status = (int)HttpStatusCode.InternalServerError });
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