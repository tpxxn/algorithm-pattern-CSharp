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

    #region 120. 三角形最小路径和
    
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
    
    #endregion

    #region 64. 最小路径和

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
    
    #endregion
    
    #region 62. 不同路径

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

    #endregion
    
    #region 63. 不同路径 II
    
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

    #endregion
    
    #region 70. 爬楼梯
    
    [Test]
    public void ClimbStairsTest()
    {
        var result = DP.ClimbStairs(4);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void ClimbStairsTest_2()
    {
        var result = DP.ClimbStairs(2);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void ClimbStairsTest_3()
    {
        var result = DP.ClimbStairs(3);
        Assert.That(result, Is.EqualTo(3));
    }

    #endregion
    
    #region 55. 跳跃游戏
    
    [Test]
    public void CanJumpTest()
    {
        var result = DP.CanJump(new int[] { 2, 3, 1, 1, 4 });
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void CanJumpTest_2()
    {
        var result = DP.CanJump(new int[] { 3, 2, 1, 0, 4 });
        Assert.That(result, Is.EqualTo(false));
    }

    #endregion
    
    #region 45. 跳跃游戏 ii
    
    [Test]
    public void JumpTest()
    {
        var result = DP.Jump(new int[] { 2, 3, 1, 1, 4 });
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void JumpTest_2()
    {
        var result = DP.Jump(new int[] { 2, 3, 0, 1, 4 });
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void JumpTest_Greedy()
    {
        var result = DP.Jump_Greedy(new int[] { 2, 3, 1, 1, 4 });
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void JumpTest_Greedy_2()
    {
        var result = DP.Jump_Greedy(new int[] { 2, 3, 0, 1, 4 });
        Assert.That(result, Is.EqualTo(2));
    }
    
    #endregion

    #region 132. 分割回文串 ii

    [Test]
    public void MinCutTest()
    {
        var result = DP.MinCut("aab");
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void MinCutTest_2()
    {
        var result = DP.MinCut("a");
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void MinCutTest_3()
    {
        var result = DP.MinCut("ab");
        Assert.That(result, Is.EqualTo(1));
    }

    #endregion
    
    #region 300. 最长递增子序列
    
    [Test]
    public void LengthOfLISTest()
    {
        var result = DP.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void LengthOfLISTest_2()
    {
        var result = DP.LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 });
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void LengthOfLISTest_3()
    {
        var result = DP.LengthOfLIS(new int[] { 7, 7, 7, 7, 7, 7, 7 });
        Assert.That(result, Is.EqualTo(1));
    }
    
    #endregion
    
    #region 139. 单词拆分

    [Test]
    public void WordBreakTest()
    {
        var result = DP.WordBreak("leetcode", new List<string> { "leet", "code" });
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void WordBreakTest_2()
    {
        var result = DP.WordBreak("applepenapple", new List<string> { "apple", "pen" });
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void WordBreakTest_3()
    {
        var result = DP.WordBreak("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" });
        Assert.That(result, Is.EqualTo(false));
    }

    #endregion
    
    #region 1143. 最长公共子序列
    
    [Test]
    public void LongestCommonSubsequenceTest()
    {
        var result = DP.LongestCommonSubsequence("abcde", "ace");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void LongestCommonSubsequenceTest_2()
    {
        var result = DP.LongestCommonSubsequence("abc", "abc");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void LongestCommonSubsequenceTest_3()
    {
        var result = DP.LongestCommonSubsequence("abc", "def");
        Assert.That(result, Is.EqualTo(0));
    }

    #endregion
    
    #region 72. 编辑距离
    
    [Test]
    public void MinDistanceTest()
    {
        var result = DP.MinDistance("horse", "ros");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void MinDistanceTest_2()
    {
        var result = DP.MinDistance("intention", "execution");
        Assert.That(result, Is.EqualTo(5));
    }
    
    #endregion
    
    #region 322. 零钱兑换

    [Test]
    public void CoinChangeTest()
    {
        var result = DP.CoinChange(new[] { 1, 2, 5 }, 11);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void CoinChangeTest_2()
    {
        var result = DP.CoinChange(new[] { 2 }, 3);
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void CoinChangeTest_3()
    {
        var result = DP.CoinChange(new[] { 1 }, 0);
        Assert.That(result, Is.EqualTo(0));
    }

    #endregion
    
    #region 518. 零钱兑换 ii
    
    [Test]
    public void ChangeTest()
    {
        var result = DP.Change(5, new[] { 1, 2, 5 });
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void ChangeTest_2()
    {
        var result = DP.Change(3, new[] { 2 });
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void ChangeTest_3()
    {
        var result = DP.Change(10, new[] { 10 });
        Assert.That(result, Is.EqualTo(1));
    }

    #endregion
    
    #region 92.背包问题
    
    [Test]
    public void BackPackTest()
    {
        var result = DP.BackPack(10, new[] { 3, 4, 8, 5 });
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void BackPackTest_2()
    {
        var result = DP.BackPack(12, new[] { 2, 3, 5, 7 });
        Assert.That(result, Is.EqualTo(12));
    }
    
    #endregion
    
    #region 125.背包问题 ii

    [Test]
    public void BackPackIITest()
    {
        var result = DP.BackPackII(10, new[] { 2, 3, 5, 7 }, new[] { 1, 5, 2, 4 });
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void BackPackIITest_2()
    {
        var result = DP.BackPackII(10, new[] { 2, 3, 8 }, new[] { 2, 5, 8 });
        Assert.That(result, Is.EqualTo(10));
    }

    #endregion
    
    #region 416. 分割等和子集
    
    [Test]
    public void CanPartitionTest()
    {
        var result = DP.CanPartition(new[] { 1, 5, 11, 5 });
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void CanPartitionTest_2()
    {
        var result = DP.CanPartition(new[] { 1, 2, 3, 5 });
        Assert.That(result, Is.EqualTo(false));
    }
    
    #endregion
}