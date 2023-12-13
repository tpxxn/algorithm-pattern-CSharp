# 滑动窗口

## 模板

```cpp
/* 滑动窗口算法框架 */
void slidingWindow(string s, string t) {
    unordered_map<char, int> need, window;
    for (char c : t) need[c]++;

    int left = 0, right = 0;
    int valid = 0;
    while (right < s.size()) {
        // c 是将移入窗口的字符
        char c = s[right];
        // 右移窗口
        right++;
        // 进行窗口内数据的一系列更新
        ...

        /*** debug 输出的位置 ***/
        printf("window: [%d, %d)\n", left, right);
        /********************/

        // 判断左侧窗口是否要收缩
        while (window needs shrink) {
            // d 是将移出窗口的字符
            char d = s[left];
            // 左移窗口
            left++;
            // 进行窗口内数据的一系列更新
            ...
        }
    }
}
```

需要变化的地方

- 1、右指针右移之后窗口数据更新
- 2、判断窗口是否要收缩
- 3、左指针右移之后窗口数据更新
- 4、根据题意计算结果

## 示例

### 最小覆盖子串

> [076. 最小覆盖子串](https://leetcode-cn.com/problems/minimum-window-substring/)
>
> 给你一个字符串 `s` 、一个字符串 `t` 。返回 `s` 中涵盖 `t` 所有字符的最小子串。如果 `s` 中不存在涵盖 `t` 所有字符的子串，则返回空字符串 `""` 。

```csharp
public string MinWindow(string s, string t)
{
    int minStart = -1;
    int minLength = int.MaxValue;
    IDictionary<char, int> counts = new Dictionary<char, int>();
    int m = s.Length;
    foreach (char c in t)
    {
        counts.TryAdd(c, 0);
        counts[c]--;
    }
    int start = 0, end = 0;
    while (end < m)
    {
        char curr = s[end];
        if (counts.ContainsKey(curr))
        {
            counts.TryAdd(curr, 0);
            counts[curr]++;
        }
        while (AllIncluded(counts))
        {
            if (end - start + 1 < minLength)
            {
                minStart = start;
                minLength = end - start + 1;
            }
            char prev = s[start];
            if (counts.ContainsKey(prev))
            {
                counts[prev]--;
            }
            start++;
        }
        end++;
    }
    return minStart < 0 ? "" : s.Substring(minStart, minLength);
}

public bool AllIncluded(IDictionary<char, int> counts)
{
    foreach (KeyValuePair<char, int> pair in counts)
    {
        if (pair.Value < 0)
        {
            return false;
        }
    }
    return true;
}
```

### 字符串的排列

> [567. 字符串的排列](https://leetcode-cn.com/problems/permutation-in-string/)
>
> 给你两个字符串 `s1` 和 `s2` ，写一个函数来判断 `s2` 是否包含 `s1` 的排列。如果是，返回 `true` ；否则，返回 `false` 。
>
> 换句话说，`s1` 的排列之一是 `s2` 的 **子串**。

```csharp
public bool CheckInclusion(string s1, string s2)
{
    int m = s1.Length, n = s2.Length;
    if (m > n)
    {
        return false;
    }
    int[] cnt = new int[26];
    foreach (char c in s1)
    {
        cnt[c - 'a']++;
    }
    int[] cur = new int[26];
    char[] s2Array = s2.ToCharArray();
    for (int i = 0; i < m; i++)
    {
        cur[s2Array[i] - 'a']++;
    }
    if (Check(cnt, cur))
    {
        return true;
    }
    for (int i = m; i < n; i++)
    {
        cur[s2Array[i] - 'a']++;
        cur[s2Array[i - m] - 'a']--;
        if (Check(cnt, cur))
        {
            return true;
        }
    }
    return false;
}

public bool Check(int[] cnt1, int[] cnt2)
{
    for (int i = 0; i < 26; i++)
    {
        if (cnt1[i] != cnt2[i])
        {
            return false;
        }
    }
    return true;
}

```

### 找到字符串中所有字母异位词

> [438. 找到字符串中所有字母异位词](https://leetcode-cn.com/problems/find-all-anagrams-in-a-string/)
>
> 给定两个字符串 `s` 和 `p`，找到 `s` 中所有 `p` 的 **异位词** 的子串，返回这些子串的起始索引。不考虑答案输出的顺序。
>
> **异位词** 指由相同字母重排列形成的字符串（包括相同的字符串）。

```csharp
public IList<int> FindAnagrams(string s, string p)
{
    IList<int> startIndices = new List<int>();
    int sLength = s.Length, pLength = p.Length;
    if (sLength < pLength)
    {
        return startIndices;
    }
    int[] sCounts = new int[26];
    int[] pCounts = new int[26];
    for (int i = 0; i < pLength; i++)
    {
        char c1 = s[i];
        sCounts[c1 - 'a']++;
        char c2 = p[i];
        pCounts[c2 - 'a']++;
    }
    if (CheckEqual(sCounts, pCounts))
    {
        startIndices.Add(0);
    }
    for (int i = pLength; i < sLength; i++)
    {
        char prev = s[i - pLength];
        sCounts[prev - 'a']--;
        char curr = s[i];
        sCounts[curr - 'a']++;
        if (CheckEqual(sCounts, pCounts))
        {
            startIndices.Add(i - pLength + 1);
        }
    }
    return startIndices;
}

public bool CheckEqual(int[] sCounts, int[] pCounts)
{
    for (int i = 0; i < 26; i++)
    {
        if (sCounts[i] != pCounts[i])
        {
            return false;
        }
    }
    return true;
}
```

### 无重复字符的最长子串

> [003. 无重复字符的最长子串](https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/)
>
> 给定一个字符串 `s`，请你找出其中不含有重复字符的 **最长子串** 的长度。
>
> 示例 1:
>
> > **输入**: "abcabcbb"
> >
> > **输出**: 3
> >
> > **解释**: 因为无重复字符的最长子串是 `"abc"`，所以其长度为 3。
>
> 示例 2:
>
> > **输入**: "bbbbb"
> >
> > **输出**: 1
> >
> > **解释**: 因为无重复字符的最长子串是 `"b"`，所以其长度为 1。
>
> 示例 3:
>
> > **输入**: "pwwkew"
> >
> > **输出**: 3
> >
> > **解释**: 因为无重复字符的最长子串是 `"wke"`，所以其长度为 3。
> >
> > 请注意，你的答案必须是 **子串** 的长度，`"pwke"` 是一个子序列，不是子串。

```csharp
public int LengthOfLongestSubstring(string s)
{
    ISet<char> set = new HashSet<char>();
    int maxLength = 0;
    int start = 0, end = 0;
    int length = s.Length;
    while (end < length)
    {
        char c = s[end];
        while (start < end && set.Contains(c))
        {
            set.Remove(s[start]);
            start++;
        }
        set.Add(c);
        maxLength = Math.Max(maxLength, end - start + 1);
        end++;
    }
    return maxLength;
}
```

## 总结

- 和双指针题目类似，更像双指针的升级版，滑动窗口核心点是维护一个窗口集，根据窗口集来进行处理
- 核心步骤
    - right 右移
    - 收缩
    - left 右移
    - 求结果

## 练习

- [ ] [076. 最小覆盖子串](https://leetcode-cn.com/problems/minimum-window-substring/)
- [ ] [567. 字符串的排列](https://leetcode-cn.com/problems/permutation-in-string/)
- [ ] [438. 找到字符串中所有字母异位词](https://leetcode-cn.com/problems/find-all-anagrams-in-a-string/)
- [ ] [003. 无重复字符的最长子串](https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/)
