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
        public void PlayerValues() {
            Player defaultPlayer = new Player();
            PlayerValuesTest(defaultPlayer, "Anonymous");
            Player player = new Player("John");
            PlayerValuesTest(player, "John");
        }
    }
}
