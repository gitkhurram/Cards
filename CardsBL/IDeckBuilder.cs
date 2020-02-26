using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CardsBL.CardsDTO;
using CardsBL.Print;

namespace CardsBL
{
    /// <summary>
    /// Deck Builder to create and perform actions on a deck.
    /// </summary>
    public interface IDeckBuilder
    {
        /// <summary>
        /// Creates a new Deck instance with the privided name.
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task<IDeck> CreateNewDeck(string Name);

        /// <summary>
        /// Shuffle the cards in the provided Deck as input
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task<IDeck> ShuffleDeck(IDeck deck);

        /// <summary>
        /// Sort the cards in the provided Deck as input
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task<IDeck> SortDeck(IDeck deck);

        /// <summary>
        /// Pull the cards in the provided Deck as input
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task<ICard> PullCard(IDeck deck);

        /// <summary>
        /// Print the cards in the provided Deck as input
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task PrintDeck(IDeck deck, enmPrinterProviders enmPrinterProviders);

        /// <summary>
        /// Print the summary of the provided Deck as input
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task PrintDeckSummary(IDeck deck, enmPrinterProviders enmPrinterProviders);
    }
}
