using System;
using System.Threading.Tasks;
using HelloWorld.Grains.Tests.Fixtures;
using HelloWorld.Interfaces.HelloWorld.Interfaces;
using Orleans.TestingHost;
using Xunit;

namespace HelloWorld.Grains.Tests
{
    [Collection(TestClusterCollectionFixture.Name)]
    public class HelloGrainTests
    {
        private readonly TestCluster _cluster;

        public HelloGrainTests(TestClusterFixture fixture)
        {
            _cluster = fixture.Cluster;
        }

        [Fact]
        public async Task SayHelloCorrectly()
        {
            //Arrange
            // var builder = new TestClusterBuilder
            // {
            //     Options =
            //     {
            //         ServiceId = Guid.NewGuid().ToString()
            //     }
            // };
            // var cluster = builder.Build();
            // await cluster.DeployAsync();

            //Act
            var helloGrain = _cluster.GrainFactory.GetGrain<IHello>(0);

            const string argMsg = "World";
            var greeting = await helloGrain.SayHello(argMsg);

            // await cluster.StopAllSilosAsync();

            //Assert
            Assert.Equal($"You said: '{argMsg}', I say: Hello!", greeting);
        }

        [Fact]
        public async Task HadSayHelloRpcInvoked()
        {
            //Arrange
            const string argMsg1 = "Hello1";

            //Act
            var helloGrain1 = _cluster.GrainFactory.GetGrain<IHello>(1);
            var helloGrain2 = _cluster.GrainFactory.GetGrain<IHello>(2);

            await helloGrain1.SayHello(argMsg1);
            var status1 = await helloGrain1.IsHelloed();

            var status2 = await helloGrain2.IsHelloed();

            //Assert 
            Assert.True(status1, "first grain should have SayHello() RPC method invoked");
            Assert.False(status2, "second grain should report it has not called SayHello() RPM method");
        }
    }
}