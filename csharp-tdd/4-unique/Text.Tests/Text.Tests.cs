using Text;
using System.Collections;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestRepeating()
    {
        int value = Str.UniqueChar("shoes");
        Assert.That(value, Is.EqualTo(-1));
    }
    
    [Test]
    public void TestRepeatingNon()
    {
        int value = Str.UniqueChar("shoe");
        Assert.That(value, Is.EqualTo(0));
    }
    
}