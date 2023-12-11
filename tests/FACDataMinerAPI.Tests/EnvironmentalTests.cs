namespace FACDataMinerAPI.Tests;

[TestFixture]
public class EnvironmentalTests
{
    [Test]
    public void TestToken()
    {
        Assert.That(TestHelpers.GetAPIKey(), Is.Not.Null);
        Assert.That(TestHelpers.GetAPIKey(), Has.Length.EqualTo(40));
        Assert.That(TestHelpers.GetAPIKey()[0], Is.EqualTo('q'));
    }
}