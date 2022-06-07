using FunctionApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
            
            var sut = new OriginalTimeFunctions(configuration);

            // Act
            sut.GetLocalTimeOriginal(HttpRequest);

            // Assert
            //...
        }

        [Fact]
        public void Test_injecting_poco_configuration()
        {
            // Arrange
            var configuration = new AlternativeTimeFunctions.Configuration {Header = "This is a header"};

            var sut = new AlternativeTimeFunctions(configuration);

            // Act
            sut.AltGetLocalTime(HttpRequest);

            //Assert
            //...
        }

        [Fact]
        public void Test_injecting_ioptions_configuration()
        {
            // Arrange
            var configuration = Options.Create(new AnotherAlternativeTimeFunctions.MyConfigs {Header = "This is a header"});
            
            var sut = new AnotherAlternativeTimeFunctions(configuration);

            // Act
            sut.AnotherAlterantiveGetLocalTime(HttpRequest);

            // Assert
            //...
        }
    }
}