using System;
using System.Collections.Generic;

namespace DeckShuffler
{
  class Program
  {
    static void Main(string[] args)
    {
      //assigning variables for suits ranks and the deck
      var suits = new List<string>() { "clubs", "spades", "hearts", "diamonds" };
      var ranks = new List<string>() { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };
      var deck = new List<Card>();
      //creating all the cards
      for (int i = 0; i < suits.Count; i++)
      {
        for (int j = 0; j < ranks.Count; j++)
        {
          var card = new Card();
          card.Rank = ranks[j];
          card.Suit = suits[i];
          deck.Add(card);
        }
      }//shuffling the deck
      for (int i = deck.Count - 1; i >= 1; i--)
      {
        var j = new Random().Next(i);
        var temp = deck[j];
        deck[j] = deck[i];
        deck[i] = temp;
      }



      //saying user choice will be entered by the user
      var UserChoice = "";
      //assigning value to player and dealer total
      var playerTotal = 0;
      var dealerTotal = 0;
      //assigning value to playagain
      var playAgain = true;
      //while user says playagain run all this code below
      while (playAgain)
      {
        //player hand and dealer hand = cards added to the list
        var playerHand = new List<Card>();
        var dealerHand = new List<Card>();
        //reseting the player and dealers hand total at the begining of each game
        playerTotal = 0;
        dealerTotal = 0;
        // showing the player their first card 
        Console.WriteLine($"Your first card is {deck[0].DisplayCard()} has a value of {deck[0].GetCardValue()}");
        // adding the first card in players hand
        playerHand.Add(deck[0]);
        // removing the card from the deck
        deck.RemoveAt(0);
        //asking user to hit enter to see their next card
        Console.WriteLine("hit 'enter' for your next card'");
        //allowing user to press enter to see next card
        Console.ReadLine().ToLower();
        //showing user their second card
        Console.WriteLine($"your second card is {deck[0].DisplayCard()} has a value of {deck[0].GetCardValue()}");
        //adding card to player hand
        playerHand.Add(deck[0]);
        //showing player how many card they have
        Console.WriteLine($"The player has {playerHand.Count} cards");
        //removing card from deck
        deck.RemoveAt(0);
        //loop for adding up the two cards
        //have to put for loop right before you need it use, cant put at top
        for (int i = playerHand.Count - 1; i >= 0; i--)
        {
          playerTotal += playerHand[i].GetCardValue();
        }
        Console.WriteLine($"the current total is {playerTotal}");
        //setting if statement for if player gets 21 with the first 2 cards
        if (playerTotal == 21)
        {
          Console.WriteLine("you win");
        }
        //telling program what to do if player doesnt get 21 with first 2 cards
        else
        {
          //dealer get dealt 2 cards
          Console.WriteLine("the dealer has been dealt two cards");
          //adding 2 cards to the dealers and removing them from the deck
          dealerHand.Add(deck[0]);
          deck.RemoveAt(0);
          dealerHand.Add(deck[0]);
          deck.RemoveAt(0);
          //asking the user if they would like to hit
          Console.WriteLine("would you like to hit 'y' or 'n'");
          UserChoice = Console.ReadLine().ToLower();
          //while loop for if player chooses to hit and their hand isnt 21
          while (UserChoice == "y" && playerTotal < 21)

          {
            playerHand.Add(deck[0]);
            dealerHand.RemoveAt(0);
            playerTotal = 0;
            for (int i = playerHand.Count - 1; i >= 0; i--)
            {
              playerTotal += playerHand[i].GetCardValue();
            }
            Console.WriteLine($"your card is {deck[0].DisplayCard()} has a value of {deck[0].GetCardValue()}");
            Console.WriteLine($"your new total is {playerTotal}");
          }
          //if statement for if players busts
          if (playerTotal > 21)
          {
            Console.WriteLine("player bust, dealer wins");
          }
          //loop for dealers turn 
          else if (playerTotal <= 21)
          {

            for (int i = dealerHand.Count - 1; i >= 0; i--)
            {
              dealerTotal += dealerHand[i].GetCardValue();
              Console.WriteLine($"the dealer has {dealerHand[i].DisplayCard()} has a value of {dealerHand[i].GetCardValue()}");
              Console.WriteLine($"dealer has a total of {dealerTotal}");
            }
            //loop for making dealer hit until their total is at least 17
            while (dealerTotal < 17)
            {
              dealerHand.Add(deck[0]);
              deck.RemoveAt(0);
              dealerTotal = 0;
              for (int i = dealerHand.Count - 1; i >= 0; i--)
              {
                dealerTotal += dealerHand[i].GetCardValue();
              }
            }
            for (int i = dealerHand.Count - 1; i >= 0; i--)
            {
              Console.WriteLine($"the dealer has {dealerHand[i].DisplayCard()} has a value of {dealerHand[i].GetCardValue()}");
            }
            Console.WriteLine($"dealer has a total of {dealerTotal}");
          }
          if (dealerTotal == playerTotal)
          {
            Console.WriteLine("push");
          }
          if (dealerTotal > playerTotal && dealerTotal < 22)
          {
            Console.WriteLine("dealer wins");
          }
          if (playerTotal > dealerTotal && playerTotal < 22)
          {
            Console.WriteLine("player wins");
          }
          if (dealerTotal > 21)
          {
            Console.WriteLine("dealer bust, player wins");
          }
        }
        Console.WriteLine("play again 'y' , 'n'?");
        UserChoice = Console.ReadLine().ToLower();
        //while statement for if player input doesnot = 'y' or 'n' 
        while (UserChoice != "y" && UserChoice != "n")
        {
          Console.WriteLine("please enter 'y' or 'n");
          UserChoice = Console.ReadLine().ToLower();
        }
        //if statement for if player wants to stop playing
        if (UserChoice == "n")
        {
          playAgain = false;
        }

      }











    }
  }
}








