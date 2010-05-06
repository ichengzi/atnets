/*
 * Created by SharpDevelop.
 * User: eric
 * Date: 2010/5/4
 * Time: 19:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ATNET.Project
{
	/// <summary>
	/// Description of ItemType.
	/// </summary>
    public struct ItemType : IEquatable<ItemType>, IComparable<ItemType>
    {
        readonly string itemName;

        public string ItemName
        {
            get { return itemName; }
        }

        public static readonly ItemType Zone = new ItemType("Zone");
        public static readonly ItemType Building = new ItemType("Building");
        public static readonly ItemType Floor = new ItemType("Floor");
        public static readonly ItemType Room = new ItemType("Room");

        public ItemType(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("itemName");
            }
            this.itemName = name;
        }

        public override string ToString()
        {
            return itemName;
        }

        public int CompareTo(ItemType other)
        {
            return itemName.CompareTo(other);
        }

        #region Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<ItemType>" declaration.

        public override bool Equals(object obj)
        {
            if (obj is ItemType)
                return Equals((ItemType)obj); // use Equals method below
            else
                return false;
        }

        public bool Equals(ItemType other)
        {
            // add comparisions for all members here
            return this.itemName == other.itemName;
        }

        public override int GetHashCode()
        {
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return itemName.GetHashCode();
        }

        public static bool operator ==(ItemType left, ItemType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ItemType left, ItemType right)
        {
            return !left.Equals(right);
        }
        #endregion
    }
}
