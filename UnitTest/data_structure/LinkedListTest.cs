using algorithm_pattern;

namespace UnitTest.data_structure;

public class LinkedListTest
{
    [SetUp]
    public void Setup()
    {
    }

    #region 83.删除排序链表中的重复元素

    [Test]
    public void StackQueueTest_MyQueue()
    {
        var result = LinkedList.DeleteDuplicates(LinkedListBuilder.Builder(new[] { 1, 2, 2 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 2 }));
    }

    [Test]
    public void StackQueueTest_MyQueue2()
    {
        var result = LinkedList.DeleteDuplicates(LinkedListBuilder.Builder(new[] { 1, 1, 2, 3, 3 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    #endregion

    #region 82.删除排序链表中的重复元素ii

    [Test]
    public void StackQueueTest_MyQueue2_1()
    {
        var result = LinkedList.DeleteDuplicates2(LinkedListBuilder.Builder(new[] { 1, 2, 3, 3, 4, 4, 5 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 2, 5 }));
    }

    [Test]
    public void StackQueueTest_MyQueue2_2()
    {
        var result = LinkedList.DeleteDuplicates2(LinkedListBuilder.Builder(new[] { 1, 1, 1, 2, 3 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 2, 3 }));
    }

    #endregion

    #region 206.反转链表

    [Test]
    public void StackQueueTest_ReverseList()
    {
        var result = LinkedList.ReverseList(LinkedListBuilder.Builder(new[] { 1, 2, 3, 4, 5 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 5, 4, 3, 2, 1 }));
    }

    [Test]
    public void StackQueueTest_ReverseList2()
    {
        var result = LinkedList.ReverseList(LinkedListBuilder.Builder(new[] { 1, 2 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 2, 1 }));
    }


    [Test]
    public void StackQueueTest_ReverseList3()
    {
        var result = LinkedList.ReverseList(LinkedListBuilder.Builder(Array.Empty<int>()));
        Assert.That(result, Is.EqualTo(null));
    }

    #endregion

    #region 92.反转链表ii

    [Test]
    public void StackQueueTest_ReverseBetween()
    {
        var result = LinkedList.ReverseBetween(LinkedListBuilder.Builder(new[] { 1, 2, 3, 4, 5 }), 2, 4);
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 4, 3, 2, 5 }));
    }

    [Test]
    public void StackQueueTest_ReverseBetween2()
    {
        var result = LinkedList.ReverseBetween(LinkedListBuilder.Builder(new[] { 5 }), 1, 1);
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 5 }));
    }

    #endregion
}