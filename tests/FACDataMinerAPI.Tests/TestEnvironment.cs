using Microsoft.Extensions.Configuration;

namespace FACDataMinerAPI.Tests;

[TestFixture]
public class TestEnvironment
{
    [Test]
    public void TestEnvironementVariables()
    {
        IConfiguration config;
        
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<TestEnvironment>();

        config = builder.Build();
        
        Assert.NotNull(config["api_token"]);
        Assert.NotNull(config["api_endpoint"]);
    }
    
}