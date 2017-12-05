﻿using System.Collections.Generic;
using System.Linq;

namespace CardProject.CardEffects.Instant
{
    public class DestroyRandomCardInDeck : IPlayerCardTypeEnumerable
    {
        public int NumberOfCards;
        public string CardType;

        public void Trigger(OwnedCard card)
        {
            TriggerWithPlayerCardTypes(card);
        }

        public string GetText()
        {
            if (NumberOfCards == 1)
            {
                if (CardType == null)
                    return string.Format("Destroy random card in deck.");
                else
                    return string.Format("Destroy random <i>{0}</i> card in deck.", CardType);
            }
            else
            {
                if (CardType == null)
                    return string.Format("Destroy {0} random cards in deck.", NumberOfCards);
                else
                    return string.Format("Destroy {0} <i>{1}</i> random cards in deck.", NumberOfCards, CardType);
            }
        }

        public IEnumerable<PlayerCardType> TriggerWithPlayerCardTypes(OwnedCard card)
        {
            return card.Owner.Deck.DestroyRandomCard(NumberOfCards, CardType);
        }

        public int TriggerWithCount(OwnedCard card)
        {
            return TriggerWithPlayerCardTypes(card).Count();
        }
    }
}