



--Creating Tables

if not exists (select * from sys.tables where name = 'Inventory')
begin

	CREATE TABLE [dbo].[Inventory](
		[UnitID] [int] IDENTITY(1,1) NOT NULL,
		[ProuctID] [int] NOT NULL,
		[Quantity] [smallint] NOT NULL,
		[UnitPrice] [decimal](5, 2) NOT NULL,
	 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([UnitID] ASC 
	 )
	 )

end



if not exists (select * from sys.tables where name = 'Invoices')

 begin
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[TotalPrice] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
))
end

if not exists (select * from sys.tables where name = 'Products')
begin

	CREATE TABLE [dbo].[Products](
		[ProductID] [int] IDENTITY(1,1) NOT NULL,
		[ProductName] [nvarchar](200) NOT NULL,
	 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
	(
		[ProductID] ASC
	))

end


if not exists (select * from sys.tables where name = 'ProductsInInvoice')
begin

CREATE TABLE [dbo].[ProductsInInvoice](
	[ProductInInvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[UnitID] [int] NOT NULL,
 CONSTRAINT [PK_ProductsInInvoice] PRIMARY KEY CLUSTERED 
(
	[ProductInInvoiceID] ASC
))

end

--Adding ForingKeys

--For [ProductsInInvoice] Table

IF OBJECT_ID('dbo.FK_ProductsInInvoice_Inventory', 'F') IS NULL
	begin
				ALTER TABLE [dbo].[ProductsInInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ProductsInInvoice_Inventory] FOREIGN KEY([UnitID])
		REFERENCES [dbo].[Inventory] ([UnitID])
	end


	IF OBJECT_ID('dbo.FK_ProductsInInvoice_Invoices', 'F') IS NULL

	begin
ALTER TABLE [dbo].[ProductsInInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ProductsInInvoice_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])

	end


-- For [Inventory] Table
	IF OBJECT_ID('dbo.FK_Inventory_Products', 'F') IS NULL

	begin
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Products] FOREIGN KEY([ProuctID])
REFERENCES [dbo].[Products] ([ProductID])
	end


--Adding Check Constraints

--For Inventory Table

	IF OBJECT_ID('dbo.CK_Inventory', 'C') IS  NULL
		ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [CK_Inventory] CHECK  (([Quantity]>=(0)))


	IF OBJECT_ID('dbo.CK_Inventory_1', 'C') IS  NULL
		ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [CK_Inventory_1] CHECK  (([UnitPrice]>=(0)))


end


