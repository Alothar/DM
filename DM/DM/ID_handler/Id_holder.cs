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

        public String Steam_32_id
        {
            get { return steam_32_id; }
            set
            {
                BitArrayConverter converter = BitArrayConverter.Instance;
                Decimal temp = Convert.ToDecimal(value);
                BitArray tmp_bits = new BitArray(Decimal.GetBits(temp));
                tmp_bits = converter.ReverseBitArray(tmp_bits);
                steam_32_id = converter.ConvertToInt(tmp_bits);
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
