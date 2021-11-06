using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.FileReader
{
    internal interface IFileReader
    {
        IEnumerator<File> GetEnumerator();
    }
}
