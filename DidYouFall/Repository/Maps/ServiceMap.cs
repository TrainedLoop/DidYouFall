using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace DidYouFall.Repository.Maps
{
    public class ServiceMap : ClassMap<Service>
    {
        public ServiceMap()
        {
            Table("service");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            References(x => x.AgentInfo);
            Map(x => x.Monitoring).Column("Monitoring").Nullable();
            Map(x => x.Name).Column("Name").Nullable();
            Map(x => x.Status).Column("Status");
        }

    }
}