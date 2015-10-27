using System;
using System.Collections.Generic;
using NUnit.Framework;
using SimplePoker;

namespace SimplePokerTests {
    [TestFixture]
    public class GameTests {

        #region Fields

        Game game;
        List<Player> winners = null;

        #endregion

        #region Helpers

        void WinnersTest(Player player, int expectedPlayers, int expectedWinners, string[] winnersNames) {
            game.AddPlayers(new List<Player> { player });
            Assert.AreEqual(expectedPlayers, game.GetPlayers().Count);
            winners = game.GetWinners();
            Assert.IsNotEmpty(winners);
            Assert.AreEqual(expectedWinners, winners.Count);
            for (int i = 0; i < winnersNames.Length; i++)
                Assert.AreEqual(winnersNames[i], winners[i].Name);
        }

        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void SetUp() {
            game = new Game();
            List<Player> players = game.GetPlayers();
            Assert.IsNotNull(players);
            Assert.AreEqual(0, players.Count);
        }

        [TearDown]
        public void TearDown() {
            game = null;
        }

        #endregion

        #region Tests

        [Test]
        public void PlayersAdding() {
            Player player = new Player();
            player.Cards = new Card[5];
            for (int i = 0; i < 5; i++)
                player.Cards[i] = new Card(Suit.Clubs, Value.Ace);
            List<Player> players = new List<Player> { new Player() };
            Assert.Throws(typeof(Exception), () => { game.AddPlayers(players); });
            players.Clear();
            players.Add(player);
            Assert.Throws(typeof(Exception), () => { game.AddPlayers(players); });
            game.AddPlayers(new List<Player>{
                new Player("Joe", new Card[5]{ new Card(Suit.Clubs, Value.Five),
                    new Card(Suit.Diamonds, Value.Five),
                    new Card(Suit.Hearts, Value.Five),
                    new Card(Suit.Spades, Value.Five),
                    new Card(Suit.Clubs, Value.Nine)})
            });
            players = game.GetPlayers();
            Assert.IsNotNull(players);
            Assert.AreEqual(1, players.Count);
            game.AddPlayers(new List<Player>{
                new Player("Joe", new Card[5]{ new Card(Suit.Clubs, Value.Jack),
                    new Card(Suit.Diamonds, Value.Jack),
                    new Card(Suit.Hearts, Value.Jack),
                    new Card(Suit.Spades, Value.Jack),
                    new Card(Suit.Clubs, Value.Six)})
            });
            players = game.GetPlayers();
            Assert.IsNotNull(players);
            Assert.AreEqual(2, players.Count);
            Assert.Throws(typeof(Exception), () => {
                game.AddPlayers(new List<Player>{
                new Player("Joe", new Card[5]{ new Card(Suit.Clubs, Value.Queen),
                    new Card(Suit.Diamonds, Value.Queen),
                    new Card(Suit.Hearts, Value.Queen),
                    new Card(Suit.Spades, Value.Queen),
                    new Card(Suit.Clubs, Value.Six)})});
            });
        }

        [Test]
        public void Winner() {
            Player player = new Player("Jordan", new Card[5]{
                    new Card(Suit.Hearts, Value.Eight),
                    new Card(Suit.Hearts, Value.Five),
                    new Card(Suit.Diamonds, Value.Five),
                    new Card(Suit.Diamonds, Value.Jack),
                    new Card(Suit.Clubs, Value.Jack)
                });
            WinnersTest(player, 1, 1, new string[] { "Jordan" });
            player = new Player("Jon", new Card[5]{
                    new Card(Suit.Hearts, Value.Jack),
                    new Card(Suit.Spades, Value.Jack),
                    new Card(Suit.Diamonds, Value.Queen),
                    new Card(Suit.Diamonds, Value.Two),
                    new Card(Suit.Clubs, Value.Two)
                });
            WinnersTest(player, 2, 1, new string[] { "Jon" });
            player = new Player("John", new Card[5]{
                    new Card(Suit.Hearts, Value.Ace),
                    new Card(Suit.Spades, Value.Ace),
                    new Card(Suit.Diamonds, Value.Ace),
                    new Card(Suit.Diamonds, Value.Six),
                    new Card(Suit.Clubs, Value.Six)
                });
            WinnersTest(player, 3, 1, new string[] { "John" });
            game = new Game();
            Assert.IsEmpty(game.GetPlayers());
            player = new Player("Jack", new Card[5]{
                    new Card(Suit.Hearts, Value.Ace),
                    new Card(Suit.Spades, Value.Ace),
                    new Card(Suit.Diamonds, Value.Three),
                    new Card(Suit.Diamonds, Value.Two),
                    new Card(Suit.Clubs, Value.Four)
                });
            WinnersTest(player, 1, 1, new string[] { "Jack" });
            player = new Player("Alex", new Card[5]{
                    new Card(Suit.Diamonds, Value.Four),
                    new Card(Suit.Clubs, Value.Three),
                    new Card(Suit.Diamonds, Value.Ace),
                    new Card(Suit.Clubs, Value.Ace),
                    new Card(Suit.Clubs, Value.Two)
                });
            WinnersTest(player, 2, 2, new string[] { "Jack", "Alex" });
        }

        #endregion

    }
}