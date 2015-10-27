using System;
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
            player = new Player("John", null);
            PlayerValuesTest(player, "John", null);
            Assert.Throws(typeof(Exception), () => { player.Cards = new Card[] { new Card(Suit.Hearts, Value.Seven) }; });
            // We can create players with some strange cards but we can't add them to the game
            player.Cards = new Card[5] { new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Diamonds, Value.Ace), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven) };
            player.Name = "AlwaysWinner";
            PlayerValuesTest(player, "AlwaysWinner", new Card[5] { new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Hearts, Value.Seven), new Card(Suit.Diamonds, Value.Ace) });
        }

        #endregion

    }
}
