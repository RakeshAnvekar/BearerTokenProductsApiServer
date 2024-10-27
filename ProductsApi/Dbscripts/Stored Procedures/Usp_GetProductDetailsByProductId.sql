use ProductDb
If OBJECT_ID('dbo.Usp_GetProductDetailsByProductId') is not null
begin
drop procedure dbo.Usp_GetProductDetailsByProductId
end
Go 
Create Procedure dbo.Usp_GetProductDetailsByProductId
@ProductId int 
as 
begin
select p.ProductName,p.id,p.Price,pc.CategoryType from dbo.[Product] p
left outer join ProductCategory  pc
on p.CategoryId= pc.CategoryId
and p.Id=@ProductId
end
