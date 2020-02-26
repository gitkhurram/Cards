using CardsBL.CardsDTO;
using CardsBL.Print;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardsBL
{
    /// <summary>
    /// CardDeck Builder
    /// </summary>
    public class CardDeckBuilder : IDeckBuilder
    {
        public async Task<IDeck> CreateNewDeck(string Name)
        {
            return new Deck(Name);
        }

        public async Task PrintDeck(IDeck deck, enmPrinterProviders enmPrinterProviders)
        {   
            switch (enmPrinterProviders)
            {
                case enmPrinterProviders.Console:
                    IPrintFactory printProvider = new ConsolePrintProvider();
                    IPrinter printer = await printProvider.CreatePrintProvider(deck);
                    await printer.Print();
                    break;
            }
        }

        public async Task PrintDeckSummary(IDeck deck, enmPrinterProviders enmPrinterProviders)
        {
            switch (enmPrinterProviders)
            {
                case enmPrinterProviders.Console:
                    IPrintFactory printProvider = new ConsolePrintProvider();
                    IPrinter printer = await printProvider.CreatePrintProvider(deck);
                    await printer.PrintSummary();
                    break;
            }
        }

        public async Task<ICard> PullCard(IDeck deck)
        {
            return await deck.PullCard();
        }

        public async Task<IDeck> ShuffleDeck(IDeck deck)
        {
            return await deck.Shuffle();
        }

        public async Task<IDeck> SortDeck(IDeck deck)
        {
            return await deck.Sort();
        }
    }
}
