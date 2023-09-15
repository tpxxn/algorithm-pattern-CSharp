# 二叉树

## 二叉树遍历

### 前中后序遍历

**前序遍历**：[144. 二叉树的前序遍历](https://leetcode.cn/problems/binary-tree-preorder-traversal/)

先访问根节点，再前序遍历左子树，再前序遍历右子树

**中序遍历**：[94. 二叉树的中序遍历](https://leetcode.cn/problems/binary-tree-inorder-traversal/)

先中序遍历左子树，再访问根节点，再中序遍历右子树

**后序遍历**：[145. 二叉树的后序遍历](https://leetcode.cn/problems/binary-tree-postorder-traversal/)

先后序遍历左子树，再后序遍历右子树，再访问根节点

注意点

- 以根访问顺序决定是什么遍历
- 左子树都是优先右子树

#### 前序递归

```csharp
// 递归遍历写法，以前序遍历为例
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
```

#### 前序非递归

```csharp
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
        var temp = stack.Pop();
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
```

#### 中序非递归

1. 设置一个栈S存放所经过的根结点（指针）信息；初始化S；
2. 第一次访问到根结点并不访问，而是入栈；
3. 中序遍历它的左子树，左子树遍历结束后，第二次遇到根结点，就将根结点（指针）退栈，并且访问根结点；然后中序遍历它的右子树。
4. 当需要退栈时，如果栈为空则结束。

```csharp
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
```

#### 后序非递归

```csharp
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
```
### DFS 和 BFS

#### DFS 深度优先搜索-从上到下

```csharp
// V1：深度遍历，结果指针作为参数传入到函数内部
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
```

#### DFS 深度优先搜索-从下向上（分治法）

```csharp
// V2：通过分治法遍历
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
    result.Add(p.val);
    result.AddRange(left);
    result.AddRange(right);
    return result;
}
```

注意点：

> DFS 深度优先搜索（从上到下） 和分治法区别：前者一般将最终结果通过指针参数传入，后者一般递归返回结果最后合并

#### BFS 广度优先搜索

```csharp
public static IList<int?> BinaryTreePaths_BFS(TreeNode root)
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
```

#### 常见题目

> [257. 二叉树的所有路径](https://leetcode-cn.com/problems/binary-tree-paths/)
>
> 给你一个二叉树的根节点 root ，按 **任意顺序** ，返回所有从根节点到叶子节点的路径。
>
> **叶子节点** 是指没有子节点的节点。

```csharp
public static IList<string> BinaryTreePaths_DFS(TreeNode root)
{
    StringBuilder path = new StringBuilder();
    List<string> paths = new List<string>();
    DFS(root, path, paths);
    return paths;
}

static void DFS(TreeNode? p, StringBuilder path, ICollection<string> paths)
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
        DFS(p.left, new StringBuilder(path.ToString()), paths);
        DFS(p.right, new StringBuilder(path.ToString()), paths);
    }
}
```

## 二叉树分治

先分别处理局部，再合并结果

适用场景

- 快速排序
- 归并排序
- 二叉树相关问题

分治法模板

- 递归返回条件
- 分段处理
- 合并结果

伪代码如下
```csharp
public ResultType Traversal(TreeNode root) {
    // null or leaf
    if (root == null) {
        // do something and return
    }
    
    // Divide
    ResultType left = Traversal(root.Left)
    ResultType right = Traversal(root.Right)
        
    // Conquer
    ResultType result = Merge from left and right
    return result
}
```

### 典型示例

> [98. 验证二叉搜索树](https://leetcode-cn.com/problems/validate-binary-search-tree/)
>
> 给你一个二叉树的根节点 root ，判断其是否是一个有效的二叉搜索树。
> 
> **有效** 二叉搜索树定义如下：
> 
> 节点的左子树只包含 **小于** 当前节点的数。
> 
> 节点的右子树只包含 **大于** 当前节点的数。
> 
> 所有左子树和右子树自身必须也是二叉搜索树。

```csharp
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
```

### 常见题目

#### maximum-depth-of-binary-tree

[maximum-depth-of-binary-tree](https://leetcode.cn/problems/maximum-depth-of-binary-tree/)

> 给定一个二叉树，找出其最大深度。

思路：分治法

```go
func maxDepth(root *TreeNode) int {
    // 返回条件处理
    if root == nil {
        return 0
    }
    // divide：分左右子树分别计算
    left := maxDepth(root.Left)
    right := maxDepth(root.Right)

    // conquer：合并左右子树结果
    if left > right {
        return left + 1
    }
    return right + 1
}
```

#### balanced-binary-tree

[balanced-binary-tree](https://leetcode.cn/problems/balanced-binary-tree/)

> 给定一个二叉树，判断它是否是高度平衡的二叉树。

思路：分治法，左边平衡 && 右边平衡 && 左右两边高度 <= 1，
因为需要返回是否平衡及高度，要么返回两个数据，要么合并两个数据，
所以用-1 表示不平衡，>0 表示树高度（二义性：一个变量有两种含义）。

```go
func isBalanced(root *TreeNode) bool {
    if maxDepth(root) == -1 {
        return false
    }
    return true
}
func maxDepth(root *TreeNode) int {
    // check
    if root == nil {
        return 0
    }
    left := maxDepth(root.Left)
    right := maxDepth(root.Right)

    // 为什么返回-1呢？（变量具有二义性）
    if left == -1 || right == -1 || left-right > 1 || right-left > 1 {
        return -1
    }
    if left > right {
        return left + 1
    }
    return right + 1
}
```

注意

> 一般工程中，结果通过两个变量来返回，不建议用一个变量表示两种含义

#### binary-tree-maximum-path-sum

[binary-tree-maximum-path-sum](https://leetcode.cn/problems/binary-tree-maximum-path-sum/)

> 给定一个**非空**二叉树，返回其最大路径和。

思路：分治法，分为三种情况：左子树最大路径和最大，右子树最大路径和最大，左右子树最大加根节点最大，需要保存两个变量：一个保存子树最大路径和，一个保存左右加根节点和，然后比较这个两个变量选择最大值即可

```go
type ResultType struct {
    SinglePath int // 保存单边最大值
    MaxPath int // 保存最大值（单边或者两个单边+根的值）
}
func maxPathSum(root *TreeNode) int {
    result := helper(root)
    return result.MaxPath
}
func helper(root *TreeNode) ResultType {
    // check
    if root == nil {
        return ResultType{
            SinglePath: 0,
            MaxPath: -(1 << 31),
        }
    }
    // Divide
    left := helper(root.Left)
    right := helper(root.Right)

    // Conquer
    result := ResultType{}
    // 求单边最大值
    if left.SinglePath > right.SinglePath {
        result.SinglePath = max(left.SinglePath + root.Val, 0)
    } else {
        result.SinglePath = max(right.SinglePath + root.Val, 0)
    }
    // 求两边加根最大值
    maxPath := max(right.MaxPath, left.MaxPath)
    result.MaxPath = max(maxPath,left.SinglePath+right.SinglePath+root.Val)
    return result
}
func max(a,b int) int {
    if a > b {
        return a
    }
    return b
}
```

#### lowest-common-ancestor-of-a-binary-tree

[lowest-common-ancestor-of-a-binary-tree](https://leetcode.cn/problems/lowest-common-ancestor-of-a-binary-tree/)

> 给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。

思路：分治法，有左子树的公共祖先或者有右子树的公共祖先，就返回子树的祖先，否则返回根节点

```go
func lowestCommonAncestor(root, p, q *TreeNode) *TreeNode {
    // check
    if root == nil {
        return root
    }
    // 相等 直接返回root节点即可
    if root == p || root == q {
        return root
    }
    // Divide
    left := lowestCommonAncestor(root.Left, p, q)
    right := lowestCommonAncestor(root.Right, p, q)


    // Conquer
    // 左右两边都不为空，则根节点为祖先
    if left != nil && right != nil {
        return root
    }
    if left != nil {
        return left
    }
    if right != nil {
        return right
    }
    return nil
}
```

### BFS 层次应用

#### binary-tree-level-order-traversal

[binary-tree-level-order-traversal](https://leetcode.cn/problems/binary-tree-level-order-traversal/)

> 给你一个二叉树，请你返回其按  **层序遍历**  得到的节点值。 （即逐层地，从左到右访问所有节点）

思路：用一个队列记录一层的元素，然后扫描这一层元素添加下一层元素到队列（一个数进去出来一次，所以复杂度 O(logN)）

```go
func levelOrder(root *TreeNode) [][]int {
	result := make([][]int, 0)
	if root == nil {
		return result
	}
	queue := make([]*TreeNode, 0)
	queue = append(queue, root)
	for len(queue) > 0 {
		list := make([]int, 0)
        // 为什么要取length？
        // 记录当前层有多少元素（遍历当前层，再添加下一层）
		l := len(queue)
		for i := 0; i < l; i++ {
            // 出队列
			level := queue[0]
			queue = queue[1:]
			list = append(list, level.Val)
			if level.Left != nil {
				queue = append(queue, level.Left)
			}
			if level.Right != nil {
				queue = append(queue, level.Right)
			}
		}
		result = append(result, list)
	}
	return result
}
```

#### binary-tree-level-order-traversal-ii

[binary-tree-level-order-traversal-ii](https://leetcode.cn/problems/binary-tree-level-order-traversal-ii/)

> 给定一个二叉树，返回其节点值自底向上的层次遍历。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）

思路：在层级遍历的基础上，翻转一下结果即可

```go
func levelOrderBottom(root *TreeNode) [][]int {
    result := levelOrder(root)
    // 翻转结果
    reverse(result)
    return result
}
func reverse(nums [][]int) {
	for i, j := 0, len(nums)-1; i < j; i, j = i+1, j-1 {
		nums[i], nums[j] = nums[j], nums[i]
	}
}
func levelOrder(root *TreeNode) [][]int {
	result := make([][]int, 0)
	if root == nil {
		return result
	}
	queue := make([]*TreeNode, 0)
	queue = append(queue, root)
	for len(queue) > 0 {
		list := make([]int, 0)
        // 为什么要取length？
        // 记录当前层有多少元素（遍历当前层，再添加下一层）
		l := len(queue)
		for i := 0; i < l; i++ {
            // 出队列
			level := queue[0]
			queue = queue[1:]
			list = append(list, level.Val)
			if level.Left != nil {
				queue = append(queue, level.Left)
			}
			if level.Right != nil {
				queue = append(queue, level.Right)
			}
		}
		result = append(result, list)
	}
	return result
}
```

#### binary-tree-zigzag-level-order-traversal

[binary-tree-zigzag-level-order-traversal](https://leetcode.cn/problems/binary-tree-zigzag-level-order-traversal/)

> 给定一个二叉树，返回其节点值的锯齿形层次遍历。Z 字形遍历

```go
func zigzagLevelOrder(root *TreeNode) [][]int {
	result := make([][]int, 0)
	if root == nil {
		return result
	}
	queue := make([]*TreeNode, 0)
	queue = append(queue, root)
	toggle := false
	for len(queue) > 0 {
		list := make([]int, 0)
		// 记录当前层有多少元素（遍历当前层，再添加下一层）
		l := len(queue)
		for i := 0; i < l; i++ {
			// 出队列
			level := queue[0]
			queue = queue[1:]
			list = append(list, level.Val)
			if level.Left != nil {
				queue = append(queue, level.Left)
			}
			if level.Right != nil {
				queue = append(queue, level.Right)
			}
		}
		if toggle {
			reverse(list)
		}
		result = append(result, list)
		toggle = !toggle
	}
	return result
}
func reverse(nums []int) {
	for i := 0; i < len(nums)/2; i++ {
		nums[i], nums[len(nums)-1-i] = nums[len(nums)-1-i], nums[i]
	}
}
```

### 二叉搜索树应用

#### validate-binary-search-tree

[validate-binary-search-tree](https://leetcode.cn/problems/validate-binary-search-tree/)

> 给定一个二叉树，判断其是否是一个有效的二叉搜索树。

思路 1：中序遍历，检查结果列表是否已经有序

思路 2：分治法，判断左 MAX < 根 < 右 MIN

```go
// v1
func isValidBST(root *TreeNode) bool {
    result := make([]int, 0)
    inOrder(root, &result)
    // check order
    for i := 0; i < len(result) - 1; i++{
        if result[i] >= result[i+1] {
            return false
        }
    }
    return true
}

func inOrder(root *TreeNode, result *[]int)  {
    if root == nil{
        return
    }
    inOrder(root.Left, result)
    *result = append(*result, root.Val)
    inOrder(root.Right, result)
}


```

```go
// v2分治法
type ResultType struct {
	IsValid bool
    // 记录左右两边最大最小值，和根节点进行比较
	Max     *TreeNode
	Min     *TreeNode
}

func isValidBST2(root *TreeNode) bool {
	result := helper(root)
	return result.IsValid
}
func helper(root *TreeNode) ResultType {
	result := ResultType{}
	// check
	if root == nil {
		result.IsValid = true
		return result
	}

	left := helper(root.Left)
	right := helper(root.Right)

	if !left.IsValid || !right.IsValid {
		result.IsValid = false
		return result
	}
	if left.Max != nil && left.Max.Val >= root.Val {
		result.IsValid = false
		return result
	}
	if right.Min != nil && right.Min.Val <= root.Val {
		result.IsValid = false
		return result
	}

	result.IsValid = true
    // 如果左边还有更小的3，就用更小的节点，不用4
    //  5
    // / \
    // 1   4
    //      / \
    //     3   6
	result.Min = root
	if left.Min != nil {
		result.Min = left.Min
	}
	result.Max = root
	if right.Max != nil {
		result.Max = right.Max
	}
	return result
}
```

#### insert-into-a-binary-search-tree

[insert-into-a-binary-search-tree](https://leetcode.cn/problems/insert-into-a-binary-search-tree/)

> 给定二叉搜索树（BST）的根节点和要插入树中的值，将值插入二叉搜索树。 返回插入后二叉搜索树的根节点。

思路：找到最后一个叶子节点满足插入条件即可

```go
// DFS查找插入位置
func insertIntoBST(root *TreeNode, val int) *TreeNode {
    if root == nil {
        root = &TreeNode{Val: val}
        return root
    }
    if root.Val > val {
        root.Left = insertIntoBST(root.Left, val)
    } else {
        root.Right = insertIntoBST(root.Right, val)
    }
    return root
}
```

## 总结

- 掌握二叉树递归与非递归遍历
- 理解 DFS 前序遍历与分治法
- 理解 BFS 层次遍历

## 练习

- [ ] [144. 二叉树的前序遍历](https://leetcode.cn/problems/binary-tree-preorder-traversal/)
- [ ] [&nbsp;&nbsp;94. 二叉树的中序遍历](https://leetcode.cn/problems/binary-tree-inorder-traversal/)
- [ ] [145. 二叉树的后序遍历](https://leetcode.cn/problems/binary-tree-postorder-traversal/)
- [ ] [257. 二叉树的所有路径](https://leetcode-cn.com/problems/binary-tree-paths/)
- [ ] [&nbsp;&nbsp;98. 验证二叉搜索树](https://leetcode.cn/problems/validate-binary-search-tree/)
- [ ] [104. 二叉树的最大深度](https://leetcode.cn/problems/maximum-depth-of-binary-tree/)
- [ ] [110. 平衡二叉树](https://leetcode.cn/problems/balanced-binary-tree/)
- [ ] [124. 二叉树中的最大路径和](https://leetcode.cn/problems/binary-tree-maximum-path-sum/)
- [ ] [236. 二叉树的最近公共祖先](https://leetcode.cn/problems/lowest-common-ancestor-of-a-binary-tree/)
- [ ] [102. 二叉树的层序遍历](https://leetcode.cn/problems/binary-tree-level-order-traversal/)
- [ ] [107. 二叉树的层序遍历II](https://leetcode.cn/problems/binary-tree-level-order-traversal-ii/)
- [ ] [103. 二叉树的锯齿形层序遍历](https://leetcode.cn/problems/binary-tree-zigzag-level-order-traversal/)
- [ ] [701. 二叉搜索树中的插入操作](https://leetcode.cn/problems/insert-into-a-binary-search-tree/)
