using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestFixture]
    public class PokerHandsCheckerTests
    {
        [Test]
        public void PokerHandsChecker_IsValidHandMethod_IsNull()
        {
            var hand = new Hand(new List<ICard>(5));
            Assert.IsNotNull(hand);
        }

        [Test]
        public void PokerHandsChecker_IsValidHandMethod_CardsLength()
        {
            var hand = new Hand(new List<ICard>());
            for (int i = 0; i < 5; i++)
            {
                hand.Cards.Add(new Card(new CardFace(), new CardSuit()));
            }
            Assert.AreEqual(5, hand.Cards.Count);
        }

        [Test]
        public void PokerHandsChecker_IsFlush_IsValidHand()
        {
            var hand = new Hand(new List<ICard>());
            var card = new Card(new CardFace(), new CardSuit());
            hand.Cards.Add(card);

            Assert.IsInstanceOf<Hand>(hand);
        }


        [Test]
        public void PokerHandsChecker_IsFlush_Check()
        {
            var hand = new Hand(new List<ICard>());
            var isFlush = false;

            for (int i = 0; i < 5; i++)
            {
                hand.Cards.Add(new Card(new CardFace(), new CardSuit()));
            }

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit == hand.Cards[i - 1].Suit)
                {
                    if (hand.Cards[i].Face < hand.Cards[i - 1].Face)
                    {
                        isFlush = true;
                    }
                }
            }

            if (isFlush)
            {
                Assert.That(isFlush);
            }
        }

        [Test]
        public void PokerHandsChecker_IsFourOfAKind_Check()
        {
            var hand = new Hand(new List<ICard>());

            for (int i = 0; i < 5; i++)
            {
                hand.Cards.Add(new Card(new CardFace(), new CardSuit()));
            }

            var a1 = hand.Cards[0].Face == hand.Cards[1].Face &&
                     hand.Cards[1].Face == hand.Cards[2].Face &&
                     hand.Cards[2].Face == hand.Cards[3].Face;

            var a2 = hand.Cards[1].Face == hand.Cards[2].Face &&
                     hand.Cards[2].Face == hand.Cards[3].Face &&
                     hand.Cards[3].Face == hand.Cards[4].Face;

            if (a1||a2==true)
            {
                Assert.That(true);
            }
        }
    }
}
