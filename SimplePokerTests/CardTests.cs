using NUnit.Framework;
using SimplePoker;

namespace SimplePokerTests {
    [TestFixture]
    public class CardTests {
        void CardValuesTest(Card card, Value value, Suit suit, string name) {
            Assert.AreEqual(value, card.Value);
            Assert.AreEqual(suit, card.Suit);
            Assert.AreEqual(name, card.Name);
        }

        [Test]
        public void SetCardValues() {
            Card card = new Card(Suit.Spades, Value.Seven);
            CardValuesTest(card, Value.Seven, Suit.Spades, "7S");
            card = new Card(Suit.Diamonds, Value.Jack);
            CardValuesTest(card, Value.Jack, Suit.Diamonds, "JD");
        }
    }
}
