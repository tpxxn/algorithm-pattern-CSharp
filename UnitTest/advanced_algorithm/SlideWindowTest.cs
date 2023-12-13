using algorithm_pattern.advanced_algorithm.SlideWindow;

namespace UnitTest.advanced_algorithm;

public class SlideWindowTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MinWindowTest()
    {
        var result = SlideWindow.MinWindow("ADOBECODEBANC", "ABC");
        Assert.That(result, Is.EqualTo("BANC"));
    }

    [Test]
    public void MinWindowTest_2()
    {
        var result = SlideWindow.MinWindow("a", "a");
        Assert.That(result, Is.EqualTo("a"));
    }

    [Test]
    public void MinWindowTest_3()
    {
        var result = SlideWindow.MinWindow("a", "aa");
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void LengthOfLongestSubstringTest()
    {
        var result = SlideWindow.LengthOfLongestSubstring("abcabcbb");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void LengthOfLongestSubstringTest_2()
    {
        var result = SlideWindow.LengthOfLongestSubstring("bbbbb");
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void LengthOfLongestSubstringTest_3()
    {
        var result = SlideWindow.LengthOfLongestSubstring("pwwkew");
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void CheckInclusionTest()
    {
        var result = SlideWindow.CheckInclusion("ab", "eidbaooo");
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void CheckInclusionTest_2()
    {
        var result = SlideWindow.CheckInclusion("ab", "eidboaoo");
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void FindAnagramsTest()
    {
        var result = SlideWindow.FindAnagrams("cbaebabacd", "abc");
        Assert.That(result, Is.EqualTo(new int[] { 0, 6 }));
    }

    [Test]
    public void FindAnagramsTest_2()
    {
        var result = SlideWindow.FindAnagrams("abab", "ab");
        Assert.That(result, Is.EqualTo(new int[] { 0, 1, 2 }));
    }
}