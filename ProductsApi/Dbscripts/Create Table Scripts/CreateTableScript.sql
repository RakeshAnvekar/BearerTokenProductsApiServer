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




