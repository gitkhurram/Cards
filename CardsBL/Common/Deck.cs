using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace CardsBL.CardsDTO
{
    /// <summary>
    /// Deck representation interface
    /// </summary>
    public interface IDeck : IAsyncEnumerable<ICard>, 
                             IEquatable<IDeck>, 
                             IEnumerable<ICard>, 
                             ICloneable
    {
        /// <summary>
        /// Get Deck name
        /// </summary>
        public string DeckName { get; }

        /// <summary>
        /// Get total cards in the Deck
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Shuffles cards in the Deck
        /// </summary>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task<IDeck> Shuffle();

        /// <summary>
        /// Sort cards in the Deck
        /// </summary>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task<IDeck> Sort();

        /// <summary>
        /// Pull a card in the Deck at random
        /// </summary>
        /// <returns>Task&lt;IDeck&gt;</returns>
        public Task<ICard> PullCard();
    }

    /// <summary>
    /// Represents Deck of 52 Cards
    /// </summary>
    public class Deck : IDeck
    {   
        List<ICard> _lstCards = new List<ICard>();
        public string DeckName { get; }

        public int Count => this._lstCards.Count;       

        public Deck(string Name)
        {
            this.DeckName = Name;
            CreateDefaultDeck();
        }

        public Deck(string Name, List<ICard> lstCards)
        {
            this.DeckName = Name;
            this._lstCards = lstCards;
        }
        public async void CreateDefaultDeck()
        {
            int i = 0;
            await foreach (Common.enmCardGroup grp in Common.GetCardGroups())
            {
                await foreach (Common.enmCardValue val in Common.GetCardValues())
                {
                    _lstCards.Add(new Card(grp, val));
                    ++i;
                }
            }
        }

        public async Task<IDeck> Shuffle()
        {   
            Random random = new Random();

            for (int i = 0; i < _lstCards.Count(); i++)            
                Swap(random.Next(_lstCards.Count), random.Next(_lstCards.Count));

            return this;
        }

        public async Task<IDeck> Sort()
        {
            this._lstCards.Sort();            
            return this;
        }

        private void Swap(int index1, int index2)
        {
            ICard c = _lstCards[index1];
            
            _lstCards[index1] = _lstCards[index2];
            _lstCards[index2] = c;
        }

        public async IAsyncEnumerator<ICard> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            foreach (Card c in _lstCards)
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;

                yield return c;
            }
        }

        public async Task<ICard> PullCard()
        {
            //int index = new Random().Next(_lstCards.Count() - 1);

            if (this._lstCards?.Count() > 0)
            {
                ICard c = this._lstCards[0];
                this._lstCards.RemoveAt(0);
                return c;
            }

            return null;
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return this._lstCards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            var lstcards = from cards in this._lstCards select (ICard)cards.Clone();            
            IDeck deck = new Deck(this.DeckName, lstcards.ToList());
            return deck;
        }

        public bool Equals([AllowNull] IDeck other)
        {
            List<ICard> OtherCards = (from c in other select c).ToList<ICard>();
            for (int i = 0; i < OtherCards.Count; i++)
            {
                if (this._lstCards[i].CompareTo(OtherCards[i]) != 0)
                    return false;
            }

            return true;
        }
    }
}
