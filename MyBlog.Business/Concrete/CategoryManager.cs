using MyBlog.Business.Interfaces;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Business.Concrete
{
   public class CategoryManager:GenericManager<Category>,ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IGenericDal<Category> genericDal;
        public CategoryManager(ICategoryDal categoryDal, IGenericDal<Category> genericDal) :base(genericDal)
        {
            _categoryDal = categoryDal;
            this.genericDal = genericDal;
        }
    }
}
