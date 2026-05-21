USE master;
GO

CREATE DATABASE CADcharlie;
GO

USE CADcharlie;
GO

CREATE TABLE [dbo].[Product](
	[ProductID] int IDENTITY(1,1) NOT NULL,
	[ProductName] nvarchar(64) NOT NULL,
	[Price] decimal(6, 2) NOT NULL,
	[Quantity] int NOT NULL,
	[CategoryID] int NOT NULL,
	[SupplierID] int NOT NULL,
	PRIMARY KEY (ProductID)
	);
GO

CREATE TABLE [dbo].[Category](
	[CategoryID] int IDENTITY(1,1) NOT NULL,
	[CategoryName] nvarchar(64) NOT NULL,
	PRIMARY KEY (CategoryID)
	);
GO

CREATE TABLE [dbo].[Supplier](
	[SupplierID] int IDENTITY(1,1) NOT NULL,
	[SupplierName] nvarchar(64) NOT NULL,
	[SupplierEmail] nvarchar(64) NOT NULL,
	[SupplierPhone] nvarchar(64) NOT NULL,
	PRIMARY KEY (SupplierID)
	);
GO

ALTER TABLE [dbo].[Product]  ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([SupplierID]) 
REFERENCES [dbo].[Supplier] ([SupplierID])
ON UPDATE CASCADE 
ON DELETE CASCADE;
GO
