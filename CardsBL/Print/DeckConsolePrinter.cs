using CardsBL.CardsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardsBL.Print
{
    internal class DeckConsolePrinter : IPrinter
    {
        IDeck deck;
        public DeckConsolePrinter(IDeck deck)
        {
            this.deck = deck;
        }

        public async Task<int> Print()
        {
            await PrintSummary();

            await foreach (ICard card in deck)
                Console.WriteLine($"{card.Group} - {card.Value}");            

            return 0;
        }

        public async Task PrintSummary()
        {
            Console.WriteLine($"Cards in the Deck >> {deck.DeckName}");
            Console.WriteLine($"Total Cards >> {deck.Count}");
        }
    }
}
