namespace algorithm_pattern;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public static class LinkedListBuilder
{
    public static ListNode Builder(int[] nums, int pos = -1)
    {
        ListNode dummyHead = new ListNode();
        ListNode curr = dummyHead;
        for (int i = 0; i < nums.Length; i++)
        {
            curr.next = new ListNode(nums[i]);
            curr = curr.next;
        }
        if (pos > -1 && pos < nums.Length)
        {
            ListNode circle = dummyHead;
            for (int i = 0; i <= pos; i++)
            {
                circle = circle.next;
            }
            curr.next = circle;
        }
        return dummyHead.next;
    }

    public static int[] ToList(ListNode head)
    {
        List<int> list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        return list.ToArray();
    }
}