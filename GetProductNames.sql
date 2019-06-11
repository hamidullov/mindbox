SELECT p.Name, c.Name
FROM Products p 
LEFT JOIN ProductsInCategories pc 
	ON p.Id = pc.ProductId
LEFT JOIN Categories c 
	ON c.Id = pc.CategoryId