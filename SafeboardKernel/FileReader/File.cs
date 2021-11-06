using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.FileReader
{
    internal struct File
    {
        private readonly StreamReader _streamReader;

        public string Type { get; private set; }

        public File(string path, string type)
        {
            _streamReader = new StreamReader(path);
            Type = type;
        }

        public IEnumerable<string> ReadLines()
        {
            string line;
            while((line = _streamReader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
