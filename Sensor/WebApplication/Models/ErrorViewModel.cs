using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models {
    public class ErrorViewModel {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty( RequestId );
    }

    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public Role UserRole { get; set; }
    }

    public class Role {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }

    public class ApplicationContext : DbContext {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null;
        public ApplicationContext( DbContextOptions<ApplicationContext> options )
            : base( options ) {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
