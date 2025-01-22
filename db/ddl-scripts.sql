/*
Created: 20/01/2025
Modified: 21/01/2025
Model: SQLite 3.7
Database: SQLite 3.7
*/

-- Create tables section -------------------------------------------------

-- Table Orders

CREATE TABLE Orders
(
  Id INTEGER NOT NULL
        CONSTRAINT PK_Orders PRIMARY KEY AUTOINCREMENT,
  CustomerName TEXT NOT NULL,
  State INTEGER NOT NULL,
  CreateDate TEXT NOT NULL,
  ChangeDate TEXT NOT NULL
)
;

-- Table OrderItems

CREATE TABLE OrderItems
(
  Id INTEGER NOT NULL
        CONSTRAINT PK_OrderItems PRIMARY KEY AUTOINCREMENT,
  OrderId INTEGER NOT NULL,
  ProductName TEXT NOT NULL,
  PricePerItem REAL NOT NULL,
  Count INTEGER NOT NULL,
  CONSTRAINT Order_OrderItems
    FOREIGN KEY (OrderId)
    REFERENCES Orders (Id)
)
;

CREATE INDEX IX_OrderId
  ON OrderItems (OrderId)
;

