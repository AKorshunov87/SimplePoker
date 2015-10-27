using System;
using System.Collections.Generic;

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
        public Player GetWinner(){
            Player result = null;

            return result;
        }

        #endregion

        #region Helpers



        #endregion

    }
}