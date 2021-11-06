using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SafeboardKernel.Scanners
{
    internal class DllScanner : Scanner
    {
        private Regex _regex = new Regex(@"Rundll32 \w*.dll");

        public override ScanResult Scan(string prtOfData)
        {
            if (_regex.IsMatch(prtOfData))
                return new ScanResult("Dll", true);
            else
                return new ScanResult("Dll", false);
        }
    }
}
