CREATE SCHEMA app;
GO

CREATE TABLE app.Customer
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(25) NOT NULL,
    LastName NVARCHAR(25) NOT NULL,
    Street NVARCHAR(50) NOT NULL,
    City NVARCHAR(25) NOT NULL,
    State NVARCHAR(25) NOT NULL,
    Zip NVARCHAR(5) NOT NULL
);
CREATE TABLE app.Store
(
    StoreNumber INT IDENTITY(1,1) PRIMARY KEY,
    Street NVARCHAR(50) NOT NULL,
    City NVARCHAR(25) NOT NULL,
    State NVARCHAR(25) NOT NULL,
    Zip NVARCHAR(5) NOT NULL
);
CREATE TABLE app.Product
(
    ProductTypeID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(25) NOT NULL
);
CREATE TABLE app.InventoryProduct
(
	InventoryProductID INT IDENTITY (1,1) PRIMARY KEY,
    StoreNumber INT FOREIGN KEY REFERENCES app.Store(StoreNumber) NOT NULL,
    ProductTypeID INT FOREIGN KEY REFERENCES app.Product(ProductTypeID) NOT NULL,
    ProductAmount INT NOT NULL
);
CREATE TABLE app.Orders
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES app.Customer(CustomerID) NOT NULL
);
CREATE TABLE app.OrderProduct
(
	OrderProductID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES app.Orders(OrderID) NOT NULL,
    StoreNumber INT FOREIGN KEY REFERENCES app.Store(StoreNumber) NOT NULL,
    ProductTypeID INT FOREIGN KEY REFERENCES app.Product(ProductTypeID) NOT NULL,
    ProductAmount INT NOT NULL
);
CREATE TABLE app.Manager
(
    ManagerID INT IDENTITY(1,1) PRIMARY KEY,
    StoreNumber INT UNIQUE FOREIGN KEY REFERENCES app.Store(StoreNumber) NOT NULL,
    FirstName NVARCHAR(25) NOT NULL,
    LastName NVARCHAR(25) NOT NULL
);
