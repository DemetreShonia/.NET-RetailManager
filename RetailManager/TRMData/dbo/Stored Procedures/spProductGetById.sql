CREATE PROCEDURE [dbo].[spProductGetById]
	@Id INT
AS
BEGIN
	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
	FROM dbo.Product
	where @Id = @Id;
END
