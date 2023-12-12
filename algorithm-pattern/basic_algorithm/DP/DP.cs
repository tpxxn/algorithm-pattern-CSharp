namespace algorithm_pattern.basic_algorithm.DP;

public partial class DP
{
    /// <summary>
    /// <para>120. 三角形最小路径和</para>
    /// <para>https://leetcode.cn/problems/triangle/</para>
    ///  会超时
    /// </summary>
    /// <param name="triangle">给定三角形</param>
    /// <returns>三角形最小路径和</returns>
    public static int MinimumTotal(IList<IList<int>> triangle)
    {
        return DFS(0, 0, triangle);
    }

    /// <summary>
    /// 返回值表示从x, y处到底部的最小路径和 
    /// </summary>
    /// <param name="x">当前递归行 x</param>
    /// <param name="y">当前递归列 y</param>
    /// <param name="triangle">给定三角形</param>
    /// <returns>从x, y处到底部的最小路径和</returns>
    private static int DFS(int x, int y, IList<IList<int>> triangle)
    {
        if (x == triangle.Count - 1)
        {
            return triangle[x][y];
        }
        int minLeft = DFS(x + 1, y, triangle);
        int minRight = DFS(x + 1, y + 1, triangle);
        return Math.Min(minLeft, minRight) + triangle[x][y];
    }

    /// <summary>
    /// 优化 DFS，缓存已经被计算的值
    /// </summary>
    /// <param name="triangle">给定三角形</param>
    /// <returns>三角形最小路径和</returns>
    public static int MinimumTotal2(IList<IList<int>> triangle)
    {
        int[,] saves = new int[triangle.Count, triangle.Count];
        return DFS2(0, 0, triangle, saves);
    }

    /// <summary>
    /// 使用saves数组记录已经被计算过的值
    /// 返回值表示从x, y处到底部的最小路径和
    /// </summary>
    /// <param name="x">当前递归行 x</param>
    /// <param name="y">当前递归列 y</param>
    /// <param name="triangle">给定三角形</param>
    /// <param name="saves">缓存的计算值</param>
    /// <returns>从x, y处到底部的最小路径和</returns>
    private static int DFS2(int x, int y, IList<IList<int>> triangle, int[,] saves)
    {
        if (x == triangle.Count - 1)
        {
            return triangle[x][y];
        }
        // 如果已经被计算过则直接返回
        if (saves[x, y] != 0)
        {
            return saves[x, y];
        }
        int minLeft = DFS2(x + 1, y, triangle, saves);
        int minRight = DFS2(x + 1, y + 1, triangle, saves);
        // 缓存已经被计算的值
        saves[x, y] = Math.Min(minLeft, minRight) + triangle[x][y];
        return saves[x, y];
    }

    /// <summary>
    /// 自底向上
    /// </summary>
    /// <param name="triangle">给定三角形</param>
    /// <returns>三角形最小路径和</returns>
    public static int MinimumTotal_DownToUp(IList<IList<int>> triangle)
    {
        // 1、状态定义：f[i][j] 表示从i,j出发，到达最后一层的最短路径
        int[,] dp = new int[triangle.Count, triangle.Count];
        // 2、初始化
        for (int i = 0; i < triangle.Count; i++)
        {
            dp[triangle.Count - 1, i] = triangle[^1][i];
        }
        // 3、递推求解
        for (int i = triangle.Count - 2; i >= 0; i--)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]) + triangle[i][j];
            }
        }
        // 4、结果
        return dp[0, 0];
    }

    /// <summary>
    /// 自顶向下
    /// </summary>
    /// <param name="triangle">给定三角形</param>
    /// <returns>三角形最小路径和</returns>
    public static int MinimumTotal_TopToDown(IList<IList<int>> triangle)
    {
        // 1、状态定义：dp[i][j] 表示从0,0出发，到达i,j的最短路径
        int[,] dp = new int[triangle.Count, triangle.Count];
        // 2、初始化
        dp[0, 0] = triangle[0][0];
        for (int i = 1; i < triangle.Count; i++)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                // 这里分为三种情况：
                // 1、上一层没有左边值
                // 2、上一层没有右边值
                // 3、其他
                if (j == 0)
                {
                    dp[i, j] = dp[i - 1, j] + triangle[i][j];
                }
                else if (j == triangle[i].Count - 1)
                {
                    dp[i, j] = dp[i - 1, j - 1] + triangle[i][j];
                }
                else
                {
                    dp[i, j] = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]) + triangle[i][j];
                }
            }
        }
        // 从最后一层中查找最小值
        int minValue = dp[triangle.Count - 1, 0];
        for (int i = 0; i < triangle.Count; i++)
        {
            minValue = Math.Min(minValue, dp[triangle.Count - 1, i]);
        }
        return minValue;
    }

    /// <summary>
    /// 空间优化
    /// </summary>
    /// <param name="triangle">给定三角形</param>
    /// <returns>三角形最小路径和</returns>
    public static int MinimumTotal_Final(IList<IList<int>> triangle)
    {
        int[] dp = new int[triangle.Count];
        for (int i = 0; i < triangle.Count; i++)
        {
            dp[i] = triangle[^1][i];
        }
        for (int i = triangle.Count - 2; i >= 0; i--)
        {
            for (int j = 0; j < triangle[i].Count; j++)
            {
                dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
            }
        }
        return dp[0];
    }
}