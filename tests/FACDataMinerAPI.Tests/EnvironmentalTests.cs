namespace FACDataMinerAPI.Tests;

[TestFixture]
public class EnvironmentalTests
{
    [Test]
    public void TestToken()
    {
        string? token = TestHelpers.GetAPIKey(); 
        
        Console.WriteLine($"Is token null? : {string.IsNullOrEmpty(token)}");
        Console.WriteLine($"Is token length ok? : {token.Length}");
        Console.WriteLine($"Is first char ok? : {token[39]}");
        
        Assert.That(TestHelpers.GetAPIKey(), Is.Not.Null);
        Assert.That(TestHelpers.GetAPIKey(), Has.Length.EqualTo(40));
        Assert.That(TestHelpers.GetAPIKey()[0], Is.EqualTo('q'));
    }
}