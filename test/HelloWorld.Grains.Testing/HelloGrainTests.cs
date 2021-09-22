using System;
using System.Threading.Tasks;
using HelloWorld.Interfaces.HelloWorld.Interfaces;
using Orleans.TestingHost;
using Xunit;

namespace HelloWorld.Grains.Testing
{
    public class HelloGrainTests
    {
        [Fact]
        public async Task SayHelloCorrectly()
        {
            //Arrange
            var builder = new TestClusterBuilder
            {
                Options =
                {
                    ServiceId = Guid.NewGuid().ToString()
                }
            };
            var cluster = builder.Build();
            await cluster.DeployAsync();

            //Act
            var helloGrain = cluster.GrainFactory.GetGrain<IHello>(1);

            const string argMsg = "World";
            var greeting = await helloGrain.SayHello(argMsg);

            await cluster.StopAllSilosAsync();

            //Assert
            Assert.Equal($"You said: '{argMsg}', I say: Hello!", greeting);
        }
    }
}