using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Repository
{
    [ActiveRecord(Schema = "didyoufall")]
    public class Server : ActiveRecordLinqBase<Server>
    {
        [PrimaryKey(PrimaryKeyType.Native, "Id")]
        public int Id { get; set; }

        [Property(Column = "Host")]
        public string Host { get; set; }

        [Property(Column = "VerificationTime")]
        public int VerificationTime { get; set; }

        [Property(Column = "ContactEmail")]
        public string ContactEmail { get; set; }

        [Property(Column = "EmailSent")]
        public bool EmailSent { get; set; }

        [BelongsTo]
        public Users User { get; set; }


    }
}