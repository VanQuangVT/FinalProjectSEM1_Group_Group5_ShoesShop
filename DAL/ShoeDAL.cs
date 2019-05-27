using System;
using Persistence;

using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class ShoeDAL
    {
        private string query;
        private MySqlDataReader reader;
        public Shoes CreateShoe(int ShoeId, string ShoeName, int Shoe_Size, int Numberofshoe,string Description, double Price)
        {
            query = @"insert into Shoes value('" + ShoeId + "','" + ShoeName + "','" + Shoe_Size + "','" + Numberofshoe+ "','" + Description + "','" + Price + "');";
            DBHelper.OpenConnection();
            reader = DBHelper.ExecQuery(query);
            Shoes shoe = null;
            if (reader.Read())
            {
                shoe = GetInfor(reader);
            }
            DBHelper.CloseConnection();
            return shoe;
        }

       

        public Shoes UpdateShoe(int shoeid, string name, int size, int NumberofShoe,string description, double price)
        {
            query = @"update Shoes set Shoe_Name ='" + name + "', ShoeSize ='" + size + "',NumberOfShoe ='" + NumberofShoe + "',ShoeDescription ='" + description + "',Price ='" + price +
             "'where  Shoe_ID='" + shoeid + "';";

            DBHelper.OpenConnection();
            reader = DBHelper.ExecQuery(query);
            Shoes shoe = null;
            if (reader.Read())
            {
                shoe = GetInfor(reader);
            }
            DBHelper.CloseConnection();
            return shoe;
        }
        public Shoes GetShoebyID(int ShoeId){
            query =@"select Shoe_ID, Shoe_Name, ShoeSize,NumberOfShoe,ShoeDescription,Price from
            Shoes where Shoe_ID = '"+ ShoeId+ "';";
            DBHelper.OpenConnection();
            reader = DBHelper.ExecQuery(query);
            
            Shoes shoe =null;
            if (reader.Read())
            {
                shoe = GetInfor(reader);
            }
            DBHelper.CloseConnection();
            return shoe;

        }
         public Shoes GetInfor(MySqlDataReader reader)
        {
            Shoes shoe = new Shoes();
            shoe.Shoe_ID = reader.GetInt16("Shoe_ID");
            shoe.Shoe_Name = reader.GetString("Shoe_Name");
            shoe.Size = reader.GetInt16("ShoeSize");
            shoe.NumberOfShoe=reader.GetInt16("NumberOfShoe");
            shoe.Description = reader.GetString("ShoeDescription");
            shoe.Price = reader.GetDouble("Price");
            return shoe;
        }
        public List<Shoes> GetShoe()
        {
            query = @"select * from Shoes;";
            DBHelper.OpenConnection();
            reader = DBHelper.ExecQuery(query);
           
            List<Shoes> shoe = new List<Shoes>();
            
                while(reader.Read())
                {
                    shoe .Add( GetInfor(reader));
                }
            DBHelper.CloseConnection();

            return shoe;
            
        }

        // public List<Shoes> GetShoe(){
        //     query = @"select *from Shoes";

        // }


    }
}
// using System;
// using Persistence;
// using MySql.Data.MySqlClient;
// using System.Collections.Generic;

// namespace DAL
// {
//     public class CustomerDAL
//     {
//         private string query;

//         private MySqlDataReader reader;
//         public Customer GetCustomerbyID(int cusID)
//         {
//             query = @"select customer_id, customer_name, customer_address, phone_number from
//             customer where customer_id = '"+ cusID+ "';";
//             DBHelper.OpenConnection();
//             reader = DBHelper.ExcQuery(query);

//             Customer customer = null;
//             if(reader.Read())
//             {
//                 customer = GetCustomerInfo(reader);
//             }
//             DBHelper.CloseConnection();
//             return customer;
//         }
//         public Customer GetCustomerInfo(MySqlDataReader reader)
//         {
//             Customer cus = new Customer();
//             cus.CustomerId = reader.GetInt16("customer_id");
//             cus.CustomerName = reader.GetString("customer_name");
//             cus.CustomerAddress = reader.GetString("customer_address");
//             cus.PhoneNumber = reader.GetInt32("phone_number");
//             return cus;
//         }

//         public void InsertCustomer(int cusID, string cusName, string cusAddress, int Phone)
//         {

//             query =@"insert into Customer value('"+cusID+"','" +cusName+"','"+cusAddress+"','"+Phone+"');";
//             DBHelper.OpenConnection();
//             reader = DBHelper.ExcQuery(query);

//             Customer customer = null;
//             if(reader.Read())
//             {
//                 customer = GetCustomerInfo(reader);
//             }
//             DBHelper.CloseConnection(); 
//         }
//         public void UpdateCustomer (int id, string name, string address, int sdt)
//         {
//             query = @"update customer set customer_name ='"+name+"', customer_address ='"+address+"',phone_number ='"+sdt+
//             "'where customer_id = '"+id+"';";
//             DBHelper.OpenConnection();
//             reader = DBHelper.ExcQuery(query);

//             Customer customer = null;
//             if(reader.Read())
//             {
//                 customer = GetCustomerInfo(reader);
//             }
//             DBHelper.CloseConnection();

//         }


//     }
// }