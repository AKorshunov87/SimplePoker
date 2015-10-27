using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePoker.Subsets {
    /// <summary>
    /// Factory to generate subset from sorted by descending card set
    /// </summary>
    internal static class SubsetFactory {

        #region Methods

        /// <summary>
        /// Create subset from sorted card set
        /// </summary>
        /// <param name="sortedCards">Card set sorted by descending</param>
        /// <returns>Subset</returns>
        internal static Subset CreateSubset(List<Card> sortedCards) {
            Subset result = null;
            SubsetType[] subsetTypes = (SubsetType[])Enum.GetValues(typeof(SubsetType));
            foreach (SubsetType type in subsetTypes.OrderByDescending(q => (int)q)) {
                Subset temp = GetSubset(type, sortedCards);
                if (temp.Set.Count > 0) {
                    result = temp;
                    break;
                }
            }
            return result;
        }

        #endregion

        #region Helpers

        private static Subset GetSubset(SubsetType type, List<Card> sortedCards) {
            Subset result = new HighCard(sortedCards);
            switch (type) {
                case SubsetType.FourOfAKind:
                    result = new FourOfAKind(sortedCards);
                    break;
                case SubsetType.Flush:
                    result = new Flush(sortedCards);
                    break;
                case SubsetType.ThreeOfAKind:
                    result = new ThreeOfAKind(sortedCards);
                    break;
                case SubsetType.TwoOfAKind:
                    result = new TwoOfAKind(sortedCards);
                    break;
                default:
                    break;
            }
            return result;
        }

        #endregion
    }
}
