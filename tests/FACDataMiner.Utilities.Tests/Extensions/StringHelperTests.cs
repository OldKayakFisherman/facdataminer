using FACDataMiner.Utilities.Extensions;

namespace FACDataMiner.Utilities.Tests.Extensions;

[TestFixture]
public class StringHelperTests
{
    [Test]
    public void TestToStringOrNullValue()
    {
        Assert.That("ABC123".ToStringOrNullValue(), Is.EqualTo("ABC123"));
        Assert.That("".ToStringOrNullValue(), Is.Null);
    }

    [Test]
    public void TestToDateTimeOrNullValue()
    {
        Assert.That("2023-10-19".ToDateTimeOrNullValue("yyyy-MM-dd"), Is.Not.Null);
        Assert.That("2023-10-19".ToDateTimeOrNullValue("yyyy-MM-dd")!.Value.Day, Is.EqualTo(19));
        Assert.That("2023-10-19".ToDateTimeOrNullValue("yyyy-MM-dd")!.Value.Month, Is.EqualTo(10));
        Assert.That("2023-10-19".ToDateTimeOrNullValue("yyyy-MM-dd")!.Value.Year, Is.EqualTo(2023));
        Assert.That("".ToDateTimeOrNullValue("yyyy-MM-dd"), Is.Null);
    }
    
    [Test]
    public void TestToBooleanOrNullValue()
    {
        Assert.That("Yes".ToBooleanOrNullValue(), Is.EqualTo(true));
        Assert.That("yes".ToBooleanOrNullValue(), Is.EqualTo(true));
        Assert.That("Y".ToBooleanOrNullValue(), Is.EqualTo(true));
        Assert.That("y".ToBooleanOrNullValue(), Is.EqualTo(true));
        Assert.That("No".ToBooleanOrNullValue(), Is.EqualTo(false));
        Assert.That("no".ToBooleanOrNullValue(), Is.EqualTo(false));
        Assert.That("N".ToBooleanOrNullValue(), Is.EqualTo(false));
        Assert.That("n".ToBooleanOrNullValue(), Is.EqualTo(false));
        Assert.That("".ToStringOrNullValue(), Is.Null);
    }

    [Test]
    public void TestToIntOrNullValue()
    {
        Assert.That("14".ToIntOrNullValue(), Is.EqualTo(14));
        Assert.That("".ToIntOrNullValue(), Is.Null);
    }
    
    [Test]
    public void TestToDecimalOrNullValue()
    {
        Assert.That("14.22".ToDecimalOrNullValue(), Is.EqualTo(14.22m));
        Assert.That("".ToDecimalOrNullValue(), Is.Null);
    }

}