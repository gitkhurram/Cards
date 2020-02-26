using CardsBL.CardsDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardsBL.Print
{
    /// <summary>
    /// Print provider factory that can print Decks
    /// </summary>
    public interface IPrintFactory
    {
        /// <summary>
        /// Create a printing provider for a provided Deck
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Task&ltIPrinter&gt</returns>
        public Task<IPrinter> CreatePrintProvider(IDeck deck);
    }
}
