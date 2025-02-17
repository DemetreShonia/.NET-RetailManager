CREATE PROCEDURE [dbo].[spInventoryGetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [ProductId], [Quantity], [PurchasePrice], [PurchaseDate]
	FROM dbo.Inventory;
END
