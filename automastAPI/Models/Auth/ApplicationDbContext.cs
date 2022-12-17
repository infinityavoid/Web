using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace automastAPI.Models.Auth
{
    public class ApplicationDbContext: IdentityDbContext<AppUser, IdentityRole<string>,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder) //всего 2 роли
        {
            IdentityRole role = new IdentityRole()
            {
                Id = "fab4fac1-c546-41de-aebc-a13da6895711",
                Name = "Admin",
                ConcurrencyStamp = "fab4fac1-c546-41de-aebc-a13da6895711",
                NormalizedName = "ADMIN"
            };
            builder.Entity<IdentityRole>().HasData(role);
            role = new IdentityRole()
            {
                Id = "c7b013f0-5201-4317-abd8-c211f91b730",
                Name = "Employee",
                ConcurrencyStamp = "c7b013f0-5201-4317-abd8-c211f91b730",
                NormalizedName = "EMPLOYEE"
            };
            builder.Entity<IdentityRole>().HasData(role);
            role = new IdentityRole()
            {
                Id = "fghiyu37-6790-6457-rty7-q5wyrty5j67",
                Name = "Buyer",
                ConcurrencyStamp = "fghiyu37-6790-6457-rty7-q5wyrty5j67",
                NormalizedName = "BUYER"
            };
            builder.Entity<IdentityRole>().HasData(role);
        }

        private void SeedUsers(ModelBuilder builder) //генерация админа
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            AppUser user = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Email = "adm@gmail.com",
                NormalizedEmail = "ADM@GMAIL.COM",
                EmailConfirmed = false,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = passwordHasher.HashPassword(user, password: "Admin*123");
            builder.Entity<AppUser>().HasData(user);
        }
        private void SeedUserRoles(ModelBuilder builder) //присваиваем пользователю админ роль админа
        {
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = "fab4fac1-c546-41de-aebc-a13da6895711",
                UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
            });
        }
    }
}
