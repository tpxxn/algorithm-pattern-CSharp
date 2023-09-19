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

    /// <summary>
    /// <para>104. 二叉树的最大深度(DFS递归)</para>
    /// <para>https://leetcode.cn/problems/maximum-depth-of-binary-tree/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>二叉树的最大深度</returns>
    public static int MaxDepth_DFS(TreeNode? root)
    {
        if (root?.val == null)
        {
            return 0;
        }
        return Math.Max(MaxDepth_DFS(root.left), MaxDepth_DFS(root.right)) + 1;
    }

    /// <summary>
    /// <para>104. 二叉树的最大深度(BFS队列)</para>
    /// <para>https://leetcode.cn/problems/maximum-depth-of-binary-tree/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>二叉树的最大深度</returns>
    public static int MaxDepth_BFS(TreeNode? root)
    {
        if (root?.val == null)
        {
            return 0;
        }
        int depth = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            depth++;
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }
        return depth;
    }

    /// <summary>
    /// <para>110. 平衡二叉树</para>
    /// <para>https://leetcode.cn/problems/balanced-binary-tree/description/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>是否为高度平衡二叉树</returns>
    public static bool IsBalanced(TreeNode? root)
    {
        if (root?.val == null)
        {
            return true;
        }
        return Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    static int GetHeight(TreeNode? node)
    {
        if (node?.val == null)
        {
            return 0;
        }
        return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
    }

    static int maxSum = int.MinValue;

    /// <summary>
    /// <para>124. 二叉树中的最大路径和</para>
    /// <para>https://leetcode.cn/problems/binary-tree-maximum-path-sum/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>最大路径和</returns>
    public static int MaxPathSum(TreeNode root)
    {
        MaxGain(root);
        return maxSum;
    }

    static int MaxGain(TreeNode? node)
    {
        if (node?.val == null)
        {
            return 0;
        }
        // 递归计算左右子节点的最大贡献值
        // 只有在最大贡献值大于 0 时，才会选取对应子节点
        int leftGain = Math.Max(MaxGain(node.left), 0);
        int rightGain = Math.Max(MaxGain(node.right), 0);
        // 节点的最大路径和取决于该节点的值与该节点的左右子节点的最大贡献值
        int priceNewPath = (int)node.val + leftGain + rightGain;
        // 更新答案
        maxSum = Math.Max(maxSum, priceNewPath);
        // 返回节点的最大贡献值
        return (int)node.val + Math.Max(leftGain, rightGain);
    }

    /// <summary>
    /// <para>236. 二叉树的最近公共祖先</para>
    /// <para>https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>最近公共祖先</returns>
    public static TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
    {
        // check
        if (root?.val == null)
        {
            return null;
        }
        // 相等 直接返回root节点即可
        if (root == p || root == q)
        {
            return root;
        }
        // Divide
        TreeNode? left = LowestCommonAncestor(root.left, p, q);
        TreeNode? right = LowestCommonAncestor(root.right, p, q);
        // Conquer
        // 左右两边都不为空，则根节点为祖先
        if (left != null && right != null)
        {
            return root;
        }
        else if (left != null)
        {
            return left;
        }
        else
        {
            return right;
        }
    }

    /// <summary>
    /// <para>102. 二叉树的层序遍历</para>
    /// <para>https://leetcode.cn/problems/binary-tree-level-order-traversal/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>层序遍历</returns>
    public static IList<IList<int?>> LevelOrder(TreeNode? root)
    {
        IList<IList<int?>> levelOrderTraversal = new List<IList<int?>>();
        if (root?.val == null)
        {
            return levelOrderTraversal;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            IList<int?> levelValues = new List<int?>();
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                levelValues.Add(node.val);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            levelOrderTraversal.Add(levelValues);
        }
        return levelOrderTraversal;
    }

    /// <summary>
    /// <para>107. 二叉树的层序遍历II</para>
    /// <para>https://leetcode.cn/problems/binary-tree-level-order-traversal-ii/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>自底向上的层序遍历</returns>
    public static IList<IList<int?>> LevelOrderBottom(TreeNode? root)
    {
        IList<IList<int?>> levelOrderBottomTraversal = new List<IList<int?>>();
        if (root?.val == null)
        {
            return levelOrderBottomTraversal;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            IList<int?> levelValues = new List<int?>();
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                levelValues.Add(node.val);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            levelOrderBottomTraversal.Add(levelValues);
        }
        return levelOrderBottomTraversal.Reverse().ToList();
    }

    /// <summary>
    /// <para>103. 二叉树的锯齿形层序遍历</para>
    /// <para>https://leetcode.cn/problems/binary-tree-zigzag-level-order-traversal/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>最近公共祖先</returns>
    public static IList<IList<int?>> ZigzagLevelOrder(TreeNode? root)
    {
        IList<IList<int?>> zigzagLevelOrderTraversal = new List<IList<int?>>();
        if (root?.val == null)
        {
            return zigzagLevelOrderTraversal;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool isLeftToRight = true;
        while (queue.Count > 0)
        {
            IList<int?> levelValues = new List<int?>();
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                if (isLeftToRight)
                {
                    levelValues.Add(node.val);
                }
                else
                {
                    levelValues.Insert(0, node.val);
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            zigzagLevelOrderTraversal.Add(levelValues);
            isLeftToRight = !isLeftToRight;
        }
        return zigzagLevelOrderTraversal;
    }

    /// <summary>
    /// <para>701. 二叉搜索树中的插入操作</para>
    /// <para>https://leetcode.cn/problems/insert-into-a-binary-search-tree/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>插入后的二叉搜索树</returns>
    public static TreeNode InsertIntoBST(TreeNode? root, int val)
    {
        if (root?.val == null)
        {
            return new TreeNode(val);
        }
        if (root.val > val)
        {
            root.left = InsertIntoBST(root.left, val);
        }
        else
        {
            root.right = InsertIntoBST(root.right, val);
        }
        return root;
    }
}