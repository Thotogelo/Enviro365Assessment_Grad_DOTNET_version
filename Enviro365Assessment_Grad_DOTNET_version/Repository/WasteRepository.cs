using System.Diagnostics;
using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.DTO;
using Enviro365Assessment_Grad_DOTNET_version.Exceptions;
using Enviro365Assessment_Grad_DOTNET_version.Model;

namespace Enviro365Assessment_Grad_DOTNET_version.Repository;

public class WasteRepository
{
    private readonly DataContext _dataContext;

    public Waste ToWaste(WasteDTO wasteDto)
    {
        return new Waste()
        {
            Id = Guid.NewGuid(),
            Category = wasteDto.Category,
            Disposalguideline = wasteDto.DisposalGuideline,
            Recyclingtips = wasteDto.RecyclingTips
        };
    }

    public WasteRepository(DataContext dataContext)
        => _dataContext = dataContext;

    public Waste? GetWasteById(Guid Id)
    {
        return _dataContext.Wastes.Find(Id);
    }

    public IEnumerable<Waste> GetWasteListByCategory(string category)
    {
        return _dataContext.Wastes.Where(x => x.Category.Equals(category.ToLower()));
    }

    public IEnumerable<Waste> GetAllWaste()
    {
        return _dataContext.Wastes;
    }

    public int SaveWaste(Waste waste)
    {
        try
        {
            _dataContext.Add(waste);
            return _dataContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new WasteErrorException(e.Message);
        }
    }

    public void UpdateWaste(Waste waste)
    {
        _dataContext.Entry(waste).CurrentValues.SetValues(waste);
        _dataContext.SaveChanges();
    }

    public int DeleteWasteById(Guid id)
    {
        try
        {
            Debug.Assert(_dataContext == null, nameof(_dataContext) + " != null");
            var waste = _dataContext.Wastes.Find(id);
            if (waste != null)
                _dataContext.Wastes.Remove(waste);
            return _dataContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new WasteErrorException(e.Message);
        }
    }

    public int DeleteWasteListByCategory(string category)
    {
        _dataContext.Wastes.RemoveRange(_dataContext.Wastes.Where(x => x.Category.Equals(category.ToLower())));
        return _dataContext.SaveChanges();
    }
}