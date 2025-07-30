// See https://aka.ms/new-console-template for more information
using LinuxFileSystemDemo;

Console.WriteLine("Hello, World!");

var directoryDemo = new DirectoryExtensionsTests();
//directoryDemo.GetAllTextFilesByPattern();
//directoryDemo.GetAllPdfFilesByPattern();
//directoryDemo.GetDirectoryInfo();

//directoryDemo.DirectoryCaseSensivityTest();
//directoryDemo.DirectoryCaseSensivityTest2();
//directoryDemo.GetDirectoryInfoTest();

var fileDemo = new FileExtensionsTests();
fileDemo.ValidateFileDemo();
fileDemo.MountingFileDemo();

Thread.Sleep(5 * 60 * 1000);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();