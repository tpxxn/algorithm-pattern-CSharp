using System.Text;

namespace algorithm_pattern.advanced_algorithm.Backtrack;

public class Backtrack_Subsets
{
    IList<IList<int>> powerSet = new List<IList<int>>();
    IList<int> temp = new List<int>();
    int[] nums;
    int n;

    /// <summary>
    /// <para>078. 子集</para>
    /// <para>https://leetcode-cn.com/problems/subsets/</para>
    /// </summary>
    /// <param name="nums">给定整数数组</param>
    /// <returns>该数组所有可能的子集</returns>
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
}

public class Backtrack_SubsetsWithDup
{
    IList<IList<int>> powerSet = new List<IList<int>>();
    IList<int> temp = new List<int>();
    int[] nums;
    int n;

    /// <summary>
    /// <para>090. 子集 II</para>
    /// <para>https://leetcode-cn.com/problems/subsets-ii/</para>
    /// </summary>
    /// <param name="nums">给定整数数组</param>
    /// <returns>该数组所有可能的子集</returns>
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
}

public class Backtrack_Permute
{
    IList<IList<int>> permutations = new List<IList<int>>();
    IList<int> temp = new List<int>();
    int n;

    /// <summary>
    /// <para>046. 全排列</para>
    /// <para>https://leetcode-cn.com/problems/permutations/</para>
    /// </summary>
    /// <param name="nums">给定整数数组</param>
    /// <returns>所有可能的全排列</returns>
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
}

public class Backtrack_PermuteUnique
{
    IList<IList<int>> permutations = new List<IList<int>>();
    IList<int> temp = new List<int>();
    int[] nums;
    int n;
    bool[] visited;

    /// <summary>
    /// <para>047. 全排列 II</para>
    /// <para>https://leetcode-cn.com/problems/permutations-ii/</para>
    /// </summary>
    /// <param name="nums">给定整数数组</param>
    /// <returns>所有不重复的全排列</returns>
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
}

public class Backtrack_CombinationSum
{
    IList<IList<int>> combinations = new List<IList<int>>();
    IList<int> temp = new List<int>();
    int[] candidates;
    int n;

    /// <summary>
    /// <para>039. 组合总和</para>
    /// <para>https://leetcode-cn.com/problems/combination-sum/</para>
    /// </summary>
    /// <param name="candidates">给定整数数组</param>
    /// <param name="target">目标数组</param>
    /// <returns>candidates中可以使数字和为目标数target的所有不同组合 </returns>
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
}

public class Backtrack_LetterCombinations
{
    static string[] lettersArr = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
    string digits;
    IList<string> combinations;

    /// <summary>
    /// <para>017. 电话号码的字母组合</para>
    /// <para>https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number/</para>
    /// </summary>
    /// <param name="digits">包含数字2-9的字符串</param>
    /// <returns>所有它能表示的字母组合</returns>
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
}