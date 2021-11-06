using SafeboardKernel.Scanners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SafeboardKernel.Tests
{
    public class DllScannerTests
    {
        [Fact]
        public void Scan_ValidString()
        {
            //Arrange
            Scanner scanner = new DllScanner();
            var prtOfData1 = "Rundll32 sus.dll SusEntry";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.True(result.Successed);
        }

        [Fact]
        public void Scan_InvalidString()
        {
            //Arrange
            Scanner scanner = new DllScanner();
            var prtOfData1 = "some text";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.False(result.Successed);
        }
    }
}
