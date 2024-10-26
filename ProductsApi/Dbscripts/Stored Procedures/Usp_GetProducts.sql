use ProductDb;
if OBJECT_ID('dbo.Usp_GetProducts','p') is not null
Begin
drop procedure dbo.Usp_GetProducts
End
Go
Create procedure Usp_GetProducts
as 
begin
select p.ProductName,p.id,p.Price,pc.CategoryType from dbo.[Product] p
left outer join ProductCategory  pc
on p.CategoryId= pc.CategoryId
end

