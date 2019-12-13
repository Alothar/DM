using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DM.ID_handler
{
    public sealed class Id_holder
    {
        private Id_holder() { }
        public string Steam32id { get; set; }

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
