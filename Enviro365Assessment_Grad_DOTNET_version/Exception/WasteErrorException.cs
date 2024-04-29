using System.Net;
using Microsoft.AspNetCore.Mvc;


namespace Enviro365Assessment_Grad_DOTNET_version;
public class WasteErrorException : Exception
{
    public WasteErrorException()
    {
    }

    public WasteErrorException(string message) : base(message)
    {
    }

    public WasteErrorException(string message, Exception inner) : base(message, inner)
    {
    }
}