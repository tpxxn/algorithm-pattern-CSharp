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
    public void BinaryTreeTest_BinaryTreePaths_BFS()
    {
        IList<int?> list = BinaryTree.BFS(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 1, 2, 3, 5 }));
    }

    #region 257. 二叉树的所有路径

    [Test]
    public void BinaryTreeTest_BinaryTreePaths_DFS()
    {
        IList<string> list = BinaryTree.BinaryTreePaths(rootTreeNode);
        object[] expected = { new List<string> { "1->2->5", "1->3" }, new List<string> { "1->3", "1->2->5" } };
        Assert.That(list, Is.AnyOf(expected));
    }

    [Test]
    public void BinaryTreeTest_BinaryTreePaths_DFS2()
    {
        root = new int?[] { 1 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<string> list = BinaryTree.BinaryTreePaths(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<string> { "1" }));
    }

    #endregion
}