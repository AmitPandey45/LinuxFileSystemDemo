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

            if (fileName1.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
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

            DirectoryInfo dir = path.GetDirectoryInfoCI();

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

            try
            {
                DirectoryInfo dir1 = new DirectoryInfo("/App/MnT/weBVoTes");
                if (dir1 != null)
                {
                    var files = dir1.GetFilesCI("*.txt", SearchOption.AllDirectories);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void GetBallotNumbers()
        {
            string[] ballotNumbers = new string[]
            {
                "000100789_C0900000125_1.PDf",
                "1034975_A0100000125_3.Pdf",
                "000102898_A0100000125_1.ppt",
                "000124419_D190120_6",
                "000366995_E600320_1",
                "000124296_F441620_3",
                "000121122_E6080000118_1",
                "000124296_D1351000121_1",
                "000366995_E120121_1"
            };

            List<string> output = new List<string>();
            foreach (var ballotNumber in ballotNumbers)
            {
                output.Add(GetBallotNumber(ballotNumber.Split("_")[1]));
            }
        }

        public string GetBallotNumber(string ballotNumber)
        {
            if (string.IsNullOrWhiteSpace(ballotNumber))
            {
                return ballotNumber;
            }

            if (ballotNumber.Length > 7)
            {
                string committeePart = ballotNumber.Substring(0, 7);

                if (committeePart.EndsWith("0000"))
                {
                    string main = committeePart.Substring(0, 3);
                    string sequenceAndYear = ballotNumber.Substring(ballotNumber.Length - 4);
                    return main + sequenceAndYear;
                }
            }

            return ballotNumber;
        }

    }
}
