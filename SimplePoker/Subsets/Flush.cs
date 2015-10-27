using System.Collections.Generic;
using System.Linq;

namespace SimplePoker.Subsets {
    internal class Flush : Subset {

        internal Flush(List<Card> sortedCards) : base(sortedCards) {
            Card firstCard = sortedCards.First();
            if (sortedCards.All(q => (int)q.Suit == (int)firstCard.Suit))
                Set = Tail = sortedCards;
        }

        internal override SubsetType SubsetType { get { return SubsetType.Flush; } }
    }
}
