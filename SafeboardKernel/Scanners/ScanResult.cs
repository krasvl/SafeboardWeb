using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.Scanners
{
    internal class ScanResult
    {
        public string ErrorType { get; private set; }
        public bool Successed { get; private set; }

        public ScanResult(string errorType, bool successed)
        {
            ErrorType = errorType;
            Successed = successed;
        }
    }
}
