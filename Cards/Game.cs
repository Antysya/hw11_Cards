using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Cards
{
    internal class Game
    {
        public List<Card> carddeck;
        public List<Player> players;
        Random rand = new Random();
        public int numPlayers;
        

        public Game()
        {
            try
                {
                    Write("Введите количество игроков: ");
                    numPlayers = int.Parse(ReadLine());
                    if (numPlayers > 6 || numPlayers < 2)
                        throw new Exception("Количество игроков не может быть меньше 2 и больше 6.");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    Write("Введите количество игроков: ");
                    numPlayers = int.Parse(ReadLine());
                }
            players = new List<Player>();
            for (int i = 0; i < numPlayers; i++)
            {
                players.Add(new Player());
            }
            Deck deck = new Deck();
            deck.Mix();
            
            carddeck = new List<Card>();
            for (int i = 0; i < 36; i++)
            {
                carddeck.Add(deck.DelCard());
            }

            dealCardsToPlayers(players, carddeck);
        }

        public void dealCardsToPlayers(List<Player> players, List<Card> deck)
        {
            int currentPlayer = 0;

            for (int i = 0; i < deck.Count; i++)
            {
                players[currentPlayer].cardsL.Add(deck[i]);

                currentPlayer++;
                currentPlayer %= players.Count;
            }
        }

        public bool playersTurn()
        {
            
            WriteLine("Ход игроков:");
            
            int maxValue = -1;
            Player playerWithMaxValue = null;
            Queue<Card> cardQueue = new Queue<Card>();

            for (int i = 0; i < players.Count; i++)
            {
                
                Player player = players[i];                
                if (player.cardsL.Count > 0)
                {

                    Card card = player.cardsL[rand.Next(player.cardsL.Count)]; 

                    WriteLine($"{i} Игрок"+
                            $" {card}");
                    player.cardsL.Remove(card);

                    if ((int)card.Dignity > maxValue)
                    {
                        maxValue = (int)card.Dignity;
                        playerWithMaxValue = player;
                    }

                   cardQueue.Enqueue(card);
                   
                }
            }
            playerWithMaxValue.cardsL.AddRange(cardQueue);
            WriteLine($"Забрал игрок {players.IndexOf(playerWithMaxValue)}.");
            
            if (playerWithMaxValue.cardsL.Count == 36)
            {
                WriteLine($"Победил игрок {players.IndexOf(playerWithMaxValue)}");
                return false;
            }
            Thread.Sleep(5000);
            Clear();
            return true;
            
        }
    }
}

