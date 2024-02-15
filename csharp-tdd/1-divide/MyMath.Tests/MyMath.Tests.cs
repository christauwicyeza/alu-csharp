using System;
using MyMath;
using NUnit.Framework.Internal;

public class Tests
{

    int[,] TestShow = new int[2, 2] { { 4, 8 }, { 16, 24 } };

    [SetUp]
    public void Setup()
    {
       
    }

    [Test]
    public void TestDivide()
    {
        int first = TestShow.GetLength(0);
        int second = Matrix.Divide(TestShow, 4).GetLength(0);
        Assert.That(second, Is.EqualTo(first));

    }

    [Test]
    public void TestNull()
    {
        Assert.IsNull(Matrix.Divide(TestShow, 0));
    }

    [Test]
    public void TestOutput()
    {
        int[,] outputTest = new int[2,2] {{2, 4}, {8, 12}};
        
        Assert.That(outputTest, Is.EqualTo(Matrix.Divide(TestShow, 2)));
    }

    [Test]
    public void TestNegativeOutput(){
         int[,] outputTest = new int[2,2] {{-2, -4}, {-8, -12}};
          Assert.That(outputTest, Is.EqualTo(Matrix.Divide(TestShow, -2)));
    }

    [Test]
    public void TestMatrixNull()
    {
        int[,] NullOutput = null;
        
        Assert.IsNull(Matrix.Divide(NullOutput, 2));
    }
}

