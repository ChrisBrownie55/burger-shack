using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories {
  public class UserRepository {
    IDbConnection _db;
    SaltRevision SALT = SaltRevision.Revision2X;

    public UserRepository(IDbConnection db) {
      _db = db;
    }

    public User Register(UserRegistration creds) {
      // generate user id (GUID)
      // and Hash password
      string id = Guid.NewGuid().ToString();
      string hash = BCrypt.Net.BCrypt.HashPassword(creds.Password, SALT);

      bool success = _db.Execute("INSERT INTO users (id, name, email, hash) VALUES (@id, @name, @email, @hash);", new {
        id,
        hash,
        name = creds.Name,
        email = creds.Email
      }) == 1;

      if (!success) {
        return null;
      }

      return new User() {
        Name = creds.Name,
        Email = creds.Email,
        Hash = null,
        Id = id
      };
    }

    public User Login(UserLogin creds) {
      User user = _db.Query<User>("SELECT * FROM users WHERE email = @Email;", creds).FirstOrDefault();

      if (user == null || !BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash)) {
        return null;
      }

      user.Hash = null;
      return user;
    }

    public User GetUserById(string id) {
      User user = _db.Query<User>("SELECT * FROM users WHERE id = @id", new { id }).FirstOrDefault();

      if (user == null) {
        return null;
      }

      user.Hash = null;
      return user;
    }

    // public User Update() {}
    // public bool ChangePassword() {}
    // public bool Delete() {}
  }
}