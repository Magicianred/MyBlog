using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.UserName).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Password).HasMaxLength(100).IsRequired();

            builder.Property(p => p.EMail).HasMaxLength(100);

            builder.Property(p => p.Surname).HasMaxLength(100);

            builder.HasMany(p => p.Blogs).WithOne(p => p.AppUser).HasForeignKey(p => p.AppUserId);

        }
    }
}
