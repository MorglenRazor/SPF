using SPF.Application;
using SPF.Domain;


namespace SPF.Infrastructure;

public class CsvModRepository : IModRepository
{
    private readonly string _filePath;

    //Предаем путь к файлу при создании обьекта
    public CsvModRepository(string filePath)
    {
        _filePath = filePath;
    }

    public IEnumerable<ModInfo> GetAllMods()
    {
        if (!File.Exists(_filePath))
        {
            return Enumerable.Empty<ModInfo>();
        }

        var mods = new List<ModInfo>();

        // Читаем все строки из файла в массив строк
        var lines = File.ReadAllLines(_filePath);

        //
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            //Разбиваем строку по запятой
            var column = line.Split(',');
            // Если строка не пустая и есть хотя бы одна колонка
            if(column.Length > 0)
            {
                // Создаем наш чистый объект и заполняем его данными из массива
                var mod = new ModInfo
                {
                    NameMod = column[0]// Допустим, имя лежит в первой колонке
                    // Если в CSV есть другие колонки, мы добавим их сюда позже
                };
                mods.Add(mod);
            }
        }
        return mods;
           
    }
}