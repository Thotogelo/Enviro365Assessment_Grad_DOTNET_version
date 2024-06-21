namespace Enviro365Assessment_Grad_DOTNET_version.Exceptions;
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