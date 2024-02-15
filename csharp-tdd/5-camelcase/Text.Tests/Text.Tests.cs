using Text;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(0,"")]
    [TestCase(1, "word")]
    [TestCase(4, "thisDayWillCome")]
    public void TestWordCount(int words, string sentence)
    {
        int result = Str.CamelCase(sentence);
        Assert.That(words, Is.EqualTo(result));
    }
}