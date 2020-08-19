using MyBlog.Business.Interfaces;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.Concrete
{
   public class AppUserManager:GenericManager<AppUser>,IAppUserService
    {
       private readonly IGenericDal<AppUser> _genericDal;
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) :base(genericDal)
        {
            _genericDal = genericDal;
            _appUserDal = appUserDal;

        }
    }
}
