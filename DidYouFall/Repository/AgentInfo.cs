using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository
{
    public class AgentInfo
    {
        public AgentInfo() { }
        public virtual int Id { get; set; }
        public virtual string ComputarName { get; set; }
        public virtual string CpuUsage { get; set; }
        public virtual long PhysicalAvailableMemoryInMiB { get; set; }
        public virtual long GetTotalMemoryInMiB { get; set; }
        public virtual string ContactEmail { get; set; }
        public virtual IList<Driver> Drivers { get; set; }
        public virtual IList<Service> Services { get; set; }
    }
}