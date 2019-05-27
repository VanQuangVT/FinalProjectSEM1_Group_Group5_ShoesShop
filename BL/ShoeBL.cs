using System;
using System.Collections.Generic;
using DAL;
using Persistence;
namespace BL{
    public class ShoeBL{

        private ShoeDAL shoedal;

        public Shoes GetShoebyID(int ShoeId){
            return shoedal.GetShoebyID(ShoeId);
        }

       public Shoes CreateShoe(int ShoeId,string ShoeName,int Shoe_Size,int Numberofshoe,string Description,double Price)
       {
           return shoedal.CreateShoe(ShoeId,ShoeName,Shoe_Size,Numberofshoe,Description,Price);
       }
       public Shoes UpdateShoe(int shoeid,string name,int size,int Numberofshoe,string Description,double price)
       {
           return shoedal.UpdateShoe(shoeid,name,size,Numberofshoe,Description,price);
       }
       public ShoeBL(){
           shoedal = new ShoeDAL();
       }
       public List<Shoes> GetShoe()
        {
            return shoedal.GetShoe();
        }
    }
}