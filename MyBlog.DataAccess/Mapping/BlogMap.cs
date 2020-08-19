using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(350).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(550).HasColumnType("ntext").IsRequired();
            builder.Property(p => p.ImagePath).HasMaxLength(350);
            builder.HasMany(p => p.Comments).WithOne(p => p.Blog).HasForeignKey(p => p.BlogId);

        }
    }
}
