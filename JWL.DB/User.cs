//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JWL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Goods = new HashSet<Good>();
            this.Lorries = new HashSet<Lorry>();
        }
    
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public Nullable<bool> Sex { get; set; }
        public Nullable<bool> Head { get; set; }
        public Nullable<int> Points { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string IDCardNo { get; set; }
        public string IDCardPic { get; set; }
        public string DrivingLicensePic { get; set; }
        public Nullable<System.DateTime> AllowTime { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        public Nullable<bool> IsDriver { get; set; }
        public Nullable<bool> IsDel { get; set; }
    
        public virtual ICollection<Good> Goods { get; set; }
        public virtual ICollection<Lorry> Lorries { get; set; }
    }
}
