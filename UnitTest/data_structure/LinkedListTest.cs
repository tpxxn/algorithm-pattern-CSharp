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

    #region 21.合并两个有序链表

    [Test]
    public void StackQueueTest_MergeTwoLists()
    {
        var result = LinkedList.MergeTwoLists(LinkedListBuilder.Builder(new[] { 1, 2, 4 }), LinkedListBuilder.Builder(new[] { 1, 3, 4 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 1, 2, 3, 4, 4 }));
    }

    [Test]
    public void StackQueueTest_MergeTwoLists2()
    {
        var result = LinkedList.MergeTwoLists(LinkedListBuilder.Builder(Array.Empty<int>()), LinkedListBuilder.Builder(Array.Empty<int>()));
        Assert.That(result, Is.EqualTo(null));
    }

    [Test]
    public void StackQueueTest_MergeTwoLists3()
    {
        var result = LinkedList.MergeTwoLists(LinkedListBuilder.Builder(Array.Empty<int>()), LinkedListBuilder.Builder(new[] { 0 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 0 }));
    }

    #endregion

    #region 86.分隔链表

    [Test]
    public void StackQueueTest_Partition()
    {
        var result = LinkedList.Partition(LinkedListBuilder.Builder(new[] { 1, 4, 3, 2, 5, 2 }), 3);
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 2, 2, 4, 3, 5 }));
    }

    [Test]
    public void StackQueueTest_Partition2()
    {
        var result = LinkedList.Partition(LinkedListBuilder.Builder(new[] { 2, 1 }), 2);
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 2 }));
    }

    #endregion

    #region 148.排序链表

    [Test]
    public void StackQueueTest_SortList()
    {
        var result = LinkedList.SortList(LinkedListBuilder.Builder(new[] { 4, 2, 1, 3 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 2, 3, 4 }));
    }

    [Test]
    public void StackQueueTest_SortList2()
    {
        var result = LinkedList.SortList(LinkedListBuilder.Builder(new[] { -1, 5, 3, 4, 0 }));
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { -1, 0, 3, 4, 5 }));
    }

    [Test]
    public void StackQueueTest_SortList3()
    {
        var result = LinkedList.SortList(LinkedListBuilder.Builder(Array.Empty<int>()));
        Assert.That(result, Is.EqualTo(null));
    }

    #endregion

    #region 143.重排链表

    [Test]
    public void StackQueueTest_ReorderList()
    {
        var result = LinkedListBuilder.Builder(new[] { 1, 2, 3, 4 });
        LinkedList.ReorderList(result);
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 4, 2, 3 }));
    }

    [Test]
    public void StackQueueTest_ReorderList2()
    {
        var result = LinkedListBuilder.Builder(new[] { 1, 2, 3, 4, 5 });
        LinkedList.ReorderList(result);
        Assert.That(LinkedListBuilder.ToList(result), Is.EqualTo(new[] { 1, 5, 2, 4, 3 }));
    }

    #endregion

    #region 141.环形链表

    [Test]
    public void StackQueueTest_HasCycle()
    {
        var result = LinkedList.HasCycle(LinkedListBuilder.Builder(new[] { 3, 2, 0, -4 }, 1));
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void StackQueueTest_HasCycle2()
    {
        var result = LinkedList.HasCycle(LinkedListBuilder.Builder(new[] { 1, 2 }, 0));
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void StackQueueTest_HasCycle3()
    {
        var result = LinkedList.HasCycle(LinkedListBuilder.Builder(new[] { 1 }));
        Assert.That(result, Is.EqualTo(false));
    }

    #endregion

    #region 142.环形链表ii

    [Test]
    public void StackQueueTest_DetectCycle()
    {
        var result = LinkedList.DetectCycle(LinkedListBuilder.Builder(new[] { 3, 2, 0, -4 }, 1));
        Assert.That(result.val, Is.EqualTo(2));
        Assert.That(result.next.val, Is.EqualTo(0));
        Assert.That(result.next.next.val, Is.EqualTo(-4));
        Assert.That(result.next.next.next.val, Is.EqualTo(2));
    }

    [Test]
    public void StackQueueTest_DetectCycle2()
    {
        var result = LinkedList.DetectCycle(LinkedListBuilder.Builder(new[] { 1, 2 }, 0));
        Assert.That(result.val, Is.EqualTo(1));
        Assert.That(result.next.val, Is.EqualTo(2));
        Assert.That(result.next.next.val, Is.EqualTo(1));
    }

    [Test]
    public void StackQueueTest_DetectCycle3()
    {
        var result = LinkedList.DetectCycle(LinkedListBuilder.Builder(new[] { 1 }));
        Assert.That(result, Is.EqualTo(null));
    }

    #endregion

    #region 234.回文链表

    [Test]
    public void StackQueueTest_IsPalindrome()
    {
        var result = LinkedList.IsPalindrome(LinkedListBuilder.Builder(new[] { 1, 2, 2, 1 }));
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void StackQueueTest_IsPalindrome2()
    {
        var result = LinkedList.IsPalindrome(LinkedListBuilder.Builder(new[] { 1, 2 }));
        Assert.That(result, Is.EqualTo(false));
    }

    #endregion


    #region 138.随机链表的复制

    [Test]
    public void StackQueueTest_CopyRandomList()
    {
        var result = LinkedList.CopyRandomList(NodeBuilder.Builder(new[] { new[] { 7, -1 }, new[] { 13, 0 }, new[] { 11, 4 }, new[] { 10, 2 }, new[] { 1, 0 } }));
        Assert.That(NodeBuilder.ToList(result), Is.EqualTo(new[] { new[] { 7, -1 }, new[] { 13, 0 }, new[] { 11, 4 }, new[] { 10, 2 }, new[] { 1, 0 } }));
    }

    [Test]
    public void StackQueueTest_CopyRandomList2()
    {
        var result = LinkedList.CopyRandomList(NodeBuilder.Builder(new[] { new[] { 1, 1 }, new[] { 2, 1 } }));
        Assert.That(NodeBuilder.ToList(result), Is.EqualTo(new[] { new[] { 1, 1 }, new[] { 2, 1 } }));
    }

    [Test]
    public void StackQueueTest_CopyRandomList3()
    {
        var result = LinkedList.CopyRandomList(NodeBuilder.Builder(new[] { new[] { 3, -1 }, new[] { 3, 0 }, new[] { 3, -1 } }));
        Assert.That(NodeBuilder.ToList(result), Is.EqualTo(new[] { new[] { 3, -1 }, new[] { 3, 0 }, new[] { 3, -1 } }));
    }

    #endregion
}