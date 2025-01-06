namespace GM.TaskHW
{
    public static class TextAnalyzer
    {
        /// <summary>Подсчет всех пробелов в каталоге </summary>
        /// <param name="directoryPath">Путь к каталогу</param>
        /// <returns>Возвращаем количество пробелов</returns>
        public static async Task<int> CountSpacesInDirectoryAsync(string directoryPath)
        {
            if (String.IsNullOrEmpty(directoryPath))
                throw new ArgumentException("Путь не указан.");
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException("Попытка доступа к пути, отсутствующему на диске.");

            var files = Directory.GetFiles(directoryPath);         
            var tasks = files.Select(CountSpacesInFileAsync);
            var results = await Task.WhenAll(tasks);

            return results.Sum();
        }

        /// <summary>Метод для подсчета количество пробелов в файле</summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Подсчет количества пробелов</returns>
        private static async Task<int> CountSpacesInFileAsync(string filePath)
        {
            string content = await File.ReadAllTextAsync(filePath);

            return content.Count(char.IsWhiteSpace);
        }
    }
}
