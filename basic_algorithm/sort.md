# 排序

## 常考排序

### 快速排序

```csharp
public void QuickSort(int[] nums)
{
    // 思路：把一个数组分为左右两段，左段小于右段
    QuickSort(nums, 0, nums.Length - 1);
}

// 原地交换，所以传入交换索引
private void QuickSort(int[] nums, int start, int end)
{
    if (start < end)
    {
        // 分治法：divide
        int pivot = Partition(nums, start, end);
        QuickSort(nums, 0, pivot - 1);
        QuickSort(nums, pivot + 1, end);
    }
}

// 分区
private int Partition(int[] nums, int start, int end)
{
    // 选取最后一个元素作为基准pivot
    int p = nums[end];
    int i = start;
    // 最后一个值就是基准所以不用比较
    for (int j = start; j < end; j++)
    {
        if (nums[j] < p)
        {
            (nums[i], nums[j]) = (nums[j], nums[i]);
            i++;
        }
    }
    // 把基准值换到中间
    (nums[i], nums[end]) = (nums[end], nums[i]);
    return i;
}
```

### 归并排序

```csharp
public void MergeSort(int[] nums)
{
    MergeSort(nums, 0, nums.Length);
}

private void MergeSort(int[] nums, int start, int end)
{
    if (end - start <= 1)
    {
        return;
    }
    // 分治法：divide 分为两段
    int mid = start + (end - start) / 2;
    MergeSort(nums, start, mid);
    MergeSort(nums, mid, end);
    // 合并两段数据
    Merge(nums, start, mid, end);
}

private void Merge(int[] nums, int start, int mid, int end)
{
    int[] temp = new int[end - start];
    // 两边数组合并游标
    int l = start;
    int r = mid;
    int k = 0;
    // 注意不能越界
    while (l < mid && r < end)
    {
        // 谁小合并谁
        if (nums[l] < nums[r])
        {
            temp[k++] = nums[l++];
        }
        else
        {
            temp[k++] = nums[r++];
        }
    }
    // 剩余部分合并
    while (l < mid)
    {
        temp[k++] = nums[l++];
    }
    while (r < end)
    {
        temp[k++] = nums[r++];
    }
    // 复制到原数组
    for (int i = 0; i < temp.Length; i++)
    {
        nums[i + start] = temp[i];
    }
}
```

### 堆排序

用数组表示的完美二叉树 complete binary tree

> 完美二叉树 VS 其他二叉树

![image.png](https://img.fuiboom.com/img/tree_type.png)

[动画展示](https://www.bilibili.com/video/av18980178/)

![image.png](https://img.fuiboom.com/img/heap.png)

核心代码

```csharp
public void HeapSort(int[] nums)
{
    // 1、无序数组nums
    // 2、将无序数组nums构建为一个大根堆
    for (int i = nums.Length / 2 - 1; i >= 0; i--)
    {
        Sink(nums, i, nums.Length);
    }
    // 3、交换nums[0]和nums[len(a)-1]
    // 4、然后把前面这段数组继续下沉保持堆结构，如此循环即可
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        // 从后往前填充值
        (nums[0], nums[i]) = (nums[i], nums[0]);
        // 前面的长度也减一
        Sink(nums, 0, i);
    }
}

private void Sink(int[] nums, int i, int length)
{
    while (true)
    {
        // 左节点索引(从0开始，所以左节点为i*2+1)
        int l = i * 2 + 1;
        // 右节点索引
        int r = i * 2 + 2;
        // 保存根、左、右三者之间较大值的索引
        int index = i;
        // 存在左节点，左节点值较大，则取左节点
        if (l < length && nums[l] > nums[index])
        {
            index = l;
        }
        // 存在右节点，且值较大，取右节点
        if (r < length && nums[r] > nums[index])
        {
            index = r;
        }
        // 如果根节点较大，则不用下沉
        if (index == i)
        {
            break;
        }
        // 如果根节点较小，则交换值，并继续下沉
        (nums[i], nums[index]) = (nums[index], nums[i]);
        i = index;
    }
}
```

## 参考

[十大经典排序](https://www.cnblogs.com/onepixel/p/7674659.html)

[二叉堆](https://labuladong.gitbook.io/algo/shu-ju-jie-gou-xi-lie/er-cha-dui-xiang-jie-shi-xian-you-xian-ji-dui-lie)

## 练习

- [ ] 手写快排、归并、堆排序
