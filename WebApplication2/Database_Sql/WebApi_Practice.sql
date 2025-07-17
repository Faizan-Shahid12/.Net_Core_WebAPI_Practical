Use BookTemp

Select * From Books

Create Procedure GetAllBooks As
Begin

Select * From Books

End

Create Procedure AddNewBook @Title VarChar(255), @Author VarChar(255), @Description VarChar(255) As
Begin

Insert into Books(Title,Author,Description) Values (@Title,@Author,@Description)

End


Create Procedure DeleteBook @Id Integer As
Begin

Delete From Books Where Books.Id = @Id

End

