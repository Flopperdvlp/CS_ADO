CREATE TABLE Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    DateOfBirth DATE
);


INSERT INTO Users
    (FirstName, LastName, Email, DateOfBirth)
VALUES
    ('John', 'Doe', 'john.doe@example.com', '1990-01-15'),
    ('Jane', 'Smith', 'jane.smith@example.com', '1985-03-22'),
    ('Michael', 'Johnson', 'michael.johnson@example.com', '1992-07-30'),
    ('Emily', 'Davis', 'emily.davis@example.com', '1988-11-05'),
    ('David', 'Wilson', 'david.wilson@example.com', '1993-09-25');


CREATE TABLE Products
(
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100),
    Price DECIMAL(10, 2),
    Stock INT
);


INSERT INTO Products
    (ProductName, Price, Stock)
VALUES
    ('Laptop', 899.99, 50),
    ('Smartphone', 599.99, 120),
    ('Headphones', 99.99, 200),
    ('Keyboard', 49.99, 150),
    ('Monitor', 179.99, 75);


CREATE TABLE Orders
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    OrderDate DATETIME,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


INSERT INTO Orders
    (UserID, OrderDate, TotalAmount)
VALUES
    (1, '2024-11-01', 899.99),
    (2, '2024-11-02', 1299.99),
    (3, '2024-11-03', 49.99),
    (4, '2024-11-04', 179.99),
    (5, '2024-11-05', 599.99);


CREATE TABLE OrderDetails
(
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);


INSERT INTO OrderDetails
    (OrderID, ProductID, Quantity)
VALUES
    (1, 1, 1),
    (1, 3, 2),
    (2, 2, 1),
    (2, 4, 1),
    (3, 5, 1),
    (4, 1, 1),
    (5, 2, 2);

