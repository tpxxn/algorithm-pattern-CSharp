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

    static void BinaryTreePaths_DFS(TreeNode? p, StringBuilder path, List<string> paths)
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
}