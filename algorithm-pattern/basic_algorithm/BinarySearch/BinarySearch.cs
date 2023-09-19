namespace algorithm_pattern;

public partial class BinarySearch
{
    /// <summary>
    /// <para>704. 二分查找</para>
    /// <para>https://leetcode-cn.com/problems/binary-search/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>target 位置</returns>
    public static int Search(int[] nums, int target)
    {
        // 1、初始化left、right
        int left = 0;
        int right = nums.Length - 1;
        // 2、处理for循环
        while (right - left > 1)
        {
            int mid = left + (right - left) / 2;
            // 3、比较nums[mid]和target值
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                left = mid;
            }
            else
            {
                right = mid;
            }
        }
        // 4、最后剩下两个元素，手动判断
        if (nums[left] == target)
        {
            return left;
        }
        else if (nums[right] == target)
        {
            return right;
        }
        else
        {
            return -1;
        }
    }

    public static int Search_Template(int[] nums, int target)
    {
        var start = 0;
        var end = nums.Length - 1;
        while (start <= end)
        {
            var mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                start = mid + 1;
            }
            else if (nums[mid] > target)
            {
                end = mid - 1;
            }
        }
        // 如果找不到，start 是第一个大于target的索引
        // 如果在B+树结构里面二分搜索，可以return start
        // 这样可以继续向子节点搜索，如：node:=node.Children[start]
        return -1;
    }
}