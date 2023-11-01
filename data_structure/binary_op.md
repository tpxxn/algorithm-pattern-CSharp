# 二进制

## 常见二进制操作

### 基本操作

a=0^a=a^0

0=a^a

由上面两个推导出：a=a^b^b

### 交换两个数

a=a^b

b=a^b

a=a^b

### 移除最后一个 1

a=n&(n-1)

### 获取最后一个 1

diff=(n&(n-1))^n

## 常见题目

### 只出现一次的数字

> [136. 只出现一次的数字](https://leetcode-cn.com/problems/single-number/)
>
> 给你一个 **非空** 整数数组 `nums` ，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。
>
> 你必须设计并实现线性时间复杂度的算法来解决此问题，且该算法只使用常量额外空间。



```csharp
public int SingleNumber(int[] nums)
{
    int single = 0;
    foreach (int num in nums)
    {
        single ^= num;
    }
    return single;
}
```

### 只出现一次的数字 II

> [137. 只出现一次的数字 II](https://leetcode-cn.com/problems/single-number-ii/)
>
> 给你一个整数数组 `nums` ，除某个元素仅出现 **一次** 外，其余每个元素都恰出现 **三次** 。请你找出并返回那个只出现了一次的元素。
>
> 你必须设计并实现线性时间复杂度的算法且使用常数级空间来解决此问题。

```csharp
public int SingleNumberII(int[] nums)
{
    int ones = 0, twos = 0;
    foreach (int num in nums)
    {
        ones ^= num & ~twos;
        twos ^= num & ~ones;
    }
    return ones;
}
```

### 只出现一次的数字 III

> [260. 只出现一次的数字 III](https://leetcode-cn.com/problems/single-number-iii/)
>
> 给你一个整数数组 `nums`，其中恰好有两个元素只出现一次，其余所有元素均出现两次。 找出只出现一次的那两个元素。你可以按 `任意顺序` 返回答案。
>
> 你必须设计并实现线性时间复杂度的算法且仅使用常量额外空间来解决此问题。

```csharp
public int[] SingleNumberIII(int[] nums)
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
```

### 位1的个数

> [191. 位1的个数](https://leetcode-cn.com/problems/number-of-1-bits/)
>
> 编写一个函数，输入是一个无符号整数，返回其二进制表达式中数字位数为 ‘1’  的个数（也被称为[汉明重量](https://baike.baidu.com/item/%E6%B1%89%E6%98%8E%E9%87%8D%E9%87%8F)）。

```csharp
public int HammingWeight(uint n)
{
    const int BITS = 32;
    int ones = 0;
    for (int i = 0; i < BITS; i++)
    {
        ones += (int)(n >> i) & 1;
    }
    return ones;
}
```

### 比特位计数

> [338. 比特位计数](https://leetcode-cn.com/problems/counting-bits/)
>
> 给你一个整数 `n` ，对于 `0 <= i <= n` 中的每个 `i` ，计算其二进制表示中 `1` 的 **个数** ，返回一个长度为 `n + 1` 的数组 `ans` 作为答案。

```csharp
public int[] CountBits(int n)
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
```

### 颠倒二进制位

> [190. 颠倒二进制位](https://leetcode-cn.com/problems/reverse-bits/)
>
> 颠倒给定的 32 位无符号整数的二进制位。

思路：依次颠倒即可

```csharp
public uint reverseBits(uint n)
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
```

### 数字范围按位与

> [201. 数字范围按位与](https://leetcode-cn.com/problems/bitwise-and-of-numbers-range/)
>
> 给你两个整数 `left` 和 `right` ，表示区间 `[left, right]` ，返回此区间内所有数字 **按位与** 的结果（包含 `left` 、`right` 端点）。

问题转化为求两个给定数字二进制状态下的最长公共前缀，可以用移位判断的思想来做，这里使用另一种`Brian Kernighan`算法：`number`和 `number−1`之间进行按位与运算后，`number`中最右边的1会被抹去变成0。

```csharp

public int RangeBitwiseAnd(int left, int right)
{
    while (left < right)
    {
        // 抹去最右边的 1
        right &= (right - 1);
    }
    return right;
}
```

## 练习

- [ ] [136. 只出现一次的数字](https://leetcode-cn.com/problems/single-number/)
- [ ] [137. 只出现一次的数字II](https://leetcode-cn.com/problems/single-number-ii/)
- [ ] [260. 只出现一次的数字III](https://leetcode-cn.com/problems/single-number-iii/)
- [ ] [191. 位1的个数](https://leetcode-cn.com/problems/number-of-1-bits/)
- [ ] [338. 比特位计数](https://leetcode-cn.com/problems/counting-bits/)
- [ ] [190. 颠倒二进制位](https://leetcode-cn.com/problems/reverse-bits/)
- [ ] [201. 数字范围按位与](https://leetcode-cn.com/problems/bitwise-and-of-numbers-range/)
