using System.Linq;
using NUnit.Framework;
using SimplePoker;

namespace SimplePokerTests {
    [TestFixture]
    public class PlayerTests {
        #region Helpers

        void PlayerValuesTest(Player player, string name, Card[] cards) {
            Assert.AreEqual(name, player.Name);
            if (cards == null) {
                Assert.IsNull(player.Cards);
            }
            else {
                Assert.IsNotNull(player.Cards);
                foreach (Card card in cards) {
                    Card playerCard = player.Cards.FirstOrDefault(q => q.Name.Equals(card.Name));
                    Assert.IsNotNull(playerCard);
                }
            }
        }

        #endregion

        #region Tests

        [Test]
        public void SetPlayerValues() {
            Player player = new Player();
            PlayerValuesTest(player, "Anonymous", null);
            player = new Player("John", new Card[] { new Card(Suit.Hearts, Value.Seven) });
            PlayerValuesTest(player, "John", null);
            //TODO:: Issue - DECK not found, 1 player can get 5 same cards!
            player.Cards = new Card[5] { new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Diamonds, Value.Ace), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven) };
            PlayerValuesTest(player, "John", new Card[5] { new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Diamonds, Value.Ace) });
        }

        #endregion
    }
}
