
--Task 1: Count Orders by Customer
--Write a query to count the number of orders placed by each customer, 
--showing only those customers who have placed more than 5 orders.

Select CustomerID,Count(OrderId) as [Order Count]  from Orders
Group by CustomerID
Having Count(OrderId) >5
Order by  Count(OrderId) desc


--Task 2: Total Quantity Sold by Product
--Write a query to find the total quantity of each product sold, 
--showing only those products that have sold more than 100 units.


Select ProductID,Sum(Quantity) as [Total Sales] from [Order Details]
Group by ProductID
Having Sum(Quantity) >100



--Task 3: Number of Products in Each Category
--Write a query to count the number of products in each category, 
--showing only those categories with more than 10 products.

Select CategoryID,Count(ProductID) from Products
group by CategoryID
having Count(ProductID) >10

--Task 4: Average Unit Price of Products
--Write a query to find the average unit price of products, 
--showing only those categories with an average unit price greater than $20.

Select CategoryID,AVG(UnitPrice) as [Unit Price] from Products
group by CategoryID
Having AVG(UnitPrice)>=20


--Task 5: Total Freight by Shipper
--Write a query to find the total freight charges handled by each shipper,
--showing only those shippers with total freight charges exceeding $20.000.

Select * from Shippers


Select ShipVia,sum(Freight) as [Total Freight] from Orders
group by ShipVia
having sum(Freight) >20000



--Task 6: Total Sales by Customer
--Write a query to find the total sales amount for each customer, 
--showing only those customers with total sales greater than $1000.

Select CustomerId,Sum(UnitPrice*Quantity) from [Order Details] od
join Orders o
on o.OrderID = od.OrderID
group by CustomerID
having Sum(UnitPrice*Quantity) > 1000


--Task 7: Average Order Quantity by Product
--Write a query to find the average order quantity for each product, 
--showing only those products with an average order quantity greater than 10.

Select ProductID,AVG(Quantity) as [Average Order Quantity] from [Order Details]
group by ProductID
having AVG(Quantity)>10



--Task 8: Total Sales by Employee
--Write a query to find the total sales amount for each employee, 
--showing only those employees with total sales greater than $5000.







--Task 9: Average Discount by Product
--Write a query to find the average discount given on each product,
--showing only those products with an average discount greater than 5%.

Select ProductID,AVG(Discount) as [Average Discount by Product] from [Order Details]
group by ProductID
having AVG(Discount) > 0.05



--Task 10: Count Orders by Employee
--Write a query to count the number of orders handled by each employee,
--showing only those employees who have handled more than 50 orders.


Select EmployeeID,Count(OrderID) as [Count Orders] from Orders
group by EmployeeID
having Count(OrderID)>50


--Task 11: Monthly Sales by Year
--Write a query to find the total sales amount for each month of each year, 
--showing only those months with total sales greater than $10000.





--Task 12: Average Order Value by Year
--Write a query to find the average order value for each year,
--showing only those years with an average order value greater than $500.




--Task 13: Total Quantity Sold by Year
--Write a query to find the total quantity of products sold each year, 
--showing only those years with total quantity sold greater than 1000 units.


--Task 14: Total Freight by Country
--Write a query to find the total freight charges for each country,
--showing only those countries with total freight charges greater than $1000.

select ShipCountry,Sum(Freight) as [Total Freight ] from Orders
group by ShipCountry
having Sum(Freight) > 1000


--Task 15: Average Freight by Country
--Write a query to find the average freight charges for each country, 
--showing only those countries with an average freight charge greater than $50.

select ShipCountry,AVG(Freight) as [Total Freight ] from Orders
group by ShipCountry
having AVG(Freight) > 50


--Task 16: Total Orders by Country and Year
--Write a query to count the number of orders placed in each country for each year, 
--showing only those countries with more than 10 orders in any year.

Select ShipCountry,Year(OrderDate),Count(OrderID) as [Total Orders] from Orders
group by ShipCountry,Year(OrderDate)
Having Count(OrderID) >10


--Task 17: Total Sales by Category and Year
--Write a query to find the total sales amount for each product category for each year, 
--showing only those categories with total sales greater than $10000 in any year.




--Task 18: Total Quantity Sold by Supplier
--Write a query to find the total quantity of products sold by each supplier,
--showing only those suppliers with total quantity sold greater than 1000 units.


Select s.ContactName,Sum(Quantity) as [Total Quantity] from [Order Details] od
join Products p 
on od.ProductID = p.ProductID
join Suppliers s
on p.SupplierID = s.SupplierID
group by s.ContactName
having Sum(Quantity)>1000



--Task 19: Average Discount by Year and Month
--Write a query to find the average discount given each month of each year, 
--showing only those months with an average discount greater than 5%.

Select Year(OrderDate),MONTH(OrderDate),AVG(od.Discount) as [Average Discount] from Orders o
join [Order Details] od
on o.OrderID = od.OrderID
group by Year(OrderDate),MONTH(OrderDate)
having AVG(od.Discount) > 0.05


--Task 20: Total Sales by Employee and Year
--Write a query to find the total sales amount handled by each employee for each year, 
--showing only those employees with total sales greater than $10000 in any year.

