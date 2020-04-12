using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();

        public int Count
        {
            get
            {
                return cards.Count();
            }
        }


        public Card this[int index]
        {
            get
            {
                return cards[index];
            }
        }


        public void AddCard(Card newCard)
        {
            if (ContainsCard(newCard))
            {
                throw new ConstraintException(newCard.FaceValue.ToString() + " of " +
                    newCard.Suit.ToString() + " already exists in the Handsss");
            }

            cards.Add(newCard);
        }


        public bool ContainsCard(Card cardToCheck)
        {
            return cards.Where(card => card.FaceValue == cardToCheck.FaceValue && card.Suit == cardToCheck.Suit).Count() != 0;
        }

        public Card RemoveCard(Card theCard)
        {
            if (!cards.Contains(theCard))
            {
                throw new ConstraintException("That card is no where to be found to remove.");
            }
            cards.Remove(theCard);
            return theCard;
        }

        public void RemoveCard(int index)
        {
            if (index < 0 || index > cards.Count - 1)
            {
                throw new ConstraintException("A card does not exist at the index specify.");
            }
            cards.RemoveAt(index);
        }

        public void RemoveCard(Suit theSuit, FaceValue theFaceValue)
        {
            Card card = cards.Where(c => c.Suit == theSuit && c.FaceValue == theFaceValue).FirstOrDefault();
            if(card == null)
            {
                throw new ConstraintException(theFaceValue.ToString() + " of " +
                                  theSuit.ToString() + " does not exist in the Hand.");
            }
            cards.Remove(card);
        }

        public void SortCard()
        {
            List<Card> orderSuit = cards.OrderBy(c => c.Suit).ToList();
            cards = orderSuit;
            List<Card> orderValue = cards.OrderBy(c => c.FaceValue).ToList();
            cards = orderValue;

        }
    }
}
