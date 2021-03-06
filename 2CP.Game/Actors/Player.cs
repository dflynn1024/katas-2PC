﻿using System;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public class Player
    {
        public Guid Id { get; }
        public string Name { get; }

        public Hand Hand { get; }

        public Player(string name, Hand hand = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Hand = hand ?? new Hand();
        }

        public void AssignCard(Card card)
        {
            Hand.AssignCard(card);
        }
    }
}
