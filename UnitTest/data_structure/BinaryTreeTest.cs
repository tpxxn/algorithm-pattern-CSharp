using algorithm_pattern;

namespace UnitTest.data_structure;

public class BinaryTreeTest
{
    int?[]? root;
    TreeNode rootTreeNode;

    [SetUp]
    public void Setup()
    {
        root = new int?[] { 5, 4, 7, 3, null, 2, null, -1, null, null, null, 9 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
    }

    [Test]
    public void BinaryTreeTest_PreorderTraversalRecursion()
    {
        IList<int?> list = BinaryTree.PreorderTraversalRecursion(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 5, 4, 3, -1, 7, 2, 9 }));
    }

    [Test]
    public void BinaryTreeTest_PreorderTraversal()
    {
        IList<int?> list = BinaryTree.PreorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 5, 4, 3, -1, 7, 2, 9 }));
    }

    [Test]
    public void BinaryTreeTest_InorderTraversal()
    {
        IList<int?> list = BinaryTree.InorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { -1, 3, 4, 5, 9, 2, 7 }));
    }

    [Test]
    public void BinaryTreeTest_PostorderTraversal()
    {
        IList<int?> list = BinaryTree.PostorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { -1, 3, 4, 9, 2, 7, 5 }));
    }
}

public class BinaryTreeTest_DFS_BFS
{
    int?[]? root;
    TreeNode rootTreeNode;

    [SetUp]
    public void Setup()
    {
        root = new int?[] { 1, 2, 3, null, 5 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
    }

    [Test]
    public void BinaryTreeTest_DFS()
    {
        IList<int?> list = BinaryTree.DFS_Traversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 1, 2, 5, 3 }));
    }

    [Test]
    public void BinaryTreeTest_DFS_Divide()
    {
        IList<int?> list = BinaryTree.DFS_Traversal_Divide(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 1, 2, 5, 3 }));
    }

    [Test]
    public void BinaryTreeTest_BFS()
    {
        IList<int?> list = BinaryTree.BFS(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 1, 2, 3, 5 }));
    }

    #region 257. 二叉树的所有路径

    [Test]
    public void BinaryTreeTest_BinaryTreePaths_BinaryTreePaths()
    {
        IList<string> list = BinaryTree.BinaryTreePaths(rootTreeNode);
        object[] expected = { new List<string> { "1->2->5", "1->3" }, new List<string> { "1->3", "1->2->5" } };
        Assert.That(list, Is.AnyOf(expected));
    }

    [Test]
    public void BinaryTreeTest_BinaryTreePaths_BinaryTreePaths2()
    {
        root = new int?[] { 1 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<string> list = BinaryTree.BinaryTreePaths(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<string> { "1" }));
    }

    #endregion
}

public class BinaryTreeTest_Practice
{
    #region 257. 二叉树的所有路径

    [Test]
    public void BinaryTreeTest_IsValidBST()
    {
        int?[] root = { 2, 1, 3 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool list = BinaryTree.IsValidBST(rootTreeNode);
        Assert.That(list, Is.EqualTo(true));
    }

    [Test]
    public void BinaryTreeTest_IsValidBST2()
    {
        int?[] root = { 5, 1, 4, null, null, 3, 6 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool list = BinaryTree.IsValidBST(rootTreeNode);
        Assert.That(list, Is.EqualTo(false));
    }

    [Test]
    public void BinaryTreeTest_IsValidBST3()
    {
        int?[] root = { 2147483647 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool list = BinaryTree.IsValidBST(rootTreeNode);
        Assert.That(list, Is.EqualTo(true));
    }

    #endregion

    #region 257. 二叉树的所有路径

    [Test]
    public void BinaryTreeTest_MaxDepth_DFS()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int list = BinaryTree.MaxDepth_DFS(rootTreeNode);
        Assert.That(list, Is.EqualTo(3));
    }

    [Test]
    public void BinaryTreeTest_MaxDepth_DFS2()
    {
        int?[] root = { 1, null, 2 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int list = BinaryTree.MaxDepth_DFS(rootTreeNode);
        Assert.That(list, Is.EqualTo(2));
    }

    [Test]
    public void BinaryTreeTest_MaxDepth_BFS()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int list = BinaryTree.MaxDepth_BFS(rootTreeNode);
        Assert.That(list, Is.EqualTo(3));
    }

    [Test]
    public void BinaryTreeTest_MaxDepth_BFS2()
    {
        int?[] root = { 1, null, 2 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int list = BinaryTree.MaxDepth_BFS(rootTreeNode);
        Assert.That(list, Is.EqualTo(2));
    }

    #endregion

    #region 110. 平衡二叉树

    [Test]
    public void BinaryTreeTest_IsBalanced()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool list = BinaryTree.IsBalanced(rootTreeNode);
        Assert.That(list, Is.EqualTo(true));
    }

    [Test]
    public void BinaryTreeTest_IsBalanced2()
    {
        int?[] root = { 1, 2, 2, 3, 3, null, null, 4, 4 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool list = BinaryTree.IsBalanced(rootTreeNode);
        Assert.That(list, Is.EqualTo(false));
    }

    #endregion

    #region 124.最大路径和

    [Test]
    public void BinaryTreeTest_MaxPathSum()
    {
        int?[] root = { 1, 2, 3 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int list = BinaryTree.MaxPathSum(rootTreeNode);
        Assert.That(list, Is.EqualTo(6));
    }

    [Test]
    public void BinaryTreeTest_MaxPathSum2()
    {
        int?[] root = { -10, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int list = BinaryTree.MaxPathSum(rootTreeNode);
        Assert.That(list, Is.EqualTo(42));
    }

    #endregion
}