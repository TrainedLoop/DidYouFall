using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Repository
{
    [ActiveRecord(Schema = "didyoufall")]
    public class User : ActiveRecordLinqBase<User>
    {
        [PrimaryKey(PrimaryKeyType.Native, "Id")]
        public int Id { get; set; }

        [Property(Column = "Email")]
        public string Email { get; set; }

        [Property(Column = "Password")]
        public string Password { get; set; }

        [Property(Column = "Name")]
        public string Name { get; set; }

        [Property(Column = "CPF")]
        public string CPF { get; set; }

        [Property(Column = "Credits")]
        public double Credits { get; set; }
    }
}