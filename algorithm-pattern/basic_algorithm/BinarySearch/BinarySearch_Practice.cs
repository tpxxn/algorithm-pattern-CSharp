namespace algorithm_pattern;

public static partial class BinarySearch
{
    /// <summary>
    /// <para>61. 搜索区间</para>
    /// <para>https://www.lintcode.com/problem/search-for-a-range/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <param name="target">目标值</param>
    /// <returns>是否为有效的二叉搜索树</returns>
    public static int[] SearchRange(int[] nums, int target)
    {
        return new int[] { -1, -1 };
    }

    /// <summary>
    /// <para>35. 搜索插入位置</para>
    /// <para>https://leetcode-cn.com/problems/search-insert-position/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <param name="target">目标值</param>
    /// <returns>插入位置</returns>
    public static int SearchInsert(int[] nums, int target)
    {
        return 0;
    }

    /// <summary>
    /// <para>74. 搜索二维矩阵</para>
    /// <para>https://leetcode-cn.com/problems/search-a-2d-matrix/</para>
    /// </summary>
    /// <param name="matrix">矩阵</param>
    /// <param name="target">目标值</param>
    /// <returns>target 是否在二维矩阵中</returns>
    public static bool SearchMatrix(int[][] matrix, int target)
    {
        return false;
    }

    /// <summary>
    /// <para>278. 第一个错误的版本</para>
    /// <para>https://www.lintcode.com/problem/first-bad-version/</para>
    /// </summary>
    /// <param name="n">版本数量</param>
    /// <returns>第一个错误的版本</returns>
    public static int FirstBadVersion(int n, int badVersion)
    {
        int low = 1, high = n;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (IsBadVersion(mid, badVersion))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        return low;
    }

    static bool IsBadVersion(int version, int badVersion)
    {
        return version >= badVersion;
    }

    /// <summary>
    /// <para>153. 寻找旋转排序数组中的最小值</para>
    /// <para>https://www.lintcode.com/problem/find-minimum-in-rotated-sorted-array/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <returns>最小值</returns>
    public static int FindMin(int[] nums)
    {
        return 0;
    }

    /// <summary>
    /// <para>154. 寻找旋转排序数组中的最小值II</para>
    /// <para>https://www.lintcode.com/problem/find-minimum-in-rotated-sorted-array-ii/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <returns>最小值</returns>
    public static int FindMin2(int[] nums)
    {
        return 0;
    }

    /// <summary>
    /// <para>33. 搜索旋转排序数组</para>
    /// <para>https://www.lintcode.com/problem/search-in-rotated-sorted-array/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <param name="target">目标值</param>
    /// <returns>target 位置</returns>
    public static int SearchRotate(int[] nums, int target)
    {
        return 0;
    }

    /// <summary>
    /// <para>81. 搜索旋转排序数组II</para>
    /// <para>https://www.lintcode.com/problem/search-in-rotated-sorted-array-ii/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <param name="target">目标值</param>
    /// <returns>target 位置</returns>
    public static bool SearchRotate2(int[] nums, int target)
    {
        return false;
    }
}