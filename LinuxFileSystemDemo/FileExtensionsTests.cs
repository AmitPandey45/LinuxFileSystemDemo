using LinuxFileSystemDemo.Extensions;

namespace LinuxFileSystemDemo
{
    public class FileExtensionsTests
    {
        public void ValidateFileDemo()
        {
            string fileName1 = "000366995_G030120_1.PDF";
            string fileName2 = "000366995_G030120_1.Pdf";
            string fileName3 = "000366995_G030120_1.pdf";
            string fileName4 = "000366995_G030120_1.PdF";

            if (fileName1.EndsWith(".pdf"))
            {
                Console.WriteLine($"{fileName1} ends with .pdf");
            }
            else
            {
                Console.WriteLine($"{fileName1} does not end with .pdf");
            }

            if (fileName2.EndsWith(".pdf"))
            {
                Console.WriteLine($"{fileName2} ends with .pdf");
            }
            else
            {
                Console.WriteLine($"{fileName2} does not end with .pdf");
            }

            if (fileName3.EndsWith(".pdf"))
            {
                Console.WriteLine($"{fileName3} ends with .pdf");
            }
            else
            {
                Console.WriteLine($"{fileName3} does not end with .pdf");
            }

            if (fileName4.EndsWith(".pdf"))
            {
                Console.WriteLine($"{fileName4} ends with .pdf");
            }
            else
            {
                Console.WriteLine($"{fileName4} does not end with .pdf");
            }
        }

        public void MountingFileDemo()
        {
            string path = "/app/mnt/WebVotes";

            DirectoryInfo dir = path.GetDirCI();

            if (dir != null)
            {
                var files = dir.GetFilesCI("*.txt", SearchOption.AllDirectories);
                Console.WriteLine($"Found {files.Length} text files in directory '{path}':");
                foreach (var file in files)
                {
                    Console.WriteLine($"File Name: {file}");
                }
            }
            else
            {
                Console.WriteLine($"Directory '{path}' does not exist or could not be resolved.");
            }
        }
    }
}
