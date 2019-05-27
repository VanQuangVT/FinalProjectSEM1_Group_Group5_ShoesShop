using System;
namespace Persistence
{
    public class Shoes
    {
       

        public int Shoe_ID{get;set;}
        public string Shoe_Name{get;set;}
        public int Size{get;set;}
        public string Description{get;set;}

        public double Price{get;set;}
        public int NumberOfShoe{get;set;}

        public Shoes()
        {
        }
        public Shoes(int shoe_id,string shoe_name,int size,int numberofshoe,string description,double price)
        {
            Shoe_ID =shoe_id;
            Shoe_Name =shoe_name;
            Size =size;
            NumberOfShoe = numberofshoe;
            Description = description;
            Price = price;
        }
     

    }
}