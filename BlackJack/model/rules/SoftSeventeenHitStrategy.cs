using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftSeventeenHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if(a_dealer.CalcScore() == g_hitLimit)
            {
                var aces = a_dealer.GetHand().Where(c => c.GetValue() == Card.Value.Ace);
                var other = a_dealer.GetHand().Where(c => c.GetValue() != Card.Value.Ace);

                int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
                int score = 0;

                foreach (Card c in other)
                {
                    if (c.GetValue() != Card.Value.Hidden)
                    {
                        score += cardScores[(int)c.GetValue()];
                    }
                }

                return aces.Count() > 0 && score == 6;
            }

            return a_dealer.CalcScore() < g_hitLimit;            
        }
    }
}
