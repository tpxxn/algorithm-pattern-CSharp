using algorithm_pattern.basic_algorithm.DP;

namespace UnitTest.basic_algorithm;

public class DPTest
{
    List<IList<int>> triangle;

    [SetUp]
    public void Setup()
    {
        triangle = new List<IList<int>> { new List<int> { 2 }, new List<int> { 3, 4 }, new List<int> { 6, 5, 7 }, new List<int> { 4, 1, 8, 3 } };
    }


    [Test]
    public void MinimumTotalTest()
    {
        var result = DP.MinimumTotal(triangle);
        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void MinimumTotalTest2()
    {
        var result = DP.MinimumTotal2(triangle);
        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void MinimumTotalTest_DownToUp()
    {
        var result = DP.MinimumTotal_DownToUp(triangle);
        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void MinimumTotalTest_TopToDown()
    {
        var result = DP.MinimumTotal_TopToDown(triangle);
        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void MinimumTotalTest_Final()
    {
        var result = DP.MinimumTotal_Final(triangle);
        Assert.That(result, Is.EqualTo(11));
    }
}