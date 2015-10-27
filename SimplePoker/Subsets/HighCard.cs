using System.Collections.Generic;

namespace SimplePoker.Subsets {
    internal class HighCard : Subset {

        internal HighCard(List<Card> sortedCards) : base(sortedCards) {
            Set = Tail = sortedCards;
        }

        internal override SubsetType SubsetType { get { return SubsetType.HighCard; } }
    }
}
