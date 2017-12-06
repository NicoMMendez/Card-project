﻿namespace CardProject.Cards.CardEffects.Instant.Chain
{
    public class CountBool : IInstant
    {
        public string Text;
        public XmlAnything<ICountable> FirstEffect;
        public XmlAnything<ICountableModifier> Modifier;
        public XmlAnything<ICountableCondition> Condition;
        public XmlAnything<IInstant> SecondEffect;

        public void Trigger(OwnedCard card)
        {
            var count = FirstEffect.Value.TriggerWithCount(card);

            if (Modifier != null)
                count = Modifier.Value.ModifyCount(count);

            if (Condition.Value.EvaluateCondition(count))
                SecondEffect.Value.Trigger(card);
        }

        public string GetText()
        {
            return Text;
        }
    }
}