CREATE TABLE dbo.Order_Product (
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Count INT NOT NULL,
    CONSTRAINT PK_Order_Product PRIMARY KEY (OrderId, ProductId),
    CONSTRAINT FK_Orders_Id FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    CONSTRAINT FK_Products_Id FOREIGN KEY (ProductId) REFERENCES Products(Id)
)