using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository
{
    public class Service
    {
        public Service() { }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Status { get; set; }
        public virtual bool Monitoring { get; set; }
        public virtual AgentInfo AgentInfo { get; set; }
    }
}