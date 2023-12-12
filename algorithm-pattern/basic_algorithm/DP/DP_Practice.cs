namespace algorithm_pattern.basic_algorithm.DP;

public partial class DP
{
    /// <summary>
    /// <para>064. 最小路径和</para>
    /// <para>https://leetcode-cn.com/problems/minimum-path-sum/</para>
    /// </summary>
    /// <param name="grid">给定包含非负整数的 m x n 网格 grid</param>
    /// <returns>从左上到右下的最小路径和</returns>
    public static int MinPathSum(int[][] grid)
    {
        // dp[i][j] 表示0,0到i,j的最小和
        int[] dp = new int[grid[0].Length];
        // 初始化：用第一行初始化
        dp[0] = grid[0][0];
        for (int i = 1; i < grid[0].Length; i++)
        {
            dp[i] = dp[i - 1] + grid[0][i];
        }
        // 状态转移方程
        // 每行第一个元素：
        // dp[j] = dp[j](到上一行这个位置的最小和) + grid[i][j];
        // 后续元素：
        // dp[j] = Math.min(dp[j-1](到左边位置的最小和), dp[j](到上一行这个位置的最小和)) + grid[i][j];
        for (int i = 1; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (j == 0)
                {
                    dp[j] += grid[i][j];
                }
                else
                {
                    dp[j] = Math.Min(dp[j - 1], dp[j]) + grid[i][j];
                }
            }
        }
        // 答案
        return dp[grid[0].Length - 1];
    }

    /// <summary>
    /// <para>062. 不同路径</para>
    /// <para>https://leetcode-cn.com/problems/unique-paths/</para>
    /// </summary>
    /// <param name="m">网格的行数</param>
    /// <param name="n">网格的列数</param>
    /// <returns>从左上到右下的不同的路径数</returns>
    public static int UniquePaths(int m, int n)
    {
        // dp[i][j] 表示0,0到i,j的路径数
        int[] dp = new int[n];
        // 初始化：到达第一行的路径数均为1
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // 每行第一个格子只有一条路到达
                if (j == 0)
                {
                    dp[j] = 1;
                }
                // 其他格子可以由左侧或上方的格子到达
                else
                {
                    dp[j] = dp[j - 1] + dp[j];
                }
            }
        }
        return dp[n - 1];
    }

    /// <summary>
    /// <para>063. 不同路径 II</para>
    /// <para>https://leetcode-cn.com/problems/unique-paths-ii/</para>
    /// </summary>
    /// <param name="obstacleGrid">网格中的障碍物和空位置分别用 `1` 和 `0` 来表示。</param>
    /// <returns>从左上到右下的不同的路径数</returns>
    public static int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        int[] dp = new int[n];
        // 初始化：遇到障碍前仅有一条路，之后全为0
        dp[0] = obstacleGrid[0][0] == 1 ? 0 : 1;
        for (int i = 1; i < n; i++)
        {
            if (obstacleGrid[0][i] == 1)
            {
                dp[i] = 0;
            }
            else
            {
                dp[i] = dp[i - 1];
            }
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // 当前格是障碍，不可达，置为0
                if (obstacleGrid[i][j] == 1)
                {
                    dp[j] = 0;
                    continue;
                }
                if (j > 0)
                {
                    dp[j] = dp[j - 1] + dp[j];
                }
            }
        }
        return dp[n - 1];
    }
}