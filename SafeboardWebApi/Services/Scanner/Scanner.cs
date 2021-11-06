using SafeboardKernel.ScanFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeboardWebApi.Services.Scanner
{
    public class Scanner : IScanner
    {
        private ScanFacade _scanFacade = new ScanFacade();

        public string[] Scan(string directoryPath) =>
            _scanFacade.Scan(directoryPath);
    }
}
