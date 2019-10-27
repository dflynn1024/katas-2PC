﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _2CP.Game.Model
{
    /// <summary>
    /// Player's Hand which is just a collection of cards.
    /// </summary>
    public class Hand
    {
        public IList<Card> Cards { get; }

        public Hand(IList<Card> cards = null)
        {
            Cards = cards ?? new List<Card>();
        }

        /// <summary>
        /// Initialise hand using card notation: "2♦,A♦".
        /// </summary>
        public Hand(string cards)
            : this(CreateCardsFromNotation(cards)){}

        public void AssignCard(Card card)
        {
            Cards.Add(card);
        }

        public void ClearCards()
        {
            Cards.Clear();
        }

        #region Private Helpers

        private static List<Card> CreateCardsFromNotation(string cards)
        {
            return cards.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(card => new Card(card)).ToList();
        }

        #endregion
    }
}