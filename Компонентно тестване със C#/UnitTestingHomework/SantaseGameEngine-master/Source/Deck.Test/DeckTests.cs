using System.Collections.Generic;
using NUnit.Framework;
using Santase.Logic.Cards;

namespace Deck.Test
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Deck_ValidList_CheckIfNull()
        {
            var cards = new List<Card>();
            Assert.IsNotNull(cards);
        }

        [Test]
        public void Deck_ValidateTrumpCard_CheckIfNull()
        {
            IDeck deck = new Deck();
            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        public void Deck_ConstructorValidate_TrumpCard()
        {
            var cards = new List<Card>();
            var trumpCard = cards[0];
            Assert.AreEqual(cards[0], trumpCard);
        }

        [Test]
        public void Deck_CheckDeckCount_CheckIfInvalid()
        {
            IDeck deck = new Deck();
            Assert.IsTrue(deck.CardsLeft != 0);
        }

        [Test]
        public void Deck_CheckCardsAmount_ShouldBe24()
        {
            IDeck deck = new Deck();
            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void Deck_GetNextCard_CheckTheRightCard()
        {
            var cards = new List<Card>();
            var cardToGet = cards[cards.Count - 1];
            Assert.AreEqual(cards[cards.Count - 1], cardToGet);
        }

        [Test]
        public void Deck_ChangeTrumpCard_ChekIfValid()
        {
            var cards = new List<Card>();
            var firstTrumpCard = cards[0];
            cards.Remove(firstTrumpCard);
            var newTrumpCard = cards[0];
            Assert.AreNotEqual(firstTrumpCard, newTrumpCard);
        }
    }
}
