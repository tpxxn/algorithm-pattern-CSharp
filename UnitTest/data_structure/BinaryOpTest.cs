using algorithm_pattern;

namespace UnitTest.data_structure;

public class BinaryOpTest
{
    [SetUp]
    public void Setup()
    {
    }

    #region 136.只出现一次的数字

    [Test]
    public void StackQueueTest_SingleNumber()
    {
        var result = BinaryOp.SingleNumber(new[] { 2, 2, 1 });
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void StackQueueTest_SingleNumber_2()
    {
        var result = BinaryOp.SingleNumber(new[] { 4, 1, 2, 1, 2 });
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void StackQueueTest_SingleNumber_3()
    {
        var result = BinaryOp.SingleNumber(new[] { 1 });
        Assert.That(result, Is.EqualTo(1));
    }

    #endregion

    #region 137.只出现一次的数字ii

    [Test]
    public void StackQueueTest_SingleNumberII()
    {
        var result = BinaryOp.SingleNumberII(new[] { 2, 2, 3, 2 });
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void StackQueueTest_SingleNumberII_2()
    {
        var result = BinaryOp.SingleNumberII(new[] { 0, 1, 0, 1, 0, 1, 99 });
        Assert.That(result, Is.EqualTo(99));
    }

    #endregion

    #region 260.只出现一次的数字iii

    [Test]
    public void StackQueueTest_SingleNumberIII()
    {
        var result = BinaryOp.SingleNumberIII(new[] { 1, 2, 1, 3, 2, 5 });
        object[] expected = { new[] { 3, 5 }, new[] { 5, 3 } };
        Assert.That(result, Is.AnyOf(expected));
    }

    [Test]
    public void StackQueueTest_SingleNumberIII_2()
    {
        var result = BinaryOp.SingleNumberIII(new[] { -1, 0 });
        object[] expected = { new[] { -1, 0 }, new[] { 0, -1 } };
        Assert.That(result, Is.AnyOf(expected));
    }

    [Test]
    public void StackQueueTest_SingleNumberIII_3()
    {
        var result = BinaryOp.SingleNumberIII(new[] { 0, 1 });
        object[] expected = { new[] { 0, 1 }, new[] { 1, 0 } };
        Assert.That(result, Is.AnyOf(expected));
    }

    #endregion

    #region 191.位1的个数

    [Test]
    public void StackQueueTest_HammingWeight()
    {
        const uint num = 0b0000_0000_0000_0000_0000_0000_0000_1011;
        var result = BinaryOp.HammingWeight(num);
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void StackQueueTest_HammingWeight_2()
    {
        const uint num = 0b0000_0000_0000_0000_0000_0000_1000_0000;
        var result = BinaryOp.HammingWeight(num);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void StackQueueTest_HammingWeight_3()
    {
        const uint num = 0b1111_1111_1111_1111_1111_1111_1111_1101;
        var result = BinaryOp.HammingWeight(num);
        Assert.That(result, Is.EqualTo(31));
    }

    #endregion

    #region 338.比特位计数

    [Test]
    public void StackQueueTest_CountBits()
    {
        var result = BinaryOp.CountBits(2);
        Assert.That(result, Is.EqualTo(new[] { 0, 1, 1 }));
    }

    [Test]
    public void StackQueueTest_CountBits_2()
    {
        var result = BinaryOp.CountBits(5);
        Assert.That(result, Is.EqualTo(new[] { 0, 1, 1, 2, 1, 2 }));
    }

    #endregion

    #region 190.颠倒二进制位

    [Test]
    public void StackQueueTest_reverseBits()
    {
        const uint num = 0b0000_0010_1001_0100_0001_1110_1001_1100;
        var result = BinaryOp.reverseBits(num);
        Assert.That(result, Is.EqualTo(964176192));
    }

    [Test]
    public void StackQueueTest_reverseBits_2()
    {
        const uint num = 0b1111_1111_1111_1111_1111_1111_1111_1101;
        var result = BinaryOp.reverseBits(num);
        Assert.That(result, Is.EqualTo(3221225471));
    }

    #endregion

    #region 201.数字范围按位与

    [Test]
    public void StackQueueTest_RangeBitwiseAnd()
    {
        var result = BinaryOp.RangeBitwiseAnd(5, 7);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void StackQueueTest_RangeBitwiseAnd_2()
    {
        var result = BinaryOp.RangeBitwiseAnd(0, 0);
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void StackQueueTest_RangeBitwiseAnd_3()
    {
        var result = BinaryOp.RangeBitwiseAnd(1, 2147483647);
        Assert.That(result, Is.EqualTo(0));
    }

    #endregion
}