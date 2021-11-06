using SafeboardKernel.Scanners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SafeboardKernel.Tests
{
    public class RmScannerTests
    {
        [Fact]
        public void Scan_ValidString()
        {
            //Arrange
            Scanner scanner = new RmScanner();
            var prtOfData1 = "rm -rf userprofile\\Documents";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.True(result.Successed);
        }

        [Fact]
        public void Scan_NoSPrefixString()
        {
            //Arrange
            Scanner scanner = new RmScanner();
            var prtOfData1 = "userprofile\\Documents";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.False(result.Successed);
        }

        [Fact]
        public void Scan_NoSuffixString()
        {
            //Arrange
            Scanner scanner = new RmScanner();
            var prtOfData1 = "rm -rf userprofile";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.False(result.Successed);
        }
    }
}
