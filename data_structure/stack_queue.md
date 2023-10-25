# 栈和队列

## 简介

栈的特点是后入先出

![image.png](https://img.fuiboom.com/img/stack.png)

根据这个特点可以临时保存一些数据，之后用到依次再弹出来，常用于 DFS 深度搜索

队列一般常用于 BFS 广度搜索，类似一层一层的搜索

## Stack 栈

### 最小栈

> [155. 最小栈](https://leetcode-cn.com/problems/min-stack/)
>
> 设计一个支持 `push` ，`pop` ，`top` 操作，并能在常数时间内检索到最小元素的栈。
>
> 实现 `MinStack` 类:
>
> `MinStack()` 初始化堆栈对象。
> 
> `void push(int val)` 将元素val推入堆栈。
> 
> `void pop()` 删除堆栈顶部的元素。
> 
> `int top()` 获取堆栈顶部的元素。
> 
> `int getMin()` 获取堆栈中的最小元素。


思路：用两个栈实现，一个最小栈始终保证最小值在顶部

```csharp
public class MinStack
{
    Stack<int> stack;
    Stack<int> minStack;
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }
    public void Push(int val)
    {
        stack.Push(val);
        if (minStack.Count == 0 || val <= minStack.Peek())
        {
            minStack.Push(val);
        }
    }
    public void Pop()
    {
        int val = stack.Pop();
        if (minStack.Peek() == val)
        {
            minStack.Pop();
        }
    }
    public int Top()
    {
        return stack.Peek();
    }
    public int GetMin()
    {
        return minStack.Peek();
    }
}

/**

 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
```

### 逆波兰表达式求值

> [150. 逆波兰表达式求值](https://leetcode-cn.com/problems/evaluate-reverse-polish-notation/)
>
> 给你一个字符串数组 `tokens` ，表示一个根据 [逆波兰表示法](https://baike.baidu.com/item/%E9%80%86%E6%B3%A2%E5%85%B0%E5%BC%8F/128437) 表示的算术表达式。
>
> 请你计算该表达式。返回一个表示表达式值的整数。

思路：通过栈保存原来的元素，遇到表达式弹出运算，再推入结果，重复这个过程

```csharp
public static int EvalRPN(string[] tokens)
{
    Stack<int> stack = new Stack<int>();
    int length = tokens.Length;
    for (int i = 0; i < length; i++)
    {
        string token = tokens[i];
        if (IsNumber(token))
        {
            stack.Push(int.Parse(token));
        }
        else
        {
            int num2 = stack.Pop();
            int num1 = stack.Pop();
            switch (token)
            {
                case "+":
                    stack.Push(num1 + num2);
                    break;
                case "-":
                    stack.Push(num1 - num2);
                    break;
                case "*":
                    stack.Push(num1 * num2);
                    break;
                case "/":
                    stack.Push(num1 / num2);
                    break;
            }
        }
    }
    return stack.Pop();
}

public static bool IsNumber(string token)
{
    return char.IsDigit(token[^1]);
}
```

### 字符串解码

> [394. 字符串解码](https://leetcode-cn.com/problems/decode-string/)
>
> 给定一个经过编码的字符串，返回它解码后的字符串。
>
> 编码规则为: `k[encoded_string]`，表示其中方括号内部的 `encoded_string` 正好重复 `k` 次。注意 `k` 保证为正整数。
>
> 你可以认为输入字符串总是有效的；输入字符串中没有额外的空格，且输入的方括号总是符合格式要求的。
>
> 此外，你可以认为原始数据不包含数字，所有的数字只表示重复的次数 `k` ，例如不会出现像 `3a` 或 `2[4]` 的输入。

思路：通过栈辅助进行操作

```csharp
public static string DecodeString(string s)
{
    StringBuilder sb = new StringBuilder();
    Stack<int> stack = new Stack<int>();
    int num = 0;
    int length = s.Length;
    for (int i = 0; i < length; i++)
    {
        char c = s[i];
        if (char.IsDigit(c))
        {
            num = num * 10 + c - '0';
        }
        else if (char.IsLetter(c))
        {
            sb.Append(c);
        }
        else if (c == '[')
        {
            stack.Push(num);
            num = 0;
            sb.Append(c);
        }
        else
        {
            int top = sb.Length - 1;
            StringBuilder temp = new StringBuilder();
            while (sb[top] != '[')
            {
                temp.Append(sb[top]);
                sb.Length = top;
                top--;
            }
            sb.Length = top;
            StringBuilder temp2 = new StringBuilder();
            for (int j = temp.Length - 1; j >= 0; j--)
            {
                temp2.Append(temp[j]);
            }
            int k = stack.Pop();
            for (int j = 0; j < k; j++)
            {
                sb.Append(temp2);
            }
        }
    }
    return sb.ToString();
}
```

### 二叉树的中序遍历

> [094. 二叉树的中序遍历](https://leetcode-cn.com/problems/binary-tree-inorder-traversal/)
>
> 给定一个二叉树的根节点 `root` ，返回 它的 **中序** 遍历 。

```csharp
// 思路：通过stack 保存已经访问的元素，用于原路返回
public static IList<int?> InorderTraversal(TreeNode root)
{
    IList<int?> traversal = new List<int?>();
    Stack<TreeNode> stack = new Stack<TreeNode>();
    TreeNode node = root;
    while (stack.Count > 0 || node != null)
    {
        while (node != null)
        {
            stack.Push(node);
            node = node.left;
        }
        node = stack.Pop();
        traversal.Add(node.val);
        node = node.right;
    }
    return traversal;
}
```

### 岛屿数量

> [200. 岛屿数量](https://leetcode-cn.com/problems/number-of-islands/)
>
> 给你一个由 `'1'`（陆地）和 `'0'`（水）组成的的二维网格，请你计算网格中岛屿的数量。
>
> 岛屿总是被水包围，并且每座岛屿只能由水平方向和/或竖直方向上相邻的陆地连接形成。
>
> 此外，你可以假设该网格的四条边均被水包围。

思路：通过深度搜索遍历可能性（注意标记已访问元素）

```csharp
static int[][] dirs = { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };

public static int NumIslands(char[][] grid)
{
    int islands = 0;
    int m = grid.Length, n = grid[0].Length;
    bool[][] visited = new bool[m][];
    for (int i = 0; i < m; i++)
    {
        visited[i] = new bool[n];
    }
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (grid[i][j] == '0' || visited[i][j])
            {
                continue;
            }
            islands++;
            visited[i][j] = true;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { i, j });
            while (queue.Count > 0)
            {
                int[] cell = queue.Dequeue();
                int row = cell[0], col = cell[1];
                foreach (int[] dir in dirs)
                {
                    int newRow = row + dir[0], newCol = col + dir[1];
                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && grid[newRow][newCol] == '1' && !visited[newRow][newCol])
                    {
                        visited[newRow][newCol] = true;
                        queue.Enqueue(new int[] { newRow, newCol });
                    }
                }
            }
        }
    }
    return islands;
}
```

### 柱状图中最大的矩形

> [084. 柱状图中最大的矩形](https://leetcode-cn.com/problems/largest-rectangle-in-histogram/)
>
> 给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。
>
> 求在该柱状图中，能够勾勒出来的矩形的最大面积。

思路：求以当前柱子为高度的面积，即转化为寻找小于当前值的左右两边值

![image.png](https://img.fuiboom.com/img/stack_rain.png)

用栈保存小于当前值的左的元素

![image.png](https://img.fuiboom.com/img/stack_rain2.png)

```csharp
public static int LargestRectangleArea(int[] heights)
{
    int length = heights.Length;
    int[] left = new int[length];
    int[] right = new int[length];
    Array.Fill(left, -1);
    Array.Fill(right, length);
    Stack<int> stack = new Stack<int>();
    for (int i = 0; i < length; i++)
    {
        int height = heights[i];
        while (stack.Count > 0 && heights[stack.Peek()] >= height)
        {
            right[stack.Pop()] = i;
        }
        if (stack.Count > 0)
        {
            left[i] = stack.Peek();
        }
        stack.Push(i);
    }
    int area = 0;
    for (int i = 0; i < length; i++)
    {
        area = Math.Max(area, (right[i] - left[i] - 1) * heights[i]);
    }
    return area;
}
```

### 接雨水

> [42. 接雨水](https://leetcode-cn.com/problems/01-matrix/)
>
> 给定 `n` 个非负整数表示每个宽度为 `1` 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。

```csharp
public static int Trap(int[] height)
{
    int amount = 0;
    Stack<int> stack = new Stack<int>();
    int n = height.Length;
    for (int i = 0; i < n; i++) {
        while (stack.Count > 0 && height[stack.Peek()] <= height[i]) {
            int curr = stack.Pop();
            if (stack.Count == 0) {
                break;
            }
            int prev = stack.Peek();
            int currWidth = i - prev - 1;
            int currHeight = Math.Min(height[prev], height[i]) - height[curr];
            amount += currWidth * currHeight;
        }
        stack.Push(i);
    }
    return amount;
}
```

## Queue 队列

常用于 BFS 宽度优先搜索

### 用栈实现队列

> [232. 用栈实现队列](https://leetcode-cn.com/problems/implement-queue-using-stacks/)
>
> 请你仅使用两个栈实现先入先出队列。队列应当支持一般队列支持的所有操作（`push`、`pop`、`peek`、`empty`）：
>
> 实现 `MyQueue` 类：
>
> `void push(int x)` 将元素 x 推到队列的末尾
> `int pop()` 从队列的开头移除并返回元素
> `int peek()` 返回队列开头的元素
> `boolean empty()` 如果队列为空，返回 `true` ；否则，返回 `false`
>
> 说明：
>
> 你 `只能` 使用标准的栈操作 —— 也就是只有 `push to top`, `peek/pop from top`, `size`, 和 `is empty` 操作是合法的。
> 你所使用的语言也许不支持栈。你可以使用 list 或者 deque（双端队列）来模拟一个栈，只要是标准的栈操作即可。

```csharp
public class MyQueue
{
    Stack<int> inStack;
    Stack<int> outStack;
    public MyQueue()
    {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }
    public void Push(int x)
    {
        inStack.Push(x);
    }
    public int Pop()
    {
        if (outStack.Count == 0)
        {
            In2Out();
        }
        return outStack.Pop();
    }
    public int Peek()
    {
        if (outStack.Count == 0)
        {
            In2Out();
        }
        return outStack.Peek();
    }
    public bool Empty()
    {
        return inStack.Count == 0 && outStack.Count == 0;
    }
    private void In2Out()
    {
        while (inStack.Count > 0)
        {
            outStack.Push(inStack.Pop());
        }
    }
}

public class MyQueue
{
    Stack<int> inStack;
    Stack<int> outStack;
    public MyQueue()
    {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }
    public void Push(int x)
    {
        inStack.Push(x);
    }
    public int Pop()
    {
        if (outStack.Count == 0)
        {
            In2Out();
        }
        return outStack.Pop();
    }
    public int Peek()
    {
        if (outStack.Count == 0)
        {
            In2Out();
        }
        return outStack.Peek();
    }
    public bool Empty()
    {
        return inStack.Count == 0 && outStack.Count == 0;
    }
    private void In2Out()
    {
        while (inStack.Count > 0)
        {
            outStack.Push(inStack.Pop());
        }
    }
}
/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
```

### 01矩阵

> [542. 01矩阵](https://leetcode-cn.com/problems/01-matrix/)
>
> 给定一个由 `0` 和 `1` 组成的矩阵 `mat` ，请输出一个大小相同的矩阵，其中每一个格子是 `mat` 中对应位置元素到最近的 `0` 的距离。
>
> 两个相邻元素间的距离为 `1` 。

```csharp
static int[][] dirs = { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
const int INFINITY = int.MaxValue / 2;

public static int[][] UpdateMatrix(int[][] mat)
{
    int m = mat.Length, n = mat[0].Length;
    int[][] distances = new int[m][];
    for (int i = 0; i < m; i++)
    {
        distances[i] = new int[n];
    }
    Queue<int[]> queue = new Queue<int[]>();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (mat[i][j] == 0)
            {
                queue.Enqueue(new int[] { i, j });
            }
            else
            {
                distances[i][j] = INFINITY;
            }
        }
    }
    while (queue.Count > 0)
    {
        int[] cell = queue.Dequeue();
        int row = cell[0], col = cell[1];
        foreach (int[] dir in dirs)
        {
            int newRow = row + dir[0], newCol = col + dir[1];
            if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && distances[newRow][newCol] == INFINITY)
            {
                distances[newRow][newCol] = distances[row][col] + 1;
                queue.Enqueue(new[] { newRow, newCol });
            }
        }
    }
    return distances;
}
```

### 克隆图

> [133. 克隆图](https://leetcode-cn.com/problems/clone-graph/)
>
> 给你无向 [连通](https://baike.baidu.com/item/%E8%BF%9E%E9%80%9A%E5%9B%BE/6460995?fr=aladdin) 图中一个节点的引用，请你返回该图的 [深拷贝](https://baike.baidu.com/item/%E6%B7%B1%E6%8B%B7%E8%B4%9D/22785317?fr=aladdin)（克隆）。
>
> 图中的每个节点都包含它的值 `val`（`int`） 和其邻居的列表（`list[Node]`）。
>
> > class Node {
> >
> > &nbsp;&nbsp;&nbsp;&nbsp; public int val;
> >
> > &nbsp;&nbsp;&nbsp;&nbsp; public List<Node> neighbors;
> >
> >}

```csharp
public static Node CloneGraph(Node node)
{
    if (node == null)
    {
        return null;
    }
    IDictionary<Node, Node> cloneDictionary = new Dictionary<Node, Node>();
    cloneDictionary.Add(node, new Node(node.val));
    Queue<Node> queue = new Queue<Node>();
    queue.Enqueue(node);
    while (queue.Count > 0)
    {
        Node original = queue.Dequeue();
        Node cloned = cloneDictionary[original];
        IList<Node> originalNeighbors = original.neighbors;
        IList<Node> clonedNeighbors = cloned.neighbors;
        foreach (Node originalNeighbor in originalNeighbors)
        {
            if (!cloneDictionary.ContainsKey(originalNeighbor))
            {
                cloneDictionary.Add(originalNeighbor, new Node(originalNeighbor.val));
                queue.Enqueue(originalNeighbor);
            }
            clonedNeighbors.Add(cloneDictionary[originalNeighbor]);
        }
    }
    return cloneDictionary[node];
}
```

## 总结

- 熟悉栈的使用场景
    - 后入先出，保存临时值
    - 利用栈 DFS 深度搜索
- 熟悉队列的使用场景
    - 利用队列 BFS 广度搜索

## 练习

- [ ] [最小栈](https://leetcode-cn.com/problems/min-stack/)
- [ ] [逆波兰表达式求值](https://leetcode-cn.com/problems/evaluate-reverse-polish-notation/)
- [ ] [字符串解码](https://leetcode-cn.com/problems/decode-string/)
- [ ] [二叉树的中序遍历](https://leetcode-cn.com/problems/binary-tree-inorder-traversal/)
- [ ] [克隆图](https://leetcode-cn.com/problems/clone-graph/)
- [ ] [岛屿数量](https://leetcode-cn.com/problems/number-of-islands/)
- [ ] [柱状图中最大的矩形](https://leetcode-cn.com/problems/largest-rectangle-in-histogram/)
- [ ] [用栈实现队列](https://leetcode-cn.com/problems/implement-queue-using-stacks/)
- [ ] [01矩阵](https://leetcode-cn.com/problems/01-matrix/)
