using System.Collections.Generic;

namespace SimplePoker.Subsets {
    /// <summary>
    /// Interface for subsets
    /// </summary>
    internal interface ISubset {
        /// <summary>
        /// Type of subset
        /// </summary>
        SubsetType SubsetType { get; }
        /// <summary>
        /// Get subsets from the cards set(hand) of the current player
        /// </summary>
        /// <param name="cards">cards of the player</param>
        /// <returns>List of subsets, each exists its own cards</returns>
        List<List<Card>> GetSubsets(Card[] cards);
    }
}
