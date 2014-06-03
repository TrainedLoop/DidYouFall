using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository.Maps
{
    public class ServerMap : ClassMap<Server>
    {
        public ServerMap()
        {
            Table("server");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            References(x => x.User);
            Map(x => x.Name).Column("Name");
            Map(x => x.IP).Column("IP");
            Map(x => x.LastCheck).Column("LastCheck");
            Map(x => x.CheckTime).Column("CheckTime").CustomType<int>();
            Map(x => x.Uptime).Column("Uptime");
            Map(x => x.Contactemail).Column("ContactEmail");
            Map(x => x.LastStatus).Column("LastStatus");
            HasMany(x => x.Ports).Element("Ports").AsBag();
            HasMany(x => x.Logs)
                .AsBag()
                .Cascade.All();
        }
    }
}