using LinuxFileSystemDemo.Extensions;

namespace LinuxFileSystemDemo
{
    public class DirectoryExtensionsTests
    {
        private readonly string basePath = AppContext.BaseDirectory;
        private readonly string textFileLocation = null;
        private readonly string pdfFileLocation = null;
        private readonly string id = Guid.NewGuid().ToString();

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

        public void DirectoryCaseSensivityTest()
        {
            try
            {
                string path1 = "temp111111";
                string path2 = "TEMP111111";
                string path3 = "TeMp111111";
                string path4 = "Temp111111";

                Console.WriteLine("============================Started DirectoryCaseSensivityTest===================");

                if (Directory.Exists(path1))
                {
                    Console.WriteLine($"Directory '{path1}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path1}' does not exist.");
                }
                Directory.CreateDirectory(path1);

                path2 = path2.ResolvePathCI();

                if (Directory.Exists(path2))
                {
                    Console.WriteLine($"Directory '{path2}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path2}' does not exist.");
                }
                Directory.CreateDirectory(path2);

                path3 = path3.ResolvePathCI();
                if (Directory.Exists(path3))
                {
                    Console.WriteLine($"Directory '{path3}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path3}' does not exist.");
                }
                Directory.CreateDirectory(path3);

                if (Directory.Exists(path4))
                {
                    Console.WriteLine($"Directory '{path4}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path4}' does not exist.");
                }
                Directory.CreateDirectory(path4);

                Console.WriteLine("============================Ended DirectoryCaseSensivityTest===================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directories: {ex.ToString()}");
            }
        }

        public void DirectoryCaseSensivityTest2()
        {
            try
            {
                string path1 = $"temp222222/DNC/{id}";
                string path2 = $"TEMP222222/dnc/{id}";
                string path3 = $"TeMp222222/Dnc/{id}";
                string path4 = $"Temp222222/dNc/{id}";

                Console.WriteLine("============================Started DirectoryCaseSensivityTest===================");

                if (Directory.Exists(path1))
                {
                    Console.WriteLine($"Directory '{path1}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path1}' does not exist.");
                }
                Directory.CreateDirectory(path1);

                path2 = path2.ResolvePathCI();
                if (Directory.Exists(path2))
                {
                    Console.WriteLine($"Directory '{path2}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path2}' does not exist.");
                }
                Directory.CreateDirectory(path2);

                path3 = path3.ResolvePathCI();
                if (Directory.Exists(path3))
                {
                    Console.WriteLine($"Directory '{path3}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path3}' does not exist.");
                }
                Directory.CreateDirectory(path3);

                path4 = path4.ResolvePathCI();
                if (Directory.Exists(path4))
                {
                    Console.WriteLine($"Directory '{path4}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path4}' does not exist.");
                }
                Directory.CreateDirectory(path4);

                Console.WriteLine("============================Ended DirectoryCaseSensivityTest===================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directories: {ex.ToString()}");
            }
        }

        public void GetDirectoryInfoTest()
        {
            string path1 = "temp111111";
            string path2 = "TEMP111111";
            string path3 = "TeMp111111";
            try
            {
                var dir1 = new DirectoryInfo(path1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                var dir1 = new DirectoryInfo(path2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                var dir1 = path3.GetDirCI();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            string path11 = $"temp222222/DNC/{id}";
            string path22 = $"TEMP222222/dnc/{id}";
            string path33 = $"TeMp222222/Dnc/{id}";

            try
            {
                var dir1 = new DirectoryInfo(path11);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                var dir1 = path22.GetDirCI();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                var dir1 = new DirectoryInfo(path33);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }
        }
    }
}
