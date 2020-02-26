using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardsBL.Print
{
    /// <summary>
    /// Interface for all printer types to print Deck
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Prints the Deck
        /// </summary>
        /// <returns></returns>
        public Task<int> Print();

        /// <summary>
        /// Prints the summary of the Deck
        /// </summary>
        /// <returns></returns>
        public Task PrintSummary();
    }
}
