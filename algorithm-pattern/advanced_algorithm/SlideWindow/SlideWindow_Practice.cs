namespace algorithm_pattern.advanced_algorithm.SlideWindow;

public class SlideWindow
{
    /// <summary>
    /// <para>76. 最小覆盖子串</para>
    /// <para>https://leetcode-cn.com/problems/minimum-window-substring/</para>
    /// </summary>
    /// <param name="s">字符串s</param>
    /// <param name="t">字符串t</param>
    /// <returns>s中涵盖t所有字符的最小子串</returns>
    public static string MinWindow(string s, string t)
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

    public static bool AllIncluded(IDictionary<char, int> counts)
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

    // <summary>
    /// <para>567. 字符串的排列</para>
    /// <para>https://leetcode-cn.com/problems/permutation-in-string/</para>
    /// </summary>
    /// <param name="s1">字符串s1</param>
    /// <param name="s2">字符串s2</param>
    /// <returns>字符串s1中是否包含字符串s2的排列</returns>
    public static bool CheckInclusion(string s1, string s2)
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

    public static bool Check(int[] cnt1, int[] cnt2)
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

    // <summary>
    /// <para>438. 找到字符串中所有字母异位词</para>
    /// <para>https://leetcode-cn.com/problems/find-all-anagrams-in-a-string/</para>
    /// </summary>
    /// <param name="s">字符串s</param>
    /// <param name="p">字符串p</param>
    /// <returns>字符串s中所有包含字符串p的字母异位词的起始索引</returns>
    public static IList<int> FindAnagrams(string s, string p)
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

    public static bool CheckEqual(int[] sCounts, int[] pCounts)
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

    // <summary>
    /// <para>3. 无重复字符的最长子串</para>
    /// <para>https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/</para>
    /// </summary>
    /// <param name="s">给定字符串</param>
    /// <returns>不含有重复字符的最长子串的长度</returns>
    public static int LengthOfLongestSubstring(string s)
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
}