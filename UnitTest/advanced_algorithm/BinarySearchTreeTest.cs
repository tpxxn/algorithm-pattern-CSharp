using algorithm_pattern;
using algorithm_pattern.advanced_algorithm.BinarySearchTree;

namespace UnitTest.advanced_algorithm;

public class BinarySearchTreeTest
{
    int?[]? root;
    TreeNode rootTreeNode;

    [SetUp]
    public void Setup()
    {
        root = new int?[] { 5, 4, 7, 3, null, 2, null, -1, null, null, null, 9 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
    }

    #region 98. 验证二叉搜索树

    [Test]
    public void BinaryTreeTest_IsValidBST()
    {
        int?[] root = { 2, 1, 3 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isValidBst = BinarySearchTree.IsValidBST(rootTreeNode);
        Assert.That(isValidBst, Is.EqualTo(true));
    }

    [Test]
    public void BinaryTreeTest_IsValidBST2()
    {
        int?[] root = { 5, 1, 4, null, null, 3, 6 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isValidBst = BinarySearchTree.IsValidBST(rootTreeNode);
        Assert.That(isValidBst, Is.EqualTo(false));
    }

    [Test]
    public void BinaryTreeTest_IsValidBST3()
    {
        int?[] root = { 2147483647 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isValidBst = BinarySearchTree.IsValidBST(rootTreeNode);
        Assert.That(isValidBst, Is.EqualTo(true));
    }

    #endregion

    #region 701. 二叉搜索树中的插入操作

    [Test]
    public void BinaryTreeTest_InsertIntoBST()
    {
        int?[] root = { 4, 2, 7, 1, 3 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode levelOrder = BinarySearchTree.InsertIntoBST(rootTreeNode, 5);
        Assert.That(BinaryTreeBuilder.ToList(levelOrder), Is.AnyOf(new List<int?> { 4, 2, 7, 1, 3, 5 }, new List<int?> { 5, 2, 7, 1, 3, null, null, null, null, null, 4 }));
    }

    [Test]
    public void BinaryTreeTest_InsertIntoBST2()
    {
        int?[] root = { 40, 20, 60, 10, 30, 50, 70 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode levelOrder = BinarySearchTree.InsertIntoBST(rootTreeNode, 25);
        Assert.That(BinaryTreeBuilder.ToList(levelOrder), Is.EqualTo(new List<int?> { 40, 20, 60, 10, 30, 50, 70, null, null, 25 }));
    }

    #endregion

    #region 450.删除二叉搜索树中的节点

    [Test]
    public void BinaryTreeTest_DeleteNode()
    {
        int?[] root = { 5, 3, 6, 2, 4, null, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode result = BinarySearchTree.DeleteNode(rootTreeNode, 3);
        Assert.That(BinaryTreeBuilder.ToList(result), Is.AnyOf(new List<int?> { 5, 4, 6, 2, null, null, 7 }, new List<int?> { 5, 2, 6, null, 4, null, 7 }));
    }

    [Test]
    public void BinaryTreeTest_DeleteNode2()
    {
        int?[] root = { 5, 3, 6, 2, 4, null, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode result = BinarySearchTree.DeleteNode(rootTreeNode, 0);
        Assert.That(BinaryTreeBuilder.ToList(result), Is.EqualTo(new List<int?> { 5, 3, 6, 2, 4, null, 7 }));
    }

    [Test]
    public void BinaryTreeTest_DeleteNode3()
    {
        int?[] root = Array.Empty<int?>();
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode result = BinarySearchTree.DeleteNode(rootTreeNode, 0);
        Assert.That(BinaryTreeBuilder.ToList(result), Is.EqualTo(new List<int?>()));
    }

    #endregion
}