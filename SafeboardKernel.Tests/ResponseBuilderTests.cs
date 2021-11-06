using SafeboardKernel.ResponseBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SafeboardKernel.Tests
{
    public class ResponseBuilderTests
    {
        [Fact]
        public void AddDanger_NewDanger()
        {
            //Arrange
            IResponseBuilder responseBuilder = new ResponseBuilder.ResponseBuilder();

            //Act
            responseBuilder.AddDanger("Prev");
            responseBuilder.AddDanger("New");

            //Assert
            Assert.Equal("Prev detects: 1", responseBuilder.GetResponse()[2]);
            Assert.Equal("New detects: 1", responseBuilder.GetResponse()[3]);
        }

        [Fact]
        public void AddDanger_TheSameDanger()
        {
            //Arrange
            IResponseBuilder responseBuilder = new ResponseBuilder.ResponseBuilder();

            //Act
            responseBuilder.AddDanger("New");
            responseBuilder.AddDanger("New");

            //Assert
            Assert.Equal("New detects: 2", responseBuilder.GetResponse()[2]);
        }

        [Fact]
        public void SetFileChecked_SetNewFile()
        {
            //Arrange
            IResponseBuilder responseBuilder = new ResponseBuilder.ResponseBuilder();

            //Act
            responseBuilder.SetFileChecked();
            responseBuilder.SetFileChecked();
            responseBuilder.SetFileChecked();

            //Assert
            Assert.Equal("Processed files: 3", responseBuilder.GetResponse()[1]);
        }

        [Fact]
        public void SetError_SetNewError()
        {
            //Arrange
            IResponseBuilder responseBuilder = new ResponseBuilder.ResponseBuilder();

            //Act
            responseBuilder.SetError();
            responseBuilder.SetError();
            responseBuilder.SetError();

            //Assert
            Assert.Equal("Errors: 3", responseBuilder.GetResponse()[2]);
        }
    }
}
