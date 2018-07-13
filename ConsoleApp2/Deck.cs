using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace ConsoleApp2
{
    public class Deck
    {
        public List<Card> CardsInDeck;

        public Deck()
        {
            //Card KingH = new Card(10,"Heart");
            CardsInDeck = new List<Card>();
            int val;
            //string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] faces = { "Ace", "Ace", "Ace", "Ace", "Ace", "Ace", "Ace", "Ace", "Ace", "Ace", "Ace", "Ace", "Ace" };
            string[] Suit = { "Hearts", "Clubs", "Diamonds", "Spades" };

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i > 9)
                    {
                        val = 10;
                    }
                    else
                    {
                        val = i + 1;
                    }

                    CardsInDeck.Add(new Card(faces[i], Suit[j], val));
                }
            }
        }

        public void shuffleCard(List<Card> nDeck)
        {
            Random r = new Random();
            for (int n = nDeck.Count - 1; n > -1; --n)
            {
                int k = r.Next(0, 52);
                Card temp = nDeck[n];
                nDeck[n] = nDeck[k];
                nDeck[k] = temp;
            }

        }

        public int Hit(List<Card> pDeck, List<Card> playerHand, int playerValue)
        {
            playerHand.Add(pDeck[0]);
            pDeck.RemoveAt(0);
            return playerValue + playerHand[playerHand.Count - 1].value;
        }

        
    }
}
