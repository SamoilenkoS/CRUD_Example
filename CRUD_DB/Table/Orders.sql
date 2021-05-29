CREATE TABLE dbo.Orders (
    Id INT NOT NULL IDENTITY(1, 1),
    CustomerId INT NOT NULL,
    CONSTRAINT FK_Customers_Id FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    CONSTRAINT PK_Orders_Id PRIMARY KEY (Id)
)