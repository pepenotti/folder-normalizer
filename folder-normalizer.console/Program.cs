using System;

namespace folder_normalizer.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Origin path:");
            var originPath = Console.ReadLine();

            Console.WriteLine("Origin extension:");
            var originExtension = Console.ReadLine();

            Console.WriteLine("Path to normalize:");
            var pathToNormalize = Console.ReadLine();

            Console.WriteLine("Extension of files to normalize:");
            var extensionToNormalize = Console.ReadLine();

            var fns = new FolderNormalizerService();
            fns.Normalize(originPath, pathToNormalize, originExtension, extensionToNormalize);

            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}
