using System;

namespace ORM_EF {

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
    }

    public class DBContext {
    }
}
