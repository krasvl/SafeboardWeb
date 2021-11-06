using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeboardKernel.Scanners
{
    internal class JsScanner : Scanner
    {
        private bool _haveOpenTag = false;

        public override void Reset()
        {
            base.Reset();
            _haveOpenTag = false;
        }

        public override ScanResult Scan(string prtOfData)
        {
            if (!_haveOpenTag && prtOfData.Contains("<script>"))
            {
                _haveOpenTag = true;

                prtOfData = RemoveFirstOpenTag(prtOfData);
            }

            if (_haveOpenTag && prtOfData.Contains("</script>"))
                return new ScanResult("JS", true);

            return new ScanResult("JS", false);
        }

        private string RemoveFirstOpenTag(string prtOfData)
        {
            string[] splitedData = prtOfData.Split("<script>");
            StringBuilder prtOfDataWithoutFirtOpenTag = new StringBuilder();

            for (int i = 1; i < splitedData.Length; i++)
            {
                prtOfDataWithoutFirtOpenTag.Append(splitedData[i]);
            }

            return prtOfDataWithoutFirtOpenTag.ToString();
        }
    }
}
