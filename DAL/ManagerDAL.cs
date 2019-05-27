using System;
using Persistence;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DAL
{
    public class ManagerDAL
    {
         private string query;

         private MySqlConnection connection = DBHelper.OpenConnection();
        private MySqlDataReader reader;

        public Manager Login(string email, string password){
            string regexEmail = @"^[^<>()[\]\\,;:'\%#^\s@\$&!@]+@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z0-9]+\.)+[a-zA-Z]{2,}))$";
            string regexPassword = @"^[-.@_a-zA-Z0-9 ]+$";
            if (Regex.IsMatch(email,regexEmail) != true || email == "" || Regex.IsMatch(password,regexPassword) != true || password == "")
            {
                return null;
            }
            if(connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = $"Select * from Managers where ManagerEmail = '{email}' and ManagerPasswords ='{password}';";
            Manager managers = null;

            MySqlCommand cmd = new MySqlCommand(query,connection);
            using(reader = cmd.ExecuteReader())
            {
                 if (reader.Read())
                {
                    managers = GetManagers(reader);
                }
            }
            connection.Close();
            return managers;
  
            
        }
        public static Manager GetManagers(MySqlDataReader reader){
             Manager managers = new Manager();
            managers.Manager_ID = reader.GetInt32("Manager_ID");
            managers.ManagerName = reader.GetString("ManagerName");
            managers.Email = reader.GetString("ManagerEmail");
            managers.Password = reader.GetString("ManagerPasswords");
            return managers;
        }

       

    }
}