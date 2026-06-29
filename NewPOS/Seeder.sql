if not exists(select * from Products where ProductName = 'Orange Juice')
begin

	insert into Products(ProductName) values ('Orange Juice')
    insert into Inventory(ProuctID ,Quantity ,UnitPrice) values (SCOPE_IDENTITY() ,1 ,100)

end

DECLARE @UnitId1 INT = SCOPE_IDENTITY();

if not exists(select * from Products where ProductName = 'Milke')
begin

	insert into Products(ProductName) values ('Milke')
    insert into Inventory(ProuctID ,Quantity ,UnitPrice) values (SCOPE_IDENTITY() ,1 ,135)

end



if not exists(select * from Invoices)
begin

	insert into Invoices(CreatedDateTime ,TotalPrice) values (GETDATE() ,0)

	declare @InvoiceID int = SCOPE_IDENTITY()


	insert into ProductsInInvoice(InvoiceID ,UnitID) values (SCOPE_IDENTITY() ,@UnitId1)


	update Invoices 
		set TotalPrice = INV.UnitPrice
		
		from Invoices I inner join ProductsInInvoice PII on I.InvoiceID = PII.InvoiceID
			 inner join Inventory INV on PII.UnitID = INV.UnitID
		where I.InvoiceID = @InvoiceID

end








