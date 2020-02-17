using System;
using Xunit;
using YahtzeeScorer;

namespace YahtzeeTests
{
    public class Tests
    {
        [Fact]
        public void Can_Score_30_Given_Five_Sixes()
        {
            Scorer sc = new Scorer();
            int[] dice = new int[] { 6, 6, 6, 6, 6 };
            int expected = 30;
            int numToScoreBy = 6;
            int actual = sc.ScoreByNumber(numToScoreBy, dice);
            Assert.Equal(expected, actual);
        }
  

        [Fact]
        public void Can_Score_0_Given_Six_Sixes()
        {
            Scorer sc = new Scorer();
            int[] dice = new int[] { 6, 6, 6, 6, 6, 6 };
            int expected = 0;
            int numToScoreBy = 6;
            int actual = sc.ScoreByNumber(numToScoreBy, dice);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Can_Score_24_Given_Four_Sixes()
        {
            Scorer sc = new Scorer();
            int[] dice = new int[] { 6, 6, 6, 6, 5 };
            int expected = 24;
            int numToScoreBy = 6;
            int actual = sc.ScoreByNumber(numToScoreBy, dice);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 4, 4, 2, 2, 1}, 4, 8)]
        [InlineData(new int[] { 4, 1, 2, 2, 1}, 4, 4)]
        [InlineData(new int[] { 4, 1, 2, 2, 1}, 1, 2)]
        [InlineData(new int[] { 4, 4, 2, 2, 2}, 2, 6)]
        [InlineData(new int[] { 4, 2, 2, 7, 7}, 7, 0)]
        [InlineData(new int[] { 2, 2, 2, 4, 4}, 2, 6)]
        [InlineData(new int[] { 4, 2, 2, -7, -7}, -7, 0)]
        public void Can_Score_Number(int[] dice, int numToScoreBy, int expected)
        {
            Scorer sc = new Scorer();
            int actual = sc.ScoreByNumber(numToScoreBy, dice);
            Assert.Equal(expected, actual);
        }

    }
}
