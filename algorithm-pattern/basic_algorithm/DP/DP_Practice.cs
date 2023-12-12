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

    /// <summary>
    /// <para>070. 爬楼梯</para>
    /// <para>https://leetcode-cn.com/problems/climbing-stairs/</para>
    /// </summary>
    /// <param name="n">爬到顶部的台阶数</param>
    /// <returns>爬到顶部的方法数</returns>
    public static int ClimbStairs(int n)
    {
        int[] dp = new int[] { 0, 1 };
        while (n > 0)
        {
            int temp = dp[0] + dp[1];
            dp[0] = dp[1];
            dp[1] = temp;
            n--;
        }
        return dp[1];
    }

    /// <summary>
    /// <para>055. 跳跃游戏</para>
    /// <para>https://leetcode-cn.com/problems/jump-game/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <returns>是否能够到达最后一个位置</returns>
    public static bool CanJump(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        dp[0] = nums[0];
        for (int i = 1; i < n && dp[i] < n - 1; i++)
        {
            if (dp[i - 1] < i)
            {
                return false;
            }
            dp[i] = Math.Max(dp[i - 1], i + nums[i]);
        }
        return true;
    }

    /// <summary>
    /// <para>45. 跳跃游戏 II</para>
    /// <para>https://leetcode-cn.com/problems/jump-game-ii/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <returns>最少的跳跃次数</returns>
    public static int Jump(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        int prev = 0;
        for (int i = 1; i < n; i++)
        {
            while (prev + nums[prev] < i)
            {
                prev++;
            }
            dp[i] = dp[prev] + 1;
        }
        return dp[n - 1];
    }

    /// <summary>
    /// <para>45. 跳跃游戏 II</para>
    /// <para>https://leetcode-cn.com/problems/jump-game-ii/</para>
    /// 贪心算法
    /// </summary>
    /// <param name="nums">数组</param>
    /// <returns>最少的跳跃次数</returns>
    public static int Jump_Greedy(int[] nums)
    {
        int currJumps = 0; // 当前跳跃次数
        int currMaxPosition = 0; // 跳跃次数 currJumps 可以到达的最大下标
        int nextMaxPosition = 0; // 跳跃次数 currJumps+1 可以到达的最大下标
        int n = nums.Length;
        for (int i = 0; i < n && currMaxPosition < n - 1; i++)
        {
            if (i > currMaxPosition)
            {
                currJumps++;
                currMaxPosition = nextMaxPosition;
            }
            nextMaxPosition = Math.Max(nextMaxPosition, i + nums[i]);
        }
        return currJumps;
    }

    /// <summary>
    /// <para>132. 分割回文串 II</para>
    /// <para>https://leetcode-cn.com/problems/palindrome-partitioning-ii/</para>
    /// </summary>
    /// <param name="s">字符串</param>
    /// <returns>最少分割次数</returns>
    public static int MinCut(string s)
    {
        int n = s.Length;
        bool[][] isPalindrome = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            isPalindrome[i] = new bool[n];
            isPalindrome[i][i] = true;
        }
        for (int i = 0; i < n - 1; i++)
        {
            isPalindrome[i][i + 1] = s[i] == s[i + 1];
        }
        for (int subLength = 3; subLength <= n; subLength++)
        {
            for (int i = 0, j = subLength - 1; j < n; i++, j++)
            {
                isPalindrome[i][j] = s[i] == s[j] && isPalindrome[i + 1][j - 1];
            }
        }
        int[] dp = new int[n];
        for (int i = 1; i < n; i++)
        {
            dp[i] = i;
            for (int j = 0; j <= i; j++)
            {
                if (isPalindrome[j][i])
                {
                    int currCuts = j == 0 ? 0 : dp[j - 1] + 1;
                    dp[i] = Math.Min(dp[i], currCuts);
                }
            }
        }
        return dp[n - 1];
    }

    /// <summary>
    /// <para>300. 最长递增子序列</para>
    /// <para>https://leetcode-cn.com/problems/longest-increasing-subsequence/</para>
    /// </summary>
    public static int LengthOfLIS(int[] nums)
    {
        // dp[i]表示从0到i的最长上升子序列长度
        int[] dp = new int[nums.Length];
        // 初始化：到第一个元素序列长度为1
        dp[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            // 注意默认为1，即此处最长子序列为自身
            int maxLen = 1;
            // dp[i] = max(dp[j]) + 1 , nums[j] < nums[i]
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    maxLen = Math.Max(maxLen, dp[j] + 1);
                }
            }
            dp[i] = maxLen;
        }
        int maxNum = 0;
        foreach (var n in dp)
        {
            maxNum = Math.Max(maxNum, n);
        }
        // 答案：dp中的最大值
        return maxNum;
    }

    /// <summary>
    /// <para>139. 单词拆分</para>
    /// <para>https://leetcode-cn.com/problems/word-break/</para>
    /// </summary>
    /// <param name="s">字符串</param>
    /// <param name="wordDict">单词字典</param>
    /// <returns>是否可以拆分成字典中的所有单词</returns>
    public static bool WordBreak(string s, IList<string> wordDict)
    {
        ISet<string> wordDictSet = new HashSet<string>(wordDict);
        int maxWordLength = 0;
        foreach (string word in wordDict)
        {
            maxWordLength = Math.Max(maxWordLength, word.Length);
        }
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        for (int i = 1; i <= n; i++)
        {
            for (int j = Math.Min(i, maxWordLength); j > 0 && !dp[i]; j--)
            {
                if (dp[i - j] && wordDictSet.Contains(s.Substring(i - j, j)))
                {
                    dp[i] = true;
                }
            }
        }
        return dp[n];
    }

    /// <summary>
    /// <para>1143. 最长公共子序列</para>
    /// <para>https://leetcode-cn.com/problems/longest-common-subsequence/</para>
    /// </summary>
    /// <param name="text1">给定字符串1</param>
    /// <param name="text2">给定字符串2</param>
    /// <returns>最长公共子序列长度</returns>
    public static int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length;
        int n = text2.Length;
        // dp[i][j] a前i个和b前j个字符最长公共子序列
        // dp[m+1][n+1]
        //   ' a d c e
        // ' 0 0 0 0 0
        // a 0 1 1 1 1
        // c 0 1 1 2 1
        int[][] dp = new int[m + 1][];
        for (int i = 0; i < m + 1; i++)
        {
            dp[i] = new int[n + 1];
        }
        for (int i = 1; i <= m; i++)
        {
            char c1 = text1[i - 1];
            for (int j = 1; j <= n; j++)
            {
                char c2 = text2[j - 1];
                // 相等取左上元素+1，否则取左或上的较大值
                if (c1 == c2)
                {
                    dp[i][j] = dp[i - 1][j - 1] + 1;
                }
                else
                {
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }
        return dp[m][n];
    }

    /// <summary>
    /// <para>72. 编辑距离</para>
    /// <para>https://leetcode-cn.com/problems/edit-distance/</para>
    /// </summary>
    /// <param name="word1">给定字符串1</param>
    /// <param name="word2">给定字符串2</param>
    /// <returns>将 word1 转换成 word2 所使用的最少操作</returns>
    public static int MinDistance(string word1, string word2)
    {
        // dp[i][j] 表示a字符串的前i个字符编辑为b字符串的前j个字符最少需要多少次操作
        // dp[i][j] = OR(dp[i-1][j-1]，a[i]==b[j],min(dp[i-1][j],dp[i][j-1],dp[i-1][j-1])+1)
        int m = word1.Length, n = word2.Length;
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
        }
        for (int j = 1; j <= n; j++)
        {
            dp[0][j] = j;
        }
        for (int i = 1; i <= m; i++)
        {
            dp[i][0] = i;
        }
        for (int i = 1; i <= m; i++)
        {
            char c1 = word1[i - 1];
            for (int j = 1; j <= n; j++)
            {
                char c2 = word2[j - 1];
                // 相等则不需要操作
                if (c1 == c2)
                {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                // 否则取删除、插入、替换最小操作次数的值+1
                else
                {
                    dp[i][j] = Math.Min(Math.Min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]) + 1;
                }
            }
        }
        return dp[m][n];
    }
}