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

    /// <summary>
    /// <para>21. 合并两个有序链表</para>
    /// <para>https://leetcode.cn/problems/merge-two-sorted-lists/</para>
    /// </summary>
    /// <param name="list1">根节点1</param>
    /// <param name="list2">根节点2</param>
    /// <returns>结果根节点</returns>
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode head = new ListNode(0);
        ListNode p = head;
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                p.next = list1;
                list1 = list1.next;
            }
            else
            {
                p.next = list2;
                list2 = list2.next;
            }
            p = p.next;
        }
        // 连接未处理完节点
        p.next = list1 == null ? list2 : list1;
        return head.next;
    }

    /// <summary>
    /// <para>86. 合并两个有序链表</para>
    /// <para>https://leetcode.cn/problems/merge-two-sorted-lists/</para>
    /// </summary>
    /// <param name="head">根节点1</param>
    /// <param name="x">特定值x</param>
    /// <returns>结果根节点</returns>
    public static ListNode Partition(ListNode head, int x)
    {
        ListNode dummyHead1 = new ListNode(0);
        ListNode dummyHead2 = new ListNode(0);
        ListNode temp1 = dummyHead1, temp2 = dummyHead2;
        ListNode temp = head;
        while (temp != null)
        {
            if (temp.val < x)
            {
                temp1.next = temp;
                temp1 = temp1.next;
            }
            else
            {
                temp2.next = temp;
                temp2 = temp2.next;
            }
            temp = temp.next;
        }
        temp1.next = dummyHead2.next;
        temp2.next = null;
        return dummyHead1.next;
    }
}