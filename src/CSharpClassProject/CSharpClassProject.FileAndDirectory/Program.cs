using System;
using System.IO;
using System.Text;

namespace CSharpClassProject.FileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {            
            UsingFileInfo();
            ReadFileUntilEnd();
            ReadFileLinePerLine();
            UsingStringReader();
            WriteFile();
            UsingStringWriter();
            ReadDirectory();
            CreateDirectory();

            Console.ReadLine();
        }

        static void UsingFileInfo()
        {
            var fileInfo = new FileInfo("..\\..\\..\\temp.txt");
            Console.WriteLine($"FullName: {fileInfo.FullName}");
            Console.WriteLine($"Exists: {fileInfo.Exists}");
            Console.WriteLine($"Extension: {fileInfo.Extension}");
            Console.WriteLine($"Directory: {fileInfo.DirectoryName}");
            Console.WriteLine($"Directory: {fileInfo.Directory.FullName}");
            Console.WriteLine($"Directory: {fileInfo.Directory.Name}");

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            using (var stream = fileInfo.Create())
            {
                stream.Write(Encoding.UTF8.GetBytes("My text."));
            }
        }

        static void UsingStringWriter()
        {
            var fileInfo = new FileInfo("..\\..\\..\\temp.txt");

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            using (var stream = fileInfo.Create())
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("My line");
            }
        }

        static void UsingStringReader()
        {
            var fileInfo = new FileInfo("..\\..\\..\\ReadMe.md");

            using (var stream = fileInfo.OpenRead())
            using (var reader = new StreamReader(stream))
            {
                string line;
                var lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;

                    Console.WriteLine($"Line {lineNumber.ToString("000")}: {line}");
                }
            }
        }

        static void ReadFileUntilEnd()
        {
            using (var reader = File.OpenText("..\\..\\..\\README.md"))
            {
                // Read all files, do not use for large files
                var text = reader.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine();

            var allText = File.ReadAllText("..\\..\\..\\README.md");
            Console.WriteLine(allText);
        }

        static void ReadFileLinePerLine()
        {
            using (var reader = File.OpenText("..\\..\\..\\README.md"))
            {
                // Read line per line
                string line;
                var lineNumber = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;

                    Console.WriteLine($"Line {lineNumber.ToString("000")}: {line}");
                }
            }
        }

        static void WriteFile()
        {
            using (var stream = File.Create("..\\..\\..\\temp.txt"))
            {
                stream.Write(Encoding.UTF8.GetBytes("My text."));
            }
        }

        static void ReadDirectory()
        {
            foreach (var directory in Directory.GetDirectories("..\\..\\..\\"))
            {
                Console.WriteLine(directory);
            }

            foreach (var directory in Directory.GetFiles("..\\..\\..\\"))
            {
                Console.WriteLine(directory);
            }
        }

        static void CreateDirectory()
        {
            var directoryPath = ".\\myDirectory";

            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
                Console.WriteLine($"Directory '{directoryPath}' deleted.");
            }

            Directory.CreateDirectory(directoryPath);
            Console.WriteLine($"Directory '{directoryPath}' created.");

            Console.WriteLine("Using DirectoryInfo");

            var directoryInfo = new DirectoryInfo(directoryPath);

            if (directoryInfo.Exists)
            {
                directoryInfo.Delete(recursive: true);
                Console.WriteLine($"Directory '{directoryInfo.FullName}' deleted.");
            }

            directoryInfo.Create();
            Console.WriteLine($"Directory '{directoryPath}' created.");

            var subDirectoryInfo = directoryInfo.CreateSubdirectory("temp");
            Console.WriteLine($"Sub directory '{subDirectoryInfo.FullName}' created.");
        }
    }
}
