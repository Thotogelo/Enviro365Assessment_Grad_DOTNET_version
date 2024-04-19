using Enviro365Assessment_Grad_DOTNET_version.Model;

namespace Enviro365Assessment_Grad_DOTNET_version.Repository;

public class WasteRepository : IWasteRepository
{
    public Waste GetWasteById(long Id)
    {
        throw new NotImplementedException();
    }

    public List<Waste> GetWasteListByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public List<Waste> GetAllWaste()
    {
        throw new NotImplementedException();
    }

    public int SaveWaste(Waste waste)
    {
        throw new NotImplementedException();
    }

    public int UpdateWaste(Waste waste)
    {
        throw new NotImplementedException();
    }

    public int DeleteWasteById(long id)
    {
        throw new NotImplementedException();
    }

    public int DeleteWasteListByCategory(string category)
    {
        throw new NotImplementedException();
    }
}