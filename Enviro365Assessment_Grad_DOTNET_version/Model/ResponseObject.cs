namespace Enviro365Assessment_Grad_DOTNET_version.Model;

public class ResponseObject
{
    public string Message { get; set; }
    public int Status { get; set; }
    public DateTime Date { get; set; }

    public ResponseObject(string Message, int Status)
    {
        this.Message = Message;
        this.Status = Status;
        this.Date = DateTime.Now;
    }

}