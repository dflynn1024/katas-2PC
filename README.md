# 2 Card Poker

Develop a simplified 2 card poker game to show off your C# programming prowess.

1.	2-6 players.
1.	2-5 rounds.
1.	The dealer shuffles the deck at the start of each round.
1.	The dealer deals 2 cards to each player.
1.	The dealer ranks each player’s hand according the poker hand ranking rules
1.	At the end of each round, each player is assigned a score (0 – weakest to strongest x-1 (where x = number of players)).
1.	The overall winner is determined once all rounds have been completed. The winner is the player with the highest score.

## Poker Hand Ranks:

In order from strongest to weakest

1.	Straight Flush (2 cards of sequential rank, same suit)
2.	Flush (2 cards, same suit)
3.	Straight (2 cards of sequential rank, different suit)
4.	1 pair (2 cards of same rank)
5.	High Card (2 cards, different rank, suit and not in sequence. Highest card wins)

*	Individual cards are ranked A (highest), K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2 (lowest). 
*	Suit order (strongest to weakest): Spades, Clubs, Hearts, Diamonds

## Feature: Shuffle Deck

```gherkin
As The Dealer
I want to Shuffle the Deck
So that the card sequence is different for each round

Scenario: Shuffle Deck X Times

Given it is the start if a new round
	And the game is not over
	And a deck of 52 cards
When I shuffle the deck X time (s)
Then the deck is in a different order each time
```

## Feature: Deal Cards

```gherkin
As The Dealer
I want to deal 2 cards to each player
So that the game can proceed

Scenario: Deal Cards

Given it is the start of a new round
	And the game is not over
	And I have shuffled the deck
When I deal the cards 
Then each player should have 2 cards
	And each player has a unique 2 cards

```
## Feature: Rank Hands

```gherkin
As The Dealer
I want to rank each players' hands
So that I can determine the winning hand

Scenario: Round Winner

Given I have dealt each player their cards
When I rank each players hand (according to poker hand rankings)
Then the player with the highest ranked hand is the winner
	And each player is assigned a score from 0 (weakest) to X-1 players (strongest)
```

## Feature: Determine Winner

```gherkin
As The Dealer
I want to determine who the overall winner is
So that the game can end

Scenario: Overall Winner

Given all rounds have been played
When I determine who the overall winner
	And players are ordered from highest score to lowest score
Then it is known who the winner is
	And each player knows what place they finished at

```



