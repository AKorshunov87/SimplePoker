using System.Collections.Generic;
using NUnit.Framework;
using SimplePoker;

namespace SimplePokerTests {
    [TestFixture]
    public class CardTests {

        #region Helpers

        void CardValuesTest(Card card, Value value, Suit suit, string name) {
            Assert.AreEqual(value, card.Value);
            Assert.AreEqual(suit, card.Suit);
            Assert.AreEqual(name, card.Name);
        }

        #endregion

        #region Tests

        [Test]
        public void SetCardValues() {
            Card card = new Card(Suit.Spades, Value.Seven);
            CardValuesTest(card, Value.Seven, Suit.Spades, "7S");
            card = new Card(Suit.Diamonds, Value.Jack);
            CardValuesTest(card, Value.Jack, Suit.Diamonds, "JD");
        }

        [Test]
        public void Sort() {
            Card[] cards = new Card[5] { new Card(Suit.Spades, Value.Queen), new Card(Suit.Diamonds, Value.Four), new Card(Suit.Clubs, Value.Five), new Card(Suit.Spades, Value.Ace), new Card(Suit.Hearts, Value.Queen) };
            List<Card> sorted = Card.Sort(cards);
            Assert.NotNull(sorted);
            Assert.AreEqual(5, sorted.Count);
            Card firstCard = sorted[0];
            Assert.AreEqual(Value.Ace, firstCard.Value);
            Assert.AreEqual(Suit.Spades, firstCard.Suit);
        }

        #endregion

    }
}
