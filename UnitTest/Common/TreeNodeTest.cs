using algorithm_pattern;

namespace UnitTest.Common;

public class Tests
{
    int?[]? root;

    [SetUp]
    public void Setup()
    {
        root = new int?[] { 5, 4, 7, 3, null, 2, null, -1, null, null, null, 9 };
    }


    [Test]
    public void BinaryTreeBuilderTest1()
    {
        var rootNode = BinaryTreeBuilder.Builder(root);
        Assert.That(rootNode.left?.left?.left?.val, Is.EqualTo(-1));
    }

    [Test]
    public void BinaryTreeBuilderTest2()
    {
        var rootNode = BinaryTreeBuilder.Builder(root);
        Assert.That(rootNode.right?.left?.left?.val, Is.EqualTo(9));
    }
}