# 链表

## 基本技能

链表相关的核心点

- null/nil 异常处理
- dummy node 哑巴节点
- 快慢指针
- 插入一个节点到排序链表
- 从一个链表中移除一个节点
- 翻转链表
- 合并两个链表
- 找到链表的中间节点

## 基本操作

### 链表删除

#### 删除排序链表中的重复元素

> [083. 删除排序链表中的重复元素](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/)
>
> 给定一个已排序的链表的头 `head` ， 删除所有重复的元素，使每个元素只出现一次 。返回 已排序的链表 。

```csharp
public ListNode DeleteDuplicates(ListNode head)
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
```

#### 删除排序链表中的重复元素ii

> [082. 删除排序链表中的重复元素ii](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/)
>
> 给定一个已排序的链表的头 `head` ， *删除原始链表中所有重复数字的节点，只留下不同的数字* 。返回 *已排序的链表* 。

思路：链表头结点可能被删除，所以用 dummy node 辅助删除

```csharp
public ListNode DeleteDuplicates2(ListNode head)
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
```

注意点
• A->B->C 删除 B，A.next = C
• 删除用一个 Dummy Node 节点辅助（允许头节点可变）
• 访问 X.next 、X.value 一定要保证 X != nil

### 链表反转

#### 反转链表

> [206. 反转链表](https://leetcode-cn.com/problems/reverse-linked-list/)
>
> 给你单链表的头节点 `head` ，请你反转链表，并返回反转后的链表。

思路：用一个 prev 节点保存向前指针，temp 保存向后的临时指针

```csharp
public ListNode ReverseList(ListNode head)
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
```

#### 反转链表ii

> [092. 反转链表ii](https://leetcode-cn.com/problems/reverse-linked-list-ii/)
>
> 给你单链表的头指针 `head` 和两个整数 `left` 和 `right` ，其中 `left <= right` 。请你反转从位置 `left` 到位置 `right` 的链表节点，返回 **反转后的链表** 。

思路：先遍历到 left 处，翻转，再拼接后续，注意指针处理

```csharp
public ListNode ReverseBetween(ListNode head, int left, int right)
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
```

### 链表合并

#### 合并两个有序链表

> [021. 合并两个有序链表](https://leetcode-cn.com/problems/merge-two-sorted-lists/)
>
> 将两个升序链表合并为一个新的 **升序** 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。

思路：通过 dummy node 链表，连接各个元素

```csharp
public ListNode MergeTwoLists(ListNode list1, ListNode list2)
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
```

#### 分隔链表

> [086. 分隔链表](https://leetcode-cn.com/problems/partition-list/)
>
> 给你一个链表的头节点 `head` 和一个特定值 `x` ，请你对链表进行分隔，使得所有 **小于** `x` 的节点都出现在 **大于或等于** `x` 的节点之前。
>
> 你应当 **保留** 两个分区中每个节点的初始相对位置。

思路：将大于 x 的节点，放到另外一个链表，最后连接这两个链表

```csharp
public ListNode Partition(ListNode head, int x)
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
```

哑巴节点使用场景

> 当头节点不确定的时候，使用哑巴节点

## 快慢指针

### 链表中点

#### 排序链表

> [148. 排序链表](https://leetcode-cn.com/problems/sort-list/)
>
> 给你链表的头结点 `head` ，请将其按 **升序** 排列并返回 **排序后的链表** 。

思路：归并排序，找中点和合并操作

```csharp
public ListNode SortList(ListNode head)
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

ListNode MergeTwoLists_SortList(ListNode list1, ListNode list2)
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
```

注意点

- 快慢指针 判断 fast 及 fast.Next 是否为 nil 值
- 递归 mergeSort 需要断开中间节点
- 递归返回条件为 head 为 nil 或者 head.Next 为 nil

#### 重排链表

> [143. 重排链表](https://leetcode-cn.com/problems/reorder-list/)
>
> 给定一个单链表 L 的头节点 head ，单链表 L 表示为：
>
> > L<sub>0</sub> → L<sub>1</sub> → … → L<sub>n - 1</sub> → L<sub>n</sub>
> 
> 请将其重新排列后变为：
>
> > L<sub>0</sub> → L<sub>n</sub> → L<sub>1</sub> → L<sub>n - 1</sub> → L<sub>2</sub> → L<sub>n - 2</sub> → …
> 
> 不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

思路：找到中点断开，翻转后面部分，然后合并前后两个链表

```csharp
public void ReorderList(ListNode head)
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
```

### 结构判断

#### 环形链表
> [141. 环形链表](https://leetcode-cn.com/problems/linked-list-cycle/)
>
> 给你一个链表的头节点 `head` ，判断链表中是否有环。
>
> 如果链表中有某个节点，可以通过连续跟踪 `next` 指针再次到达，则链表中存在环。 为了表示给定链表中的环，评测系统内部使用整数 `pos` 来表示链表尾连接到链表中的位置（**索引从 0 开始**）。**注意：`pos` 不作为参数进行传递** 。仅仅是为了标识链表的实际情况。
>
> 如果链表中存在环 ，则返回 `true` 。 否则，返回 `false` 。

思路：快慢指针，快慢指针相同则有环，证明：如果有环每走一步快慢指针距离会减 1
![fast_slow_linked_list](https://img.fuiboom.com/img/fast_slow_linked_list.png)

```csharp
public bool HasCycle(ListNode head)
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
```

#### 环形链表ii

> [142. 环形链表ii](https://leetcode-cn.com/problems/linked-list-cycle-ii/)
>
> 给定一个链表的头节点  `head` ，返回链表开始入环的第一个节点。 如果链表无环，则返回 `null`。
>
> 如果链表中有某个节点，可以通过连续跟踪 `next` 指针再次到达，则链表中存在环。 为了表示给定链表中的环，评测系统内部使用整数 `pos` 来表示链表尾连接到链表中的位置（**索引从 0 开始**）。如果 `pos` 是 `-1`，则在该链表中没有环。**注意：`pos` 不作为参数进行传递**，仅仅是为了标识链表的实际情况。
>
> **不允许修改** 链表。

思路：快慢指针，快慢相遇之后，慢指针回到头，快慢指针步调一致一起移动，相遇点即为入环点
![cycled_linked_list](https://img.fuiboom.com/img/cycled_linked_list.png)

```csharp
public ListNode DetectCycle(ListNode head) {
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
```

#### 回文链表

> [234. 回文链表](https://leetcode-cn.com/problems/palindrome-linked-list/)
>
> 给你一个单链表的头节点 `head` ，请你判断该链表是否为回文链表。如果是，返回 `true` ；否则，返回 `false` 。

```csharp
public bool IsPalindrome(ListNode head)
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
public ListNode ReverseFirstHalf(ListNode head, ListNode firstHalfEnd)
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
```

## 其他

#### 随机链表的复制

> [138. 随机链表的复制](https://leetcode-cn.com/problems/copy-list-with-random-pointer/)
>
> 给你一个长度为 `n` 的链表，每个节点包含一个额外增加的随机指针 `random` ，该指针可以指向链表中的任何节点或空节点。
>
> 构造这个链表的 [深拷贝](https://baike.baidu.com/item/%E6%B7%B1%E6%8B%B7%E8%B4%9D/22785317?fr=aladdin)。 深拷贝应该正好由 `n` 个 **全新** 节点组成，其中每个新节点的值都设为其对应的原节点的值。新节点的 `next` 指针和 `random` 指针也都应指向复制链表中的新节点，并使原链表和复制链表中的这些指针能够表示相同的链表状态。复制链表中的指针都不应指向原链表中的节点 。
>
> 例如，如果原链表中有 `X` 和 `Y` 两个节点，其中 `X.random --> Y` 。那么在复制链表中对应的两个节点 `x` 和 `y` ，同样有 `x.random --> y` 。
>
> 返回复制链表的头节点。
>
> 用一个由 `n` 个节点组成的链表来表示输入/输出中的链表。每个节点用一个 `[val, random_index]` 表示：
>
> - `val`：一个表示 `Node.val` 的整数。
>
> - `random_index`：随机指针指向的节点索引（范围从 `0` 到 `n-1`）；如果不指向任何节点，则为 `null` 。
>
> 你的代码 **只** 接受原链表的头节点 `head` 作为传入参数。

思路：1、hash 表存储指针，2、复制节点跟在原节点后面

```csharp
public Node CopyRandomList(Node head)
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
```

## 总结

链表必须要掌握的一些点，通过下面练习题，基本大部分的链表类的题目都是手到擒来~

- null/nil 异常处理
- dummy node 哑巴节点
- 快慢指针
- 插入一个节点到排序链表
- 从一个链表中移除一个节点
- 翻转链表
- 合并两个链表
- 找到链表的中间节点

## 练习

- [ ] [083. 删除排序链表中的重复元素](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/)
- [ ] [082. 删除排序链表中的重复元素ii](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/)
- [ ] [206. 反转链表](https://leetcode-cn.com/problems/reverse-linked-list/)
- [ ] [092. 反转链表ii](https://leetcode-cn.com/problems/reverse-linked-list-ii/)
- [ ] [021. 合并两个有序链表](https://leetcode-cn.com/problems/merge-two-sorted-lists/)
- [ ] [086. 分隔链表](https://leetcode-cn.com/problems/partition-list/)
- [ ] [148. 排序链表](https://leetcode-cn.com/problems/sort-list/)
- [ ] [143. 重排链表](https://leetcode-cn.com/problems/reorder-list/)
- [ ] [141. 环形链表](https://leetcode-cn.com/problems/linked-list-cycle/)
- [ ] [142. 环形链表ii](https://leetcode-cn.com/problems/linked-list-cycle-ii/)
- [ ] [234. 回文链表](https://leetcode-cn.com/problems/palindrome-linked-list/)
- [ ] [138. 随机链表的复制](https://leetcode-cn.com/problems/copy-list-with-random-pointer/)
