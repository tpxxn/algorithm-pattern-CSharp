using algorithm_pattern.advanced_algorithm.SlideWindow;

namespace UnitTest.advanced_algorithm;

public class SlideWindowTest
{
    [SetUp]
    public void Setup()
    {
    }

    #region 76. 最小覆盖子串

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

    #endregion

    #region 3. 无重复字符的最长子串

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

    #endregion

    #region 567. 字符串的排列

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

    #endregion

    #region 438. 找到字符串中所有字母异位词

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

    #endregion
}