# 动态规划

## 背景

> [120. 三角形最小路径和](https://leetcode-cn.com/problems/triangle/)
>
> 给定一个三角形，找出自顶向下的最小路径和。每一步只能移动到下一行中相邻的结点上。

例如，给定三角形：

```text
[
     [2],
    [3,4],
   [6,5,7],
  [4,1,8,3]
]
```

自顶向下的最小路径和为  11（即，2 + 3 + 5 + 1 = 11）。

### DFS

使用 DFS：

```csharp
// 会超时
public int MinimumTotal(IList<IList<int>> triangle)
{
    return DFS(0, 0, triangle);
}

// 返回值表示从x, y处到底部的最小路径和 
private int DFS(int x, int y, IList<IList<int>> triangle)
{
    if (x == triangle.Count - 1)
    {
        return triangle[x][y];
    }
    int minLeft = DFS(x + 1, y, triangle);
    int minRight = DFS(x + 1, y + 1, triangle);
    return Math.Min(minLeft, minRight) + triangle[x][y];
}
```

### DFS的优化

优化 DFS，缓存已经被计算的值（称为：记忆化搜索 本质上：动态规划）

```csharp
public int MinimumTotal(IList<IList<int>> triangle)
{
    int[,] saves = new int[triangle.Count, triangle.Count];
    return DFS2(0, 0, triangle, saves);
}

// 使用saves数组记录已经被计算过的值
// 返回值表示从x, y处到底部的最小路径和
private int DFS2(int x, int y, IList<IList<int>> triangle, int[,] saves)
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
```

### 从DFS到动态规划

动态规划就是把大问题变成小问题，并解决了小问题重复计算的方法称为动态规划

动态规划和 DFS 区别

- 二叉树 子问题是没有交集，所以大部分二叉树都用递归或者分治法，即 DFS，就可以解决
- 像 triangle 这种是有重复走的情况，**子问题是有交集**，所以可以用动态规划来解决

#### 自底向上

```csharp
public int MinimumTotal(IList<IList<int>> triangle)
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
```

#### 自顶向下

```csharp
public int MinimumTotal(IList<IList<int>> triangle)
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
```

#### 空间优化

经过观察发现当前状态只与上一批状态有关，所以二维数组可以优化为一位数组，减少空间占用。

```csharp
public int MinimumTotal(IList<IList<int>> triangle)
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
```

除此之外，也可以覆盖原有数据以实现空间复用。

## 使用场景

满足两个条件

- 满足以下条件之一
    - 求最大/最小值（Maximum/Minimum ）
    - 求是否可行（Yes/No ）
    - 求可行个数（Count(\*) ）
- 满足不能排序或者交换（Can not sort / swap ）

如题：[longest-consecutive-sequence](https://leetcode-cn.com/problems/longest-consecutive-sequence/)  位置可以交换，所以不用动态规划

## 四点要素

1. **状态 State**
    - 灵感，创造力，存储小规模问题的结果
2. 方程 Function
    - 状态之间的联系，怎么通过小的状态，来算大的状态
3. 初始化 Intialization
    - 最极限的小状态是什么, 起点
4. 答案 Answer
    - 最大的那个状态是什么，终点

## 常见四种类型

1. Matrix DP (10%)
1. Sequence (40%)
1. Two Sequences DP (40%)
1. Backpack (10%)

> 注意点
>
> - 贪心算法大多题目靠背答案，所以如果能用动态规划就尽量用动规，不用贪心算法

### 矩阵类型

#### 最小路径和

> [064. 最小路径和](https://leetcode-cn.com/problems/minimum-path-sum/)
>
> 给定一个包含非负整数的 `m x n`  网格 `grid`，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
> 
> 说明：每次只能向下或者向右移动一步。
> 
> **示例 1：**
>
> ```
> 输入：grid = [[1,3,1],[1,5,1],[4,2,1]]
> 输出：7
> 解释：因为路径 1→3→1→1→1 的总和最小。
> ```
>
> **示例 2：**
>
> ```
> 输入：grid = [[1,2,3],[4,5,6]]
> 输出：12
> ```

```csharp
public int minPathSum(int[][] grid) {
    // dp[i][j] 表示0,0到i,j的最小和
    int[] dp = new int[grid[0].length];
    // 初始化：用第一行初始化
    dp[0] = grid[0][0];
    for (int i = 1; i < grid[0].length; i++) {
        dp[i] = dp[i-1] + grid[0][i];
    }
    // 状态转移方程
    // 每行第一个元素：
    // dp[j] = dp[j](到上一行这个位置的最小和) + grid[i][j];
    // 后续元素：
    // dp[j] = Math.min(dp[j-1](到左边位置的最小和), dp[j](到上一行这个位置的最小和)) + grid[i][j];
    for (int i = 1; i < grid.length; i++) {
        for (int j = 0; j < grid[0].length; j++) {
            if (j == 0) {
                dp[j] = dp[j] + grid[i][j];
            } else {
                dp[j] = Math.min(dp[j-1], dp[j]) + grid[i][j];
            }
        }
    }
    // 答案
    return dp[grid[0].length - 1];
}
```

#### 不同路径

> [062. 不同路径](https://leetcode-cn.com/problems/unique-paths/)
>
> 一个机器人位于一个 `m x n` 网格的左上角 （起始点在下图中标记为“Start” ）。
> 
> 机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。
>
> 问总共有多少条不同的路径？
> 
> **示例 1：**
> 
> ![img](../images/dp_unique_paths.png)
> 
> ```
> 输入：m = 3, n = 7
> 输出：28
> ```
>
> **示例 2：**
>
> ```
> 输入：m = 3, n = 2
> 输出：3
> 解释：
> 从左上角开始，总共有 3 条路径可以到达右下角。
> 1. 向右 -> 向下 -> 向下
> 2. 向下 -> 向下 -> 向右
> 3. 向下 -> 向右 -> 向下
> ```

```csharp
public int UniquePaths(int m, int n)
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
```

#### 不同路径 II

> [063. 不同路径 II](https://leetcode-cn.com/problems/unique-paths-ii/)
>
> 一个机器人位于一个 `m x n` 网格的左上角 （起始点在下图中标记为“Start” ）。
> 机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。
>
> 问总共有多少条不同的路径？
>
> 现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？
> 
> 网格中的障碍物和空位置分别用 `1` 和 `0` 来表示。
> 
> **示例 1：**
>
> >![img](../images/dp_unique_paths_2_1.jpg)
> >
> > **输入**：obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
> >
> > **输出**：2
> >
> > **解释**：
> > 3x3 网格的正中间有一个障碍物。
> > 从左上角到右下角一共有 2 条不同的路径：
> > 1. 向右 -> 向右 -> 向下 -> 向下
> > 2. 向下 -> 向下 -> 向右 -> 向右
>
>
> **示例 2：**
>
> > ![img](../images/dp_unique_paths_2_2.jpg)
> >
> >
> > 输入：obstacleGrid = [[0,1],[0,0]]
> >
> > 输出：1

```csharp
public int UniquePathsWithObstacles(int[][] obstacleGrid
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
```

### 序列类型

#### 爬楼梯

> [070. 爬楼梯](https://leetcode-cn.com/problems/climbing-stairs/)
>
> 假设你正在爬楼梯。需要 `n` 阶你才能到达楼顶。
>
> 每次你可以爬 `1` 或 `2` 个台阶。你有多少种不同的方法可以爬到楼顶？

```csharp
public int ClimbStairs(int n)
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
```

#### 跳跃游戏

> [055. 跳跃游戏](https://leetcode-cn.com/problems/jump-game/)
>
> 给你一个非负整数数组 `nums`，你最初位于数组的 **第一个下标** 。数组中的每个元素代表你在该位置可以跳跃的最大长度。
>
> 判断你是否能够到达最后一个下标，如果可以，返回 `true` ；否则，返回 `false` 。

```csharp
public bool CanJump(int[] nums)
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
```

#### 跳跃游戏-ii

> [045. 跳跃游戏-ii](https://leetcode-cn.com/problems/jump-game-ii/)
>
> 给定一个长度为 `n` 的 `0` 索引整数数组 nums。初始位置为 `nums[0]`。
>
> 每个元素 `nums[i]` 表示从索引 `i` 向前跳转的最大长度。换句话说，如果你在 `nums[i]` 处，你可以跳转到任意 `nums[i + j]` 处:
>
> `0 <= j <= nums[i]`
> `i + j < n`
> 返回到达 `nums[n - 1]` 的最小跳跃次数。生成的测试用例可以到达 `nums[n - 1]`。

v1 动态规划
```csharp
public int Jump(int[] nums)
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
```

v2 动态规划+贪心算法
```csharp
public int Jump_Greedy(int[] nums)
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
```

#### 分割回文串-ii

> [132. 分割回文串-ii](https://leetcode-cn.com/problems/palindrome-partitioning-ii/)
>
> 给你一个字符串 `s`，请你将 `s` 分割成一些子串，使每个子串都是回文。
>
> 返回符合要求的 **最少分割次数**。

```csharp
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
```

注意点

- 判断回文字符串时，可以提前用动态规划算好，减少时间复杂度

#### 最长递增子序列

> [300. 最长递增子序列](https://leetcode-cn.com/problems/longest-increasing-subsequence/)
>
> 给你一个整数数组 `nums` ，找到其中最长严格递增子序列的长度。
>
> **子序列** 是由数组派生而来的序列，删除（或不删除）数组中的元素而不改变其余元素的顺序。例如，`[3,6,2,7]` 是数组 `[0,3,1,6,2,2,7]` 的子序列。

```csharp
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
```

#### 单词拆分

> [139. 单词拆分](https://leetcode-cn.com/problems/word-break/)
>
> 给你一个字符串 `s` 和一个字符串列表 `wordDict` 作为字典。请你判断是否可以利用字典中出现的单词拼接出 `s`。
>
> **注意**：不要求字典中出现的单词全部都使用，并且字典中的单词可以重复使用。
>
> **示例 1：**
>
> > **输入**: s = "leetcode", wordDict = ["leet", "code"]
> >
> > **输出**: true
> >
> > **解释**: 返回 true 因为 "leetcode" 可以由 "leet" 和 "code" 拼接成。
>
> **示例 2：**
>
> > **输入**: s = "applepenapple", wordDict = ["apple", "pen"]
> > 
> > **输出**: true
> >
> > **解释**: 返回 true 因为 "applepenapple" 可以由 "apple" "pen" "apple" 拼接成。
>
> **示例 3：**
>
> > **输入**: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
> >
> > **输出**: false

```csharp
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
```

#### 小结

常见处理方式是给 0 位置占位，这样处理问题时一视同仁，初始化则在原来基础上 `length+1`，返回结果 `f[n]`

- 状态可以为前 i 个
- 初始化 `length+1`
- 取值 `index=i-1`
- 返回值：`f[n]`或者 `f[m][n]`

### 双序列类型

#### 最长公共子序列

> [1143. 最长公共子序列](https://leetcode-cn.com/problems/longest-common-subsequence/)
>
> 给定两个字符串  text1 和  text2，返回这两个字符串的最长公共子序列。
> 一个字符串的   子序列   是指这样一个新的字符串：它是由原字符串在不改变字符的相对顺序的情况下删除某些字符（也可以不删除任何字符）后组成的新字符串。
> 例如，"ace" 是 "abcde" 的子序列，但 "aec" 不是 "abcde" 的子序列。两个字符串的「公共子序列」是这两个字符串所共同拥有的子序列。

```csharp
public int longestCommonSubsequence(String text1, String text2) {
    // dp[i][j] a前i个和b前j个字符最长公共子序列
    // dp[m+1][n+1]
    //   ' a d c e
    // ' 0 0 0 0 0
    // a 0 1 1 1 1
    // c 0 1 1 2 1
    int[][] dp = new int[text1.length() + 1][text2.length() + 1];
    for (int i = 1; i <= text1.length(); i++) {
        for (int j = 1; j <= text2.length(); j++) {
            // 相等取左上元素+1，否则取左或上的较大值
            if (text1.charAt(i - 1) == text2.charAt(j - 1)) {
                dp[i][j] = dp[i - 1][j - 1] + 1;
            } else {
                dp[i][j] = Math.max(dp[i - 1][j], dp[i][j - 1]);
            }
        }
    }
    return dp[text1.length()][text2.length()];
}
```

注意点

- 从 1 开始遍历到最大长度

- 索引需要减一

####  编辑距离

> [072. 编辑距离](https://leetcode-cn.com/problems/edit-distance/)
>
> 给你两个单词  word1 和  word2，请你计算出将  word1  转换成  word2 所使用的最少操作数 。你可以对一个单词进行如下三种操作：
>
> 1. 插入一个字符
> 2. 删除一个字符
> 3. 替换一个字符

思路：和上题很类似，相等则不需要操作，否则取删除、插入、替换最小操作次数的值+1

```csharp
// dp[i][j] 表示a字符串的前i个字符编辑为b字符串的前j个字符最少需要多少次操作
    // dp[i][j] = OR(dp[i-1][j-1]，a[i]==b[j],min(dp[i-1][j],dp[i][j-1],dp[i-1][j-1])+1)
public int minDistance(String word1, String word2) {
    int[][] dp = new int[word1.length() + 1][word2.length() + 1];
    for (int i = 0; i <= word1.length(); i++) {
        dp[i][0] = i;
    }
    for (int i = 0; i <= word2.length(); i++) {
        dp[0][i] = i;
    }
    for (int i = 1; i <= word1.length(); i++) {
        for (int j = 1; j <= word2.length(); j++) {
            // 相等则不需要操作
            if (word1.charAt(i - 1) == word2.charAt(j - 1)) {
                dp[i][j] = dp[i - 1][j - 1];
            } 
            // 否则取删除、插入、替换最小操作次数的值+1
            else {
                dp[i][j] = Math.min(Math.min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]) + 1;
            }
        }
    }
    return dp[word1.length()][word2.length()];
}
```

说明

> 另外一种做法：MAXLEN(a,b)-LCS(a,b)

### 零钱和背包

#### 零钱兑换

> [322. 零钱兑换](https://leetcode-cn.com/problems/coin-change/)
>
> 给定不同面额的硬币 coins 和一个总金额 amount。编写一个函数来计算可以凑成总金额所需的最少的硬币个数。如果没有任何一种硬币组合能组成总金额，返回  -1。

思路：和其他 DP 不太一样，i 表示钱或者容量

```csharp
public int coinChange(int[] coins, int amount) {
    // 状态 dp[i]表示金额为i时，组成的最小硬币个数
    int[] dp = new int[amount + 1];
    dp[0] = 0;
    for (int i = 1; i <= amount; i++) {
        // 初始化为最大值
        int minNum = Integer.MAX_VALUE;
        for (int n : coins) {
            if (i - n >= 0) {
                // 如果上个金额也无法组成，则直接标记
                if (dp[i - n] == -1) {
                    dp[i] = -1;
                    continue;
                } else {
                    minNum = Math.min(minNum, dp[i - n] + 1);
                }
            } else if (i % n == 0) {
                minNum = i / n;
            }
        }
        dp[i] = (minNum == Integer.MAX_VALUE ? -1 : minNum);
    }
    return dp[amount];
}
```

#### 零钱兑换 II

> [518. 零钱兑换 II](https://leetcode-cn.com/problems/coin-change-2/)
>
> 给定不同面额的硬币和一个总金额。写出函数来计算可以凑成总金额的硬币组合数。假设每一种面额的硬币有无限个。

先遍历物品再遍历背包 - 组合数

先遍历背包再遍历物品 - 排列数

```csharp
public int change(int amount, int[] coins) {
    // 状态 dp[i]表示金额为i时，组合的方法数
    int[] dp = new int[amount + 1];
    dp[0] = 1;
    // 先遍历物品再遍历背包
    for (int n : coins) {
        for (int i = n; i <= amount; i++) {
            dp[i] += dp[i - n];
        }
    }
    return dp[amount];
}
```

### 背包问题

> [092. 背包问题](https://www.lintcode.com/problem/backpack/description)
>
> 在 `n` 个物品中挑选若干物品装入背包，最多能装多满？假设背包的大小为 `m`，每个物品的大小为 A<sub>i</sub>
>
> （每个物品只能选择一次且物品大小均为正整数）

```csharp
func backPack (m int, A []int) int {
    // write your code here
    // f[i][j] 前i个物品，是否能装j
    // f[i][j] =f[i-1][j] f[i-1][j-a[i] j>a[i]
    // f[0][0]=true f[...][0]=true
    // f[n][X]
    f:=make([][]bool,len(A)+1)
    for i:=0;i<=len(A);i++{
        f[i]=make([]bool,m+1)
    }
    f[0][0]=true
    for i:=1;i<=len(A);i++{
        for j:=0;j<=m;j++{
            f[i][j]=f[i-1][j]
            if j-A[i-1]>=0 && f[i-1][j-A[i-1]]{
                f[i][j]=true
            }
        }
    }
    for i:=m;i>=0;i--{
        if f[len(A)][i] {
            return i
        }
    }
    return 0
}
```

#### 背包问题-ii

> [125. 背包问题-ii](https://www.lintcode.com/problem/backpack-ii/description)
>
> 有 `n` 个物品和一个大小为 `m` 的背包. 给定数组 `A` 表示每个物品的大小和数组 `V` 表示每个物品的价值.
> 
> 问最多能装入背包的总价值是多大?

思路：f[i][j] 前 i 个物品，装入 j 背包 最大价值

```csharp
func backPackII (m int, A []int, V []int) int {
    // write your code here
    // f[i][j] 前i个物品，装入j背包 最大价值
    // f[i][j] =max(f[i-1][j] ,f[i-1][j-A[i]]+V[i]) 是否加入A[i]物品
    // f[0][0]=0 f[0][...]=0 f[...][0]=0
    f:=make([][]int,len(A)+1)
    for i:=0;i<len(A)+1;i++{
        f[i]=make([]int,m+1)
    }
    for i:=1;i<=len(A);i++{
        for j:=0;j<=m;j++{
            f[i][j]=f[i-1][j]
            if j-A[i-1] >= 0{
                f[i][j]=max(f[i-1][j],f[i-1][j-A[i-1]]+V[i-1])
            }
        }
    }
    return f[len(A)][m]
}
func max(a,b int)int{
    if a>b{
        return a
    }
    return b
}
```

#### 分割等和子集

> [416. 分割等和子集](https://leetcode-cn.com/problems/partition-equal-subset-sum/)
>
> 给定一个**只包含正整数**的**非空**数组。是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。

等价于0-1背包问题，只不过目标为数组和的一半。状态转移可以参考题解：[动态规划（转换为 0-1 背包问题）](https://leetcode-cn.com/problems/partition-equal-subset-sum/solution/0-1-bei-bao-wen-ti-xiang-jie-zhen-dui-ben-ti-de-yo/)。

```csharp
public boolean canPartition(int[] nums) {
    // 首先计算数组的和
    int sum = 0;
    for (int n : nums) {
        sum += n;
    }
    // 如果和不是2的倍数则肯定无法分割
    if (sum % 2 != 0) {
        return false;
    }
    sum /= 2;
    // dp[i][j]表示从数组的[0, i]子区间内挑选一些正整数(每个数只能用一次)使得这些数的和恰好等于j
    boolean[][] dp = new boolean[nums.length][sum + 1];
    if (nums[0] <= sum) {
        dp[0][nums[0]] = true;
    }
    for (int i = 1; i < nums.length; i++) {
        for (int j = 0; j <= sum; j++) {
            // 注意这里的状态转移方程
            if (nums[i] == j) {
                dp[i][j] = true;
            } else if (nums[i] < j) {
                dp[i][j] = dp[i - 1][j] || dp[i-1][j-nums[i]];
            } else {
                dp[i][j] = dp[i-1][j];
            }
        }
    }
    return dp[nums.length - 1][sum];
}
```

## 练习

Matrix DP (10%)

- [ ] [120. 三角形最小路径和](https://leetcode-cn.com/problems/triangle/)
- [ ] [064. 最小路径和](https://leetcode-cn.com/problems/minimum-path-sum/)
- [ ] [062. 不同路径](https://leetcode-cn.com/problems/unique-paths/)
- [ ] [063. 不同路径-ii](https://leetcode-cn.com/problems/unique-paths-ii/)

Sequence (40%)

- [ ] [070. 爬楼梯](https://leetcode-cn.com/problems/climbing-stairs/)
- [ ] [055. 跳跃游戏](https://leetcode-cn.com/problems/jump-game/)
- [ ] [045. 跳跃游戏-ii](https://leetcode-cn.com/problems/jump-game-ii/)
- [ ] [132. 分割回文串-ii](https://leetcode-cn.com/problems/palindrome-partitioning-ii/)
- [ ] [300. 最长递增子序列](https://leetcode-cn.com/problems/longest-increasing-subsequence/)
- [ ] [139. 单词拆分](https://leetcode-cn.com/problems/word-break/)

Two Sequences DP (40%)

- [ ] [1143. 最长公共子序列](https://leetcode-cn.com/problems/longest-common-subsequence/)
- [ ] [072. 编辑距离](https://leetcode-cn.com/problems/edit-distance/)

Backpack & Coin Change (10%)

- [ ] [322. 零钱兑换](https://leetcode-cn.com/problems/coin-change/)
- [ ] [518. 零钱兑换 II](https://leetcode-cn.com/problems/coin-change-2/)
- [ ] [092. 背包问题](https://www.lintcode.com/problem/backpack/description)
- [ ] [125. 背包问题-ii](https://www.lintcode.com/problem/backpack-ii/description)
- [ ] [416. 分割等和子集](https://leetcode-cn.com/problems/partition-equal-subset-sum/)
