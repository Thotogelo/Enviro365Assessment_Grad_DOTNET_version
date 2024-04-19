using System.Net;
using Microsoft.AspNetCore.Mvc;


namespace Enviro365Assessment_Grad_DOTNET_version;
public class WasteError : Exception
{
    public WasteError()
    {
    }

    public WasteError(string message) : base(message)
    {
    }

    public WasteError(string message, Exception inner) : base(message, inner)
    {
    }
}