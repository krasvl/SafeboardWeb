using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SafeboardKernel.Scanners
{
    internal class RmScanner : Scanner
    {
        private Regex _regex = new Regex(@"rm -rf .*\\Documents");

        public override ScanResult Scan(string prtOfData)
        {
            if (_regex.IsMatch(prtOfData))
                return new ScanResult("RM", true);
            else
                return new ScanResult("RM", false);
        }

    }
}
