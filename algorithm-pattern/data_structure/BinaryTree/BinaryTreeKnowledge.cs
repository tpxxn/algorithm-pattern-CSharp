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
    /// <param name="root"></param>
    /// <returns></returns>
    public static IList<int?> PreorderTraversal(TreeNode root)
    {
        var res = new List<int?>();
        if (root.val == null)
        {
            return res;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var temp = stack.Pop();
            res.Add(temp.val);
            if (temp.right != null)
            {
                stack.Push(temp.right);
            }
            if (temp.left != null)
            {
                stack.Push(temp.left);
            }
        }
        return res;
    }
}