using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository
{
    public class Server
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Host { get; set; }
        public virtual int? Verificationtime { get; set; }
        public virtual string Contactemail { get; set; }
        public virtual bool Emailsent { get; set; }
        public virtual IList<int> Ports { get; set; }
        public virtual User User { get; set; }
    }
}