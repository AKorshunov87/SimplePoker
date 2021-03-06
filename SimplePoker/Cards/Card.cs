﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePoker {
    /// <summary>
    /// Information about card
    /// </summary>
    public class Card {

        #region Fields

        Value value;
        Suit suit;
        string name;
        Player owner;

        #endregion

        #region Properties

        /// <summary>
        /// Card suit (spades , hearts, diamonds, clubs)
        /// </summary>
        public Suit Suit { get { return suit; } }

        /// <summary>
        /// Card value (2, 3, 4,..., 10,..., Ace)
        /// </summary>
        public Value Value { get { return value; } }

        /// <summary>
        /// Abbreviation of the card (3H, 4H, AC, 10C, QS, etc)
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// The player who owns the card
        /// </summary>
        internal Player Owner {
            get { return owner; }
            set { owner = value; }
        }

        #endregion

        #region Constructors

        public Card(Suit suit, Value value) {
            this.value = value;
            this.suit = suit;
            this.name = GetName();
            this.owner = null;
        }

        #endregion

        #region Methods

        public static List<Card> Sort(Card[] cards) {
            List<Card> result = new List<Card>();
            if (cards != null)
                result = cards.OrderByDescending(q => (int)q.value).ToList();
            return result;
        }

        #endregion

        #region Helpers

        string GetName() {
            string cardSuit = String.Format("{0}", suit.ToString()[0]);
            string cardValue = String.Empty;
            if ((int)value > 10)
                cardValue = String.Format("{0}", value.ToString()[0]);
            else
                cardValue = String.Format("{0}", (int)value);
            return String.Format("{0}{1}", cardValue, cardSuit);
        }

        #endregion

    }
}
