//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMS201724112113.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class equipment
    {
        public int eqptId { get; set; }
        public string eqptName { get; set; }
        public string specifications { get; set; }
        public string picture { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public string location { get; set; }
        public Nullable<int> mgrId { get; set; }
        public Nullable<int> num { get; set; }
    
        public virtual employee employee { get; set; }
    }
}
