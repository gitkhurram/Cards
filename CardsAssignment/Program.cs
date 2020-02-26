using CardsBL;
using CardsBL.CardsDTO;
using CardsBL.Print;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CardsAssignment
{
    class Program
    {
        async static Task Main(string[] args)
        {
            IDeckBuilder builder = new CardDeckBuilder();
            List<IDeck> lstDecks = new List<IDeck>();
            
            do
            {
                Console.Write("Action or ? >> ");
                char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                Console.WriteLine();
                switch(input)
                {
                    case 'N': //Add new deck in the list
                        Console.Write("Provide Deck Name: ");
                        lstDecks.Add(await builder.CreateNewDeck(Console.ReadLine()));
                        break;
                    case 'L': //List all decks by namaes and total cards in them
                        var listDeckQuery = from deck in lstDecks select builder.PrintDeckSummary(deck, enmPrinterProviders.Console);
                        await Task.WhenAll(listDeckQuery.ToArray());
                        break;
                    case 'S': //Shuffle all decks
                        var listShuffleDeckQuery = from deck in lstDecks select builder.ShuffleDeck(deck);
                        await Task.WhenAll(listShuffleDeckQuery.ToArray());
                        break;
                    case 'T': //Sort all decks
                        var listSortDeckQuery = from deck in lstDecks select builder.SortDeck(deck);
                        await Task.WhenAll(listSortDeckQuery.ToArray());
                        break;
                    case 'P'://Pull a card from each deck at random
                        var listPullCardQuery = from deck in lstDecks select builder.PullCard(deck);
                        ICard[] cards = await Task.WhenAll(listPullCardQuery.ToArray());
                        foreach(ICard c in cards)
                            Console.WriteLine($"{c.Group}-{c.Value}");
                        break;
                    case 'A': //Print all decks in the list
                        var listPrintDeckQuery = from deck in lstDecks select builder.PrintDeck(deck, enmPrinterProviders.Console);
                        await Task.WhenAll(listPrintDeckQuery.ToArray());
                        break;
                    case 'X':
                        return;
                    case '?':
                        Console.WriteLine("N - Create and Add New Deck in the List.");
                        Console.WriteLine("L - Summary of all Decks in the List.");
                        Console.WriteLine("S - Shuffle all Decks in the List.");
                        Console.WriteLine("T - Sort all Decks in the List.");
                        Console.WriteLine("P - Pull a Card from each Deck in the List at random.");
                        Console.WriteLine("A - Print all Decks in the List.");
                        break;
                    default:
                        break;
                }
            } while (true);

        } //Main
    }
}
