using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS201724112113.Entity
{
    public class EqptEntity
    {
        public int EqptId { set; get; }
        public string EqptName { set; get; }
        public string Specifications { set; get; }
        public string Picture { set; get; }
        public string Price { set; get; }
        public string PurchaseDate { set; get; }
        public string Location { set; get; }
        public string Mgr { set; get; }
        public int Num { set; get; }
    }
}