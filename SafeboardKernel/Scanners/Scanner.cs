using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.Scanners
{
    internal abstract class Scanner
    {
        public abstract ScanResult Scan(string data);

        public virtual void Reset()
        {

        }

    }
}
