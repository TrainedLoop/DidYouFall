using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository
{
    public class ServerLog
    {
        public ServerLog() { }
        public virtual int Id { get; set; }
        public virtual Server Server { get; set; }
        public virtual DateTime? DownAt { get; set; }
        public virtual DateTime? UpAt { get; set; }
        public virtual bool Closed { get; set; }
        public virtual bool EmailSended { get; set; }



    }
}