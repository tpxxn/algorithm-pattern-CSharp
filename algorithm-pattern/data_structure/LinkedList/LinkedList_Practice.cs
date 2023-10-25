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
    /// <param name="head">根节点</param>
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

    /// <summary>
    /// <para>148. 排序链表</para>
    /// <para>https://leetcode.cn/problems/sort-list/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    public static ListNode SortList(ListNode head)
    {
        if (head?.next == null)
        {
            return head;
        }
        ListNode slow = head, fast = head.next;
        while (fast is { next: not null })
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        ListNode head2 = slow.next;
        slow.next = null;
        ListNode list1 = SortList(head);
        ListNode list2 = SortList(head2);
        return MergeTwoLists_SortList(list1, list2);
    }

    static ListNode MergeTwoLists_SortList(ListNode list1, ListNode list2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode temp = dummyHead;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                temp.next = list1;
                list1 = list1.next;
            }
            else
            {
                temp.next = list2;
                list2 = list2.next;
            }
            temp = temp.next;
        }
        temp.next = list1 ?? list2;
        return dummyHead.next;
    }

    /// <summary>
    /// <para>143. 重排链表</para>
    /// <para>https://leetcode.cn/problems/reorder-list/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    public static void ReorderList(ListNode head)
    {
        if (head == null)
        {
            return;
        }
        ListNode fast = head, slow = head;
        while (fast.next is { next: not null })
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        ListNode rightHead = slow.next;
        slow.next = null;
        ListNode prev = null, curr = rightHead;
        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        ListNode node1 = head, node2 = prev;
        while (node1 != null && node2 != null)
        {
            ListNode temp1 = node1.next, temp2 = node2.next;
            node1.next = node2;
            node1 = temp1;
            node2.next = node1;
            node2 = temp2;
        }
    }

    /// <summary>
    /// <para>141. 环形链表</para>
    /// <para>https://leetcode.cn/problems/linked-list-cycle/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    public static bool HasCycle(ListNode head)
    {
        ListNode fast = head, slow = head;
        while (fast is { next: not null })
        {
            fast = fast.next.next;
            slow = slow.next;
            if (fast == slow)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// <para>142. 环形链表ii</para>
    /// <para>https://leetcode.cn/problems/linked-list-cycle-ii/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    public static ListNode DetectCycle(ListNode head) {
        // 思路：快慢指针，快慢相遇之后，慢指针回到头，快慢指针步调一致一起移动，相遇点即为入环点
        ListNode p = head, q = head;
        while (p != null && q is { next: not null }) {
            p = p.next;
            q = q.next.next;
            if (p == q) {
                // 指针重新从头开始移动
                ListNode m = head;
                // 比较指针对象（不要比对指针Val值）
                while (m != p) {
                    m = m.next;
                    p = p.next;
                }
                return p;
            }
        }
        return null;
    }

    /// <summary>
    /// <para>234. 回文链表</para>
    /// <para>https://leetcode.cn/problems/palindrome-linked-list/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    public static bool IsPalindrome(ListNode head)
    {
        ListNode fast = head, slow = head;
        while (fast is { next: not null })
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        bool odd = fast != null;
        ListNode firstHalfEnd = slow;
        ListNode secondHalfStart = odd ? slow.next : slow;
        ListNode node1 = ReverseFirstHalf(head, firstHalfEnd);
        ListNode node2 = secondHalfStart;
        while (node1 != null)
        {
            if (node1.val != node2.val)
            {
                return false;
            }
            node1 = node1.next;
            node2 = node2.next;
        }
        return true;
    }

    public static ListNode ReverseFirstHalf(ListNode head, ListNode firstHalfEnd)
    {
        ListNode prev = null, curr = head;
        while (curr != firstHalfEnd)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }

    /// <summary>
    /// <para>138. 随机链表的复制</para>
    /// <para>https://leetcode.cn/problems/copy-list-with-random-pointer/</para>
    /// </summary>
    /// <param name="head">根节点</param>
    public static Node CopyRandomList(Node head)
    {
        if (head == null)
        {
            return null;
        }
        // 复制节点，紧挨到到后面
        // 1->2->3  ==>  1->1'->2->2'->3->3'
        Node cur = head;
        while (cur != null)
        {
            Node cloneNode = new Node(cur.val);
            cloneNode.next = cur.next;
            Node temp = cur.next;
            cur.next = cloneNode;
            cur = temp;
        }
        // 处理random指针
        cur = head;
        while (cur != null)
        {
            if (cur.random != null)
            {
                cur.next.random = cur.random.next;
            }
            cur = cur.next.next;
        }
        // 分离两个链表
        cur = head;
        Node cloneHead = cur.next;
        while (cur is { next: not null })
        {
            Node temp = cur.next;
            cur.next = cur.next.next;
            cur = temp;
        }
        // 原始链表头：head 1->2->3
        // 克隆的链表头：cloneHead 1'->2'->3'
        return cloneHead;
    }
}