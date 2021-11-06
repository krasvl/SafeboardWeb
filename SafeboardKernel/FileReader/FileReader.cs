using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.FileReader
{
    internal class FileReader : IFileReader
    {
        private readonly string[] _filePaths;

        public FileReader(string directoryPath)
        {
            _filePaths = Directory.GetFiles(directoryPath);
        }

        public IEnumerator<File> GetEnumerator()
        {
            foreach (var filePath in _filePaths)
            {
                yield return new File(filePath, Path.GetExtension(filePath));
            }
        }
    }
}
