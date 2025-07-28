namespace LinuxFileSystemDemo.Extensions
{
    public static class FileExtensions
    {
        public static bool ExistsCI(this FileInfo file)
        {
            var dir = file.Directory;
            if (dir == null || !dir.Exists) return false;

            return dir.EnumerateFiles()
                      .Any(f => f.Name.Equals(file.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
