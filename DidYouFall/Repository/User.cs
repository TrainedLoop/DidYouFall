using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Repository
{
    public class User
    {
        public User() { }
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual string Company { get; set; }
        public virtual IList<Server> Servers { get; set; }




    }
}