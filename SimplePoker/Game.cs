using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePoker {
    /// <summary>
    /// Main class. Game properties and methods (players, winner calculation, Deck, etc)
    /// </summary>
    public class Game {

        #region Fields

        Deck deck;
        List<Player> players;

        #endregion

        #region Constructors

        /// <summary>
        /// Creating the new game. New sets of cards and list of players will be created.
        /// </summary>
        public Game() {
            this.deck = new Deck();
            this.players = new List<Player>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add players to the game
        /// </summary>
        /// <param name="players">list of players which needs to be added</param>
        public void AddPlayers(List<Player> players) {
            if (players != null) {
                foreach (Player player in players) {
                    Card[] playerCards = player.Cards;
                    if (playerCards != null) {
                        foreach (Card card in playerCards)
                            deck.GiveCardToPlayer(card, player);
                    }
                    else
                        throw new Exception(String.Format("The player can't play without cards."));
                }
                this.players.AddRange(players);
            }
        }

        /// <summary>
        /// Get players which play in the current game
        /// </summary>
        /// <returns>List of the players</returns>
        public List<Player> GetPlayers() {
            return players;
        }

        /// <summary>
        /// Get a winner(s)! (more than one in case of a tie)
        /// </summary>
        /// <returns>Player(s) who win this game</returns>
        public List<Player> GetWinners() {
            List<Player> result = new List<Player>();
            if (players != null && players.Count > 0) {
                List<Player> sortedPlayers = players.OrderByDescending(p => (int)p.Subset.SubsetType).ToList();
                Player firstWinner = sortedPlayers.First();
                result.Add(firstWinner);
                List<Player> winnersList = sortedPlayers.Where(p => p.Subset.SubsetType == firstWinner.Subset.SubsetType).ToList();
                if (winnersList.Count > 1) {
                    result = CompareTails(winnersList);
                }
            }
            return result;
        }

        #endregion

        #region Helpers

        List<Player> CompareTails(List<Player> winnersList) {
            Player prevWinner = null;
            List<Player> result = new List<Player>();
            foreach (Player player in winnersList) {
                if (prevWinner == null) {
                    prevWinner = player;
                    result.Add(player);
                    continue;
                }

                List<Card> tail = player.Subset.Tail;
                List<Card> prevWinnerTail = prevWinner.Subset.Tail;
                int equalityCount = 0;
                for (int i = 0; i < tail.Count; i++) {
                    Card card = tail[i];
                    Card prevWinnerCard = prevWinnerTail[i];
                    if ((int)card.Value > (int)prevWinnerCard.Value) {
                        result.Clear();
                        result.Add(player);
                        prevWinner = player;
                        break;
                    }
                    equalityCount++;
                }
                if (equalityCount == tail.Count)
                    result.Add(player);
            }
            return result;
        }

        #endregion

    }
}