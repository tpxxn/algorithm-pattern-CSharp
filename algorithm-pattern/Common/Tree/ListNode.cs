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

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}

public static class NodeBuilder
{
    public static Node Builder(int[][] nums)
    {
        Node dummyHead = new Node(0);
        Node curr = dummyHead;
        for (int i = 0; i < nums.Length; i++)
        {
            curr.next = new Node(nums[i][0]);
            curr = curr.next;
        }
        curr = dummyHead;
        for (int i = 0; i < nums.Length; i++)
        {
            var index = nums[i][1];
            if (index >= 0)
            {
                Node randomCurr = dummyHead.next;
                for (int j = 0; j <= index; j++)
                {
                    curr.next.random = randomCurr;
                    randomCurr = randomCurr.next;
                }
            }
            curr = curr.next;
        }
        return dummyHead.next;
    }

    public static int[][] ToList(Node head)
    {
        Node actualHead = head;
        List<int[]> list = new List<int[]>();
        while (head != null)
        {
            var index = -1;
            if (head.random != null)
            {
                Node curr = actualHead;
                while (curr != null)
                {
                    index++;
                    if (head.random == curr)
                    {
                        break;
                    }
                    curr = curr.next;
                }
            }
            list.Add(new[] { head.val, index });
            head = head.next;
        }
        return list.ToArray();
    }
}