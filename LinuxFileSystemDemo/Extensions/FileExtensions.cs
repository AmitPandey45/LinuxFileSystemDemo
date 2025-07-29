namespace LinuxFileSystemDemo.Extensions
{
    public static class FileExtensions
    {
        public static string? ResolveFilePathCI(
            this string inputPath,
            SearchOption searchOption = SearchOption.TopDirectoryOnly,
            MatchCasing matchCasing = MatchCasing.CaseInsensitive,
            bool ignoreInaccessible = false)
        {
            if (string.IsNullOrEmpty(inputPath))
                return null;

            inputPath = Path.GetFullPath(inputPath); // Normalize

            var directoryPath = Path.GetDirectoryName(inputPath);
            var fileName = Path.GetFileName(inputPath);

            if (string.IsNullOrEmpty(directoryPath) || string.IsNullOrEmpty(fileName))
                return null;

            var resolvedDirectoryPath = directoryPath.ResolveDirectoryCI(); // Custom method to resolve dir CI
            if (string.IsNullOrEmpty(resolvedDirectoryPath))
                return null;

            var file = new DirectoryInfo(resolvedDirectoryPath)
                .EnumerateFiles(fileName, new EnumerationOptions
                {
                    MatchCasing = matchCasing,
                    RecurseSubdirectories = searchOption == SearchOption.AllDirectories,
                    IgnoreInaccessible = ignoreInaccessible
                })
                .FirstOrDefault();

            return file?.FullName;
        }

        /// <summary>
        /// Resolves a file path to a case-insensitive match if it exists.
        /// </summary>
        public static FileInfo? GetFileInfoCI(this string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            var resolvedPath = path.ResolveFilePathCI();
            if (string.IsNullOrEmpty(resolvedPath) || !File.Exists(resolvedPath))
                return null;

            return new FileInfo(resolvedPath);
        }

        /// <summary>
        /// Returns true if the file exists in a case-insensitive manner.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>True if file exists (case-insensitive); otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if file is null.</exception>
        /// <exception cref="ArgumentException">Thrown if file path is empty or directory is missing.</exception>
        public static bool ExistsCI(this FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            return File.Exists(file.FullName);
        }

        /// <summary>
        /// Deletes the file if it exists (case-insensitive).
        /// </summary>
        /// <param name="file">The file to delete.</param>
        /// <exception cref="ArgumentNullException">Thrown if file is null.</exception>
        /// <exception cref="ArgumentException">Thrown if file path is invalid.</exception>
        /// <exception cref="FileNotFoundException">Thrown if file does not exist.</exception>
        public static void DeleteCI(this FileInfo file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            File.Delete(file.FullName);
        }
    }
}
