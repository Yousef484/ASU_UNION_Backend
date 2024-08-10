using ASU_UNION.DTOs;
using ASU_UNION.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace ASU_UNION.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine); // Add this line for logging
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            base.OnModelCreating(builder);
            builder.Entity<RoleCategory>()
                .HasData(
                 new RoleCategory
                 {
                     ID = 1,
                     RoleName = "Backend"
                 },
                 new RoleCategory
                 {
                     ID = 2,
                     RoleName = "Frontend"
                 },
                 new RoleCategory
                 {
                     ID = 3,
                     RoleName = "Android"
                 },
                 new RoleCategory
                 {
                     ID = 4,
                     RoleName = "IOS"
                 },
                 new RoleCategory
                 {
                     ID = 5,
                     RoleName = "Flutter"
                 },
                  new RoleCategory
                  {
                      ID = 6,
                      RoleName = "Machine Learning"
                  },
                   new RoleCategory
                   {
                       ID = 7,
                       RoleName = "Cyber Security"
                   },
                    new RoleCategory
                    {
                        ID = 8,
                        RoleName = "UI/UX"
                    },
                     new RoleCategory
                     {
                         ID = 9,
                         RoleName = "Game Development"
                     }
                      
                 );


            builder.Entity<IdentityRole>().HasData(
              new IdentityRole
              {
                  Name = "Admin",
                  NormalizedName = "ADMIN"
              });


           
        }
        public DbSet<Post> Postss { get; set; }
        public DbSet<UsersToNotify> UsersEmails { get; set; }
        public DbSet<Suggestations> Suggestations { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<RoleCategory> RoleCategories { get; set; }
    }
}
