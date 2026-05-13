// Путь к файлу со списком модов
string pathToModList = "../OuterFile/mods.csv";

// Создаем объект FileInfo для получения информации о файле
FileInfo fileInf = new FileInfo(pathToModList);

// Проверяем, существует ли файл по указанному пути
if (fileInf.Exists)
{
    Console.WriteLine("File content:");
    // Читаем все строки из файла в массив строк
    string[] lines = File.ReadAllLines(pathToModList);
    
    // Перебираем каждую строку в массиве и выводим её в консоль
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
}
else
{
    // Выводим сообщение, если файл не найден
    Console.WriteLine("File not found.");
}