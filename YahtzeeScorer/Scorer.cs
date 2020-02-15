using System;
using System.Linq;

namespace YahtzeeScorer
{
    public class Scorer
    {

        //public int ScoreByNumber(int[] dice, int chosenNum)
        //{
        //    int sum = 0;

        //    foreach(int die in dice)
        //    {
        //        if(die == chosenNum)
        //        {
        //            sum += die;
        //        }
        //    }

        //    return dice.Length == 5 ? sum : 0;
        //}


        public int ScoreByNumber(int[] dice, int chosenNumber)
        {
            //return dice.Length == 5 ? dice.Sum(n => n == chosenNumber ? n : 0) : 0;
            return dice.Length == 5 ? (from die in dice where die == chosenNumber select die).Sum() : 0;
        }

        public int ScoreByHighestPair(int[] dice)
        {
            return dice.OrderByDescending(n => n).GroupBy(num => num).Where(grp => grp.Count() > 1).Select(y => y.Key).First() * 2;
        }

        public int ScoreTwoPair(int[] dice)
        {
            return dice.GroupBy(n => n).Where(grp => grp.Count() > 1).Select(i => i.Key).Take(2).Sum() * 2;
        }

        public int ScoreThreeOfAKind(int[] dice)
        {
            return dice.OrderBy(n => n).GroupBy(n => n).Where(grp => grp.Count() > 2).Select(y => y.Key).Last() * 3;
        }

        public int ScoreFourOfAKind(int[] dice)
        {
            return dice.OrderBy(n => n).GroupBy(n => n).Where(grp => grp.Count() > 2).Select(y => y.Key).Last() * 4;
        }

        public int ScoreSmallStraight(int[] dice)
        {
            var groups = dice.Distinct().OrderBy(n => n);
            var lastval = groups.First();
            return dice.Count() == 5 ? groups.Count() > 3 && !groups.Any(val => { var valid = val - lastval > 1 ? true : false; lastval = val; return valid; }) ? dice.Sum() : 0 : 0;
        }

        public int ScoreLargeStraight(int[] dice)
        {
            return dice.Count() == 5 ? !dice.Select((i, j) => i - j).Distinct().Skip(1).Any() ? dice.Sum() : 0 : 0;
        }

        public int ScoreFullHouse(int[] dice)
        {
            var groups = dice.GroupBy(n => n);
            return groups.Any(g1 => g1.Count() >= 3 && groups.Any(g2 => g2.Count() >= 2 && g2.Key != g1.Key)) ? dice.Sum() : 0;
        }

        public int ScoreYahtzee(int[] dice)
        {
            return dice.Count() == 5 ? dice.GroupBy(n => n).Count() < 2 ? 50 : 0 : 0;
        }

    }
}
