namespace algorithm_pattern;

public class BinaryTreeKnowledge
{
    /// <summary>
    /// 前序递归
    /// </summary>
    /// <param name="root">根节点</param>
    public static void PreorderTraversalRecursion(TreeNode root)
    {
        if (root.val == null)
        {
            return;
        }
        Console.WriteLine(root.val);
        if (root.left != null)
        {
            PreorderTraversalRecursion(root.left);
        }
        if (root.right != null)
        {
            PreorderTraversalRecursion(root.right);
        }
    }

    /// <summary>
    /// 前序非递归
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
    /// 中序非递归
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
        while (stack.Any() || root != null)
        {
            while (root is { val: not null })
            {
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            result.Add(root.val);
            root = root.right;
        }
        return result;
    }

    /// <summary>
    /// 后序非递归
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
}