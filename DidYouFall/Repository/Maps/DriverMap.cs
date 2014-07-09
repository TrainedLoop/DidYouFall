using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace DidYouFall.Repository.Maps
{
    public class DriverMap : ClassMap<Driver>
    {
        public DriverMap()
        {
            Table("driver");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            References(x => x.AgentInfo);
            Map(x => x.Format).Column("Format").Nullable();
            Map(x => x.FreeSpace).Column("FreeSpace").Nullable();
            Map(x => x.Label).Column("Label").Nullable();
            Map(x => x.Monitoring).Column("Monitoring");
            Map(x => x.Status).Column("Status").Nullable();
            Map(x => x.TotalSpace).Column("TotalSpace").Nullable();
            Map(x => x.Volume).Column("Volume").Nullable();
        }
    }
}