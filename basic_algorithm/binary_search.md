# 二分搜索

## 二分搜索模板

给一个**有序数组**和目标值，找第一次/最后一次/任何一次出现的索引，如果没有出现返回-1

模板四点要素

- 1、初始化：start=0、end=len-1
- 2、循环退出条件：start + 1 < end
- 3、比较中点和目标值：A[mid] ==、 <、> target
- 4、判断最后两个元素是否符合：A[start]、A[end] ? target

时间复杂度 O(logn)，使用场景一般是有序数组的查找

### 典型示例

> [704. 二分查找](https://leetcode-cn.com/problems/binary-search/)
>
> 给定一个 `n` 个元素有序的（升序）整型数组 `nums` 和一个目标值 `target` ，写一个函数搜索 `nums` 中的 `target`，如果目标值存在返回下标，否则返回 `-1`。

```csharp
// 二分搜索最常用模板
public static int Search(int[] nums, int target)
{
    // 1、初始化left、right
    int left = 0;
    int right = nums.Length - 1;
    // 2、处理for循环
    while (right - left > 1)
    {
        int mid = left + (right - left) / 2;
        // 3、比较nums[mid]和target值
        if (nums[mid] == target)
        {
            return mid;
        }
        else if (nums[mid] < target)
        {
            left = mid;
        }
        else
        {
            right = mid;
        }
    }
    // 4、最后剩下两个元素，手动判断
    if (nums[left] == target)
    {
        return left;
    }
    else if (nums[right] == target)
    {
        return right;
    }
    else
    {
        return -1;
    }
}
```

### 模板

大部分二分查找类的题目都可以用这个模板，然后做一点特殊逻辑即可

另外二分查找还有一些其他模板如下图，大部分场景模板#3 都能解决问题，而且还能找第一次/最后一次出现的位置，应用更加广泛

![binary_search_template](https://img.fuiboom.com/img/binary_search_template.png)

所以用模板#3 就对了，详细的对比可以这边文章介绍：[二分搜索模板](https://leetcode-cn.com/explore/learn/card/binary-search/212/template-analysis/847/)

如果是最简单的二分搜索，不需要找第一个、最后一个位置、或者是没有重复元素，可以使用模板#1，代码更简洁

```csharp
// 无重复元素搜索时，更方便
public static int Search_Template(int[] nums, int target)
{
    var start = 0;
    var end = nums.Length - 1;
    while (start <= end)
    {
        var mid = start + (end - start) / 2;
        if (nums[mid] == target)
        {
            return mid;
        }
        else if (nums[mid] < target)
        {
            start = mid + 1;
        }
        else if (nums[mid] > target)
        {
            end = mid - 1;
        }
    }
    // 如果找不到，start 是第一个大于target的索引
    // 如果在B+树结构里面二分搜索，可以return start
    // 这样可以继续向子节点搜索，如：node:=node.Children[start]
    return -1;
}
```

## 常见题目

### 搜索区间

> [061. 搜索区间](https://www.lintcode.com/problem/search-for-a-range/description)
>
> 给定一个包含 `n` 个整数的排序数组，找出给定目标值 `target` 的起始和结束位置。
>
> 如果目标值不在数组中，则返回`[-1, -1]`

思路：核心点就是找第一个 target 的索引，和最后一个 target 的索引，所以用两次二分搜索分别找第一次和最后一次的位置

```csharp
func searchRange (A []int, target int) []int {
    if len(A) == 0 {
        return []int{-1, -1}
    }
    result := make([]int, 2)
    start := 0
    end := len(A) - 1
    for start+1 < end {
        mid := start + (end-start)/2
        if A[mid] > target {
            end = mid
        } else if A[mid] < target {
            start = mid
        } else {
            // 如果相等，应该继续向左找，就能找到第一个目标值的位置
            end = mid
        }
    }
    // 搜索左边的索引
    if A[start] == target {
        result[0] = start
    } else if A[end] == target {
        result[0] = end
    } else {
        result[0] = -1
        result[1] = -1
        return result
    }
    start = 0
    end = len(A) - 1
    for start+1 < end {
        mid := start + (end-start)/2
        if A[mid] > target {
            end = mid
        } else if A[mid] < target {
            start = mid
        } else {
            // 如果相等，应该继续向右找，就能找到最后一个目标值的位置
            start = mid
        }
    }
    // 搜索右边的索引
    if A[end] == target {
        result[1] = end
    } else if A[start] == target {
        result[1] = start
    } else {
        result[0] = -1
        result[1] = -1
        return result
    }
    return result
}
```

### 搜索插入位置

> [035. 搜索插入位置](https://leetcode-cn.com/problems/search-insert-position/)
> 
> 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
>
> 请必须使用时间复杂度为 `O(log n)` 的算法。

```csharp
func searchInsert(nums []int, target int) int {
    // 思路：找到第一个 >= target 的元素位置
    start := 0
    end := len(nums) - 1
    for start+1 < end {
        mid := start + (end-start)/2
        if nums[mid] == target {
            // 标记开始位置
            start = mid
        } else if nums[mid] > target {
            end = mid
        } else {
            start = mid
        }
    }
    if nums[start] >= target {
        return start
    } else if nums[end] >= target {
        return end
    } else if nums[end] < target { // 目标值比所有值都大
        return end + 1
    }
    return 0
}
```

### 搜索二维矩阵

> [074. 搜索二维矩阵](https://leetcode-cn.com/problems/search-a-2d-matrix/)
>
> 编写一个高效的算法来判断 `m x n` 矩阵中，是否存在一个目标值。该矩阵具有如下特性：
>
> - 每行中的整数从左到右按升序排列。
> - 每行的第一个整数大于前一行的最后一个整数。
>
> 给你一个整数 `target` ，如果 `target` 在矩阵中，返回 `true` ；否则，返回 `false` 。

```csharp
func searchMatrix(matrix [][]int, target int) bool {
    // 思路：将2纬数组转为1维数组 进行二分搜索
    if len(matrix) == 0 || len(matrix[0]) == 0 {
        return false
    }
    row := len(matrix)
    col := len(matrix[0])
    start := 0
    end := row*col - 1
    for start+1 < end {
        mid := start + (end-start)/2
        // 获取2纬数组对应值
        val := matrix[mid/col][mid%col]
        if val > target {
            end = mid
        } else if val < target {
            start = mid
        } else {
            return true
        }
    }
    if matrix[start/col][start%col] == target || matrix[end/col][end%col] == target{
        return true
    }
    return false
}
```

### 第一个错误的版本

> [278. 第一个错误的版本](https://leetcode-cn.com/problems/first-bad-version/)
>
> 你是产品经理，目前正在带领一个团队开发新的产品。不幸的是，你的产品的最新版本没有通过质量检测。由于每个版本都是基于之前的版本开发的，所以错误的版本之后的所有版本都是错的。
>
> 假设你有 n 个版本 `[1, 2, ..., n]`，你想找出导致之后所有版本出错的第一个错误的版本。
>
> 你可以通过调用 `bool isBadVersion(version)` 接口来判断版本号 `version` 是否在单元测试中出错。实现一个函数来查找第一个错误的版本。你应该尽量减少对调用 API 的次数。

```csharp
func firstBadVersion(n int) int {
    // 思路：二分搜索
    start := 0
    end := n
    for start+1 < end {
        mid := start + (end - start)/2
        if isBadVersion(mid) {
            end = mid
        } else if isBadVersion(mid) == false {
            start = mid
        }
    }
    if isBadVersion(start) {
        return start
    }
    return end
}
```

### 寻找旋转排序数组中的最小值

> [153. 寻找旋转排序数组中的最小值](https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/)
>
> 已知一个长度为 n 的数组，预先按照升序排列，经由 `1` 到 `n` 次 **旋转** 后，得到输入数组。例如，原数组 `nums` = `[0,1,2,4,5,6,7]` 在变化后可能得到：
> - 若旋转 4 次，则可以得到 `[4,5,6,7,0,1,2]`
> - 若旋转 7 次，则可以得到 `[0,1,2,4,5,6,7]`
>
> 注意，数组 `[a[0], a[1], a[2], ..., a[n-1]]` 旋转一次 的结果为数组 `[a[n-1], a[0], a[1], a[2], ..., a[n-2]]` 。
>
> 给你一个元素值 **互不相同** 的数组 `nums` ，它原来是一个升序排列的数组，并按上述情形进行了多次旋转。请你找出并返回数组中的 **最小元素** 。
>
> 你必须设计一个时间复杂度为 `O(log n)` 的算法解决此问题。

```csharp
func findMin(nums []int) int {
    // 思路：/ / 最后一个值作为target，然后往左移动，最后比较start、end的值
    if len(nums) == 0 {
        return -1
    }
    start := 0
    end := len(nums) - 1

    for start+1 < end {
        mid := start + (end-start)/2
        // 最后一个元素值为target
        if nums[mid] <= nums[end] {
            end = mid
        } else {
            start = mid
        }
    }
    if nums[start] > nums[end] {
        return nums[end]
    }
    return nums[start]
}
```

### 寻找旋转排序数组中的最小值II

> [154. 寻找旋转排序数组中的最小值II](https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array-ii/)
>
> 已知一个长度为 n 的数组，预先按照升序排列，经由 `1` 到 `n` 次 **旋转** 后，得到输入数组。例如，原数组 `nums` = `[0,1,4,4,5,6,7]` 在变化后可能得到：
> - 若旋转 4 次，则可以得到 `[4,5,6,7,0,1,4]`
> - 若旋转 7 次，则可以得到 `[0,1,4,4,5,6,7]`
>
> 注意，数组 `[a[0], a[1], a[2], ..., a[n-1]]` 旋转一次 的结果为数组 `[a[n-1], a[0], a[1], a[2], ..., a[n-2]]` 。
>
> 给你一个可能存在 **重复** 元素值的数组 `nums` ，它原来是一个升序排列的数组，并按上述情形进行了多次旋转。请你找出并返回数组中的 **最小元素** 。
>
> 你必须尽可能减少整个过程的操作步骤。


```csharp
func findMin(nums []int) int {
    // 思路：跳过重复元素，mid值和end值比较，分为两种情况进行处理
    if len(nums) == 0 {
        return -1
    }
    start := 0
    end := len(nums) - 1
    for start+1 < end {
        // 去除重复元素
        for start < end && nums[end] == nums[end-1] {
            end--
        }
        for start < end && nums[start] == nums[start+1] {
            start++
        }
        mid := start + (end-start)/2
        // 中间元素和最后一个元素比较（判断中间点落在左边上升区，还是右边上升区）
        if nums[mid] <= nums[end] {
            end = mid
        } else {
            start = mid
        }
    }
    if nums[start] > nums[end] {
        return nums[end]
    }
    return nums[start]
}
```

### 搜索旋转排序数组

> [033. 搜索旋转排序数组](https://leetcode-cn.com/problems/search-in-rotated-sorted-array/)
>
> 整数数组 `nums` 按升序排列，数组中的值 **互不相同** 。
>
> 在传递给函数之前，`nums` 在预先未知的某个下标 `k`（`0 <= k < nums.length`） 上进行了 **旋转**，使数组变为 `[nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]`（下标 **从 0 开始** 计数）。例如， `[0,1,2,4,5,6,7]` 在下标 `3` 处经旋转后可能变为 `[4,5,6,7,0,1,2]` 。
>
> 给你 **旋转后** 的数组 `nums` 和一个整数 `target` ，如果 `nums` 中存在这个目标值 `target` ，则返回它的下标，否则返回 `-1` 。
>
> 你必须设计一个时间复杂度为 `O(log n)` 的算法解决此问题。

```csharp
func search(nums []int, target int) int {
    // 思路：/ / 两条上升直线，四种情况判断
    if len(nums) == 0 {
        return -1
    }
    start := 0
    end := len(nums) - 1
    for start+1 < end {
        mid := start + (end-start)/2
        // 相等直接返回
        if nums[mid] == target {
            return mid
        }
        // 判断在那个区间，可能分为四种情况
        if nums[start] < nums[mid] {
            if nums[start] <= target && target <= nums[mid] {
                end = mid
            } else {
                start = mid
            }
        } else if nums[end] > nums[mid] {
            if nums[end] >= target && nums[mid] <= target {
                start = mid
            } else {
                end = mid
            }
        }
    }
    if nums[start] == target {
        return start
    } else if nums[end] == target {
        return end
    }
    return -1
}
```

注意点

> 面试时，可以直接画图进行辅助说明，空讲很容易让大家都比较蒙圈

### 搜索旋转排序数组II 

> [081. 搜索旋转排序数组II](https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii/)
>
> 已知存在一个按非降序排列的整数数组 `nums` ，数组中的值不必互不相同。
>
> 在传递给函数之前，`nums` 在预先未知的某个下标 `k`（`0 <= k < nums.length`）上进行了 **旋转** ，使数组变为 `[nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]`（下标 **从 0 开始** 计数）。例如， `[0,1,2,4,4,4,5,6,6,7]` 在下标 `5` 处经旋转后可能变为 `[4,5,6,6,7,0,1,2,4,4]` 。
>
>给你 **旋转后** 的数组 `nums` 和一个整数 `target` ，请你编写一个函数来判断给定的目标值是否存在于数组中。如果 `nums` 中存在这个目标值 `target` ，则返回 `true` ，否则返回 `false` 。
>
> 你必须尽可能减少整个操作步骤。

```csharp
func search(nums []int, target int) bool {
    // 思路：/ / 两条上升直线，四种情况判断，并且处理重复数字
    if len(nums) == 0 {
        return false
    }
    start := 0
    end := len(nums) - 1
    for start+1 < end {
        // 处理重复数字
        for start < end && nums[start] == nums[start+1] {
            start++
        }
        for start < end && nums[end] == nums[end-1] {
            end--
        }
        mid := start + (end-start)/2
        // 相等直接返回
        if nums[mid] == target {
            return true
        }
        // 判断在那个区间，可能分为四种情况
        if nums[start] < nums[mid] {
            if nums[start] <= target && target <= nums[mid] {
                end = mid
            } else {
                start = mid
            }
        } else if nums[end] > nums[mid] {
            if nums[end] >= target && nums[mid] <= target {
                start = mid
            } else {
                end = mid
            }
        }
    }
    if nums[start] == target || nums[end] == target {
        return true
    }
    return false
}
```

## 总结

二分搜索核心四点要素（必背&理解）

- 1、初始化：start=0、end=len-1
- 2、循环退出条件：start + 1 < end
- 3、比较中点和目标值：A[mid] ==、 <、> target
- 4、判断最后两个元素是否符合：A[start]、A[end] ? target

## 练习题

- [ ] [704. 二分查找](https://leetcode-cn.com/problems/binary-search/)
- [ ] [061. 搜索区间](https://www.lintcode.com/problem/search-for-a-range/description)
- [ ] [035. 搜索插入位置](https://leetcode-cn.com/problems/search-insert-position/)
- [ ] [074. 搜索二维矩阵](https://leetcode-cn.com/problems/search-a-2d-matrix/)
- [ ] [278. 第一个错误的版本](https://leetcode-cn.com/problems/first-bad-version/)
- [ ] [153. 寻找旋转排序数组中的最小值](https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/)
- [ ] [154. 寻找旋转排序数组中的最小值II](https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array-ii/)
- [ ] [033. 搜索旋转排序数组](https://leetcode-cn.com/problems/search-in-rotated-sorted-array/)
- [ ] [081. 搜索旋转排序数组II](https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii/)
