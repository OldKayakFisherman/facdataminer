using Microsoft.Extensions.Configuration;
using DotNetEnv;

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

        Env.TraversePath().Load();

        Assert.NotNull(Env.GetString("api_token"));
        Assert.NotNull(Env.GetString("api_endpoint"));
      
        
    }
    
}