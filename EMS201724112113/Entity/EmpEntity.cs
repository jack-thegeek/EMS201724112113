using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS201724112113.Entity
{
    public class EmpEntity
    {
        public int EmpId { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string IsMgr { set; get; }
        public string Dept { set; get; }
    }
}