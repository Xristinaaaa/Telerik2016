using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count!=5)
            {
                return false;
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            IsValidHand(hand);

            var a1 = hand.Cards[0].Face == hand.Cards[1].Face &&
                     hand.Cards[1].Face == hand.Cards[2].Face &&
                     hand.Cards[2].Face == hand.Cards[3].Face;

            var a2 = hand.Cards[1].Face == hand.Cards[2].Face &&
                     hand.Cards[2].Face == hand.Cards[3].Face &&
                     hand.Cards[3].Face == hand.Cards[4].Face;

            return a1 || a2;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            IsValidHand(hand);

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit==hand.Cards[i-1].Suit)
                {
                    if (!(hand.Cards[i].Face<hand.Cards[i].Face))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
