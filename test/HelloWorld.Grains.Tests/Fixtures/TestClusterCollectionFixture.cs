using Xunit;

namespace HelloWorld.Grains.Tests.Fixtures
{
    [CollectionDefinition(Name)]
    public class TestClusterCollectionFixture : ICollectionFixture<TestClusterFixture>
    {
        public const string Name = "Test Cluster Collection";
    }
}