using System.Text;

namespace algorithm_pattern;

public partial class BinaryTree
{
    /// <summary>
    /// 递归遍历写法，以前序遍历为例
    /// </summary>
    /// <param name="root">根节点</param>
    public static IList<int?> PreorderTraversalRecursion(TreeNode root)
    {
        List<int?> result = new List<int?>();
        Traverse(root, result);
        return result;
    }

    static void Traverse(TreeNode? p, ICollection<int?> result)
    {
        if (p?.val == null)
        {
            return;
        }
        // 其他遍历调整这里的语句顺序即可
        result.Add(p.val);
        Traverse(p.left, result);
        Traverse(p.right, result);
    }

    /// <summary>
    /// <para>144. 二叉树的前序遍历</para>
    /// <para>https://leetcode.cn/problems/binary-tree-preorder-traversal/</para>
    /// <para>前序非递归</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>前序遍历结果</returns>
    public static IList<int?> PreorderTraversal(TreeNode root)
    {
        List<int?> result = new List<int?>();
        if (root.val == null)
        {
            return result;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Any())
        {
            TreeNode temp = stack.Pop();
            result.Add(temp.val);
            if (temp.right != null)
            {
                stack.Push(temp.right);
            }
            if (temp.left != null)
            {
                stack.Push(temp.left);
            }
        }
        return result;
    }

    /// <summary>
    /// <para>94. 二叉树的中序遍历</para>
    /// <para>https://leetcode.cn/problems/binary-tree-inorder-traversal/</para>
    /// <para>中序非递归</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>中序遍历结果</returns>
    public static IList<int?> InorderTraversal(TreeNode root)
    {
        List<int?> result = new List<int?>();
        if (root.val == null)
        {
            return result;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;
        while (stack.Any() || current != null)
        {
            while (current is { val: not null })
            {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            result.Add(current.val);
            current = current.right;
        }
        return result;
    }

    /// <summary>
    /// <para>145. 二叉树的后序遍历</para>
    /// <para>https://leetcode.cn/problems/binary-tree-postorder-traversal/</para>
    /// <para>后序非递归</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>后序遍历结果</returns>
    public static IList<int?> PostorderTraversal(TreeNode root)
    {
        List<int?> result = new List<int?>();
        if (root.val == null)
        {
            return result;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Any())
        {
            TreeNode temp = stack.Pop();
            result.Add(temp.val);
            if (temp.left != null)
            {
                stack.Push(temp.left);
            }
            if (temp.right != null)
            {
                stack.Push(temp.right);
            }
        }
        return Enumerable.Reverse(result).ToList();
    }

    /// <summary>
    /// BFS(深度优先搜索)
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>深度优先搜索结果</returns>
    public static IList<int?> DFS_Traversal(TreeNode root)
    {
        List<int?> result = new List<int?>();
        DFS(root, ref result);
        return result;
    }

    static void DFS(TreeNode p, ref List<int?> result)
    {
        if (p.val == null)
        {
            return;
        }
        result.Add(p.val);
        if (p.left != null)
        {
            DFS(p.left, ref result);
        }
        if (p.right != null)
        {
            DFS(p.right, ref result);
        }
    }

    /// <summary>
    /// BFS(深度优先搜索)-分治法
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>深度优先搜索结果</returns>
    public static IList<int?> DFS_Traversal_Divide(TreeNode root)
    {
        IList<int?> result = DivideAndConquer(root);
        return result;
    }

    static IList<int?> DivideAndConquer(TreeNode? p)
    {
        List<int?> result = new List<int?>();
        if (p?.val == null)
        {
            return result;
        }
        // 分治(Divide)
        IList<int?> left = DivideAndConquer(p.left);
        IList<int?> right = DivideAndConquer(p.right);
        // 合并结果(Conquer)
        result = result.Append(p.val).ToList();
        result.AddRange(left);
        result.AddRange(right);
        return result;
    }

    /// <summary>
    /// BFS(广度优先搜索)
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>广度优先搜索结果</returns>
    public static IList<int?> BFS(TreeNode root)
    {
        List<int?> result = new List<int?>();
        if (root.val == null)
        {
            return result;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Any())
        {
            TreeNode p = queue.Dequeue();
            result.Add(p.val);
            if (p.left != null)
            {
                queue.Enqueue(p.left);
            }
            if (p.right != null)
            {
                queue.Enqueue(p.right);
            }
        }
        return result;
    }
}