using System.Text;

namespace algorithm_pattern;

public static class StackQueue
{
    static int[][] dirs = { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
    const int INFINITY = int.MaxValue / 2;

    /// <summary>
    /// <para>155. 最小栈</para>
    /// <para>https://leetcode.cn/problems/min-stack/</para>
    /// </summary>
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
    /// <summary>
    /// <para>150. 逆波兰表达式求值</para>
    /// <para>https://leetcode.cn/problems/evaluate-reverse-polish-notation/</para>
    /// </summary>
    /// <param name="tokens">逆波兰表示法的算数表达式</param>
    /// <returns>表示表达式的整数</returns>
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

    /// <summary>
    /// <para>394. 字符串解码</para>
    /// <para>https://leetcode.cn/problems/decode-string/</para>
    /// </summary>
    /// <param name="s">编码字符串</param>
    /// <returns>解码字符串</returns>
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

    /// <summary>
    /// <para>94. 二叉树的中序遍历</para>
    /// <para>https://leetcode.cn/problems/binary-tree-inorder-traversal/</para>
    /// <para>中序非递归</para>
    /// </summary>
    /// <param name="root">根节点</param>
    /// <returns>中序遍历结果</returns>
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

    /// <summary>
    /// <para>84. 柱状图中最大的矩形</para>
    /// <para>https://leetcode.cn/problems/largest-rectangle-in-histogram/</para>
    /// </summary>
    /// <param name="heights">各个柱子的高度</param>
    /// <returns>最大的矩形面积</returns>
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
    
    /// <summary>
    /// <para>42. 接雨水</para>
    /// <para>https://leetcode.cn/problems/trapping-rain-water/</para>
    /// </summary>
    /// <param name="node">柱子的高度</param>
    /// <returns>接的雨水量</returns>
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

    /// <summary>
    /// <para>232. 用栈实现队列</para>
    /// <para>https://leetcode.cn/problems/implement-queue-using-stacks/</para>
    /// </summary>
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
    
    /// <summary>
    /// <para>200. 岛屿数量</para>
    /// <para>https://leetcode.cn/problems/number-of-islands/</para>
    /// </summary>
    /// <param name="grid">陆地(1)和水(0)构成的二维网格</param>
    /// <returns>岛屿的数量</returns>
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
    
    /// <summary>
    /// <para>542. 01矩阵</para>
    /// <para>https://leetcode.cn/problems/01-matrix/</para>
    /// </summary>
    /// <param name="mat">01矩阵</param>
    /// <returns>结果矩阵</returns>
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

    /// <summary>
    /// <para>133. 克隆图</para>
    /// <para>https://leetcode.cn/problems/clone-graph/</para>
    /// </summary>
    /// <param name="node">图的节点</param>
    /// <returns>图的深拷贝</returns>
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

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}