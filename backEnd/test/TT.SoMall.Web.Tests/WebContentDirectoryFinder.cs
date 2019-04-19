using System;
using System.IO;
using System.Linq;

namespace TT.SoMall
{
    /// <summary>
    /// This class is used to find root path of the web project. Used for;
    /// 1. unit tests (to find views).
    /// 2. entity framework core command line commands (to find the conn string).
    /// </summary>
    public static class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            var domainAssemblyDirectoryPath = Path.GetDirectoryName(typeof(SoMallDomainModule).Assembly.Location);
            if (domainAssemblyDirectoryPath == null)
            {
                throw new Exception($"Could not find location of {typeof(SoMallDomainModule).Assembly.FullName} assembly!");
            }

            var directoryInfo = new DirectoryInfo(domainAssemblyDirectoryPath);
            while (!DirectoryContains(directoryInfo.FullName, "TT.SoMall.sln"))
            {
                if (directoryInfo.Parent == null)
                {
                    throw new Exception("Could not find content root folder!");
                }

                directoryInfo = directoryInfo.Parent;
            }

            var webFolder = Path.Combine(directoryInfo.FullName, $"src{Path.DirectorySeparatorChar}TT.SoMall.Web");
            if (Directory.Exists(webFolder))
            {
                return webFolder;
            }

            throw new Exception("Could not find root folder of the web project!");
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
        }
    }
}
