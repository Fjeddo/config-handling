using FluentAssertions;
using FunctionApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace UnitTests
{
    public class SomeTests
    {
        private static readonly DefaultHttpRequest HttpRequest = new(new DefaultHttpContext());

        [Fact]
        public void Test_injecting_iconfiguration()
        {
            // Arrange
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>()
            {
                {"Header", "This is a header"}
            }).Build();
            
            var sut = new FunctionUsingIConfiguration(configuration);

            // Act
            var actionResult = sut.GetLocalTimeOriginal(HttpRequest);

            // Assert
            actionResult.As<OkObjectResult>()
                .Value.As<string>()
                .Should().StartWith("This is a header");
        }

        [Fact]
        public void Test_injecting_poco_configuration()
        {
            // Arrange
            var configuration = new FunctionUsingPoco.Configuration {Header = "This is a header"};

            var sut = new FunctionUsingPoco(configuration);

            // Act
            var actionResult = sut.AltGetLocalTime(HttpRequest);

            //Assert
            actionResult.As<OkObjectResult>()
                .Value.As<string>()
                .Should().StartWith("This is a header");
        }

        [Fact]
        public void Test_injecting_ioptions_configuration()
        {
            // Arrange
            var configuration = Options.Create(new FunctionUsingIOptions.MyConfigs {Header = "This is a header"});
            
            var sut = new FunctionUsingIOptions(configuration);

            // Act
            var actionResult = sut.AnotherAlterantiveGetLocalTime(HttpRequest);

            // Assert
            actionResult.As<OkObjectResult>()
                .Value.As<string>()
                .Should().StartWith("This is a header");
        }
    }
}