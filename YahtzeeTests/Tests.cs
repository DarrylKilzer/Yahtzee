using System;
using Xunit;
using YahtzeeScorer;

namespace YahtzeeTests
{
    public class Tests
    {
        [Fact]
       public void Score_By_Number_Returns_30_Given_Five_Sixes()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 6, 6, 6, 6, 6 };
            int expectedScore = 30;
            int actualScore = scorer.ScoreByNumber(dice, 6);
            Assert.Equal(expectedScore, actualScore);
        }

        [Fact]
        public void Score_By_Number_Returns_0_Given_Four_Dice()
        {
            Scorer scorer = new Scorer();
            int[] dice = new int[] { 4, 5, 6, 1 };
            int expectedScore = 0;
            int actualScore = scorer.ScoreByNumber(dice, 6);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 6,6,6,6,6}, 4, 0)]
        [InlineData(new int[] { 6,6,6,6,6}, 6, 30)]
        [InlineData(new int[] { 6,6,6,6,5}, 6, 24)]
        [InlineData(new int[] { 6,6,6,6}, 6, 0)]
        public void Score_By_Number(int[] dice, int chosenNum, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreByNumber(dice, chosenNum);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, 5)]
        [InlineData(new int[] { 5, 2, 3, 4, 5 }, 5, 10)]
        [InlineData(new int[] { 2, 2, 2, 1, 3 }, 2, 6)]
        [InlineData(new int[] { 4, 4, 4, 4, 4 }, 4, 20)]
        [InlineData(new int[] { 1, 1, 1, 1, 5 }, 1, 4)]
        public void Score_Of_All_Dice_By_Number(int[] dice, int chosenNumber, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreByNumber(dice, chosenNumber);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 2, 2, 2, 1, 3 }, 4)]
        [InlineData(new int[] { 2, 2, 3, 1, 3 }, 6)]
        public void Score_By_Highest_Pair(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreByHighestPair(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 2, 2, 2, 3, 3 }, 10)]
        [InlineData(new int[] { 2, 4, 4, 3, 3 }, 14)]
        public void Score_Two_Pair(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreTwoPair(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 2, 2, 2, 3, 3 }, 6)]
        [InlineData(new int[] { 2, 4, 3, 3, 3 }, 9)]
        public void Score_Three_Of_A_Kind(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreThreeOfAKind(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 2, 2, 2, 2, 3 }, 8)]
        [InlineData(new int[] { 2, 3, 3, 3, 3 }, 12)]
        public void Score_Four_Of_A_Kind(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreFourOfAKind(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 1 }, 11)]
        [InlineData(new int[] { 1, 1, 4, 5, 6 }, 0)]
        public void Score_Small_Straight(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreSmallStraight(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 15)]
        [InlineData(new int[] { 2, 3, 4, 5, 6 }, 20)]
        [InlineData(new int[] { 2, 3, 4, 5 }, 0)]
        public void Score_Large_Straight(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreLargeStraight(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 3, 3, 3, 4, 4 }, 17)]
        [InlineData(new int[] { 2, 3, 4, 5, 6 }, 0)]
        public void Score_Full_House(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreFullHouse(dice);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new int[] { 3, 3, 3, 3, 3 }, 50)]
        [InlineData(new int[] { 2, 3, 4, 5, 6 }, 0)]
        [InlineData(new int[] { 2, 3, 4, 5 }, 0)]
        public void Score_Yahtzee(int[] dice, int expectedScore)
        {
            Scorer scorer = new Scorer();
            int actualScore = scorer.ScoreYahtzee(dice);
            Assert.Equal(expectedScore, actualScore);
        }

    }
}
