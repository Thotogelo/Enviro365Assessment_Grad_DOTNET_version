using System.Net;
using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Enviro365Assessment_Grad_DOTNET_version.Controller;

[ApiController]
[Route("/api/[controller]")]
public class WasteController : ControllerBase
{
    private readonly DataContext _dataContext;

    public WasteController(DataContext dataContext) =>
        _dataContext = dataContext;


    [HttpPost]
    [Produces("application/json")]
    public ActionResult<ResponseObject> SaveWaste(Waste waste)
    {
        try
        {
            _dataContext.Add(waste);
            int rowsAffected = _dataContext.SaveChanges();
            return (rowsAffected > 0) ? new ResponseObject("Waste saved successfully.", 200) : new ResponseObject("Waste not saved.", 400);
        }
        catch (Exception e)
        {
            return new ResponseObject(e.Message, (int)HttpStatusCode.InternalServerError);
        }
    }
}