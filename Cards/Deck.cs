using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//колода
namespace Cards
{
    internal class Deck
    {
        public Card[] deck;
        public const int NUMCARDS = 36;
        public int currentCard;
        public Random rand;


        public Deck()
        {

            Char[] suits = { (Char)3, (Char)4, (Char)5, (Char)6 };
            currentCard = 0;
            Dignitys[] dignitys = { (Dignitys)0, (Dignitys)1, (Dignitys)2, (Dignitys)3, (Dignitys)4, (Dignitys)5, (Dignitys)6, (Dignitys)7, (Dignitys)8 };
            deck = new Card[NUMCARDS];

            rand = new Random();
            deck = new Card[NUMCARDS];
            for (int i = 0; i < deck.Length; i++)
                deck[i] = new Card(dignitys[i % 9], suits[i / 10]);
        }

        public void Mix()
        {
            currentCard = 0;
            for (int i = 0; i < deck.Length; i++)
            {
                int one = rand.Next(NUMCARDS);
                (deck[one], deck[i]) = (deck[i], deck[one]);
            }
        }

        public Card DelCard()
        {
            if (currentCard < deck.Length)
                return deck[currentCard++];
            else
                return null;
        }

    }

    public enum Dignitys {
        ШЕСТЕРКА = 0, СЕМЕРКА, ВОСЬМЕРКА, ДЕВЯТКА, ДЕСЯТА, ВАЛЕТ, ДАМА, КОРОЛЬ, ТУЗ };

    class Card
    {

        public  Dignitys Dignity;
        public Char Suit { get; set; }
        public Card(Dignitys dignity, Char suit)
        {

            Dignity = dignity;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"\n\t*******************\n" +
                $"\t*                 *\n" +
                $"\t*     {Dignity}       *\n" +
                $"\t*                 *\n" +
                $"\t*        {Suit}        *\n" +
                "\t*                 *\n" +
                "\t*******************";
        }

    /*public override string ToString()
        {
            return $"{Dignity}  {Suit}";
        }*/

    }
}



