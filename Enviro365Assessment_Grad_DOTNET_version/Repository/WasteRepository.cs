using Enviro365Assessment_Grad_DOTNET_version.Data;
using Enviro365Assessment_Grad_DOTNET_version.Model;

namespace Enviro365Assessment_Grad_DOTNET_version.Repository;

public class WasteRepository : IWasteRepository
{
    private readonly DataContext _dataContext;

    public WasteRepository(DataContext dataContext) =>
        _dataContext = dataContext;

    public Waste GetWasteById(long Id)
    {
        try
        {
            return _dataContext.Wastes.Find(Id);
        }
        catch (Exception e)
        {
            throw new WasteError(e.Message);
        }
    }

    public List<Waste> GetWasteListByCategory(string category)
    {
        try
        {
            return _dataContext.Wastes.Where(x => x.Category.Equals(category.ToLower())).ToList();
        }
        catch (Exception e)
        {
            throw new WasteError(e.Message);
        }
    }

    public List<Waste> GetAllWaste()
    {
        try
        {
            return _dataContext.Wastes.ToList();
        }
        catch (Exception e)
        {
            throw new WasteError(e.Message);
        }
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
            throw new WasteError(e.Message);
        }
    }

    //TODO Not correlty implemented
    public int UpdateWaste(Waste waste)
    {
        try
        {
            var dbWaste = _dataContext.Wastes.Find(waste.Id);
            _dataContext.Entry(dbWaste).CurrentValues.SetValues(waste);
            int rowsAffected = _dataContext.SaveChanges();
            return rowsAffected;
        }
        catch (Exception e)
        {
            throw new WasteError(e.Message);
        }
    }

    public int DeleteWasteById(long id)
    {
        try
        {
            Waste? dbwaste = _dataContext.Wastes.Find(id);

            _dataContext.Wastes.Remove(dbwaste);
            int rowsAffected = _dataContext.SaveChanges();
            return rowsAffected;
        }
        catch (Exception e)
        {
            throw new WasteError(e.Message);
        }
    }

    public int DeleteWasteListByCategory(string category)
    {
        try
        {
            List<Waste> wasteList = _dataContext.Wastes.Where(x => x.Category.Equals(category.ToLower())).ToList();

            _dataContext.Wastes.RemoveRange(wasteList);
            int rowsAffected = _dataContext.SaveChanges();
            return rowsAffected;
        }
        catch (Exception e)
        {
            throw new WasteError(e.Message);
        }
    }
}