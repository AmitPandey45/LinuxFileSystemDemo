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
                var dir11 = "C:/MnT/wEBVotes".ResolveDirectoryCI();
                var dir1 = new DirectoryInfo(dir11);
                var dir1List = dir1.GetDirectories();

                var dir22 = "C:/MnT/wEBVotes";
                var dir2 = new DirectoryInfo(dir22);
                var dir2List = dir2.GetDirectories();

                string actualPath = "/bin/Debug/net8.0/mnt/weBvoTes".ResolveDirectoryCI();
                var ddd = "/bin/Debug/net8.0/mnt/weBvoTes".ResolveDirectoryCI();

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
                string path4 = "Temp111112"; // to solve delete file because there are two folder created with same name only case sensitivity difference

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

                path2 = path2.ResolveDirectoryCI();

                if (Directory.Exists(path2))
                {
                    Console.WriteLine($"Directory '{path2}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path2}' does not exist.");
                }
                Directory.CreateDirectory(path2);

                path3 = path3.ResolveDirectoryCI();
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

                path2 = path2.ResolveDirectoryCI();
                if (Directory.Exists(path2))
                {
                    Console.WriteLine($"Directory '{path2}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path2}' does not exist.");
                }
                Directory.CreateDirectory(path2);

                path3 = path3.ResolveDirectoryCI();
                if (Directory.Exists(path3))
                {
                    Console.WriteLine($"Directory '{path3}' exists.");
                }
                else
                {
                    Console.WriteLine($"Directory '{path3}' does not exist.");
                }
                Directory.CreateDirectory(path3);

                path4 = path4.ResolveDirectoryCI();
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
            Console.WriteLine("============================Started GetDirectoryInfoTest===================");

            string path1 = "temp111111";
            string path2 = "TEMP111111";
            string path3 = "TeMp111111";
            try
            {
                Console.WriteLine($"Getting DirectoryInfo for path {path1}");
                var dir1 = new DirectoryInfo(path1);
                if (dir1 != null)
                {
                    Console.WriteLine($"Path Found {path1}");
                    this.CreateFile(dir1.FullName, "shouldbecreatedfile.txt");
                    this.CreateFile(dir1.FullName, "createdFileToDelete.txt");
                }
                else
                {
                    Console.WriteLine($"Path Not Found {path1}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                Console.WriteLine($"Getting DirectoryInfo for path {path2}");
                var dir1 = new DirectoryInfo(path2);
                if (dir1 != null)
                {
                    Console.WriteLine($"Path Found {path2}");
                    try
                    {
                        this.CreateFile(dir1.FullName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error creating file in directory {path2}: {ex.ToString()}");
                    }
                }
                else
                {
                    Console.WriteLine($"Path Not Found {path2}");
                }

                Console.WriteLine($"Started Deleting file for path {path2}");
                var fileToDelete = Path.Combine(path2, "createdFiLeTodeLEtE.txt");
                var resolvedDirectoryPath = path2.ResolveDirectoryCI();
                Console.WriteLine($"Resolved Directory: {resolvedDirectoryPath}");
                Console.WriteLine($"Resolved File Path: {fileToDelete.ResolveFilePathCI()}");
                FileInfo file = fileToDelete.GetFileInfoCI();
                if (file != null && file.ExistsCI())
                {
                    Console.WriteLine($"Deleting file: {file.FullName}");
                    file.DeleteCI();
                    Console.WriteLine("File deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"File not found or does not exist: {fileToDelete}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                Console.WriteLine($"Getting DirectoryInfo for path {path3}");
                var dir1 = path3.GetDirectoryInfoCI();
                if (dir1 != null)
                {
                    Console.WriteLine($"Path Found {path3}");
                }
                else
                {
                    Console.WriteLine($"Path Not Found {path3}");
                }
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
                Console.WriteLine($"Getting DirectoryInfo for path {path11}");
                var dir1 = new DirectoryInfo(path11);
                if (dir1 != null)
                {
                    Console.WriteLine($"Path Found {path11}");
                }
                else
                {
                    Console.WriteLine($"Path Not Found {path11}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                Console.WriteLine($"Getting DirectoryInfo for path {path22}");
                var dir1 = path22.GetDirectoryInfoCI();
                if (dir1 != null)
                {
                    Console.WriteLine($"Path Found {path22}");
                }
                else
                {
                    Console.WriteLine($"Path Not Found {path22}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            try
            {
                Console.WriteLine($"Getting DirectoryInfo for path {path33}");
                var dir1 = new DirectoryInfo(path33);
                if (dir1 != null)
                {
                    Console.WriteLine($"Path Found {path33}");
                    this.CreateFile(dir1.FullName);
                }
                else
                {
                    Console.WriteLine($"Path Not Found {path33}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing directory: {ex.ToString()}");
            }

            Console.WriteLine("============================Started GetDirectoryInfoTest===================");
        }

        private void CreateFile(string folderPath, string fileName = "myfile.txt")
        {
            string filePath = Path.Combine(folderPath, fileName);
            string content = $"Hello, this is some sample text! {filePath}";

            File.WriteAllText(filePath, content);
            Console.WriteLine("File created at: " + filePath);
        }
    }
}
