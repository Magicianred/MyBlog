using Microsoft.Extensions.DependencyInjection;
using MyBlog.Business.Concrete;
using MyBlog.DataAccess.Interfaces;
using MyBlog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyBlog.Business.Containers.MicrosoftIoc
{
   public static class CustomIocExtention 
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(IGenericDal<>));
        }
    }
}
