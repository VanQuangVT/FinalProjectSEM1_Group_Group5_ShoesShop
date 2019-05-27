using System;
using BL;
using Persistence;
using System.Collections.Generic;
namespace PL_Console
{
    public class ShoesChoice
    {


        public void ManagerShoe()
        {
            Menu m = new Menu();
            Console.WriteLine("============================");
            Console.WriteLine("---Quản lý danh sách giày---");
            Console.WriteLine("============================");
            Console.WriteLine("1.Thêm danh sách giày");
            Console.WriteLine("2.Cập nhập danh sách giày");
            Console.WriteLine("0.Thoát");
            int luachon;
            Console.WriteLine("============================");
            Console.Write("Nhập lựa chọn của bạn:");
            // luachon = Convert.ToInt16(Console.ReadLine());
            while (true)
            {
                bool isINT = Int32.TryParse(Console.ReadLine(), out luachon);
                if (!isINT)
                {
                    Console.WriteLine("Giá trị sai vui lòng nhập lại.");
                    Console.Write("Nhập lựa chọn của bạn : ");
                }
                else if (luachon < 0 || luachon > 2)
                {
                    Console.WriteLine("Giá trị sai vui lòng nhập lại từ 0 đến 2. ");
                    Console.Write("Nhập lựa chọn của bạn : ");
                }

                else
                {
                    break;
                }
            }
            switch (luachon)
            {
                case 1:
                    CreateShoe();
                    break;
                case 2:
                    UpdateShoe();
                    break;
                case 0:
                    m.MenuChoice();
                    break;

            }
        }

        public void CreateShoe()
        {
            ShoeBL shoelb = new ShoeBL();
            Shoes shoe = new Shoes();


            while (true)
            {
                do
                {
                    Console.Write("Nhập tên giày:");
                    shoe.Shoe_Name = Console.ReadLine();
                    if (shoe.Shoe_Name == "" || shoe.Shoe_Name == " ")
                    {
                        Console.WriteLine("không đc để trống");
                    }

                } while (shoe.Shoe_Name == "" || shoe.Shoe_Name == " ");

                Console.Write("Nhập Size giày:");
                shoe.Size = Convert.ToInt16(Console.ReadLine());
                while (shoe.Size < 0)
                {


                    if (shoe.Size < 0)
                    {
                        Console.WriteLine("Size không được số âm");
                    }








                }




                do
                {
                    Console.Write("Nhập số lượng");
                    shoe.NumberOfShoe = Convert.ToInt16(Console.ReadLine());
                    if (shoe.NumberOfShoe < 0)
                    {
                        Console.WriteLine("Số lượng không được phép nhỏ hơn không!");
                    }


                } while (shoe.NumberOfShoe < 0);
                Console.Write("Description:");
                shoe.Description = Console.ReadLine();
                do
                {
                    Console.Write("Price:");
                    shoe.Price = Convert.ToDouble(Console.ReadLine());
                    if (shoe.Price < 1000)
                    {
                        Console.WriteLine("Giá sản phẩm không được nhỏ hơn 1000");
                    }

                } while (shoe.Price < 1000);
                shoelb.CreateShoe(shoe.Shoe_ID, shoe.Shoe_Name, shoe.Size, shoe.NumberOfShoe, shoe.Description, shoe.Price);

                Console.WriteLine("======================");
                char b;
                Console.Write("Bạn  muốn tiếp tục?(Y/N)");
                b = char.Parse(Console.ReadLine());
                switch (b)
                {

                    case 'Y':
                        continue;
                    case 'y':
                        continue;
                    case 'N':
                        ManagerShoe();
                        break;
                    case 'n':
                        ManagerShoe();
                        break;

                }


            }
        }
        public void UpdateShoe()
        {
            ShoeBL shoelb = new ShoeBL();
            Shoes shoe = new Shoes();

            while (true)
            {
                Console.Write("Nhập ID:");
                shoe.Shoe_ID = Convert.ToInt16(Console.ReadLine());
                while (shoelb.GetShoebyID(shoe.Shoe_ID) == null)
                {
                    Console.WriteLine("Mã bạn không tồn tại mời nhập lại");
                    Console.Write("Nhập ID:");
                    shoe.Shoe_ID = Convert.ToInt16(Console.ReadLine());
                }


                Console.WriteLine("=======Thông tin bạn muốn cập nhập=======");
                Console.Write("Sửa Shoe_Name:", shoe.Shoe_Name);
                shoe.Shoe_Name = Console.ReadLine();
                do
                {
                    Console.Write("Sửa ShoeSize:", shoe.Size);
                    shoe.Size = Convert.ToInt16(Console.ReadLine());
                    if (shoe.Size < 0)
                    {
                        Console.WriteLine("Size giày không được nhỏ hơn không");
                    }

                } while (shoe.Size < 0);
                do
                {
                    Console.Write("Sửa NumberOfShoe:", shoe.NumberOfShoe);
                    shoe.NumberOfShoe = Convert.ToInt16(Console.ReadLine());
                    if (shoe.NumberOfShoe < 0)
                    {
                        Console.WriteLine("Số lượng không được phép nhỏ hơn không!");
                    }
                } while (shoe.NumberOfShoe < 0);

                Console.Write("Sửa ShoeDescription:", shoe.Description);
                shoe.Description = Console.ReadLine();
                do
                {
                    Console.Write("Sửa Price:", shoe.Price);
                    shoe.Price = Convert.ToDouble(Console.ReadLine());
                    if (shoe.Price < 1000)
                    {
                        Console.WriteLine("Giá sản phẩm không được nhỏ hơn 1000");
                    }
                } while (shoe.Price < 1000);


                shoelb.UpdateShoe(shoe.Shoe_ID, shoe.Shoe_Name, shoe.Size, shoe.NumberOfShoe, shoe.Description, shoe.Price);

                Console.WriteLine("======================");
                char b;
                Console.Write("Bạn  muốn tiếp tục?(Y/N)");
                b = char.Parse(Console.ReadLine());
                switch (b)
                {
                    case 'Y':
                        continue;
                    case 'y':
                        continue;
                    case 'N':
                        ManagerShoe();
                        break;
                    case 'n':
                        ManagerShoe();
                        break;
                }
            }


            }
            //    public void DisplayShoe()
            // {
            //     Console.Clear();
            //     ShoeBL shoe = new ShoeBL();
            //     List<Shoes> list = shoe.GetShoe();
            //     Menu shoemenu = new Menu();
            //     var table = new ConsoleTable("ID", "Tên giày", "Kích cỡ", "Số lượng","Miêu tả","Giá sản phẩm");
            //     foreach (Shoes sho in list)
            //     {
            //         table.AddRow(sho.Shoe_ID,sho.Shoe_Name,sho.Size,sho.NumberOfShoe,sho.Description,sho.Price);
            //     }
            //     table.Write();
            //     Console.WriteLine();

            //     while (true)
            //     {
            //         Console.Write("Nhấn Enter để tiếp tục");
            //         string choice1;
            //         choice1 = Console.ReadLine();
            //         switch (choice1)
            //         {
            //             case "":
            //                 {
            //                     shoemenu.MenuChoice();
            //                     break;
            //                 }
            //             default:
            //                 {
            //                     continue;
            //                 }
            //         }
            //         break;


            //   string KtTenMatHang()
            //         {
            //             string kt;
            //             int index;
            //             while (true)
            //             {
            //                 index = -1;
            //                 try
            //                 {
            //                     kt = Console.ReadLine();
            //                 }
            //                 catch (System.Exception)
            //                 {
            //                     Console.WriteLine("nhập lại:");
            //                     continue;
            //                 }
            //                 if (kt == " ")
            //                 {
            //                     Console.Write("------------------------------------------------------------- ");
            //                     Console.Write("\nKhông đc để trống!");
            //                     Console.Write("\n------------------------------------------------------------- ");
            //                     Console.Write("\nNhập lại đi:\a");
            //                     continue;
            //                 }
            //                 for (int i = 0; i < kt.Length; i++)
            //                 {
            //                     if (kt[i] >= 65 && kt[i] <= 90 || kt[i] >= 97 && kt[i] <= 122)
            //                     {
            //                         index = 1;
            //                         break;
            //                     }
            //                 }
            //                 if (index == -1)
            //                 {
            //                     Console.Write("------------------------------------------------------------- ");
            //                     Console.Write("\nKhông đc là số mà phải là chữ!");
            //                     Console.Write("\n------------------------------------------------------------- ");
            //                     Console.Write("\nNhập lại:");
            //                     continue;
            //                 }
            //                 break;
            //             }
            //             return kt;




        }

    }
