using System;
using System.Collections.Generic;

namespace CardsBL.CardsDTO
{
    public static class Common
    { 
        public enum enmCardGroup
        { 
            Diamond = 0,
            Club = 1,
            Spade = 2,
            Heart = 3
        }

        public enum enmCardValue
        {   
            Ace = 0,
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,            
            Jack = 10,
            Queen = 11,
            King = 12
        }

        public static async IAsyncEnumerable<enmCardGroup> GetCardGroups()
        {   
            yield return enmCardGroup.Diamond;
            yield return enmCardGroup.Club;
            yield return enmCardGroup.Spade;
            yield return enmCardGroup.Heart;
        }

        public static async IAsyncEnumerable<enmCardValue> GetCardValues()
        {
            yield return enmCardValue.Ace;
            yield return enmCardValue.Two;
            yield return enmCardValue.Three;
            yield return enmCardValue.Four;
            yield return enmCardValue.Five;
            yield return enmCardValue.Six;
            yield return enmCardValue.Seven;
            yield return enmCardValue.Eight;
            yield return enmCardValue.Nine;
            yield return enmCardValue.Ten;            
            yield return enmCardValue.Jack;
            yield return enmCardValue.Queen;
            yield return enmCardValue.King;
        }
    }    

}
