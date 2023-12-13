using algorithm_pattern.advanced_algorithm.Backtrack;

namespace UnitTest.advanced_algorithm;

public class BacktrackTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SubsetsTest()
    {
        var result = new Backtrack_Subsets().Subsets(new int[] { 1, 2, 3 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 3 },
            new List<int> { 2 },
            new List<int> { 2, 3 },
            new List<int> { 1 },
            new List<int> { 1, 3 },
            new List<int> { 1, 2 },
            new List<int> { 1, 2, 3 },
        }));
    }

    [Test]
    public void SubsetsTest_2()
    {
        var result = new Backtrack_Subsets().Subsets(new int[] { 0 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 0 },
        }));
    }

    [Test]
    public void SubsetsWithDupTest()
    {
        var result = new Backtrack_SubsetsWithDup().SubsetsWithDup(new int[] { 1, 2, 2 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 2 },
            new List<int> { 2, 2 },
            new List<int> { 1 },
            new List<int> { 1, 2 },
            new List<int> { 1, 2, 2 },
        }));
    }

    [Test]
    public void SubsetsWithDupTest_2()
    {
        var result = new Backtrack_SubsetsWithDup().SubsetsWithDup(new int[] { 0 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int>
            {
                Capacity = 0
            },
            new List<int> { 0 },
        }));
    }

    [Test]
    public void PermuteTest()
    {
        var result = new Backtrack_Permute().Permute(new int[] { 1, 2, 3 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 3, 2 },
            new List<int> { 2, 1, 3 },
            new List<int> { 2, 3, 1 },
            new List<int> { 3, 2, 1 },
            new List<int> { 3, 1, 2 }
        }));
    }

    [Test]
    public void PermuteTest_2()
    {
        var result = new Backtrack_Permute().Permute(new int[] { 0, 1 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int> { 0, 1 },
            new List<int> { 1, 0 }
        }));
    }

    [Test]
    public void PermuteTest_3()
    {
        var result = new Backtrack_Permute().Permute(new int[] { 1 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int> { 1 }
        }));
    }


    [Test]
    public void PermuteUniqueTest()
    {
        var result = new Backtrack_PermuteUnique().PermuteUnique(new int[] { 1, 1, 2 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int> { 1, 1, 2 },
            new List<int> { 1, 2, 1 },
            new List<int> { 2, 1, 1 }
        }));
    }

    [Test]
    public void PermuteUniqueTest_2()
    {
        var result = new Backtrack_PermuteUnique().PermuteUnique(new int[] { 1, 2, 3 });
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 3, 2 },
            new List<int> { 2, 1, 3 },
            new List<int> { 2, 3, 1 },
            new List<int> { 3, 1, 2 },
            new List<int> { 3, 2, 1 }
        }));
    }

    [Test]
    public void CombinationSumTest()
    {
        var result = new Backtrack_CombinationSum().CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int> { 2, 2, 3 },
            new List<int> { 7 }
        }));
    }

    [Test]
    public void CombinationSumTest_2()
    {
        var result = new Backtrack_CombinationSum().CombinationSum(new int[] { 2, 3, 5 }, 8);
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            new List<int> { 2, 2, 2, 2 },
            new List<int> { 2, 3, 3 },
            new List<int> { 3, 5 }
        }));
    }

    [Test]
    public void CombinationSumTest_3()
    {
        var result = new Backtrack_CombinationSum().CombinationSum(new int[] { 2 }, 1);
        Assert.That(result, Is.EqualTo(new List<List<int>>
        {
            Capacity = 0
        }));
    }

    [Test]
    public void LetterCombinationsTest()
    {
        var result = new Backtrack_LetterCombinations().LetterCombinations("23");
        Assert.That(result, Is.EqualTo(new List<string>
        {
            "ad",
            "ae",
            "af",
            "bd",
            "be",
            "bf",
            "cd",
            "ce",
            "cf"
        }));
    }

    [Test]
    public void LetterCombinationsTest_2()
    {
        var result = new Backtrack_LetterCombinations().LetterCombinations("");
        Assert.That(result, Is.EqualTo(new List<string>
        {
            Capacity = 0
        }));
    }

    [Test]
    public void LetterCombinationsTest_3()
    {
        var result = new Backtrack_LetterCombinations().LetterCombinations("2");
        Assert.That(result, Is.EqualTo(new List<string>
        {
            "a",
            "b",
            "c"
        }));
    }
}