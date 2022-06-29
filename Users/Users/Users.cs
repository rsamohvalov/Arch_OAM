using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using Sensors;
using Agregator;

namespace Users {
    public class Role {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
     

    public class Operator : Role {
        public List<AggregateInDb> AgregatorList;
        public Operator() {
            AgregatorList = new List<AggregateInDb>();
            RoleName = "Оператор";
        }
        public Operator( List<AggregateInDb> aggregateInDbs ) {
            AgregatorList = aggregateInDbs;
            RoleName = "Оператор";
        }
    }
    public class Administrator : Role {

    }

    public class Credential {
        [Key]
        public int CredentialId { get; set; }
        public string login { get; set; }
        public string HashedPassword { get; set; }
        public Credential() {

        }
        public Credential( string login, string password ) {
            this.login = login;            
            var md5 = MD5.Create();
            var hash = md5.ComputeHash( System.Text.Encoding.UTF8.GetBytes( password ) );
            HashedPassword = Convert.ToBase64String( hash );
        }
    }

    public class UserInfo {
        public int UserInfoId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserInfo( string name, string surname, string email ) {
            Name = name;
            Surname = surname;
            Email = email;
        }
    }

    public class User {        
        public int UserId { get; set; }
        public Role UserRole { get; set; }
        public Credential Credentials { get; set; }
        public UserInfo UserInfo { get; set; }

        public User() { }
        public User( UserInfo info, Credential credentials, Role role ) {
            UserRole = role;
            UserInfo = info;
            Credentials = credentials;
        }
        public override bool Equals( object obj ) {
            User user = obj as User;
            if(user.Credentials.login == this.Credentials.login &&
                user.Credentials.HashedPassword == this.Credentials.HashedPassword &&
                user.UserInfo.Name == user.UserInfo.Name) {
                return true;
            } else
                return false;
        }
    }

    public class ApplicationContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<AggregateInDb> Aggregators { get; set; }
        public DbSet<SensorInDb> Sensors { get; set; }
        public DbSet<SensorDbValue> Values { get; set; }

        public ApplicationContext( DbContextOptions<ApplicationContext> options ) : base (options) {
        }        
    }

    public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext> {
        public ApplicationContext CreateDbContext( string[] args ) {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath( Directory.GetCurrentDirectory() );
            builder.AddJsonFile( "appsettings.json" );
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString( "DefaultConnection" );
            optionsBuilder.UseSqlServer( connectionString, opts => opts.CommandTimeout( (int)TimeSpan.FromMinutes( 10 ).TotalSeconds ) );
            return new ApplicationContext( optionsBuilder.Options );
        }
    }


    public interface IUserRepository {
        public void AddUser( User user );
        public User Login( string login, string HashedPassword );
        public void Delete( User user );
        public List<string> PrintUsers();
    }

    public class SqlUserRepository : IUserRepository {
        public ApplicationContext applicationContext;

        public SqlUserRepository( string connectionString ) {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer( connectionString ).Options;
            applicationContext = new ApplicationContext( options );
        }
        public void AddUser( User user ) {
            foreach(User u in applicationContext.Users) {
                if(user.Credentials.login == u.Credentials.login &&
                   user.Credentials.HashedPassword == u.Credentials.HashedPassword &&
                   user.UserInfo.Name == user.UserInfo.Name
                   ) {
                    return;
                }
            }
            applicationContext.Users.Add( user );
            applicationContext.SaveChanges();
        }
        public User Login( string login, string password ) {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash( System.Text.Encoding.UTF8.GetBytes( password ) );
            string HashedPassword = Convert.ToBase64String( hash );
            var user = applicationContext.Users.Where( c => ( c.Credentials != null &&
                                                              c.Credentials.login == login &&
                                                              c.Credentials.HashedPassword == HashedPassword
                                                             )
                                                       ).SingleOrDefault();
            return user;
        }
        public void Delete( User user ) {
            applicationContext.Users.Remove( user );
            applicationContext.SaveChanges();
        }

        public List<string> PrintUsers() {
            List<string> result = new List<string>();
            foreach(User u in applicationContext.Users.ToList() ) {
                result.Add( u.UserInfo.Name + " " + u.UserInfo.Surname );
            }
            return result;
        }
    }

    public class UserNotFoundException : Exception {
        public UserNotFoundException() : base( "User not found in DB" ) { }
    }
    public class UserCredintialsMismatchException : Exception {
        public UserCredintialsMismatchException() : base( "Wrong login-password" ) { }
    }
}
