﻿using System.Collections.Generic;
using System.Linq;

public class DiscardRandomCardEffect : IPlayerCardTypeEnumerableInstantCardEffect
{
    public int NumberOfCards;
    public string CardType;

    public void Trigger(Card card)
    {
        TriggerWithPlayerCardTypes(card);
    }

    public string GetText()
    {
        if (NumberOfCards == 1)
        {
            if (CardType == null)
                return string.Format("Discard random card in hand.");
            else
                return string.Format("Discard random <i>{0}</i> card in hand.", CardType);
        }
        else
        {
            if (CardType == null)
                return string.Format("Discard {0} random cards in hand.", NumberOfCards);
            else
                return string.Format("Discard {0} <i>{1}</i> random cards in hand.", NumberOfCards, CardType);
        }
    }

    public IEnumerable<PlayerCardType> TriggerWithPlayerCardTypes(Card card)
    {
        return card.Owner.Hand.DiscardRandomCard(NumberOfCards, CardType);
    }

    public int TriggerWithCount(Card card)
    {
        return TriggerWithPlayerCardTypes(card).Count();
    }
}