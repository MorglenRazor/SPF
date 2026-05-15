using SPF.Domain;

namespace SPF.Application;
public interface IPatchFinderService
{
    //
    Task<string> CheckModInNetworkAsync(ModInfo mod);
}