using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository.Maps
{
    public class UsersMap : ClassMap<Users>
    {
        public UsersMap()
         {
			Table("users");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			Map(x => x.Email).Column("Email");
			Map(x => x.Password).Column("Password");
			Map(x => x.Name).Column("Name");
			Map(x => x.Company).Column("Company");
         }
    }
}