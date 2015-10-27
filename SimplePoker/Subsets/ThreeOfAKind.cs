using System.Linq;
using System.Collections.Generic;

namespace SimplePoker.Subsets {
    internal class ThreeOfAKind : Subset {

        internal ThreeOfAKind(List<Card> sortedCards) : base(sortedCards) {
            for (int i = 0; i < 3; i++) {
                int firstCardValue = (int)sortedCards[i].Value;
                int secondCardValue = (int)sortedCards[i + 1].Value;
                int thirdCardValue = (int)sortedCards[i + 2].Value;
                if (firstCardValue == secondCardValue && secondCardValue == thirdCardValue) {
                    Set = new List<Card> { sortedCards[i], sortedCards[i + 1], sortedCards[i + 2] };
                    Tail = sortedCards.Where(q => (int)q.Value != firstCardValue).ToList();
                    break;
                }
            }
        }

        internal override SubsetType SubsetType { get { return SubsetType.ThreeOfAKind; } }
    }
}
