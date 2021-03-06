﻿using System;
using System.Collections.Generic;
using System.Linq;
using SimplePoker.Subsets;

namespace SimplePoker {
    /// <summary>
    /// Information about player
    /// </summary>
    public class Player {

        #region Fields

        string name;
        Card[] cards;
        Subset subset;

        #endregion

        #region Properties

        /// <summary>
        /// Player name
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Array of Five playing cards, i.e. hand ("3H, 4H, 5H, 6H, 8H", etc)
        /// </summary>
        public Card[] Cards {
            get { return cards; }
            set {
                SetCards(value);
                SetSubset();
            }
        }

        /// <summary>
        /// Subset that player have in his hand(Four of a kind, Flush, etc)
        /// </summary>
        internal Subset Subset { get { return subset; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Create default player.
        /// </summary>
        public Player() {
            this.name = "Anonymous";
            this.cards = null;
        }

        /// <summary>
        /// Create player with set of cards and name
        /// </summary>
        /// <param name="name">player name</param>
        /// <param name="cards">set of cards</param>
        public Player(string name, Card[] cards) : this() {
            this.name = name;
            SetCards(cards);
            SetSubset();
        }

        #endregion

        #region Helpers

        void SetCards(Card[] value) {
            if (value != null) {
                if (value.Length == 5)
                    this.cards = value;
                else
                    throw new Exception(String.Format("Each player can have 5 cards only."));
            }
        }

        void SetSubset() {
            if (cards != null && cards.Any(c => c != null)) {
                List<Card> sortedCards = Card.Sort(cards);
                this.subset = SubsetFactory.CreateSubset(sortedCards);
            }
        }

        #endregion

    }
}
