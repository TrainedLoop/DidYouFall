using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace DidYouFall.Repository.Maps
{
    public class AgentInfoMap : ClassMap<AgentInfo>
    {
        public AgentInfoMap()
        {
            Table("agentInfo");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            References(x => x.User);
            Map(x => x.ComputarName).Column("ComputarName");
            Map(x => x.CpuUsage).Column("CpuUsage");
            Map(x => x.GetTotalMemoryInMiB).Column("GetTotalMemoryInMiB");
            Map(x => x.PhysicalAvailableMemoryInMiB).Column("PhysicalAvailableMemoryInMiB");
            Map(x => x.ContactEmail).Column("ContactEmail");
            Map(x => x.LastCheck).Column("LastCheck");
            HasMany(x => x.Drivers)
                .AsBag()
                .Cascade.All();
            HasMany(x => x.Services)
                .AsBag()
                .Cascade.All();
        }
    }
}