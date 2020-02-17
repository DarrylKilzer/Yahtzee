using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeScorer
{
    public class Scorer
    {
        public int ScoreByNumber(int numToScoreBy, int[] dice)
        {
            int score = 0;
            if(dice.Length == 5)
            {
                for(int i = 0; i < dice.Length; i++)
                {
                    int die = dice[i];
                    if(die == numToScoreBy && die < 7 && die > 0)
                    {
                        score += die;
                    }
                }
            }
            return score;
        }
    }
}
