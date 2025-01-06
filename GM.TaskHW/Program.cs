using System.Diagnostics;

namespace GM.TaskHW
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string testFilesDir = Path.GetFullPath(@"..\..\..\restFiles");

            Console.WriteLine($"Поиск файлов в папке:  {testFilesDir}");
            Console.WriteLine();

            var stopwatch = Stopwatch.StartNew();
            try
            {
                int totalSpaces = await TextAnalyzer.CountSpacesInDirectoryAsync(testFilesDir);
                stopwatch.Stop();
                Console.WriteLine($"Всего пробелов: {totalSpaces}");
                Console.WriteLine($"Затраченное время: {stopwatch.ElapsedMilliseconds} ms");
            }
           
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch ( DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception) 
            {
                Console.WriteLine("Не предвиденная ошибка");
            }
           
        }
    }
}
