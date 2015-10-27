using System.Collections.Generic;
using System.Linq;

namespace SimplePoker.Subsets {
    internal class FourOfAKind : Subset {

        internal FourOfAKind(List<Card> sortedCards) : base(sortedCards) {
            for (int i = 0; i < 2; i++) {
                int firstCardValue = (int)sortedCards[i].Value;
                int secondCardValue = (int)sortedCards[i + 1].Value;
                int thirdCardValue = (int)sortedCards[i + 2].Value;
                int fourthCardValue = (int)sortedCards[i + 3].Value;
                if (firstCardValue == secondCardValue && secondCardValue == thirdCardValue) {
                    Set = new List<Card> { sortedCards[i], sortedCards[i + 1], sortedCards[i + 2], sortedCards[i + 3] };
                    Tail = sortedCards.Where(q => (int)q.Value != firstCardValue).ToList();
                    break;
                }
            }
        }

        internal override SubsetType SubsetType { get { return SubsetType.FourOfAKind; } }
    }
}
