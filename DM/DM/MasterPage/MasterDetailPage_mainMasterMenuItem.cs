using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DM.MasterPage
{

    public class MasterDetailPage_mainMasterMenuItem
    {
        public MasterDetailPage_mainMasterMenuItem() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}