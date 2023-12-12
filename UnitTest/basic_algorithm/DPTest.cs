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


    [Test]
    public void MinPathSumTest()
    {
        var grid = new int[][]
        {
            new int[] { 1, 3, 1 },
            new int[] { 1, 5, 1 },
            new int[] { 4, 2, 1 }
        };
        var result = DP.MinPathSum(grid);
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void MinPathSumTest_2()
    {
        var grid = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
        };
        var result = DP.MinPathSum(grid);
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void UniquePathsTest()
    {
        var result = DP.UniquePaths(3, 7);
        Assert.That(result, Is.EqualTo(28));
    }

    [Test]
    public void UniquePathsTest_2()
    {
        var result = DP.UniquePaths(3, 2);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void UniquePathsWithObstaclesTest()
    {
        var obstacleGrid = new int[][]
        {
            new int[] { 0, 0, 0 },
            new int[] { 0, 1, 0 },
            new int[] { 0, 0, 0 }
        };
        var result = DP.UniquePathsWithObstacles(obstacleGrid);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void UniquePathsWithObstaclesTest_2()
    {
        var obstacleGrid = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 0, 0 }
        };
        var result = DP.UniquePathsWithObstacles(obstacleGrid);
        Assert.That(result, Is.EqualTo(1));
    }
}