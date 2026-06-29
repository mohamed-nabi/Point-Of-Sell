
--SP and Functions for Products Table


create PROCEDURE SP_AddProduct
    @ProductName nvarchar(200) ,
	@ProductID int output
AS
BEGIN
    SET NOCOUNT ON; 

    insert into Products(ProductName)
	values (@ProductName)
	
	set @ProductID = SCOPE_IDENTITY()
END;


-------------------------------------------------


create PROCEDURE SP_UpdateProduct
	@ProductID int ,@ProductName nvarchar(200),
	@IsSuccess bit output

as
begin

	set nocount on

	Update Products
		set ProductName = @ProductName
			where ProductID = @ProductID

	if(@@ROWCOUNT > 0)
		begin
			set @IsSuccess = 1
		end

	else
		begin


			THROW 51020, 'ProductID Does Not Exist', 1;

		end

end


----------------------------------------------------


create PROCEDURE SP_GetAllProducts
as
begin
	select * from Products
end

----------------------------------------------------
create function FN_CheckProductExists(@ProductID int)
returns bit
as
begin
	DECLARE @Exists BIT;

	
    IF EXISTS (SELECT 1 FROM Products WHERE ProductID = @ProductID)
        SET @Exists = 1; 
    ELSE
        SET @Exists = 0; 

    RETURN @Exists;
end


-------------------------------------------------------
alter PROCEDURE SP_AddInventoryUnit
    @ProductID int ,@Quantity smallint,@UnitPrice decimal(5 ,2),
	@InventoryUnitID int output
AS
BEGIN
    SET NOCOUNT ON; 

	if not exists(select 1 from Products where ProductID = @ProductID)
	begin
		throw 51000 ,'ProductID not Exists' ,1
	end

    insert into Inventory(ProductID ,Quantity ,UnitPrice)
		values(@ProductID ,@Quantity ,@UnitPrice)
	
	set @InventoryUnitID = SCOPE_IDENTITY()
END;

--------------------------------------------------------------------------



create PROCEDURE SP_UpdateInventory
	@InventoryUnitID int ,
	@Quantity smallint,@UnitPrice decimal(5 ,2)
	,@IsSuccess bit output

as
begin

	set nocount on

	Update Inventory
		set Quantity = @Quantity ,
			UnitPrice = @UnitPrice
			where InventoryUnitID = @InventoryUnitID

	set @IsSuccess = iif(@@ROWCOUNT > 0 ,1,0)

end

----------------------------------------------------------------------
create Procedure SP_GetAllInventoryUnits
as

begin

	select * from Inventory

end

---------------------------------------------------------------


create function FN_CheckUnitInventroyExists(@InventoryUnitID int)
returns bit
as
begin
	DECLARE @Exists BIT;

	
    IF EXISTS (SELECT 1 FROM Inventory WHERE InventoryUnitID = @InventoryUnitID)
        SET @Exists = 1; 
    ELSE
        SET @Exists = 0; 

    RETURN @Exists;
end

---------------------------------------------------------------

create procedure SP_GetUnitInventoryByUnitInventoryID
@UnitInventoryID int ,@ProductID int output ,
@Quantity smallint output ,@UnitPrice decimal(5 ,2) output
as
begin


	select @ProductID = @ProductID ,@Quantity = Quantity ,@UnitPrice = UnitPrice
	from Inventory 
	where InventoryUnitID = @UnitInventoryID

end

---------------------------------------------------------------


create Procedure SP_GetAllInvoices
as

begin

	select * from Invoices

end

---------------------------------------------------------------

create procedure SP_GetProductsInInvoiceByInvoiceID
@InvoiceID int
as
begin


	select * from ProductsInInvoice where InvoiceID = @InvoiceID


end

------------------------------------------------------------
create procedure SP_GetProductByID
@ProductID int ,@ProductName nvarchar(200) output
as
begin


	set @ProductName = 
		(select ProductName from Products
			where ProductID = @ProductID)

end

---------------------------------------------------------------


