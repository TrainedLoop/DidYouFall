using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("user");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Email).Column("Email");
            Map(x => x.Password).Column("Password");
            Map(x => x.Name).Column("Name");
            Map(x => x.Company).Column("Company");
            HasMany(x => x.Servers)
                .AsBag()
                .Cascade.All();
        }
    }
}