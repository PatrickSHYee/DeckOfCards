using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            List<Card> hand = deck.Deal(5);
            deck.Discard(hand);
        }
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
	//     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
	//     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
	//     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
	//         discard pile	
    // 
    // A deck knows the following information about itself:
	//     int CardsRemaining -- number of cards left in the deck
	//     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played
    class Deck
    {
        private List<Card> _deckOfCards;
        public List<Card> DeckOfCards { get; set; }
        private List<Card> _discardedCards = new List<Card>();
        public List<Card> DiscardedCards { get; set; }
        // a deck has 52 cards of each of suits with ranks
        public Deck()
        {
            DeckOfCards = new List<Card>();
            DiscardedCards = new List<Card>();;
            for (int r = 2; r <= 14; r++)
            {
                for (int s = 1; s <= 4; s++)
                {
                    DeckOfCards.Add(new Card((Suit)s, (Rank)r));
                }
            }
        }

        public Deck(int howMany)
        {
            for (int i = 0; i < howMany; i++)
            {
                new Deck();
            }
        }

        public List<Card> Deal(int numOfCards)
        {
            List<Card> BigHand = new List<Card>();
            for (int c = 0; c < numOfCards; c++)
            {
                BigHand.Add(DeckOfCards[0]);
                DeckOfCards.RemoveAt(0);
            }
            return BigHand;
        }

        public void Discard(List<Card> hand)
        {
            while (hand.Count > 0)
            {
                DiscardedCards.Add(hand[0]);
                hand.RemoveAt(0);
            }
        }

        public void Shuffle()
        {
            List<Card> newDeckOfCards = new List<Card>();
            Random shuffler = new Random();
            // put the cards back to the DeckOfCards from the Discard piles
            if (DiscardedCards.Count == 0)
            {
                while (DiscardedCards.Count > 0)
                {
                    DeckOfCards.Add(DiscardedCards[0]);
                    DiscardedCards.RemoveAt(0);
                }
            }
            while (DeckOfCards.Count > 0)
            {
                Card getCard = DeckOfCards[shuffler.Next(1, DeckOfCards.Count)-1];
                newDeckOfCards.Add(getCard);
                DeckOfCards.Remove(getCard);
            }
            DeckOfCards = newDeckOfCards;
        }
    }

    /// <summary>
    /// the suits for the cards to have
    /// </summary>
    public enum Suit
    {
        Hearts = 1,
        Diamonds, Clubs, Spades
    }

    public enum Rank
    {
        Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }
    // What makes a card?
	//     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    class Card
    {
        private Suit _theSuit;
        public Suit TheSuit { get; set; }
        private Rank _ranked;
        public Rank Ranked { get; set; }

        public Card(Suit suit, Rank rank)
        {
            this.TheSuit = suit;
            this.Ranked = rank;
        }

    }
}
