using System;
using System.Collections;

namespace DM.ID_handler
{
    public sealed class BitArrayConverter
    {
        private BitArrayConverter() { }

        public BitArray ReverseBitArray(BitArray bitArray)
        {
            BitArray reversed = new BitArray(32);
            for (int i = 0; i < 32; i++)
            {
                reversed[reversed.Length - 1 - i] = bitArray[i];
            }

            return reversed;
        }
        public String ConvertToInt(BitArray bitArray)
        {
            String s = "";
            for (int i = 0; i < bitArray.Length; i++)
            {
                s += (bitArray[i].ToString().Equals("True") ? 1 : 0);
            }
            uint tmp_int = Convert.ToUInt32(s, 2);
            s = tmp_int.ToString();
            return s;
        }
        public static BitArrayConverter Instance { get { return NestedBitArrayConverter.instance; } }
        private class NestedBitArrayConverter
        {
            static NestedBitArrayConverter()
            {
            }

            internal static readonly BitArrayConverter instance = new BitArrayConverter();
        }
    }
}
