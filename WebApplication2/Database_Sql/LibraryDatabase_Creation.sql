-- Drop if exists (for testing)
DROP DATABASE IF EXISTS LibraryDB;
CREATE DATABASE LibraryDB;
USE LibraryDB;

-- USERS table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    UserType NVARCHAR(20) CHECK (UserType IN ('Student', 'Staff')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- AUTHORS table
CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

-- CATEGORIES table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) UNIQUE NOT NULL
);

-- BOOKS table
CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(150) NOT NULL,
    AuthorID INT FOREIGN KEY REFERENCES Authors(AuthorID),
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    ISBN NVARCHAR(13) UNIQUE NOT NULL,
    PublishedYear INT CHECK (PublishedYear BETWEEN 1000 AND YEAR(GETDATE()))
);

-- BOOK COPIES table (physical books)
CREATE TABLE BookCopies (
    CopyID INT PRIMARY KEY IDENTITY(1,1),
    BookID INT FOREIGN KEY REFERENCES Books(BookID),
    IsAvailable BIT DEFAULT 1,
    ShelfLocation NVARCHAR(50)
);

-- LOANS table
CREATE TABLE Loans (
    LoanID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    CopyID INT FOREIGN KEY REFERENCES BookCopies(CopyID),
    IssueDate DATE,
    DueDate DATE,
    ReturnDate DATE
);

-- RESERVATIONS table
CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    BookID INT FOREIGN KEY REFERENCES Books(BookID),
    ReservationDate DATE,
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Fulfilled', 'Cancelled'))
);

-- PENALTIES table
CREATE TABLE Penalties (
    PenaltyID INT PRIMARY KEY IDENTITY(1,1),
    LoanID INT FOREIGN KEY REFERENCES Loans(LoanID),
    Amount DECIMAL(6,2),
    IsPaid BIT DEFAULT 0,
    IssuedDate DATE
);

-- STAFF ROLES (for extended user permissions)
CREATE TABLE StaffRoles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Role NVARCHAR(20) CHECK (Role IN ('Librarian', 'Admin')),
    AssignedDate DATE
);

-- USERS
INSERT INTO Users (FullName, Email, UserType)
VALUES
('Ali Khan', 'ali.khan@example.com', 'Student'),
('Sara Ali', 'sara.ali@example.com', 'Student'),
('John Doe', 'john.doe@library.com', 'Staff'),
('Hina Rauf', 'hina.rauf@library.com', 'Staff');

-- AUTHORS
INSERT INTO Authors (Name)
VALUES
('George Orwell'),
('J.K. Rowling'),
('Jane Austen'),
('Stephen King');

-- CATEGORIES
INSERT INTO Categories (Name)
VALUES
('Fiction'),
('Science'),
('History'),
('Fantasy');

-- BOOKS
INSERT INTO Books (Title, AuthorID, CategoryID, ISBN, PublishedYear)
VALUES
('1984', 1, 1, '9780451524935', 1949),
('Pride and Prejudice', 3, 1, '9780141040349', 1813),
('Harry Potter and the Sorcerer''s Stone', 2, 4, '9780590353427', 1997),
('The Shining', 4, 1, '9780307743657', 1977);

-- BOOK COPIES
INSERT INTO BookCopies (BookID, ShelfLocation)
VALUES
(1, 'A1'),
(1, 'A2'),
(2, 'B1'),
(3, 'C1'),
(3, 'C2'),
(4, 'D1');

-- LOANS
INSERT INTO Loans (UserID, CopyID, IssueDate, DueDate, ReturnDate)
VALUES
(1, 1, '2025-07-01', '2025-07-15', NULL),        -- Not returned yet
(2, 3, '2025-07-05', '2025-07-20', '2025-07-12'); -- Returned early

-- RESERVATIONS
INSERT INTO Reservations (UserID, BookID, ReservationDate, Status)
VALUES
(1, 3, '2025-07-10', 'Pending'),
(2, 1, '2025-07-11', 'Fulfilled');

-- PENALTIES
INSERT INTO Penalties (LoanID, Amount, IsPaid, IssuedDate)
VALUES
(1, 100.00, 0, '2025-07-16'),
(2, 50.00, 1, '2025-07-13');

-- STAFF ROLES
INSERT INTO StaffRoles (UserID, Role, AssignedDate)
VALUES
(3, 'Librarian', '2025-01-01'),
(4, 'Admin', '2025-03-01');

