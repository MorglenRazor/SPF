


using SPF.Application;
using SPF.Domain;

namespace SPF.Infrastructure;

public class NexusScraper : IPatchFinderService
{
    private readonly HttpClient _httpClient;

    public NexusScraper()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
    }

    public async Task<string> CheckModInNetworkAsync(ModInfo mod)
    {
        string safeQuery = Uri.EscapeDataString(mod.NameMod);
        string searchUrl = $"https://www.nexusmods.com/games/skyrimspecialedition/search?keyword={safeQuery}";

        try
        {
            //стучимся в нексус
            HttpResponseMessage response = await _httpClient.GetAsync(searchUrl);
            return $"[{response.StatusCode}] Ссылка: {searchUrl}";
        }
        catch (HttpRequestException ex)
        {
            return $"Ошибка сети: {ex.Message}";
        }
    }
}