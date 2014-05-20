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
            References(x => x.Users).Column("User");
            Map(x => x.Host).Column("Host");
            Map(x => x.Verificationtime).Column("VerificationTime");
            Map(x => x.Contactemail).Column("ContactEmail");
            Map(x => x.Emailsent).Column("EmailSent");
        }
    }
}