# 递归

## 介绍

将大问题转化为小问题，通过递归依次解决各个小问题

## 示例

### 反转字符串

> [344. 反转字符串](https://leetcode-cn.com/problems/reverse-string/)
>
> 编写一个函数，其作用是将输入的字符串反转过来。输入字符串以字符数组 `s` 的形式给出。
>
> 不要给另外的数组分配额外的空间，你必须[原地](https://baike.baidu.com/item/%E5%8E%9F%E5%9C%B0%E7%AE%97%E6%B3%95)**修改输入数组**、使用 O(1) 的额外空间解决这一问题。

```csharp
public void ReverseString(char[] s)
{
    for (int i = 0, j = s.Length - 1; i < j; i++, j--)
    {
        (s[i], s[j]) = (s[j], s[i]);
    }
}
```

### 两两交换链表中的节点

> [024. 两两交换链表中的节点](https://leetcode-cn.com/problems/swap-nodes-in-pairs/)
>
> 给你一个链表，两两交换其中相邻的节点，并返回交换后链表的头节点。你必须在不修改节点内部的值的情况下完成本题（即，只能进行节点交换）。

```csharp
public ListNode SwapPairs(ListNode head)
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
```

### 不同的二叉搜索树

> [095. 不同的二叉搜索树 ii](https://leetcode-cn.com/problems/unique-binary-search-trees-ii/)
>
> 给你一个整数 `n` ，请你生成并返回所有由 `n` 个节点组成且节点值从 `1` 到 `n` 互不相同的不同 **二叉搜索树** 。可以按 **任意顺序** 返回答案。

```csharp
public IList<TreeNode> GenerateTrees(int n)
{
    return n == 0 ? new List<TreeNode>() : GenerateTrees(1, n);
}

public IList<TreeNode> GenerateTrees(int start, int end)
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
```

## 递归+备忘录

### 斐波那契数

> [509. 斐波那契数](https://leetcode-cn.com/problems/fibonacci-number/)
>
> **斐波那契数**（通常用 `F(n)` 表示）形成的序列称为 **斐波那契数列**。该数列由 `0` 和 `1` 开始，后面的每一项数字都是前面两项数字的和。也就是：
>
> > F(0) = 0, F(1)= 1
> >
> > F(n) = F(n - 1) + F(n - 2), 其中 n > 1
>
> 给定 `n`，计算 `F(n)`。

```csharp
public int Fib(int n)
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
```

## 练习

- [ ] [344. 反转字符串](https://leetcode-cn.com/problems/reverse-string/)
- [ ] [024. 两两交换链表中的节点](https://leetcode-cn.com/problems/swap-nodes-in-pairs/)
- [ ] [095. 不同的二叉搜索树 ii](https://leetcode-cn.com/problems/unique-binary-search-trees-ii/)
- [ ] [509. 斐波那契数](https://leetcode-cn.com/problems/fibonacci-number/)
