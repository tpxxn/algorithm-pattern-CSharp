namespace algorithm_pattern.advanced_algorithm.BinarySearchTree;

public class BinarySearchTree
{
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

    /// <summary>
    /// <para>450. 删除二叉搜索树中节点</para>
    /// <para>https://leetcode.cn/problems/delete-node-in-a-bst/</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>删除后的二叉搜索树</returns>
    public static TreeNode? DeleteNode(TreeNode? root, int key)
    {
        // 删除节点分为三种情况：
        // 1、只有左节点 替换为右
        // 2、只有右节点 替换为左
        // 3、有左右子节点 左子节点连接到右边最左节点即可
        if (root?.val == null)
        {
            return root;
        }
        if (root.val < key)
        {
            root.right = DeleteNode(root.right, key);
        }
        else if (root.val > key)
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (root.val == key)
        {
            if (root.left?.val == null)
            {
                return root.right;
            }
            else if (root.right?.val == null)
            {
                return root.left;
            }
            else
            {
                var current = root.right;
                // 一直向左找到最后一个左节点即可
                while (current.left?.val != null)
                {
                    current = current.left;
                }
                current.left = root.left;
                return root.right;
            }
        }
        return root;
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
}