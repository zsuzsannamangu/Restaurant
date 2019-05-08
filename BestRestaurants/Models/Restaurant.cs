
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int Id { get; set; }


    public static List<Restaurant> restList = new List<Restaurant> {};

    public Restaurant (string name, string address, string phoneNumber, int id = 0)
    {
      Name = name;
      Address = address;
      PhoneNumber = phoneNumber;
      Id = id;
      restList = new List<Restaurant>{};
    }

    public int GetId()
    {
      return Id;
    }

    public void AddRestaurant(Restaurant item)
    {
      restList.Add(item);
    }


    public static Restaurant GetRestaurant(string name)
    {
      Restaurant returnRestaurant = new Restaurant("name", "address", "phoneNumber");
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants WHERE id = @name;";
      MySqlParameter thisName = new MySqlParameter();
      thisName.ParameterName = "@name";
      thisName.Value = name;
      cmd.Parameters.Add(thisName);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string Name = rdr.GetString(0);
        string Address = rdr.GetString(1);
        string PhoneNumber = rdr.GetString(2);
        returnRestaurant = new Restaurant(Name, Address, PhoneNumber);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return returnRestaurant;
    }

    public static void RemoveRestaurant(string id, string name)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants WHERE id = @name";
      cmd.Parameters.AddWithValue("@name", name);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  //   private static void RemoveItem(string name, string address, string phoneNumber)
  //   {
  //     MySqlConnection conn = DB.Connection();
  //     conn.Open();
  //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
  //     cmd.CommandText = @"DELETE FROM restaurant WHERE id = @name;";
  //     cmd.Parameters.AddWithValue("@name", name);
  //     cmd.ExecuteNonQuery();
  //   }
  //   conn.Close();
  //   if (conn != null)
  //   {
  //     conn.Dispose();
  //   }
  // }
    //
    // public static void RemoveRestaurant(string input)
    // {
    //   RemoveItem(input, "name", "address", "phoneNumber");
    // }

    public override bool Equals(System.Object otherRestaurant)
    {
      if (!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool descriptionEquality = (this.Name == newRestaurant.Name);
        return (descriptionEquality);
      }
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO restaurants (name, address, phoneNumber) VALUES (@RestaurantsName, @RestaurantsAddress, @RestaurantsPhoneNumber);";

      cmd.Parameters.AddWithValue("@RestaurantsName", Name);
      cmd.Parameters.AddWithValue("@RestaurantsAddress", Address);
      cmd.Parameters.AddWithValue("@RestaurantsPhoneNumber", PhoneNumber);
      cmd.ExecuteNonQuery();

      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRest = new List<Restaurant> {};


      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string name = rdr.GetString(0);
        string address = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        int id = rdr.GetInt32(3);

        Restaurant newRest = new Restaurant(name, address, phoneNumber, id);
        allRest.Add(newRest);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allRest;

    }


  }
}
