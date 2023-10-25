namespace algorithm_pattern;

public class LinkedList
{
    /// <summary>
    /// <para>83. 删除排序链表中的重复元素</para>
    /// <para>https://leetcode.cn/problems/remove-duplicates-from-sorted-list/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    /// <returns>结果根节点</returns>
    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null)
        {
            return head;
        }
        ListNode temp = head;
        while (temp.next != null)
        {
            if (temp.val == temp.next.val)
            {
                temp.next = temp.next.next;
            }
            else
            {
                temp = temp.next;
            }
        }
        return head;
    }

    /// <summary>
    /// <para>82. 删除排序链表中的重复元素ii</para>
    /// <para>https://leetcode.cn/problems/remove-duplicates-from-sorted-list-ii/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    /// <returns>结果根节点</returns>
    public static ListNode DeleteDuplicates2(ListNode head)
    {
        ListNode dummyHead = new ListNode(0);
        dummyHead.next = head;
        ListNode curr = dummyHead;
        while (curr.next != null)
        {
            ListNode next = curr.next;
            if (next.next == null || next.next.val != next.val)
            {
                curr = curr.next;
            }
            else
            {
                while (next.next != null && next.next.val == next.val)
                {
                    next.next = next.next.next;
                }
                curr.next = next.next;
            }
        }
        return dummyHead.next;
    }

    /// <summary>
    /// <para>206. 反转链表</para>
    /// <para>https://leetcode.cn/problems/reverse-linked-list/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    /// <returns>结果根节点</returns>
    public static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null, curr = head;
        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }

    /// <summary>
    /// <para>92. 反转链表ii</para>
    /// <para>https://leetcode.cn/problems/reverse-linked-list-ii/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    /// <param name="left">位置 left</param>
    /// <param name="right">位置 right</param>
    /// <returns>结果根节点</returns>
    public static ListNode ReverseBetween(ListNode head, int left, int right)
    {
        ListNode dummyHead = new ListNode(0, head);
        ListNode prev = dummyHead;
        for (int i = 1; i < left; i++)
        {
            prev = prev.next;
        }
        ListNode curr = prev.next;
        for (int i = left; i < right; i++)
        {
            ListNode next = curr.next;
            curr.next = next.next;
            next.next = prev.next;
            prev.next = next;
        }
        return dummyHead.next;
    }
}