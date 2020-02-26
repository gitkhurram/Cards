using CardsBL.CardsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardsBL.Print
{
    internal class ConsolePrintProvider : IPrintFactory
    {
        public async Task<IPrinter> CreatePrintProvider(IDeck deck)
        {
            return new DeckConsolePrinter(deck);
        }  
    }
}
