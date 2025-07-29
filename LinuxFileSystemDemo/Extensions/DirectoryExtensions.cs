namespace LinuxFileSystemDemo.Extensions
{
    public static class DirectoryExtensions
    {
        public static DirectoryInfo? GetDirCI(this string path)
        {
            var resolvedPath = ResolveDirectoryCI(path);
            if (string.IsNullOrEmpty(resolvedPath) || !Directory.Exists(resolvedPath))
                return null;

            return new DirectoryInfo(resolvedPath);
        }

        public static void DeleteCI(this DirectoryInfo dir)
        {
            if (dir == null)
                throw new ArgumentNullException(nameof(dir));

            if (!dir.Exists)
                return;

            try
            {
                dir.Delete(recursive: true);
            }
            catch (IOException ex)
            {
                // Optionally rethrow or log based on your app needs
                throw new IOException($"Failed to delete directory '{dir.FullName}'.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException($"Access denied to directory '{dir.FullName}'.", ex);
            }
        }

        public static string[] GetFilesCI(
            this DirectoryInfo directory,
            string searchPattern,
            SearchOption option = SearchOption.TopDirectoryOnly,
            MatchCasing matchCasing = MatchCasing.CaseInsensitive,
            bool ignoreInaccessible = false)
        {
            if (directory == null)
            {
                throw new ArgumentNullException(nameof(directory));
            }

            if (string.IsNullOrWhiteSpace(searchPattern))
            {
                throw new ArgumentException("Search pattern must not be null or whitespace.", nameof(searchPattern));
            }

            var opts = new EnumerationOptions
            {
                MatchCasing = matchCasing,
                RecurseSubdirectories = option == SearchOption.AllDirectories,
                IgnoreInaccessible = ignoreInaccessible // Optional: helps with permission issues
            };

            return directory.GetFiles(searchPattern, opts)
                .Select(f => f.FullName)
                .ToArray();
        }

        public static bool FileExistsCI(this DirectoryInfo directory, string fileName)
        {
            if (directory == null)
            {
                throw new ArgumentNullException(nameof(directory));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name must not be null or whitespace.", nameof(fileName));
            }

            return directory.EnumerateFiles()
                .Any(file => file.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
        }

        public static FileInfo? GetFileCI(this DirectoryInfo directory, string fileName)
        {
            if (directory == null)
            {
                throw new ArgumentNullException(nameof(directory));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name must not be null or whitespace.", nameof(fileName));
            }

            return directory.EnumerateFiles()
                .FirstOrDefault(file => file.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));
        }

        public static string ResolveDirectoryCI(this string inputPath)
        {
            if (string.IsNullOrWhiteSpace(inputPath))
                return null;

            inputPath = Path.GetFullPath(inputPath); // Normalize path, important on Windows

            var parts = inputPath.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            string root = Path.GetPathRoot(inputPath) ?? string.Empty;

            if (string.IsNullOrEmpty(root))
                return null;

            string currentPath = root;

            foreach (var part in parts.SkipWhile(p => p.Equals(root.TrimEnd(Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase)))
            {
                if (!Directory.Exists(currentPath))
                    return null;

                var match = new DirectoryInfo(currentPath)
                    .EnumerateDirectories("*", new EnumerationOptions
                    {
                        MatchCasing = MatchCasing.CaseInsensitive,
                        RecurseSubdirectories = false
                    })
                    .FirstOrDefault(d => d.Name.Equals(part, StringComparison.OrdinalIgnoreCase));

                if (match == null)
                    return null;

                currentPath = match.FullName;
            }

            return currentPath;
        }

        public static string ResolvePathCI2(this string inputPath)
        {
            var parts = inputPath.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

            string currentPath = Path.IsPathRooted(inputPath)
                ? Path.DirectorySeparatorChar.ToString()
                : "";

            foreach (var part in parts)
            {
                var dir = new DirectoryInfo(currentPath);
                if (!dir.Exists) return null;

                var match = dir.GetDirectories("*", new EnumerationOptions
                {
                    MatchCasing = MatchCasing.CaseInsensitive
                }).FirstOrDefault(d => d.Name.Equals(part, StringComparison.OrdinalIgnoreCase));

                if (match == null)
                    return null;

                currentPath = Path.Combine(currentPath, match.Name);
            }

            return currentPath;
        }
    }
}
