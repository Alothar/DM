using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DM.ID_handler
{
    public sealed class Id_holder
    {
        private Id_holder() { }

        private String steam_32_id;

        private string steam32id;

        public string Steam32id 
        {
            get 
            {
                if (steam_32_id != null)
                    steam32id = steam_32_id;
                return steam32id; 
            }
            set 
            {
                if (steam_32_id != null)
                    steam32id = steam_32_id;
                else
                    steam32id = value;
            }
        }

        public String Steam_32_id
        {
            get 
            {
                if (steam32id != null)
                    steam_32_id = steam32id;
                return steam_32_id; 
            }
            set
            {
                if (steam32id != null)
                    steam_32_id = steam32id;
                else
                {
                    BitArrayConverter converter = BitArrayConverter.Instance;
                    Decimal temp = Convert.ToDecimal(value);
                    BitArray tmp_bits = new BitArray(Decimal.GetBits(temp));
                    tmp_bits = converter.ReverseBitArray(tmp_bits);
                    steam_32_id = converter.ConvertToInt(tmp_bits);
                }
            }
        }

        public static Id_holder Instance { get { return NestedId_holder.instance; } }
        private class NestedId_holder
        {
            static NestedId_holder()
            {
            }

            internal static readonly Id_holder instance = new Id_holder();
        }
    }
}
