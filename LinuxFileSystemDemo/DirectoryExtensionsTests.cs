using LinuxFileSystemDemo.Extensions;

namespace LinuxFileSystemDemo
{
    public class DirectoryExtensionsTests
    {
        private readonly string basePath = AppContext.BaseDirectory;
        private readonly string textFileLocation = null;
        private readonly string pdfFileLocation = null;

        public DirectoryExtensionsTests()
        {
            textFileLocation = Path.Combine(basePath, ConfigReader.GetValue("TextFilesLocation"));
            pdfFileLocation = Path.Combine(basePath, ConfigReader.GetValue("PdfFilesLocation"));
        }

        public void GetAllTextFilesByPattern()
        {
            string[] allTextFilesWindowsAllDir = Directory.GetFiles(textFileLocation, "*.txt", SearchOption.AllDirectories);
            string[] allTextFilesWindowsTopDir = Directory.GetFiles(textFileLocation, "*.txt", SearchOption.TopDirectoryOnly);

            var directory = new DirectoryInfo(textFileLocation);
            string[] allTextFilesLinuxAllDir = directory.GetFilesCI("*.txt", SearchOption.AllDirectories);
            string[] allTextFilesLinuxTopDir = directory.GetFilesCI("*.txt", SearchOption.TopDirectoryOnly);

            Console.WriteLine($"allTextFilesWindowsAllDir: {allTextFilesWindowsAllDir.Length}");
            Console.WriteLine($"allTextFilesWindowsTopDir: {allTextFilesWindowsTopDir.Length}");
            Console.WriteLine($"allTextFilesLinuxAllDir: {allTextFilesLinuxAllDir.Length}");
            Console.WriteLine($"allTextFilesLinuxTopDir: {allTextFilesLinuxTopDir.Length}");
        }

        public void GetAllPdfFilesByPattern()
        {
            string[] allPdfFilesWindowsAllDir = Directory.GetFiles(pdfFileLocation, "*.pdf", SearchOption.AllDirectories);
            string[] allPdfFilesWindowsTopDir = Directory.GetFiles(pdfFileLocation, "*.pdf", SearchOption.TopDirectoryOnly);

            var directory = new DirectoryInfo(pdfFileLocation);
            string[] allPdfFilesLinuxAllDir = directory.GetFilesCI("*.pdf", SearchOption.AllDirectories);
            string[] allPdfFilesLinuxTopDir = directory.GetFilesCI("*.pdf", SearchOption.TopDirectoryOnly);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"allPdfFilesWindowsAllDir: {allPdfFilesWindowsAllDir.Length}");
            Console.WriteLine($"allPdfFilesWindowsTopDir: {allPdfFilesWindowsTopDir.Length}");
            Console.WriteLine($"allPdfFilesLinuxAllDir: {allPdfFilesLinuxAllDir.Length}");
            Console.WriteLine($"allPdfFilesLinuxTopDir: {allPdfFilesLinuxTopDir.Length}");
        }

        public void GetDirectoryInfo()
        {
            try
            {
                var directory1 = new DirectoryInfo(pdfFileLocation);
                var pdfFiles = directory1.GetFilesCI("*.pdf");
                string[] files = pdfFiles.OrderBy(file => new FileInfo(file).CreationTime).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                string actualPath = "/app/bin/Debug/net8.0/mnt/weBvoTes".ResolvePathCI2();
                var ddd = "/app/bin/Debug/net8.0/mnt/weBvoTes".ResolvePathCI();

                var directory1 = new DirectoryInfo("/app/bin/Debug/net8.0/mnt/weBvoTes");
                var dirs = directory1.GetDirectories();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }
        }
    }
}
