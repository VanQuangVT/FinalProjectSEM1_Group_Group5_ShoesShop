create database if not exists ShoesShop;
use ShoesShop;
create table if not exists Shoes(
Shoe_ID int(20) auto_increment primary key not null,
Shoe_Name varchar(50) not null,
ShoeSize int not null,
NumberOfShoe int not null,
ShoeDescription varchar(300) not null,
Price double not null
);

drop table Shoes;


create table if not exists Cusmoters(
Cusmoter_ID int primary key,
CusmoterName varchar(200),
PhoneNumber varchar(10),
Address varchar(200)
);

create table if not exists Orders(
Order_ID int primary key,
Order_Date datetime
);

create table if not exists OrderDetails(
Order_ID int ,
Shoe_ID int,
Amount double,
constraint fk_OrderDetails_Shoes foreign key(Shoe_ID) references Shoes(Shoe_ID),
constraint fk_OrderDetails_Order foreign key(Order_ID) references Orders(Order_ID)
); 
drop table OrderDetails;
create table if not exists CustomerDetails(
Order_ID int,
Customer_ID int,
NumberOfOrders int,
constraint fk_CustomerDetails_Order foreign key(Order_ID) references Orders(Order_ID),
constraint fk_CustomerDetails_Cusmoter foreign key(Customer_ID) references Cusmoters(Cusmoter_ID)
);

insert into Shoes (Shoe_Name,ShoeSize,NumberOfShoe,ShoeDescription,Price)
value('donche',38,40,'nhedep',300000),
     ('sss',36,33,'chiu',111111);
select *from Shoes;
update Shoes set Shoe_Name = 'kkkkk' where Shoe_ID= 1;

create table if not exists Accounts(
Acc_name varchar(20) primary key,
Acc_password varchar(20) not null
);
insert into Accounts(Acc_name,Acc_password)
value('vanquang12','123456');
drop table Accounts;

select * from Accounts;

select *from Shoes ;
create table if not exists Managers(
Manager_ID int primary key auto_increment,
ManagerName varchar(100) not null,
ManagerEmail varchar(100) not null,
ManagerPasswords varchar(100) not null
);
drop table Managers;
insert into Managers(ManagerName,ManagerEmail,ManagerPasswords)
value('Quang','quanghihi@gmail.com','123456');
select * from Managers;






