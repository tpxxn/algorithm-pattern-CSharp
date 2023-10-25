using algorithm_pattern;

namespace UnitTest.basic_algorithm;

public class SortTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SortTest_QuickSort()
    {
        var array = new[] { 2, 1, 5, 3, 4, 6 };
        Sort.QuickSort(array);
        Assert.That(array, Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6 }));
    }

    [Test]
    public void SortTest_MergeSort()
    {
        var array = new[] { 2, 1, 5, 3, 4, 6 };
        Sort.MergeSort(array);
        Assert.That(array, Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6 }));
    }


    [Test]
    public void SortTest_HeapSort()
    {
        var array = new[] { 2, 1, 5, 3, 4, 6 };
        Sort.HeapSort(array);
        Assert.That(array, Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6 }));
    }
}