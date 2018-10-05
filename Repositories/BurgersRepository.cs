using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories {
  public class BurgersRepository {
    private IDbConnection _db;
    private string TableName = "burgers";
    public BurgersRepository(IDbConnection db) {
      _db = db;
    }

    // CRUD via Sql ↓
    // Get all
    public IEnumerable<Burger> GetAll() {
      return _db.Query<Burger>($"SELECT * FROM {TableName};");
    }

    // Get by id
    public Burger GetById(int id) {
      return _db.Query($"SELECT * FROM {TableName} WHERE id = @id;", new { id }).FirstOrDefault();
    }

    // Create
    public Burger Create(Burger burger) {
      try {
        // ExecuteScalar runs execute on each command ↓
        int id = _db.ExecuteScalar<int>($@"
          INSERT INTO {TableName} (name, description, price) VALUES (@Name, @Description, @Price);
          SELECT LAST_INSERT_ID();
        ", burger);
        burger.Id = id;
        return burger;
      } catch (SqlException error) {
        System.Console.WriteLine(error.Message);
        return null;
      }
    }

    // Update
    public Burger UpdateById(Burger burger) {
      try {
        _db.ExecuteScalar<Burger>($"UPDATE {TableName} SET (name, description, price) VALUES (@Name, @Description, @Price) WHERE id = @Id;", burger);
        return burger;
      } catch (SqlException error) {
        System.Console.WriteLine(error.Message);
        return null;
      }
    }

    // Delete by id
    public bool DeleteById(int id) {
      // 1 is deleted, 0 is error
      return _db.Execute($"DELETE FROM {TableName} WHERE id = @id;", new { id }) == 1;
    }

    public IEnumerable<Burger> GetBurgersByUserId(string id) {
      return _db.Query<Burger>(@"
        SELECT * FROM userburgers
        JOIN burgers ON burgers.id = userburgers.burgerId
        WHERE userId = @id;
      ", new { id });
    }
  }
}