using Enviro365Assessment_Grad_DOTNET_version.Model;

namespace Enviro365Assessment_Grad_DOTNET_version.Repository;

public interface IWasteRepository
{
    Waste? GetWasteById(long Id);

    List<Waste> GetWasteListByCategory(string category);

    List<Waste> GetAllWaste();

    int SaveWaste(Waste waste);

    int UpdateWaste(Waste waste);

    int DeleteWasteById(long id);

    int DeleteWasteListByCategory(string category);
}