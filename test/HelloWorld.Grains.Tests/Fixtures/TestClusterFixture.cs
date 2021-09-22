using System;
using Orleans.Hosting;
using Orleans.TestingHost;

namespace HelloWorld.Grains.Tests.Fixtures
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TestClusterFixture : IDisposable
    {
        public TestCluster Cluster { get; }

        public TestClusterFixture()
        {
            Cluster = CreateTestCluster();
            Cluster.Deploy();
        }

        public void Dispose()
        {
            Cluster.StopAllSilos();
        }

        private static TestCluster CreateTestCluster()
        {
            var builder = new TestClusterBuilder();

            builder.AddSiloBuilderConfigurator<TestSiloConfigurations>();

            return builder.Build();
        }
    }

    public class TestSiloConfigurations : ISiloConfigurator
    {
        public void Configure(ISiloBuilder siloBuilder)
        {
            siloBuilder.ConfigureServices(services =>
            {
               //do some IoC configurations if needed. 
            });
        }
    }
}