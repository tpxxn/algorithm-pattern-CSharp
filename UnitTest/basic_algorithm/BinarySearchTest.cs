using algorithm_pattern;

namespace UnitTest.basic_algorithm;

public class BinarySearchTest
{
    [SetUp]
    public void Setup()
    {
    }

    #region 704.二分查找

    [Test]
    public void BinarySearchTest_Search()
    {
        var result = BinarySearch.Search(new[] { -1, 0, 3, 5, 9, 12 }, 9);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void BinarySearchTest_Search2()
    {
        var result = BinarySearch.Search(new[] { -1, 0, 3, 5, 9, 12 }, 2);
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void BinarySearchTest_Search_Template()
    {
        var result = BinarySearch.Search_Template(new[] { -1, 0, 3, 5, 9, 12 }, 9);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void BinarySearchTest_Search_Template2()
    {
        var result = BinarySearch.Search_Template(new[] { -1, 0, 3, 5, 9, 12 }, 2);
        Assert.That(result, Is.EqualTo(-1));
    }

    #endregion

    #region 61.搜索区间

    [Test]
    public void BinarySearchTest_SearchRange()
    {
        var result = BinarySearch.SearchRange(Array.Empty<int>(), 9);
        Assert.That(result, Is.EqualTo(new[] { -1, -1 }));
    }

    [Test]
    public void BinarySearchTest_SearchRange2()
    {
        var result = BinarySearch.SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 8);
        Assert.That(result, Is.EqualTo(new[] { 3, 4 }));
    }

    [Test]
    public void BinarySearchTest_SearchRange3()
    {
        var result = BinarySearch.SearchRange(new[] { 5, 7, 7, 8, 8, 10 }, 9);
        Assert.That(result, Is.EqualTo(new[] { -1, -1 }));
    }

    #endregion

    #region 35.搜索插入位置

    [Test]
    public void BinarySearchTest_SearchInsert()
    {
        var result = BinarySearch.SearchInsert(new[] { 1, 3, 5, 6 }, 5);
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void BinarySearchTest_SearchInsert2()
    {
        var result = BinarySearch.SearchInsert(new[] { 1, 3, 5, 6 }, 2);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void BinarySearchTest_SearchInsert3()
    {
        var result = BinarySearch.SearchInsert(new[] { 1, 3, 5, 6 }, 7);
        Assert.That(result, Is.EqualTo(4));
    }

    #endregion

    #region 74.搜索二维矩阵

    [Test]
    public void BinarySearchTest_SearchMatrix()
    {
        var result = BinarySearch.SearchMatrix(new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } }, 3);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void BinarySearchTest_SearchMatrix2()
    {
        var result = BinarySearch.SearchMatrix(new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } }, 13);
        Assert.That(result, Is.EqualTo(false));
    }

    #endregion

    #region 278.第一个错误的版本

    [Test]
    public void BinarySearchTest_FirstBadVersion()
    {
        var result = BinarySearch.FirstBadVersion(5, 4);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void BinarySearchTest_FirstBadVersion2()
    {
        var result = BinarySearch.FirstBadVersion(1, 1);
        Assert.That(result, Is.EqualTo(1));
    }

    #endregion

    #region 153.寻找旋转排序数组中的最小值

    [Test]
    public void BinarySearchTest_FindMin()
    {
        var result = BinarySearch.FindMin(new[] { 3, 4, 5, 1, 2 });
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void BinarySearchTest_FindMin2()
    {
        var result = BinarySearch.FindMin(new[] { 4, 5, 6, 7, 0, 1, 2 });
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void BinarySearchTest_FindMin3()
    {
        var result = BinarySearch.FindMin(new[] { 11, 13, 15, 17 });
        Assert.That(result, Is.EqualTo(11));
    }

    #endregion

    #region 154.寻找旋转排序数组中的最小值II

    [Test]
    public void BinarySearchTest_FindMin2_1()
    {
        var result = BinarySearch.FindMin2(new[] { 1, 3, 5 });
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void BinarySearchTest_FindMin2_2()
    {
        var result = BinarySearch.FindMin2(new[] { 2, 2, 2, 0, 1 });
        Assert.That(result, Is.EqualTo(0));
    }

    #endregion

    #region 33.搜索旋转排序数组

    [Test]
    public void BinarySearchTest_SearchRotate()
    {
        var result = BinarySearch.SearchRotate(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void BinarySearchTest_SearchRotate2()
    {
        var result = BinarySearch.SearchRotate(new[] { 4, 5, 6, 7, 0, 1, 2 }, 3);
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void BinarySearchTest_SearchRotate3()
    {
        var result = BinarySearch.SearchRotate(new[] { 1 }, 0);
        Assert.That(result, Is.EqualTo(-1));
    }

    #endregion

    #region 81.搜索旋转排序数组II

    [Test]
    public void BinarySearchTest_SearchRotate2_1()
    {
        var result = BinarySearch.SearchRotate2(new[] { 2, 5, 6, 0, 0, 1, 2 }, 0);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void BinarySearchTest_SearchRotate2_2()
    {
        var result = BinarySearch.SearchRotate2(new[] { 2, 5, 6, 0, 0, 1, 2 }, 3);
        Assert.That(result, Is.EqualTo(false));
    }

    #endregion
}