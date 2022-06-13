using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test6.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using test6.Areas.Identity;
using test6.Areas.Identity.Pages;

namespace test6.Data
{
    public class test6Context : IdentityDbContext<test6User>
    {
        public test6Context(DbContextOptions<test6Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityCofiguration());
            
            
        }
    }

    internal class ApplicationUserEntityCofiguration : IEntityTypeConfiguration<test6User>
    {
        void IEntityTypeConfiguration<test6User>.Configure(EntityTypeBuilder<test6User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }
}
