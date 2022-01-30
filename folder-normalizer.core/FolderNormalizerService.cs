using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace folder_normalizer.core
{
    public class FolderNormalizerService : IFolderNormalizerService
    {
       
        private const char FORDWARD_DASH = '/';
        private const char BACKWARD_DASH = '\\';

        public void Normalize(string originFolderPath, string pathToNormalize, string originExtension, string extensionToNormalize)
        {
            var originFiles = Directory.GetFiles(originFolderPath, "*."+originExtension);
            var filesToNormalize = Directory.GetFiles(pathToNormalize, "*." + extensionToNormalize);

            if (pathToNormalize.Last() != FORDWARD_DASH || pathToNormalize.Last() != BACKWARD_DASH)
                pathToNormalize += pathToNormalize.Contains(FORDWARD_DASH) ? FORDWARD_DASH : BACKWARD_DASH;

            Console.WriteLine($"Origin ({originFiles.Length}) | Destination ({filesToNormalize.Length})");

            foreach(var ftn in filesToNormalize)
            {
                var ftnFileName = Path.GetFileNameWithoutExtension(ftn);
                var originFilePath = originFiles.FirstOrDefault(of => of.Contains(ftnFileName));

                if (String.IsNullOrWhiteSpace(originFilePath))
                {
                    Console.WriteLine($"Deleted {pathToNormalize + ftn}");
                    File.Delete(ftn);
                }
            };
        }
    }
}
