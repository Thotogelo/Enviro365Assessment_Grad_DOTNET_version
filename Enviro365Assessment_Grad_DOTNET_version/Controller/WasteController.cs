using System.Net;
using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.Model;
using Microsoft.AspNetCore.Mvc;

namespace Enviro365Assessment_Grad_DOTNET_version.Controller;

[ApiController]
[Route("/v1/api/[controller]")]
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

    [HttpGet("category/{category}")]
    [Produces("application/json")]
    public ActionResult<List<Waste>> GetWasteListByCategory(string category)
    {
        try
        {
            return Ok(_dataContext.Wastes.Where(x => x.Category.Equals(category.ToLower())).ToList());
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

    [HttpGet("data")]
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

    [HttpPost("save")]
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

    [HttpPut("update")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public IActionResult UpdateWaste(Waste waste)
    {
        try
        {
            var dbWaste = _dataContext.Wastes.Find(waste.Id);
            if (dbWaste == null)
                return NotFound(new ProblemDetails { Title = "Waste not found.", Status = (int)HttpStatusCode.NotFound });

            _dataContext.Entry(dbWaste).CurrentValues.SetValues(waste);
            int rowsAffected = _dataContext.SaveChanges();
            return (rowsAffected > 0)
                ? Ok(new ProblemDetails { Title = "Waste updated successfully.", Status = (int)HttpStatusCode.OK })
                : BadRequest(new ProblemDetails { Title = "Waste not updated.", Status = (int)HttpStatusCode.BadRequest });
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

    [HttpDelete("category/{category}")]
    public IActionResult DeleteWasteListByCategory(string category)
    {
        try
        {
            List<Waste> wasteList = _dataContext.Wastes.Where(x => x.Category.Equals(category.ToLower())).ToList();

            _dataContext.Wastes.RemoveRange(wasteList.ToArray());
            int rowsAffected = _dataContext.SaveChanges();
            if (rowsAffected > 0)
            {
                return Ok(new ProblemDetails
                {
                    Title = "Waste list removed successfuly.",
                });
            }
            else
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Waste list not removed.",
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