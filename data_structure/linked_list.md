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
```

#### 删除排序链表中的重复元素ii

> [082. 删除排序链表中的重复元素ii](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/)
>
> 给定一个已排序的链表的头 `head` ， *删除原始链表中所有重复数字的节点，只留下不同的数字* 。返回 *已排序的链表* 。

思路：链表头结点可能被删除，所以用 dummy node 辅助删除

```csharp
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
```

#### 反转链表ii

> [092. 反转链表ii](https://leetcode-cn.com/problems/reverse-linked-list-ii/)
>
> 给你单链表的头指针 `head` 和两个整数 `left` 和 `right` ，其中 `left <= right` 。请你反转从位置 `left` 到位置 `right` 的链表节点，返回 **反转后的链表** 。

思路：先遍历到 left 处，翻转，再拼接后续，注意指针处理

```csharp
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
```

### 链表合并

#### 合并两个有序链表

> [021. 合并两个有序链表](https://leetcode-cn.com/problems/merge-two-sorted-lists/)
>
> 将两个升序链表合并为一个新的 **升序** 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。

思路：通过 dummy node 链表，连接各个元素

```csharp
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
```

#### 分隔链表

> [086. 分隔链表](https://leetcode-cn.com/problems/partition-list/)
>
> 给你一个链表的头节点 `head` 和一个特定值 `x` ，请你对链表进行分隔，使得所有 **小于** `x` 的节点都出现在 **大于或等于** `x` 的节点之前。
>
> 你应当 **保留** 两个分区中每个节点的初始相对位置。

思路：将大于 x 的节点，放到另外一个链表，最后连接这两个链表

```csharp
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
```

哑巴节点使用场景

> 当头节点不确定的时候，使用哑巴节点

## 快慢指针

### 链表中点

#### 排序链表

> [148. 排序链表](https://leetcode-cn.com/problems/sort-list/)
>
> 在*O*(*n*log*n*) 时间复杂度和常数级空间复杂度下，对链表进行排序。

思路：归并排序，找中点和合并操作

```csharp
func sortList(head *ListNode) *ListNode {
    // 思路：归并排序，找中点和合并操作
    return mergeSort(head)
}
func findMiddle(head *ListNode) *ListNode {
    // 1->2->3->4->5
    slow := head
    fast := head.Next
    // 快指针先为nil
    for fast !=nil && fast.Next != nil {
        fast = fast.Next.Next
        slow = slow.Next
    }
    return slow
}
func mergeTwoLists(l1 *ListNode, l2 *ListNode) *ListNode {
    dummy := &ListNode{Val: 0}
    head := dummy
    for l1 != nil && l2 != nil {
        if l1.Val < l2.Val {
            head.Next = l1
            l1 = l1.Next
        } else {
            head.Next = l2
            l2 = l2.Next
        }
        head = head.Next
    }
    // 连接l1 未处理完节点
    for l1 != nil {
        head.Next = l1
        head = head.Next
        l1 = l1.Next
    }
    // 连接l2 未处理完节点
    for l2 != nil {
        head.Next = l2
        head = head.Next
        l2 = l2.Next
    }
    return dummy.Next
}
func mergeSort(head *ListNode) *ListNode {
    // 如果只有一个节点 直接就返回这个节点
    if head == nil || head.Next == nil{
        return head
    }
    // find middle
    middle := findMiddle(head)
    // 断开中间节点
    tail := middle.Next
    middle.Next = nil
    left := mergeSort(head)
    right := mergeSort(tail)
    result := mergeTwoLists(left, right)
    return result
}
```

注意点

- 快慢指针 判断 fast 及 fast.Next 是否为 nil 值
- 递归 mergeSort 需要断开中间节点
- 递归返回条件为 head 为 nil 或者 head.Next 为 nil

#### 重排链表

> [143. 重排链表](https://leetcode-cn.com/problems/reorder-list/)
>
> 给定一个单链表*L*：*L*→*L*→…→*L\_\_n*→*L*
> 将其重新排列后变为：*L*→*L\_\_n*→*L*→*L\_\_n*→*L*→*L\_\_n*→…

思路：找到中点断开，翻转后面部分，然后合并前后两个链表

```csharp
func reorderList(head *ListNode)  {
    // 思路：找到中点断开，翻转后面部分，然后合并前后两个链表
    if head == nil {
        return
    }
    mid := findMiddle(head)
    tail := reverseList(mid.Next)
    mid.Next = nil
    head = mergeTwoLists(head, tail)
}
func findMiddle(head *ListNode) *ListNode {
    fast := head.Next
    slow := head
    for fast != nil && fast.Next != nil {
        fast = fast.Next.Next
        slow = slow.Next
    }
    return slow
}
func mergeTwoLists(l1 *ListNode, l2 *ListNode) *ListNode {
    dummy := &ListNode{Val: 0}
    head := dummy
    toggle := true
    for l1 != nil && l2 != nil {
        // 节点切换
        if toggle {
            head.Next = l1
            l1 = l1.Next
        } else {
            head.Next = l2
            l2 = l2.Next
        }
        toggle = !toggle
        head = head.Next
    }
    // 连接l1 未处理完节点
    for l1 != nil {
        head.Next = l1
        head = head.Next
        l1 = l1.Next
    }
    // 连接l2 未处理完节点
    for l2 != nil {
        head.Next = l2
        head = head.Next
        l2 = l2.Next
    }
    return dummy.Next
}
func reverseList(head *ListNode) *ListNode {
    var prev *ListNode
    for head != nil {
        // 保存当前head.Next节点，防止重新赋值后被覆盖
        // 一轮之后状态：nil<-1 2->3->4
        //              prev   head
        temp := head.Next
        head.Next = prev
        // pre 移动
        prev = head
        // head 移动
        head = temp
    }
    return prev
}
```

### 结构判断

#### 环形链表
> [141. 环形链表](https://leetcode-cn.com/problems/linked-list-cycle/)
>
> 给定一个链表，判断链表中是否有环。

思路：快慢指针，快慢指针相同则有环，证明：如果有环每走一步快慢指针距离会减 1
![fast_slow_linked_list](https://img.fuiboom.com/img/fast_slow_linked_list.png)

```csharp
func hasCycle(head *ListNode) bool {
    // 思路：快慢指针 快慢指针相同则有环，证明：如果有环每走一步快慢指针距离会减1
    if head == nil {
        return false
    }
    fast := head.Next
    slow := head
    for fast != nil && fast.Next != nil {
        // 比较指针是否相等（不要使用val比较！）
        if fast == slow {
            return true
        }
        fast = fast.Next.Next
        slow = slow.Next
    }
    return false
}
```

#### 环形链表ii

> [142. 环形链表ii](https://leetcode-cn.com/problems/linked-list-cycle-ii/)
>
> 给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回`null`。

思路：快慢指针，快慢相遇之后，慢指针回到头，快慢指针步调一致一起移动，相遇点即为入环点
![cycled_linked_list](https://img.fuiboom.com/img/cycled_linked_list.png)

```csharp
func detectCycle(head *ListNode) *ListNode {
    // 思路：快慢指针，快慢相遇之后，慢指针回到头，快慢指针步调一致一起移动，相遇点即为入环点
    if head == nil {
        return head
    }
    fast := head.Next
    slow := head

    for fast != nil && fast.Next != nil {
        if fast == slow {
            // 慢指针重新从头开始移动，快指针从第一次相交点下一个节点开始移动
            fast = head
            slow = slow.Next // 注意
            // 比较指针对象（不要比对指针Val值）
            for fast != slow {
                fast = fast.Next
                slow = slow.Next
            }
            return slow
        }
        fast = fast.Next.Next
        slow = slow.Next
    }
    return nil
}
```

坑点

- 指针比较时直接比较对象，不要用值比较，链表中有可能存在重复值情况
- 第一次相交后，快指针需要从下一个节点开始和头指针一起匀速移动

另外一种方式是 fast=head,slow=head

```csharp
func detectCycle(head *ListNode) *ListNode {
    // 思路：快慢指针，快慢相遇之后，其中一个指针回到头，快慢指针步调一致一起移动，相遇点即为入环点
    // nb+a=2nb+a
    if head == nil {
        return head
    }
    fast := head
    slow := head

    for fast != nil && fast.Next != nil {
        fast = fast.Next.Next
        slow = slow.Next
        if fast == slow {
            // 指针重新从头开始移动
            fast = head
            for fast != slow {
                fast = fast.Next
                slow = slow.Next
            }
            return slow
        }
    }
    return nil
}
```

这两种方式不同点在于，**一般用 fast=head.Next 较多**，因为这样可以知道中点的上一个节点，可以用来删除等操作。

- fast 如果初始化为 head.Next 则中点在 slow.Next
- fast 初始化为 head,则中点在 slow

#### 回文链表

> [234. 回文链表](https://leetcode-cn.com/problems/palindrome-linked-list/)
>
> 请判断一个链表是否为回文链表。

```csharp
func isPalindrome(head *ListNode) bool {
    // 1 2 nil
    // 1 2 1 nil
    // 1 2 2 1 nil
    if head==nil{
        return true
    }
    slow:=head
    // fast如果初始化为head.Next则中点在slow.Next
    // fast初始化为head,则中点在slow
    fast:=head.Next
    for fast!=nil&&fast.Next!=nil{
        fast=fast.Next.Next
        slow=slow.Next
    }

    tail:=reverse(slow.Next)
    // 断开两个链表(需要用到中点前一个节点)
    slow.Next=nil
    for head!=nil&&tail!=nil{
        if head.Val!=tail.Val{
            return false
        }
        head=head.Next
        tail=tail.Next
    }
    return true

}

func reverse(head *ListNode)*ListNode{
    // 1->2->3
    if head==nil{
        return head
    }
    var prev *ListNode
    for head!=nil{
        t:=head.Next
        head.Next=prev
        prev=head
        head=t
    }
    return prev
}
```

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
func copyRandomList(head *Node) *Node {
	if head == nil {
		return head
	}
	// 复制节点，紧挨到到后面
	// 1->2->3  ==>  1->1'->2->2'->3->3'
	cur := head
	for cur != nil {
		clone := &Node{Val: cur.Val, Next: cur.Next}
		temp := cur.Next
		cur.Next = clone
		cur = temp
	}
	// 处理random指针
	cur = head
	for cur != nil {
		if cur.Random != nil {
			cur.Next.Random = cur.Random.Next
		}
		cur = cur.Next.Next
	}
	// 分离两个链表
	cur = head
	cloneHead := cur.Next
	for cur != nil && cur.Next != nil {
		temp := cur.Next
		cur.Next = cur.Next.Next
		cur = temp
	}
	// 原始链表头：head 1->2->3
	// 克隆的链表头：cloneHead 1'->2'->3'
	return cloneHead
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
