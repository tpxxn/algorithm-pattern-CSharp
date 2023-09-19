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
    
    
}