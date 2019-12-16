using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var startingDeck = from s in Suits()
            //                   from r in Ranks()
            //                   select new { Suit = s, Rank = r };
            var startingDeck = Suits().SelectMany(
                suit => Ranks().Select(
                    rank => new { Suit = suit, Rank = rank }));

            // display each card we've generated
            foreach (var card in startingDeck)
            {
                Console.WriteLine(card);
            }

            var shuffledDeck = startingDeck;
            var times = 0;
            do
            {
                // shuffle cards by interleaving top 26 cards with bottom 26 cards
                shuffledDeck = shuffledDeck.Take(26).InterleaveSequenceWith(shuffledDeck.Skip(26));
                times++;

            } while (!startingDeck.SequenceEquals(shuffledDeck));

            Console.WriteLine("Shuffled!");
            Console.WriteLine(times);
        }

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }




    }
}
