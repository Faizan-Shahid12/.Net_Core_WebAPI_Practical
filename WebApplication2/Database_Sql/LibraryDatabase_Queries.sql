Use LibraryDB

Select BookCopies.* From Books
Join BookCopies on BookCopies.BookID = Books.BookID

Alter Procedure GetCopiesofBook @BookName VarChar(255) As
Begin

Select @BookName As Books, Count(BookCopies.IsAvailable) As 'Number of Books' From BookCopies
Join Books on Books.BookID = BookCopies.BookID
Where Books.Title = @BookName

End

Exec GetCopiesofBook @BookName = '1984'

/* Get Name of the Book and the Amount paid of Penalty if Paid*/
Alter Procedure GetLoanedBooks @Name VarChar(255) As
Begin

Select Books.Title, Penalties.Amount From Books
Join BookCopies on Books.BookID = BookCopies.CopyID
Join Loans on BookCopies.CopyID = Loans.LoanID
Join Penalties on Penalties.LoanID = Loans.LoanID
Where Books.Title = @Name AND Penalties.IsPaid = 1

End

Exec GetLoanedBooks @Name = '1984' 

Alter Procedure GetUserNameUsingBooks @Name Varchar(253) = '1984' AS
Begin

Declare @Use Integer

Select @Use= Loans.UserID From Books
Join BookCopies on Books.BookID = BookCopies.BookID
Join Loans on Loans.CopyID = BookCopies.CopyID
Where Books.Title = @Name

Select Users.*, @Name AS 'LoanedBook' From Users
Where Users.UserID = @Use

Select StaffRoles.Role From StaffRoles
Where UserID = @Use

End

Exec GetUserNameUsingBooks