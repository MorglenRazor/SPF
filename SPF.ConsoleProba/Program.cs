// Путь к файлу со списком модов
using SPF.Application;
using SPF.Infrastructure;

string pathToModList = "../OuterFile/mods.csv";
// 1. Настройка (Dependency Injection на минималках)
// Мы создаем конкретный объект из слоя Инфраструктуры, но общаться с ним будем через Интерфейс
// Было: IModRepository repository = new FakeModRepository();
IModRepository repository = new CsvModRepository(pathToModList);

// 2. Выполнение бизнес-логики
// Просим репозиторий отдать нам моды. Консоль не знает, откуда они берутся (из файла, сети или заглушки).
var mods = repository.GetAllMods();

Console.WriteLine("=== Начинаем сетевой поиск модов ===");

// 3. Проходимся по списку и стучимся в сеть для каждого мода
Console.WriteLine("=== Найденные моды ===");
foreach (var mod in mods)
{
    Console.WriteLine($"Ищем мод: {mod.NameMod}");
    string result = await new NexusScraper().CheckModInNetworkAsync(mod);
    Console.WriteLine(result);
}
Console.WriteLine("======================");

Console.WriteLine("\nНажми любую клавишу для выхода...");
Console.ReadKey();