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
        public string Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Array of Five playing cards, i.e. hand ("3H, 4H, 5H, 6H, 8H", etc)
        /// </summary>
        public Card[] Cards {
            get { return cards; }
            set { SetCards(value); }
        }

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

        #endregion

    }
}
