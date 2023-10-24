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
        if (nums.Length == 0)
        {
            return new[] { -1, -1 };
        }

        int mid;
        int[] bound = new int[2];

        // search for left bound
        var start = 0;
        var end = nums.Length - 1;
        while (start + 1 < end)
        {
            mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                end = mid;
            }
            else if (nums[mid] < target)
            {
                start = mid;
            }
            else
            {
                end = mid;
            }
        }
        if (nums[start] == target)
        {
            bound[0] = start;
        }
        else if (nums[end] == target)
        {
            bound[0] = end;
        }
        else
        {
            bound[0] = bound[1] = -1;
            return bound;
        }

        // search for right bound
        start = 0;
        end = nums.Length - 1;
        while (start + 1 < end)
        {
            mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                start = mid;
            }
            else if (nums[mid] < target)
            {
                start = mid;
            }
            else
            {
                end = mid;
            }
        }
        if (nums[end] == target)
        {
            bound[1] = end;
        }
        else if (nums[start] == target)
        {
            bound[1] = start;
        }
        else
        {
            bound[0] = bound[1] = -1;
            return bound;
        }

        return bound;
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
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return low;
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
        int m = matrix.Length, n = matrix[0].Length;
        int low = 0, high = m * n - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int row = mid / n, column = mid % n;
            if (matrix[row][column] == target)
            {
                return true;
            }
            else if (matrix[row][column] > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
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
        int low = 0, high = nums.Length - 1;
        while (low < high && nums[low] > nums[high])
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] < nums[low])
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        return nums[low];
    }

    /// <summary>
    /// <para>154. 寻找旋转排序数组中的最小值II</para>
    /// <para>https://www.lintcode.com/problem/find-minimum-in-rotated-sorted-array-ii/</para>
    /// </summary>
    /// <param name="nums">数组</param>
    /// <returns>最小值</returns>
    public static int FindMin2(int[] nums)
    {
        int low = 0, high = nums.Length - 1;
        while (low < high && nums[low] >= nums[high])
        {
            int mid = low + (high - low) / 2;
            if (nums[low] == nums[mid] && nums[high] == nums[mid])
            {
                low++;
                high--;
            }
            else if (nums[mid] < nums[low])
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        return nums[low];
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
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[low] <= nums[mid])
            {
                if (target >= nums[low] && target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            else
            {
                if (target <= nums[high] && target > nums[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
        }
        return -1;
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
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                return true;
            }
            if (nums[low] == nums[mid] && nums[high] == nums[mid])
            {
                low++;
                high--;
            }
            else if (nums[low] <= nums[mid])
            {
                if (target >= nums[low] && target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            else
            {
                if (target <= nums[high] && target > nums[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
        }
        return false;
    }
}