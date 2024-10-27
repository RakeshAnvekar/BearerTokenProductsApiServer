Create Database ProductDb;
use ProductDb;

create Table ProductCategory(
CategoryId int not null primary key,
CategoryType varchar(30) not null
)

Create Table Product(
 Id int not null primary key,
 ProductName varchar(30) not null,
 Price DECIMAL(10, 2),
  CategoryId int not null,
 Foreign key (CategoryId) references ProductCategory(CategoryId)	
)

create Table UserType
(
UserTypeId  int not null primary key,
UserType varchar(50) not null
)


Create Table UserDetails
(
UserId int not null primary key,
UserName varchar(100) not null,
UserEmail varchar(100) not null,
UserPassword varchar(100) not null,
UserTypeId int not null,
Foreign key (UserTypeId) references UserType (UserTypeId)
)

