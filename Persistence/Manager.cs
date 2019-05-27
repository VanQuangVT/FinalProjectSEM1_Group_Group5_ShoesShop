using System;
namespace Persistence
{
    public class Manager{
       
        public int Manager_ID{get;set;}
        public string ManagerName{get;set;}
        public string Email{get;set;}
        public string Password{get;set;}
        public Manager()
        {

        }
        public Manager(int id ,string name,string email,string password)
        {
                Manager_ID =id;
                ManagerName = name;
                Email =email;
                Password = password;
        }
    }
}