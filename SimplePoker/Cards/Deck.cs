using System;
using System.Collections.Generic;

namespace SimplePoker {
    /// <summary>
    /// Deck information (52 cards collection and Card - Owner pairs for the game which exists this deck)
    /// </summary>
    internal class Deck {

        #region Fields

        Dictionary<string, Card> cards = new Dictionary<string, Card>();

        #endregion

        #region Properties

        /// <summary>
        /// The cards from the deck
        /// </summary>
        internal Dictionary<string, Card> Cards { get { return cards; } }

        #endregion

        #region Constructors

        /// <summary>
        /// When creating a new deck a new sets of cards will be created
        /// </summary>
        internal Deck() {
            Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Give current card to a player. Player become an owner of the card until the game ends or reset.
        /// </summary>
        /// <param name="card">card</param>
        /// <param name="player">player which become an owner</param>
        /// <returns>Card which was given</returns>
        internal Card GiveCardToPlayer(Card card, Player player) {
            Card deckCard = cards[card.Name];
            if (deckCard != null) {
                if (deckCard.Owner == null)
                    deckCard.Owner = player;
                else
                    throw new Exception(String.Format("The card {0} is already have an owner ({1}) for this game.", deckCard.Name, deckCard.Owner.Name));
            }
            else {
                throw new Exception(String.Format("There is no {0} card in a deck.", card.Name));
            }
            return deckCard;
        }

        #endregion

        #region Helpers

        void Initialize() {
            foreach (Value value in Enum.GetValues(typeof(Value))) {
                foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                    Card card = new Card(suit, value);
                    this.cards.Add(card.Name, card);
                }
            }
        }

        #endregion

    }
}
