namespace algorithm_pattern;

public class BinaryOp
{
    /// <summary>
    /// <para>136. 只出现一次的数字</para>
    /// <para>https://leetcode-cn.com/problems/single-number/</para>
    /// </summary>
    /// <param name="nums">给定数组</param>
    /// <returns>只出现一次的元素</returns>
    public static int SingleNumber(int[] nums)
    {
        int single = 0;
        foreach (int num in nums)
        {
            single ^= num;
        }
        return single;
    }

    /// <summary>
    /// <para>137. 只出现一次的数字ii</para>
    /// <para>https://leetcode-cn.com/problems/single-number-ii/</para>
    /// </summary>
    /// <param name="nums">给定数组</param>
    /// <returns>只出现一次的元素</returns>
    public static int SingleNumberII(int[] nums)
    {
        int ones = 0, twos = 0;
        foreach (int num in nums)
        {
            ones ^= num & ~twos;
            twos ^= num & ~ones;
        }
        return ones;
    }


    /// <summary>
    /// <para>260. 只出现一次的数字iii</para>
    /// <para>https://leetcode-cn.com/problems/single-number-iii/</para>
    /// </summary>
    /// <param name="nums">给定数组</param>
    /// <returns>只出现一次的两个元素</returns>
    public static int[] SingleNumberIII(int[] nums)
    {
        int[] singles = new int[2];
        int xor = 0;
        foreach (int num in nums)
        {
            xor ^= num;
        }
        int lowBit = xor & -xor;
        foreach (int num in nums)
        {
            if ((num & lowBit) != 0)
            {
                singles[0] ^= num;
            }
            else
            {
                singles[1] ^= num;
            }
        }
        return singles;
    }


    /// <summary>
    /// <para>191. 位1的个数</para>
    /// <para>https://leetcode-cn.com/problems/number-of-1-bits/</para>
    /// </summary>
    /// <param name="nums">给定数组</param>
    /// <returns>位1的个数</returns>
    public static int HammingWeight(uint n)
    {
        const int BITS = 32;
        int ones = 0;
        for (int i = 0; i < BITS; i++)
        {
            ones += (int)(n >> i) & 1;
        }
        return ones;
    }


    /// <summary>
    /// <para>338. 比特位计数</para>
    /// <para>https://leetcode-cn.com/problems/counting-bits/</para>
    /// </summary>
    /// <param name="nums">给定数组</param>
    /// <returns>只出现一次的元素</returns>
    public static int[] CountBits(int n)
    {
        const int BITS = 32;
        int[] ans = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j < BITS; j++)
            {
                ans[i] += (i >> j) & 1;
            }
        }
        return ans;
    }

    /// <summary>
    /// <para>190. 颠倒二进制位</para>
    /// <para>https://leetcode-cn.com/problems/reverse-bits/</para>
    /// </summary>
    /// <param name="nums">给定数组</param>
    /// <returns>只出现一次的元素</returns>
    public static uint reverseBits(uint n)
    {
        const int BITS = 32;
        uint reversed = 0;
        for (int i = 0, j = BITS - 1; i < BITS; i++, j--)
        {
            uint bit = (n >> i) & 1;
            reversed |= bit << j;
        }
        return reversed;
    }


    /// <summary>
    /// <para>201. 数字范围按位与</para>
    /// <para>https://leetcode-cn.com/problems/bitwise-and-of-numbers-range/</para>
    /// </summary>
    /// <param name="nums">给定数组</param>
    /// <returns>只出现一次的元素</returns>
    public static int RangeBitwiseAnd(int left, int right)
    {
        while (left < right)
        {
            // 抹去最右边的 1
            right &= (right - 1);
        }
        return right;
    }
}