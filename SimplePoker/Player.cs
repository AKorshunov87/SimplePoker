using System;

namespace SimplePoker {
    /// <summary>
    /// Information about player
    /// </summary>
    public class Player {

        #region Fields

        string name;
        Card[] cards;

        #endregion

        #region Properties

        /// <summary>
        /// Player name
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Array of Five playing cards, i.e. hand ("3H, 4H, 5H, 6H, 8H", etc)
        /// </summary>
        public Card[] Cards {
            get { return cards; }
            set {
                if (value.Length == 5)
                    cards = value;
            }
        }

        #endregion

        #region Constructors

        public Player() {
            this.name = "Anonymous";
            this.cards = null;
        }

        public Player(string name, Card[] cards) : this() {
            this.name = name;
            if (cards.Length == 5)
                this.cards = cards;
        }

        #endregion
    }
}
