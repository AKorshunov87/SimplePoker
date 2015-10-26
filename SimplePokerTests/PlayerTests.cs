using System;
using NUnit.Framework;
using SimplePoker;

namespace SimplePokerTests {
    [TestFixture]
    public class PlayerTests {
        void PlayerValuesTest(Player player, string name) {
            Assert.AreEqual(name, player.Name);
        }

        [Test]
        public void SetPlayerValues() {
            Player player = new Player();
            PlayerValuesTest(player, "Anonymous");
            player = new Player("John");
            PlayerValuesTest(player, "John");
        }
    }
}
