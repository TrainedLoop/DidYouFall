using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository
{
    public class Driver
    {
        public Driver() { }
        public virtual int Id { get; set; }
        public virtual string Label { get; set; }
        public virtual long FreeSpace { get; set; }
        public virtual long TotalSpace { get; set; }
        public virtual string Volume { get; set; }
        public virtual bool Status { get; set; }
        public virtual string Format { get; set; }
        public virtual bool Monitoring { get; set; }
        public virtual AgentInfo AgentInfo { get; set; }
    }
}