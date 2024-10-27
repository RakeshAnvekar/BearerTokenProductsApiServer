Use ProductDb
If OBJECT_ID('dbo.Usp_GetUserDetails','p')  is not null
begin
drop procedure dbo.Usp_GetUserDetails
end
Go

Create procedure dbo.Usp_GetUserDetails
@UserName varchar(100),
@Password varchar(100)
As
begin


Select * from UserDetails ud
left outer join UserType ut
on ud.UserTypeId=ut.UserTypeId
and ud.UserName=@UserName 
and ud.UserPAssword=@Password 

end

