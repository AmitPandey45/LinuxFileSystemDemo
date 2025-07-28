// See https://aka.ms/new-console-template for more information
using LinuxFileSystemDemo;

Console.WriteLine("Hello, World!");

var directoryDemo = new DirectoryExtensionsTests();
directoryDemo.GetAllTextFilesByPattern();
directoryDemo.GetAllPdfFilesByPattern();
directoryDemo.GetDirectoryInfo();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();