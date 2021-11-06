using SafeboardKernel.Scanners;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.ResponseBuilder
{
    internal class ResponseBuilder : IResponseBuilder
    {
        private Stopwatch stopwatch;
        private int checkedFiles = 0;
        private Dictionary<string, int> DangerTypesCount = new Dictionary<string, int>();
        private int errorsCount = 0;

        public ResponseBuilder()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void AddDanger(string type)
        {
            if (DangerTypesCount.Keys.Contains(type))
                DangerTypesCount[type]++;
            else
                DangerTypesCount.Add(type, 1);
        }

        public void SetFileChecked() =>
            checkedFiles++;

        public void SetError() =>
            errorsCount++;

        public string[] GetResponse()
        {
            stopwatch.Stop();
            List<string> result = new List<string>();

            result.Add("====== Scan result ======");
            result.Add($"Processed files: {checkedFiles}");
            foreach (var danger in DangerTypesCount)
            {
                result.Add($"{danger.Key} detects: {danger.Value}");
            }
            result.Add($"Errors: {errorsCount}");
            result.Add($"Exection time: {stopwatch.Elapsed}");
            result.Add("=========================");

            return result.ToArray();
        }
    }
}
