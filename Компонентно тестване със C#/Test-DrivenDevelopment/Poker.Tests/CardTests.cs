using System;
using NUnit.Framework;

namespace Poker.Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void Card_TestConstructor_CorrectCardFace()
        {
            var cardFace = new CardFace();
            var card = new Card(cardFace, new CardSuit());
            Assert.AreEqual(cardFace, card.Face);
        }

        [Test]
        public void Card_TestConstructor_CorrectCardSuit()
        {
            var cardSuit = new CardSuit();
            var card = new Card(new CardFace(), cardSuit);
            Assert.AreEqual(cardSuit, card.Suit);
        }

        [TestCase(5, 1)]
        [TestCase(3, 4)]
        public void Card_TestToString_CheckIfCorrectnput(CardFace cardFace, CardSuit cardSuit)
        {
            var card = new Card(cardFace, cardSuit);
            Assert.IsNotEmpty(card.ToString());
        }
    }
}
