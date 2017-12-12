﻿using CardProject.Cards.CardTypes.PlayerCardTypes;
using System.Collections.Generic;
using System.Linq;

namespace CardProject.Cards.CardEffects.Instants
{
    public class DestroyRandomCardInHand : IPlayerCardTypeEnumerable
    {
        public int NumberOfCards;
        public string CardType;

        public void Trigger(TriggerArgs args)
        {
            TriggerWithPlayerCardTypes(args);
        }

        public string GetText()
        {
            if (NumberOfCards == 1)
            {
                if (CardType == null)
                    return string.Format("Destroy random card in hand.");
                else
                    return string.Format("Destroy random <i>{0}</i> card in hand.", CardType);
            }
            else
            {
                if (CardType == null)
                    return string.Format("Destroy {0} random cards in hand.", NumberOfCards);
                else
                    return string.Format("Destroy {0} <i>{1}</i> random cards in hand.", NumberOfCards, CardType);
            }
        }

        public IEnumerable<PlayerCardType> TriggerWithPlayerCardTypes(TriggerArgs args)
        {
            return args.Player.Hand.DestroyRandomCard(NumberOfCards, CardType);
        }

        public int TriggerWithCount(TriggerArgs args)
        {
            return TriggerWithPlayerCardTypes(args).Count();
        }
    }
}