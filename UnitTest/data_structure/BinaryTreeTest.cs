using algorithm_pattern;

namespace UnitTest;

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
        BinaryTreeKnowledge.PreorderTraversalRecursion(rootTreeNode);
        Assert.Pass();
    }

    [Test]
    public void BinaryTreeTest_PreorderTraversal()
    {
        IList<int?> list = BinaryTreeKnowledge.PreorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 5, 4, 3, -1, 7, 2, 9 }));
    }
}