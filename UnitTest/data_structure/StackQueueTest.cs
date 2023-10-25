using algorithm_pattern;
using MinStack = algorithm_pattern.StackQueue_Practice.MinStack;
using Node = algorithm_pattern.StackQueue_Practice.Node;
using MyQueue = algorithm_pattern.StackQueue_Practice.MyQueue;

namespace UnitTest.data_structure;

public class StackQueueTest
{
    [SetUp]
    public void Setup()
    {
    }

    #region 155.最小栈

    [Test]
    public void StackQueueTest_MinStack()
    {
        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Assert.That(minStack.GetMin(), Is.EqualTo(-3));
        minStack.Pop();
        Assert.That(minStack.Top(), Is.EqualTo(0));
        Assert.That(minStack.GetMin(), Is.EqualTo(-2));
    }

    #endregion

    #region 150.逆波兰表达式求值

    [Test]
    public void StackQueueTest_EvalRPN()
    {
        var result = StackQueue_Practice.EvalRPN(new[] { "2", "1", "+", "3", "*" });
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void StackQueueTest_EvalRPN2()
    {
        var result = StackQueue_Practice.EvalRPN(new[] { "4", "13", "5", "/", "+" });
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void StackQueueTest_EvalRPN3()
    {
        var result = StackQueue_Practice.EvalRPN(new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" });
        Assert.That(result, Is.EqualTo(22));
    }

    #endregion

    #region 394.字符串解码

    // ReSharper disable StringLiteralTypo
    [Test]
    public void StackQueueTest_DecodeString()
    {
        var result = StackQueue_Practice.DecodeString("3[a]2[bc]");
        Assert.That(result, Is.EqualTo("aaabcbc"));
    }

    [Test]
    public void StackQueueTest_DecodeString2()
    {
        var result = StackQueue_Practice.DecodeString("3[a2[c]]");
        Assert.That(result, Is.EqualTo("accaccacc"));
    }

    [Test]
    public void StackQueueTest_DecodeString3()
    {
        var result = StackQueue_Practice.DecodeString("2[abc]3[cd]ef");
        Assert.That(result, Is.EqualTo("abcabccdcdcdef"));
    }

    [Test]
    public void StackQueueTest_DecodeString4()
    {
        var result = StackQueue_Practice.DecodeString("abc3[cd]xyz");
        Assert.That(result, Is.EqualTo("abccdcdcdxyz"));
    }
    // ReSharper restore StringLiteralTypo

    #endregion

    #region 94.二叉树的中序遍历

    [Test]
    public void StackQueueTest_InorderTraversal()
    {
        int?[] root = { 5, 4, 7, 3, null, 2, null, -1, null, null, null, 9 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<int?> list = StackQueue_Practice.InorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { -1, 3, 4, 5, 9, 2, 7 }));
    }

    #endregion

    #region 200.岛屿数量

    [Test]
    public void StackQueueTest_NumIslands()
    {
        int list = StackQueue_Practice.NumIslands(new[]
        {
            new[] { '1', '1', '1', '1', '0' },
            new[] { '1', '1', '0', '1', '0' },
            new[] { '1', '1', '0', '0', '0' },
            new[] { '0', '0', '0', '0', '0' }
        });
        Assert.That(list, Is.EqualTo(1));
    }

    [Test]
    public void StackQueueTest_NumIslands2()
    {
        int list = StackQueue_Practice.NumIslands(new[]
        {
            new[] { '1', '1', '0', '0', '0' },
            new[] { '1', '1', '0', '0', '0' },
            new[] { '0', '0', '1', '0', '0' },
            new[] { '0', '0', '0', '1', '1' }
        });
        Assert.That(list, Is.EqualTo(3));
    }

    #endregion

    #region 84.柱状图中最大的矩形

    [Test]
    public void StackQueueTest_LargestRectangleArea()
    {
        int list = StackQueue_Practice.LargestRectangleArea(new[] { 2, 1, 5, 6, 2, 3 });
        Assert.That(list, Is.EqualTo(10));
    }

    [Test]
    public void StackQueueTest_LargestRectangleArea2()
    {
        int list = StackQueue_Practice.LargestRectangleArea(new[] { 2, 4 });
        Assert.That(list, Is.EqualTo(4));
    }

    #endregion

    #region 42.接雨水

    [Test]
    public void StackQueueTest_Trap()
    {
        int list = StackQueue_Practice.Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        Assert.That(list, Is.EqualTo(6));
    }

    [Test]
    public void StackQueueTest_Trap2()
    {
        int list = StackQueue_Practice.Trap(new[] { 4, 2, 0, 3, 2, 5 });
        Assert.That(list, Is.EqualTo(9));
    }

    #endregion

    #region 232.用栈实现队列

    [Test]
    public void StackQueueTest_MyQueue()
    {
        MyQueue myQueue = new MyQueue();
        myQueue.Push(1);
        myQueue.Push(2);
        Assert.That(myQueue.Peek(), Is.EqualTo(1));
        Assert.That(myQueue.Pop(), Is.EqualTo(1));
        Assert.That(myQueue.Empty(), Is.EqualTo(false));
    }

    #endregion

    #region 542.01矩阵

    [Test]
    public void StackQueueTest_UpdateMatrix()
    {
        int[][] list = StackQueue_Practice.UpdateMatrix(new[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 1, 0 },
            new[] { 0, 0, 0 }
        });
        Assert.That(list, Is.EqualTo(new[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 1, 0 },
            new[] { 0, 0, 0 }
        }));
    }

    [Test]
    public void StackQueueTest_UpdateMatrix2()
    {
        int[][] list = StackQueue_Practice.UpdateMatrix(new[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 1, 0 },
            new[] { 1, 1, 1 }
        });
        Assert.That(list, Is.EqualTo(new[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 1, 0 },
            new[] { 1, 2, 1 }
        }));
    }

    #endregion

    #region 133.克隆图

    [Test]
    public void StackQueueTest_CloneGraph()
    {
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);
        node1.neighbors = new List<Node> { node2, node4 };
        node2.neighbors = new List<Node> { node1, node3 };
        node3.neighbors = new List<Node> { node2, node4 };
        node4.neighbors = new List<Node> { node1, node3 };
        var result = StackQueue_Practice.CloneGraph(node1);
        Assert.That(result.val, Is.EqualTo(1));
        Assert.Multiple(() =>
        {
            Assert.That(result.neighbors[0].val, Is.EqualTo(2));
            Assert.That(result.neighbors[1].val, Is.EqualTo(4));
        });
        Assert.Multiple(() =>
        {
            Assert.That(result.neighbors[0].neighbors[0].val, Is.EqualTo(1));
            Assert.That(result.neighbors[0].neighbors[1].val, Is.EqualTo(3));
        });
    }

    #endregion
}