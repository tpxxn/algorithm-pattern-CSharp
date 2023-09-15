using System.Text;

namespace algorithm_pattern;

public partial class BinaryTree
{
    /// <summary>
    /// <para>257. 二叉树的所有路径</para>
    /// <para>https://leetcode-cn.com/problems/binary-tree-paths/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>二叉树的所有路径</returns>
    public static IList<string> BinaryTreePaths(TreeNode root)
    {
        StringBuilder path = new StringBuilder();
        List<string> paths = new List<string>();
        BinaryTreePaths_DFS(root, path, paths);
        return paths;
    }

    static void BinaryTreePaths_DFS(TreeNode? p, StringBuilder path, ICollection<string> paths)
    {
        if (p?.val == null)
        {
            return;
        }
        path.Append(p.val);
        if (p.left?.val == null && p.right?.val == null)
        {
            paths.Add(path.ToString());
        }
        else
        {
            path.Append("->");
            BinaryTreePaths_DFS(p.left, new StringBuilder(path.ToString()), paths);
            BinaryTreePaths_DFS(p.right, new StringBuilder(path.ToString()), paths);
        }
    }


    /// <summary>
    /// <para>98. 验证二叉搜索树</para>
    /// <para>https://leetcode.cn/problems/validate-binary-search-tree/description/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>是否为有效的二叉搜索树</returns>
    public static bool IsValidBST(TreeNode root)
    {
        return IsValidBST_DivideAndConquer(root, long.MinValue, long.MaxValue);
    }

    static bool IsValidBST_DivideAndConquer(TreeNode? p, long? min, long? max)
    {
        if (p?.val == null)
        {
            return true;
        }
        // 返回条件
        if (p.val <= min || max <= p.val)
        {
            return false;
        }
        // 分治(Divide)
        var left = IsValidBST_DivideAndConquer(p.left, min, p.val);
        var right = IsValidBST_DivideAndConquer(p.right, p.val, max);
        // 合并结果(Conquer)
        return left && right;
    }
}