using System;
using System.Numerics;
using MyMath;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestNull()
    {
        List<int> testList = new List<int>() { };
        Assert.That(0, Is.EqualTo(Operations.Max(testList)));
    }

    [TestCase(90)]
    public void TestMaxNumber(int value)
    {
        List<int> TempList = new List<int>() { 19, 10, 56, 90 };
        Assert.That(90, Is.EqualTo(Operations.Max(TempList)));
    }
}
