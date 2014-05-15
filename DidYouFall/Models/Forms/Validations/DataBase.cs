using DidYouFall.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidYouFall.Models.Forms.Validations
{
    public class DataBase
    {
        public void RegisteredEmail(string email)
        {
            var user= Users.Queryable.Where(i => i.Email == email).FirstOrDefault();
            if (user == null)
                throw new Exception("Usuario já registado");
        }
    }
}