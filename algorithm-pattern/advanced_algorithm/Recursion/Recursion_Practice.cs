namespace algorithm_pattern.advanced_algorithm.Recursion;

public class Recursion
{
    /// <summary>
    /// <para>344. 反转字符串</para>
    /// <para>https://leetcode-cn.com/problems/reverse-string/</para>
    /// </summary>
    /// <param name="s"></param>    
    public static void ReverseString(char[] s)
    {
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            (s[i], s[j]) = (s[j], s[i]);
        }
    }

    /// <summary>
    /// <para>24. 两两交换链表中的节点</para>
    /// <para>https://leetcode-cn.com/problems/swap-nodes-in-pairs/</para>
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static ListNode SwapPairs(ListNode head)
    {
        if (head?.next == null)
        {
            return head;
        }
        ListNode newHead = head.next;
        head.next = SwapPairs(newHead.next);
        newHead.next = head;
        return newHead;
    }

    /// <summary>
    /// <para>95. 不同的二叉搜索树 II</para>
    /// <para>https://leetcode-cn.com/problems/unique-binary-search-trees-ii/</para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static IList<TreeNode> GenerateTrees(int n)
    {
        return n == 0 ? new List<TreeNode>() : GenerateTrees(1, n);
    }

    public static IList<TreeNode> GenerateTrees(int start, int end)
    {
        IList<TreeNode> trees = new List<TreeNode>();
        if (start > end)
        {
            trees.Add(null);
        }
        else
        {
            for (int rootVal = start; rootVal <= end; rootVal++)
            {
                IList<TreeNode> leftSubtrees = GenerateTrees(start, rootVal - 1);
                IList<TreeNode> rightSubtrees = GenerateTrees(rootVal + 1, end);
                foreach (TreeNode leftSubtree in leftSubtrees)
                {
                    foreach (TreeNode rightSubtree in rightSubtrees)
                    {
                        TreeNode root = new TreeNode(rootVal);
                        root.left = leftSubtree;
                        root.right = rightSubtree;
                        trees.Add(root);
                    }
                }
            }
        }
        return trees;
    }

    // 备忘录
    static readonly IDictionary<int, int> memo = new Dictionary<int, int>();

    /// <summary>
    /// <para>509. 斐波那契数</para>
    /// <para>https://leetcode-cn.com/problems/fibonacci-number/</para>
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int Fib(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        if (!memo.ContainsKey(n))
        {
            memo.Add(n, Fib(n - 1) + Fib(n - 2));
        }
        return memo[n];
    }
}