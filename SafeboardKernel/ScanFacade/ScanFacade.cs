using SafeboardKernel.FileReader;
using SafeboardKernel.ResponseBuilder;
using SafeboardKernel.Scanners;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.ScanFacade
{
    public class ScanFacade
    {
        private readonly Scanner _jsScanner = new JsScanner();
        private readonly Scanner _rmScanner = new RmScanner();
        private readonly Scanner _dllScanner = new DllScanner();

        public string[] Scan(string directoryPath)
        {
            IFileReader _fileReader;

            try
            {
                _fileReader = new FileReader.FileReader(directoryPath);
            }
            catch (DirectoryNotFoundException)
            {
                return new string[] { "Directory with this path was not found" };
            }

            IResponseBuilder _responseBuilder = new ResponseBuilder.ResponseBuilder();

            foreach (var file in _fileReader)
            {
                List<Scanner> scanners = GetScannersByFileType(file.Type);

                try
                {
                    foreach (var line in file.ReadLines())
                    {
                        ScanResult[] scanResults = ScanLine(scanners, line);

                        var successedScanResult = scanResults.Where(r => r.Successed).FirstOrDefault();
                        if (successedScanResult != null)
                        {
                            _responseBuilder.AddDanger(successedScanResult.ErrorType);
                            break;
                        }
                    }
                    _responseBuilder.SetFileChecked();
                }
                catch
                {
                    _responseBuilder.SetError();
                }

                scanners.ForEach(s => s.Reset());
            }

            return _responseBuilder.GetResponse();
        }

        private List<Scanner> GetScannersByFileType(string fileType)
        {
            List<Scanner> scanners = new List<Scanner>();

            if (fileType == ".js")
            {
                scanners.Add(_jsScanner);
                scanners.Add(_rmScanner);
                scanners.Add(_dllScanner);
            }
            else
            {
                scanners.Add(_rmScanner);
                scanners.Add(_dllScanner);
            }

            return scanners;
        }

        private ScanResult[] ScanLine(List<Scanner> scanners, string line)
        {
            List<ScanResult> scanResults = new List<ScanResult>();
            List<Task> scanTasks = new List<Task>();

            foreach (var scanner in scanners)
            {
                var scanTask = new Task(() =>
                {
                    var result = scanner.Scan(line);
                    lock (scanResults)
                    {
                        scanResults.Add(result);
                    }
                });
                scanTasks.Add(scanTask);
            }

            foreach (var task in scanTasks)
                task.Start();

            foreach (var task in scanTasks)
                task.Wait();


            return scanResults.ToArray();
        }

    }
}
