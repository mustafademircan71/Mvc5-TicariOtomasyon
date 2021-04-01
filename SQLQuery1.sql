Create Trigger SatisStokAzalt
on SalesActs
After insert
as
Declare @ProductID int
Declare @Quantity int
Select @ProductID=ProductID,@Quantity=Quantity from inserted
Update Products set Stock=Stock-@Quantity Where ProductID=@ProductID