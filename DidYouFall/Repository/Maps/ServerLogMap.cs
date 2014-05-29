using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository.Maps
{
    public class ServerLogMap : ClassMap<ServerLog>
    {
        public ServerLogMap()
        {
            Table("serverLog");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            References(x => x.Server);
            Map(x => x.DownAt).Column("DownAt").Nullable();
            Map(x => x.UpAt).Column("UpAt").Nullable();
            Map(x => x.EmailSended).Column("EmailSended");
            Map(x => x.Closed).Column("Closed");

        }
    }
}