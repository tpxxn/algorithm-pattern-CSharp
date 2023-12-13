# 回溯法

## 背景

回溯法（backtrack）常用于遍历列表所有子集，是 DFS 深度搜索一种，一般用于全排列，穷尽所有可能，遍历的过程实际上是一个决策树的遍历过程。时间复杂度一般 O(N!)，它不像动态规划存在重叠子问题可以优化，回溯算法就是纯暴力穷举，复杂度一般都很高。

## 模板

```go
result = []
func backtrack(选择列表,路径):
    if 满足结束条件:
        result.add(路径)
        return
    for 选择 in 选择列表:
        做选择
        backtrack(选择列表,路径)
        撤销选择
```

核心就是从选择列表里做一个选择，然后一直递归往下搜索答案，如果遇到路径不通，就返回来撤销这次选择。

## 常见例题

### 集合类

#### [078. 子集](https://leetcode-cn.com/problems/subsets/)

> 给你一个整数数组 `nums` ，数组中的元素 **互不相同** 。返回该数组所有可能的子集（幂集）。
>
> 解集 **不能** 包含重复的子集。你可以按 **任意顺序** 返回解集。

遍历过程

![image.png](https://img.fuiboom.com/img/backtrack.png)

```csharp
IList<IList<int>> powerSet = new List<IList<int>>();
IList<int> temp = new List<int>();
int[] nums;
int n;

public IList<IList<int>> Subsets(int[] nums)
{
    this.nums = nums;
    this.n = nums.Length;
    _Backtrack(0);
    return powerSet;
}

void _Backtrack(int index)
{
    if (index == n)
    {
        powerSet.Add(new List<int>(temp));
    }
    else
    {
        _Backtrack(index + 1);
        temp.Add(nums[index]);
        _Backtrack(index + 1);
        temp.RemoveAt(temp.Count - 1);
    }
}
```

#### [090. 子集 ii](https://leetcode-cn.com/problems/subsets-ii/)

> 给你一个整数数组 `nums` ，其中可能包含重复元素，请你返回该数组所有可能的子集（幂集）。
>
> 解集 **不能** 包含重复的子集。返回的解集中，子集可以按 **任意顺序** 排列。

```csharp
IList<IList<int>> powerSet = new List<IList<int>>();
IList<int> temp = new List<int>();
int[] nums;
int n;

public IList<IList<int>> SubsetsWithDup(int[] nums)
{
    Array.Sort(nums);
    this.nums = nums;
    this.n = nums.Length;
    Backtrack(0, false);
    return powerSet;
}

void Backtrack(int index, bool prevSelected)
{
    if (index == n)
    {
        powerSet.Add(new List<int>(temp));
    }
    else
    {
        Backtrack(index + 1, false);
        if (index == 0 || nums[index - 1] != nums[index] || prevSelected)
        {
            temp.Add(nums[index]);
            Backtrack(index + 1, true);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}
```

### 排列类

#### [046. 全排列](https://leetcode-cn.com/problems/permutations/)

> 给定一个不含重复数字的数组 `nums` ，返回其 *所有可能的全排列* 。你可以 **按任意顺序** 返回答案。

思路：需要记录已经选择过的元素，满足条件的结果才进行返回

```csharp
IList<IList<int>> permutations = new List<IList<int>>();
IList<int> temp = new List<int>();
int n;

public IList<IList<int>> Permute(int[] nums)
{
    foreach (int num in nums)
    {
        temp.Add(num);
    }
    n = nums.Length;
    Backtrack(0);
    return permutations;
}

void Backtrack(int index)
{
    if (index == n)
    {
        permutations.Add(new List<int>(temp));
    }
    else
    {
        for (int i = index; i < n; i++)
        {
            (temp[index], temp[i]) = (temp[i], temp[index]);
            Backtrack(index + 1);
            (temp[index], temp[i]) = (temp[i], temp[index]);
        }
    }
}

```

#### [047. 全排列 ii](https://leetcode-cn.com/problems/permutations-ii/)

> 给定一个可包含重复数字的序列 `nums` ，**按任意顺序** 返回所有不重复的全排列。

```csharp
IList<IList<int>> permutations = new List<IList<int>>();
IList<int> temp = new List<int>();
int[] nums;
int n;
bool[] visited;

public IList<IList<int>> PermuteUnique(int[] nums)
{
    Array.Sort(nums);
    this.nums = nums;
    this.n = nums.Length;
    this.visited = new bool[n];
    Backtrack(0);
    return permutations;
}

void Backtrack(int index)
{
    if (index == n)
    {
        permutations.Add(new List<int>(temp));
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            if (visited[i] || (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1]))
            {
                continue;
            }
            temp.Add(nums[i]);
            visited[i] = true;
            Backtrack(index + 1);
            temp.RemoveAt(index);
            visited[i] = false;
        }
    }
}
```

### 组合类

#### [039. 组合总和](https://leetcode-cn.com/problems/combination-sum/)

> 给你一个 **无重复元素** 的整数数组 `candidates` 和一个目标整数 `target` ，找出 `candidates` 中可以使数字和为目标数 `target` 的 所有 **不同组合** ，并以列表形式返回。你可以按 **任意顺序** 返回这些组合。
>
> `candidates` 中的 **同一个** 数字可以 **无限制重复被选取** 。如果至少一个数字的被选数量不同，则两种组合是不同的。
>
> 对于给定的输入，保证和为 `target` 的不同组合数少于 `150` 个。

```csharp
IList<IList<int>> combinations = new List<IList<int>>();
IList<int> temp = new List<int>();
int[] candidates;
int n;

public IList<IList<int>> CombinationSum(int[] candidates, int target)
{
    Array.Sort(candidates);
    this.candidates = candidates;
    this.n = candidates.Length;
    Backtrack(0, target);
    return combinations;
}

void Backtrack(int index, int remain)
{
    if (remain == 0)
    {
        combinations.Add(new List<int>(temp));
    }
    else
    {
        for (int i = index; i < n && candidates[i] <= remain; i++)
        {
            temp.Add(candidates[i]);
            Backtrack(i, remain - candidates[i]);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}
```

#### [017. 电话号码的字母组合](https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number/)

> 给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回。
>
> 给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。
>
> ![电话](../images/backtrack_letter_combinations_of_a_phone_number.png)

```csharp
static string[] lettersArr = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
string digits;
IList<string> combinations;

public IList<string> LetterCombinations(string digits)
{
    this.digits = digits;
    this.combinations = new List<string>();
    if (digits.Length == 0)
    {
        return combinations;
    }
    Backtrack(0, new StringBuilder());
    return combinations;
}

void Backtrack(int index, StringBuilder combination)
{
    if (index == digits.Length)
    {
        combinations.Add(combination.ToString());
    }
    else
    {
        int digit = digits[index] - '0';
        string letters = lettersArr[digit];
        foreach (char c in letters)
        {
            combination.Append(c);
            Backtrack(index + 1, combination);
            combination.Length--;
        }
    }
}
```

## 练习

- [ ] [078. 子集](https://leetcode-cn.com/problems/subsets/)
- [ ] [090. 子集 ii](https://leetcode-cn.com/problems/subsets-ii/)
- [ ] [046. 全排列](https://leetcode-cn.com/problems/permutations/)
- [ ] [047. 全排列 ii](https://leetcode-cn.com/problems/permutations-ii/)
- [ ] [039. 组合总和](https://leetcode-cn.com/problems/combination-sum/)
- [ ] [017. 电话号码的字母组合](https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number/)

挑战题目

- [ ] [131. 分割回文串](https://leetcode-cn.com/problems/palindrome-partitioning/)
- [ ] [093. 复原IP地址](https://leetcode-cn.com/problems/restore-ip-addresses/)
