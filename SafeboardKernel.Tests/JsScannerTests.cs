using SafeboardKernel.Scanners;
using System;
using Xunit;

namespace SafeboardKernel.Tests
{
    public class JsScannerTests
    {
        [Fact]
        public void Scan_OpenAndCloseTagInTheSamePrtOfData()
        {
            //Arrange
            Scanner scanner = new JsScanner();
            var prtOfData = "<script>someJsCode</script>";
            //Act
            var result = scanner.Scan(prtOfData);

            //Assert
            Assert.True(result.Successed);
        }

        [Fact]
        public void Scan_OpenAndCloseTagInOtherPrtOfData()
        {
            //Arrange
            Scanner scanner = new JsScanner();
            var prtOfData1 = "<script>someJsCode";
            var prtOfData2 = "someJsCode";
            var prtOfData3 = "someJsCode>";
            var prtOfData4 = "someJsCode</script>";

            //Act
            scanner.Scan(prtOfData1);
            scanner.Scan(prtOfData2);
            scanner.Scan(prtOfData3);
            var result = scanner.Scan(prtOfData4);

            //Assert
            Assert.True(result.Successed);
        }

        [Fact]
        public void Scan_CloseTagBeforeOpenTagInOtherPrtOfData()
        {
            //Arrange
            Scanner scanner = new JsScanner();
            var prtOfData1 = "</script>someJsCode";
            var prtOfData2 = "someJsCode";
            var prtOfData3 = "someJsCode>";
            var prtOfData4 = "someJsCode<script>";

            //Act
            scanner.Scan(prtOfData1);
            scanner.Scan(prtOfData2);
            scanner.Scan(prtOfData3);
            var result = scanner.Scan(prtOfData4);

            //Assert
            Assert.False(result.Successed);
        }

        [Fact]
        public void Scan_CloseTagBeforeOpenTagInTheSamePrtOfData()
        {
            //Arrange
            Scanner scanner = new JsScanner();
            var prtOfData1 = "</script>someJsCode<script>";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.False(result.Successed);
        }

        [Fact]
        public void Scan_ManyOpenTagsInTheSamePrtOfData()
        {
            //Arrange
            Scanner scanner = new JsScanner();
            var prtOfData1 = "<script>someJsCode<script>someJsCode</script>someJsCode<script>";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.True(result.Successed);
        }

        [Fact]
        public void Scan_NoOpenTags()
        {
            //Arrange
            Scanner scanner = new JsScanner();
            var prtOfData1 = "someJsCode</script>";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.False(result.Successed);
        }

        [Fact]
        public void Scan_NoCloseTags()
        {
            //Arrange
            Scanner scanner = new JsScanner();
            var prtOfData1 = "<script>someJsCode";

            //Act
            var result = scanner.Scan(prtOfData1);

            //Assert
            Assert.False(result.Successed);
        }
    }
}
