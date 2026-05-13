using SPF.Domain;

namespace SPF.Application;
public interface IModRepository
{
    public IEnumerable<ModInfo> GetAllMods();    
}