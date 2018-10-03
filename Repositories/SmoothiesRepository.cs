using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories {
  public class SmoothiesRepository {
    private IDbConnection _db;
    private string TableName = "smoothies";
    public SmoothiesRepository(IDbConnection db) {
      _db = db;
    }

    // CRUD via Sql ↓
    // Get all
    public IEnumerable<Smoothie> GetAll() {
      return _db.Query<Smoothie>($"SELECT * FROM {TableName};");
    }

    // Get by id
    public Smoothie GetById(int id) {
      return _db.Query($"SELECT * FROM {TableName} WHERE id = @id;", new { id }).FirstOrDefault();
    }

    // Create
    public Smoothie Create(Smoothie smoothie) {
      try {
        // ExecuteScalar runs execute on each command ↓
        int id = _db.ExecuteScalar<int>($@"
          INSERT INTO {TableName} (name, description, price) VALUES (@Name, @Description, @Price);
          SELECT LAST_INSERT_ID();
        ", smoothie);
        smoothie.Id = id;
        return smoothie;
      } catch (SqlException error) {
        System.Console.WriteLine(error.Message);
        return null;
      }
    }

    // Update
    public Smoothie UpdateById(Smoothie smoothie) {
      try {
        _db.ExecuteScalar<Smoothie>($"UPDATE {TableName} SET (name, description, price) VALUES (@Name, @Description, @Price) WHERE id = @Id;", smoothie);
        return smoothie;
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
  }
}