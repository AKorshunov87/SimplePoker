using System.Linq;
using System.Collections.Generic;

namespace SimplePoker.Subsets {
    internal class TwoOfAKind : Subset {

        internal TwoOfAKind(List<Card> sortedCards) : base(sortedCards) {
            for (int i = 0; i < 4; i++) {
                int firstCardValue = (int)sortedCards[i].Value;
                int secondCardValue = (int)sortedCards[i + 1].Value;
                if (firstCardValue == secondCardValue) {
                    Set = new List<Card> { sortedCards[i], sortedCards[i + 1] };
                    Tail = sortedCards.Where(q => (int)q.Value != firstCardValue).ToList();
                    break;
                }
            }
        }

        internal override SubsetType SubsetType { get { return SubsetType.TwoOfAKind; } }
    }
}
