using CardsBL.CardsDTO;
using System;
using Xunit;
using System.Linq;
using Moq;

namespace UnitTestCardAssignment
{
    public class DeckTest : IDisposable
    {   

        [Fact]
        public void TestDeckName()
        {
            IDeck deck = new Deck("test-deck");
            Assert.Equal("test-deck", deck.DeckName);
        }

        [Fact]
        public void TestDeckDefaultCount()
        {
            IDeck deck = new Deck("test-deck");
            Assert.Equal(52, deck.Count);
        }

        [Fact]
        public async void TestDeckShuffle()
        {
            IDeck deck1 = new Deck("test-deck1");
            IDeck deck2 = (IDeck) deck1.Clone();
            Assert.True(deck1.Equals(deck2));

            await deck1.Shuffle();
            Assert.False(deck1.Equals(deck2));
        }

        [Fact]
        public async void TestPullDeckCardCount()
        {
            IDeck deck1 = new Deck("test-deck");
            int count = deck1.Count;
            await deck1.PullCard();
            Assert.Equal(count-1,  deck1.Count);            
        }

        public void Dispose()
        {
        }
    }
}
