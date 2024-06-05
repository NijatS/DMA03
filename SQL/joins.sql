--1. Retrieve all customers

Select * from Customers

--2. List all orders with their corresponding customer name

Select o.OrderID,c.ContactName from Orders o
inner join Customers c
on o.CustomerID = c.CustomerID

--3. Find the total number of orders placed by each customer sql

select  c.CustomerID,c.ContactName, count(OrderId) as [Total Orders] from Orders o
join Customers c
on c.CustomerID = o.CustomerID
group by c.ContactName,c.CustomerID


--4. List products with their supplier's name

select p.*,s.ContactName from Products p
left join Suppliers s
on p.SupplierID = s.SupplierID


--5. Find the top 5 most expensive products

Select TOP(5)* from Products
order by UnitPrice desc


--6. List all employees who have not reported to anyone 

Select * from Employees
Where ReportsTo is null

--7. Calculate the total sales for each product

Select  ProductName,Round(Sum(od.UnitPrice*Quantity*(1-Discount)),2)
as [Total Sales] from [Order Details] od
inner join Products p 
on od.ProductID = p.ProductID
group by ProductName


--8. Find the total number of products in each category name

Select c.CategoryID,c.CategoryName,Count(p.ProductID) as [Total Products]  from Products p
inner join Categories c
on p.CategoryID = c.CategoryID
group by c.CategoryID,c.CategoryName



--9. List all employees along with their manager's name

Select worker.LastName + ' '+worker.FirstName as [Worker Data],
manager.LastName + ' '+manager.FirstName as [Manager Data] from Employees worker
join Employees manager
on worker.ReportsTo = manager.EmployeeID


--10. Retrieve total sales made in the year 1997

Select Round(Sum(od.Quantity*od.UnitPrice*(1-Discount)),2)  as [Total Sales] from [Order Details] od
join Orders o
on o.OrderID=od.OrderID
Where Year(o.OrderDate) =1997


--11. List all products that have not been ordered

Select * from Products p
left join [Order Details] od
on p.ProductID = od.ProductID
Where OrderID is null


--12. Find customers who have placed more than 10 orders

Select ContactName,Count(OrderId) from Orders o
join Customers c
on c.CustomerID = o.CustomerID
group by ContactName
having Count(OrderId)>10


--13. Find the average unit price of products in each category

Select CategoryName,AVG(UnitPrice) as [ Average Price] 
from Categories c
join Products p 
on c.CategoryID = p.CategoryID
group by CategoryName




--14. List all orders along with the total amount for each order

--15. List the names of customers who have ordered products from the 'Beverages' category

Select distinct cu.ContactName from Categories c
join Products p
on c.CategoryID = p.CategoryID
join [Order Details] od
on od.ProductID = p.ProductID
join Orders o 
on od.OrderID = o.OrderID
join Customers cu
on cu.CustomerID = o.CustomerID
where c.CategoryName = 'Beverages'


--16. List the names of employees and the number of orders they have handled

Select FirstName + ' ' +LastName,Count(OrderID) as [Order Count] from Employees e
inner join Orders o
on o.EmployeeID = e.EmployeeID
group by FirstName,LastName

--17. Find the average discount given on orders

Select  o.OrderID ,AVG(od.Discount) as [Average Discount] from Orders o
join [Order Details] od
on o.OrderID = od.OrderID
group by o.OrderID
having AVG(od.Discount)>0


--18. List all suppliers located in a specific country (e.g., 'USA')

Select * from Suppliers
Where Country = 'USA'

--19. Retrieve the top 5 customer name who have placed the highest number of orders

Select Top(5)c.ContactName,Count(OrderID) as [Total Orders] from Orders o
join Customers c
on o.CustomerID = c.CustomerID
group by c.ContactName
order by Count(OrderID) desc


--20. Task: Retrieve Sales Information for Each Product
--Objective: Write a query to retrieve a list of products along with the total quantity sold and the 
--total sales amount for each product. Sort the results by the total sales amount in descending order.

Select p.ProductName,Sum(od.Quantity),Round(Sum(od.UnitPrice*od.Quantity*(1-od.Discount)),2)
as [Total Sales] from [Order Details] od
inner join Products p 
on p.ProductID = od.ProductID
group by p.ProductName
Order by [Total Sales] desc


--21. Task: Retrieve Basic Customer Order Information
--Objective: Write a query to retrieve a list of all customers and their most recent order details,
--including the customer name, order ID, order date, and total order amount. Sort the results by customer name.


--22. Task: Retrieve Supplier and Product Order Information
--Objective: Write a query to retrieve a list of suppliers and their products, along with the total 
--number of orders and total sales amount for each product. Sort the results by supplier
--name and then by total sales amount in descending order.


