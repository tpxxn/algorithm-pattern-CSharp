# 二叉搜索树

## 定义

- 每个节点中的值必须大于（或等于）存储在其左侧子树中的任何值。
- 每个节点中的值必须小于（或等于）存储在其右子树中的任何值。

## 应用

### 验证二叉搜索树

> [098. 验证二叉搜索树](https://leetcode-cn.com/problems/validate-binary-search-tree/)
>
> 给你一个二叉树的根节点 `root` ，判断其是否是一个有效的二叉搜索树。
>
> **有效** 二叉搜索树定义如下：
>
> 节点的左子树只包含 **小于** 当前节点的数。
>
> 节点的右子树只包含 **大于** 当前节点的数。
>
> 所有左子树和右子树自身必须也是二叉搜索树。

```csharp
public bool IsValidBST(TreeNode root)
{
    return IsValidBST_DivideAndConquer(root, long.MinValue, long.MaxValue);
}

bool IsValidBST_DivideAndConquer(TreeNode? p, long? min, long? max)
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
```

### 二叉搜索树中的插入操作

> [701. 二叉搜索树中的插入操作](https://leetcode.cn/problems/insert-into-a-binary-search-tree/)
>
> 给定二叉搜索树（BST）的根节点 `root` 和要插入树中的值 `value` ，将值插入二叉搜索树。 返回插入后二叉搜索树的根节点。 输入数据 **保证** ，新值和原始二叉搜索树中的任意节点值都不同。
>
> **注意**，可能存在多种有效的插入方式，只要树在插入后仍保持为二叉搜索树即可。 你可以返回 **任意有效的结果** 。

思路：找到最后一个叶子节点满足插入条件即可

```csharp
public TreeNode InsertIntoBST(TreeNode? root, int val)
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
```

### 删除二叉搜索树中节点

> [450. 删除二叉搜索树中节点](https://leetcode.cn/problems/delete-node-in-a-bst/)
>
> 给定一个二叉搜索树的根节点 **root** 和一个值 **key**，删除二叉搜索树中的 **key** 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的根节点的引用。
>
> 一般来说，删除节点可分为两个步骤：
>
> 1. 首先找到需要删除的节点；
>
> 2. 如果找到了，删除它。

```csharp
public TreeNode? DeleteNode(TreeNode? root, int key)
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
```

### 平衡二叉树

> [110. 平衡二叉树](https://leetcode-cn.com/problems/balanced-binary-tree/)
>
> 给定一个二叉树，判断它是否是高度平衡的二叉树。
>
> 本题中，一棵高度平衡二叉树定义为：
>
> 一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1 。

```csharp
public bool IsBalanced(TreeNode? root) {
    if (root?.val == null) {
        return true;
    }
    return Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
}

int GetHeight(TreeNode? node) {
    if (node?.val == null) {
        return 0;
    }
    return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
}
```

## 练习

- [ ] [098. 验证二叉搜索树](https://leetcode.cn/problems/validate-binary-search-tree/)
- [ ] [701. 二叉搜索树中的插入操作](https://leetcode.cn/problems/insert-into-a-binary-search-tree/)
- [ ] [450. 删除二叉搜索树中节点](https://leetcode.cn/problems/delete-node-in-a-bst/)
- [ ] [110. 平衡二叉树](https://leetcode.cn/problems/balanced-binary-tree/)
