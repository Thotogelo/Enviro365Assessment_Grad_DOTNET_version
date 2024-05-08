using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.Model;

namespace Enviro365Assessment_Grad_DOTNET_version.Repository;

public class WasteRepository
{
    private readonly DataContext _dataContext;

    public WasteRepository(DataContext dataContext)
        => _dataContext = dataContext;

    public Waste? GetWasteById(long Id)
    {
        try
        {
            return _dataContext.Wastes.Find(Id);
        }
        catch (Exception e)
        {
            throw new WasteErrorException(e.Message);
        }
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

    public int UpdateWaste(Waste waste)
    {
        try
        {
            var dbWaste = _dataContext.Wastes.Find(waste.Id);
            if (dbWaste == null)
                return 0;

            _dataContext.Entry(dbWaste).CurrentValues.SetValues(waste);
            return _dataContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new WasteErrorException(e.Message);
        }
    }

    public int DeleteWasteById(long id)
    {
        try
        {
            var dbwaste = _dataContext.Wastes.Find(id);
            if (dbwaste == null)
                return 0;

            _dataContext.Wastes.Remove(dbwaste);
            return _dataContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new WasteErrorException(e.Message);
        }
    }

    public int DeleteWasteListByCategory(string category)
    {
        try
        {
            List<Waste> wasteList = _dataContext.Wastes.Where(x => x.Category.Equals(category.ToLower())).ToList();
            _dataContext.Wastes.RemoveRange(wasteList);
            return _dataContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new WasteErrorException(e.Message);
        }
    }
}