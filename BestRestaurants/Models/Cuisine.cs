using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurant.Models
{
  public class Cuisine
  {
    public string Type { get; set; }
    public string Cost { get; set; }

    public static List<Cuisine> cusList = new List<Cuisine> {};

    public Cuisine (string type, string cost)
    {
      Type = type;
      Cost = cost;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public override bool Equals(System.Object otherRestaurant)
    // {
    //   if (!(otherRestaurant is Restaurant))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Cuisine newCuisine = (Cuisine) otherCuisine;
    //     bool descriptionEquality = (this.Type == newCuisine.Type);
    //     return (descriptionEquality);
    //   }
    // }

    // public void Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @;
    //   MySqlParameter type = new MySqlParameter();
    //   type.ParameterName = "@RestaurantName";
    //   type.Value = this.Type;
    //
    //   MySqlParameter name = new MySqlParameter();
    //   name.ParameterName = "@RestaurantAddress";
    //   name.Value = this.Name;
    //
    //   MySqlParameter sex = new MySqlParameter();
    //   sex.ParameterName = "@RestaurantPhoneNumber";
    //   sex.Value = this.Sex;
    //
    //   // cmd.Parameters.AddWithValue("@");
    //   cmd.Parameters.Add(name);
    //   cmd.Parameters.Add(address);
    //   cmd.Parameters.Add(phoneNumber);
    //   cmd.ExecuteNonQuery();
    //   // more logic will go here
    //   Id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
  }
}
