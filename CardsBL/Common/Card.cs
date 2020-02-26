using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CardsBL.CardsDTO
{
    /// <summary>
    /// Public interface to present a Card
    /// </summary>
    public interface ICard : IComparable<ICard>, ICloneable
    {
        /// <summary>
        /// Group name of the Card from Common.enmCardGroup
        /// </summary>
        public Common.enmCardGroup Group { get; set; }

        /// <summary>
        /// Value of the Card from Common.enmCardGroup
        /// </summary>
        public Common.enmCardValue Value { get; set; }
    }

    /// <summary>
    /// Class represents a Card. It has a Group of type enmCardGroup and Value of type enmCardValue
    /// </summary>
    public class Card : ICard
    {
        public Common.enmCardGroup Group { get; set; }
        public Common.enmCardValue Value { get; set; }

        public Card(Common.enmCardGroup group, Common.enmCardValue value)
        {
            this.Group = group;
            this.Value = value;
        }
        
        public int CompareTo([AllowNull] ICard other)
        {
            if ((int)this.Group == (int)other.Group && (int)this.Value == (int)other.Value)
                return 0;
            else if ((int)this.Group < (int)other.Group)
                return -1;
            else if ((int)this.Group > (int)other.Group)
                return 1;
            else if ((int)this.Value < (int)other.Value)
                return -1;
            else if ((int)this.Value == (int)other.Value)
                return 0;
            else
                return 1;
        }

        public object Clone()
        {
            return new Card(this.Group, this.Value);
        }
    }
}
