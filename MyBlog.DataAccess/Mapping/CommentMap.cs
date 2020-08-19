using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.AuthorEMail).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(400).IsRequired();

            builder.HasOne(p => p.ParentComment).WithMany(p => p.SubComments).HasForeignKey(p => p.ParentCommentId);
        }
    }
}
