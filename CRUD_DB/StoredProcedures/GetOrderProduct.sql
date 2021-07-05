create procedure [dbo].[GetOrderProduct]
as
SELECT op.OrderId
      ,op.ProductId
      ,op.Count
      ,p.Title
  FROM dbo.Order_Product op
  inner join dbo.Products p
  on op.ProductId = p.Id