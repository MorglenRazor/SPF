using SPF.Application;
using SPF.Domain;

namespace SPF.Infrastructure;

public class FakeModRepository : IModRepository
{
    public IEnumerable<ModInfo> GetAllMods()
    {
        return new List<ModInfo>
        {
            new ModInfo {NameMod = "Mod1"},
            new ModInfo {NameMod = "Mod2"},
            new ModInfo {NameMod = "Mod3"}
        };
    }
}       