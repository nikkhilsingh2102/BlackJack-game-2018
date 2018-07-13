using System;
using ConsoleApp1;
using ConsoleApp2;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            List<Card> playerCards = new List<Card>();
            List<Card> dealerCards = new List<Card>();
            List<Card> splitCard = new List<Card>();
            int playerValue;
            int dealerValue;
            string Action;
            string splitAction;
            string ContinueAction;
            playerValue = 0;
            int splitHandValue = 0;
            dealerValue = 0;

            deck.shuffleCard(deck.CardsInDeck);

            DealInitialHands(deck, playerCards, dealerCards, ref playerValue, ref dealerValue);

            while (dealerValue < 16)
            {
                dealerValue = deck.Hit(deck.CardsInDeck, dealerCards, dealerValue);
            }
            //Console.WriteLine($"{ dealerValue}");

            if (playerCards[0].face == playerCards[1].face)
            {
                Console.WriteLine($" Your cards: :{playerCards[0].face} of {playerCards[0].suit} and {playerCards[1].face} of {playerCards[1].suit}, Click X to split, or click C to continue");
                splitAction = Console.ReadLine();
                if (splitAction == "x" || splitAction == "X")
                {
                    splitCard.Add(playerCards[1]);
                    playerValue = playerValue - playerCards[1].value;
                    playerCards.RemoveAt(1);

                    playerValue = deck.Hit(deck.CardsInDeck, playerCards, playerValue);
                    splitHandValue = deck.Hit(deck.CardsInDeck, splitCard, splitHandValue);

                    Console.WriteLine($"your score is: ,{playerValue}, h to hit, \ns to stand, your cards:{playerCards[0].face} of {playerCards[0].suit} and {playerCards[1].face} of {playerCards[1].suit} ");
                    int j = 2;
                    while (playerValue < 21)
                    {


                        Action = Console.ReadLine();
                        if (playerValue < 21 && Action == "h" || Action == "H")
                        {


                            playerValue = deck.Hit(deck.CardsInDeck, playerCards, playerValue);
                            Console.WriteLine($"your score is: ,{playerValue}, your {j + 1}{Card.endingTerm(j + 1)} card is a:{playerCards[j].face} of {playerCards[j].suit} ");
                        }
                        else
                        {

                            if (Action == "S" || Action == "s")
                            {
                                break;
                            }
                        }
                        j = j + 1;
                    }
                    Console.WriteLine("2nd hand");
                    Console.WriteLine($"your score is: ,{splitHandValue},h to hit, \ns to stand, your cards:{splitCard[0].face} of {splitCard[0].suit} and {splitCard[1].face} of {splitCard[1].suit}");
                    int k = 2;
                    while (splitHandValue < 21)
                    {
                        Action = Console.ReadLine();
                        if (splitHandValue < 21 && Action == "h" || Action == "H")
                        {
                            splitHandValue = deck.Hit(deck.CardsInDeck, splitCard, splitHandValue);
                            Console.WriteLine($"your score is: ,{splitHandValue}, your {k + 1}{Card.endingTerm(k + 1)} card is a:{splitCard[k].face} of {splitCard[k].suit} ");
                        }
                        else
                        {
                            if (Action == "S" || Action == "s")
                            {
                                break;
                            }
                        }
                    }


                    if (playerValue < 22 && splitHandValue < 22 && playerValue > dealerValue || splitHandValue > dealerValue && dealerValue < 22)
                    {
                        Console.WriteLine("winner winner chicken dinner!");
                        Console.WriteLine($"dealer score is: ,{dealerValue}");
                        Console.ReadLine();
                    }
                    else
                    {
                        if (playerValue < dealerValue && splitHandValue < dealerValue && playerValue < 22 && splitHandValue < 22 && dealerValue < 22)
                        {
                            Console.WriteLine("you must be new...you lose!!!");
                            Console.WriteLine($"dealer score is: ,{dealerValue}");
                            Console.ReadLine();

                        }
                        else
                        {
                            if (playerValue > 21 && splitHandValue > 21)
                            {
                                Console.WriteLine("oops you are bust, you lose");
                                Console.WriteLine($"dealer score is: ,{dealerValue}");
                                Console.ReadLine();
                            }
                            else
                            {
                                if (dealerValue == splitHandValue || dealerValue == playerValue && dealerValue < 22 && playerValue < 22 && splitHandValue < 22)
                                {
                                    Console.WriteLine("you guys are artists because you drew!!");
                                    Console.WriteLine($"dealer score is: ,{dealerValue}");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    if (playerValue < 22 && splitHandValue < 22 && dealerValue > 21)
                                    {
                                        Console.WriteLine("winner winner chicken dinner!");
                                        Console.WriteLine($"dealer score is: ,{dealerValue}");
                                        Console.ReadLine();

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (splitAction == "C" || splitAction == "c")
                    {
                        Console.WriteLine($"your score is: ,{playerValue}, h to hit, \ns to stand, your cards:{playerCards[0].face} of {playerCards[0].suit} and {playerCards[1].face} of {playerCards[1].suit} ");
                        int i = 2;
                        while (playerValue < 21)
                        {



                            Action = Console.ReadLine();
                            if (playerValue < 21 && Action == "h" || Action == "H")
                            {



                                playerValue = deck.Hit(deck.CardsInDeck, playerCards, playerValue);
                                Console.WriteLine($"your score is: ,{playerValue}, your {i + 1}{Card.endingTerm(i + 1)} card is a:{playerCards[i].face} of {playerCards[i].suit} ");
                            }
                            else
                            {


                                if (Action == "S" || Action == "s")
                                {

                                    break;
                                }
                            }

                            i = i + 1;

                        }



                        if (playerValue > dealerValue && playerValue < 22)
                        {


                            Console.WriteLine("winner winner chicken dinner!");
                            Console.WriteLine($"dealer score is: ,{dealerValue}");
                            Console.ReadLine();
                        }

                        else
                        {



                            if (playerValue == dealerValue && playerValue < 22 && dealerValue < 22)
                            {



                                Console.WriteLine("you guys are artists because you drew!!");
                                Console.WriteLine($"dealer score is: ,{dealerValue}");
                                Console.ReadLine();
                            }
                            else
                            {



                                if (playerValue > 21)
                                {



                                    Console.WriteLine("oops you are bust, you lose");
                                    Console.WriteLine($"dealer score is: ,{dealerValue}");
                                    Console.ReadLine();
                                }
                                else
                                {


                                    if (playerValue > 21 && dealerValue > 21)
                                    {

                                        Console.WriteLine("you must be new...you lose!!!");
                                        Console.WriteLine($"dealer score is: ,{dealerValue}");
                                        Console.ReadLine();
                                    }

                                    if (playerValue < dealerValue && playerValue < 21 && dealerValue < 21)
                                    {

                                        Console.WriteLine("you must be new...you lose!!!");
                                        Console.WriteLine($"dealer score is: ,{dealerValue}");
                                        Console.ReadLine();

                                    }

                                    if (playerValue < 22 && dealerValue > 21)
                                    {
                                        Console.WriteLine("winner winner chicken dinner!");
                                        Console.WriteLine($"dealer score is: ,{dealerValue}");
                                        Console.ReadLine();
                                    }



                                }
                            }
                        }
                    }
                }


            }
            else
            {





                Console.WriteLine($"your score is: ,{playerValue}, h to hit, \ns to stand, your cards:{playerCards[0].face} of {playerCards[0].suit} and {playerCards[1].face} of {playerCards[1].suit} ");
                int i = 2;
                while (playerValue < 21)
                {



                    Action = Console.ReadLine();
                    if (playerValue < 21 && Action == "h" || Action == "H")
                    {



                        playerValue = deck.Hit(deck.CardsInDeck, playerCards, playerValue);
                        Console.WriteLine($"your score is: ,{playerValue}, your {i + 1}{Card.endingTerm(i + 1)} card is a:{playerCards[i].face} of {playerCards[i].suit} ");
                    }
                    else
                    {


                        if (Action == "S" || Action == "s")
                        {

                            break;
                        }
                    }

                    i = i + 1;

                }



                if (playerValue > dealerValue && playerValue < 22)
                {


                    Console.WriteLine("winner winner chicken dinner!");
                    Console.WriteLine($"dealer score is: ,{dealerValue}");
                    Console.ReadLine();
                }

                else
                {



                    if (playerValue == dealerValue && playerValue < 22 && dealerValue < 22)
                    {



                        Console.WriteLine("you guys are artists because you drew!!");
                        Console.WriteLine($"dealer score is: ,{dealerValue}");
                        Console.ReadLine();
                    }
                    else
                    {



                        if (playerValue > 21)
                        {



                            Console.WriteLine("oops you are bust, you lose");
                            Console.WriteLine($"dealer score is: ,{dealerValue}");
                            Console.ReadLine();
                        }
                        else
                        {


                            if (playerValue > 21 && dealerValue > 21)
                            {

                                Console.WriteLine("you must be new...you lose!!!");
                                Console.WriteLine($"dealer score is: ,{dealerValue}");
                                Console.ReadLine();
                            }

                            if (playerValue < dealerValue && playerValue < 21 && dealerValue < 21)
                            {

                                Console.WriteLine("you must be new...you lose!!!");
                                Console.WriteLine($"dealer score is: ,{dealerValue}");
                                Console.ReadLine();

                            }

                            if (playerValue < 22 && dealerValue > 21)
                            {
                                Console.WriteLine("winner winner chicken dinner!");
                                Console.WriteLine($"dealer score is: ,{dealerValue}");
                                Console.ReadLine();
                            }



                        }
                    }
                }
            }

        }

        private static void DealInitialHands(Deck deck, List<Card> playerCards, List<Card> dealerCards, ref int playerValue, ref int dealerValue)
        {
            for (int c = 0; c < 2; c++)
            {
                playerValue = deck.Hit(deck.CardsInDeck, playerCards, playerValue);
                dealerValue = deck.Hit(deck.CardsInDeck, dealerCards, dealerValue);
            }
        }

        private static void getAction()

    }


}

