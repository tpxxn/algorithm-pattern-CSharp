using algorithm_pattern;
using algorithm_pattern.advanced_algorithm.Recursion;

namespace UnitTest.advanced_algorithm;

public class RecursionTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReverseStringTest()
    {
        var result = new char[] { 'h', 'e', 'l', 'l', 'o' };
        Recursion.ReverseString(result);
        Assert.That(result, Is.EqualTo(new char[] { 'o', 'l', 'l', 'e', 'h' }));
    }

    [Test]
    public void ReverseStringTest_2()
    {
        var result = new char[] { 'H', 'a', 'n', 'n', 'a', 'h' };
        Recursion.ReverseString(result);
        Assert.That(result, Is.EqualTo(new char[] { 'h', 'a', 'n', 'n', 'a', 'H' }));
    }

    [Test]
    public void SwapPairsTest()
    {
        var result = Recursion.SwapPairs(LinkedListBuilder.Builder(new[] { 1, 2, 3, 4 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 2, 1, 4, 3 }));
    }

    [Test]
    public void SwapPairsTest_2()
    {
        var result = Recursion.SwapPairs(LinkedListBuilder.Builder(new int[] { }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new int[] { }));
    }

    [Test]
    public void SwapPairsTest_3()
    {
        var result = Recursion.SwapPairs(LinkedListBuilder.Builder(new[] { 1 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1 }));
    }

    [Test]
    public void GenerateTreesTest()
    {
        var result = Recursion.GenerateTrees(3);
        Assert.That(result[0].val, Is.EqualTo(1));
        Assert.That(result[0].right.val, Is.EqualTo(2));
        Assert.That(result[0].right.right.val, Is.EqualTo(3));
        Assert.That(result[1].val, Is.EqualTo(1));
        Assert.That(result[1].right.val, Is.EqualTo(3));
        Assert.That(result[1].right.left.val, Is.EqualTo(2));
        Assert.That(result[2].val, Is.EqualTo(2));
        Assert.That(result[2].left.val, Is.EqualTo(1));
        Assert.That(result[2].right.val, Is.EqualTo(3));
        Assert.That(result[3].val, Is.EqualTo(3));
        Assert.That(result[3].left.val, Is.EqualTo(1));
        Assert.That(result[3].left.right.val, Is.EqualTo(2));
        Assert.That(result[4].val, Is.EqualTo(3));
        Assert.That(result[4].left.val, Is.EqualTo(2));
        Assert.That(result[4].left.left.val, Is.EqualTo(1));
    }

    [Test]
    public void FibTest()
    {
        var result = Recursion.Fib(2);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void FibTest_2()
    {
        var result = Recursion.Fib(3);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void FibTest_3()
    {
        var result = Recursion.Fib(4);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void FibTest_4()
    {
        var result = Recursion.Fib(5);
        Assert.That(result, Is.EqualTo(5));
    }
}