using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Helper
{
    class Helper
    {
        public static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
    }
}
