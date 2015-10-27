using System.Collections.Generic;

namespace SimplePoker.Subsets {
    /// <summary>
    /// Parent abstract class for subsets
    /// </summary>
    internal abstract class Subset {

        List<Card> tail = new List<Card>();
        List<Card> set = new List<Card>();

        /// <summary>
        /// Constructor of subset
        /// </summary>
        /// <param name="sortedCards">cards of the player sorted from high to low</param>
        internal Subset(List<Card> sortedCards) { }
        /// <summary>
        /// Type of subset
        /// </summary>
        internal abstract SubsetType SubsetType { get; }
        /// <summary>
        /// Returns list of subset cards (three of a kind, two of a kind, etc)
        /// </summary>
        internal virtual List<Card> Set {
            get { return this.set; }
            set { this.set = value; }
        }
        /// <summary>
        /// Returns tail of the card set (hand) after card subset was found
        /// </summary>
        internal virtual List<Card> Tail {
            get { return this.tail; }
            set { this.tail = value; }
        }
    }
}
