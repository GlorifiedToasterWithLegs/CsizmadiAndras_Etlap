using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Etlap
{
    public class FoodService
    {
		MySqlConnection connection;
		public FoodService()
		{
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
			builder.Server = "localhost";
			builder.Port = 3306;
			builder.UserID = "root";
			builder.Password = "";
			builder.Database = "etlapdb";

			connection = new MySqlConnection(builder.ConnectionString);
		}

		private void CloseCon()
		{
			if (connection.State == System.Data.ConnectionState.Open)
			{
				connection.Close();
			}
		}

		private void OpenCon()
		{
			if (connection.State != System.Data.ConnectionState.Open)
			{
				connection.Open();
			}
		}

		public List<String> Courses()
		{
			List<String> returnList = new List<String>();
			OpenCon();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = "SELECT DISTINCT kategoria FROM etlap";
			using (MySqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					string course = reader.GetString("kategoria");
					returnList.Add(course);
				}
			}

			CloseCon();
			return returnList;
		}

		public bool Create(Food food)
		{
			OpenCon();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = "INSERT INTO etlap(nev, leiras, ar, kategoria) VALUES (@name, @desc, @price, @course)";
			command.Parameters.AddWithValue("@name", food.Name);
			command.Parameters.AddWithValue("@desc", food.Desc);
			command.Parameters.AddWithValue("@price", food.Price);
			command.Parameters.AddWithValue("@course", food.Course);
			int affected = command.ExecuteNonQuery();
			CloseCon();
			return affected == 1;
		}

		public List<Food> Fetch()
		{
			List<Food> returnList = new List<Food>();
			OpenCon();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = "SELECT * FROM etlap";
			using (MySqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Food food = new Food();
					food.ID = reader.GetInt32("id");
					food.Name = reader.GetString("nev");
					food.Desc = reader.GetString("leiras");
					food.Price = reader.GetInt32("ar");
					food.Course = reader.GetString("kategoria");
					returnList.Add(food);
				}
			}

			CloseCon();
			return returnList;
		}

		public bool Modify(int id, Food food)
		{
			OpenCon();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = "UPDATE etlap SET nev = @name, leiras = @desc, ar = @price, kategoria = @course WHERE id = @id";
			command.Parameters.AddWithValue("@id", id);
			command.Parameters.AddWithValue("@name", food.Name);
			command.Parameters.AddWithValue("@desc", food.Desc);
			command.Parameters.AddWithValue("@price", food.Price);
			command.Parameters.AddWithValue("@course", food.Course);
			int affected = command.ExecuteNonQuery();
			CloseCon();
			return affected == 1;
		}

		public bool ModifyAll(int amount, string type)
		{
			int[] curVal = {};
			OpenCon();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = "SELECT ar FROM etlap";
			using (MySqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					int value = reader.GetInt32("ar");
					curVal.Append(value);
				}
			}
			// curVal has the current values now, time to modify
			command.CommandText = "UPDATE etlap SET ar = @price WHERE id = @id";
			int affected = 0;
			int i = 0;
			foreach (int value in curVal)
			{
				if (type == "ft")
				{
					command.Parameters.AddWithValue("@price", value + amount);
				}
				else 
				{
					command.Parameters.AddWithValue("@price", value * (1 + amount/100));
				}
				command.Parameters.AddWithValue("@id", i);
				affected += command.ExecuteNonQuery();
				i++;
			}
			
			CloseCon();
			return affected == curVal.Length;
		}

		public bool Delete(int id)
		{
			OpenCon();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = "DELETE FROM etlap WHERE id = @id";
			command.Parameters.AddWithValue("@id", id);
			int affected = command.ExecuteNonQuery();
			CloseCon();
			return affected == 1;
		}
	}
}
