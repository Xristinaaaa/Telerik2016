using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void Hand_TestConstructor_ReturnValidList()
        {
            var cards = new List<ICard>();
            Assert.IsNotNull(cards);
        }

        [Test]
        public void Hand_TestList_CorrectCount()
        {
            var cards = new List<ICard>();

            for (int i = 0; i < 10; i++)
            {
                cards.Add(new Card(new CardFace(), new CardSuit()));
            }

            Assert.AreEqual(10, cards.Count);
        }

        [Test]
        public void Hand_TestToString_CheckIfCorrectInput()
        {
            var listOfCards = new List<ICard>();
            while (listOfCards.Count==10)
            {
                listOfCards.Add(new Card(new CardFace(), new CardSuit()));
            }

            Assert.IsNotEmpty(listOfCards.ToString());
        }
    }
}
