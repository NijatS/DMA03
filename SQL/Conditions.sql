--Easy: Retrieve the first 5 products from the Products table.
Select top(5)* from Products


--Easy: Retrieve all customers whose contact name contains the substring "Maria".

select * from Customers
where ContactName like'%maria%'

--Medium: Retrieve all employees who are in the 'Sales' or 'Marketing' departments.

select * from Employees
where Title like 'sales%' or Title like 'Marketing'

--Medium: Retrieve all orders with a Freight charge between $50 and $200.

select * from Orders
where Freight between 50 and 200

--Hard: Retrieve the top 10 most expensive products.
SELECT TOP(10)* FROM Products
ORDER BY UnitPrice DESC

--Hard: Retrieve all employees who were hired between January 1, 1992, and December 31, 1995.
SELECT * FROM Employees
WHERE HireDate BETWEEN '1992-01-01' AND '1995-12-31'

--Easy: Retrieve all products ordered by ProductName in ascending order.
SELECT * FROM Products
ORDER BY ProductName 

--Easy: Retrieve all customers located in 'Berlin' who have postal codes starting with '1'.
SELECT * FROM Customers
WHERE City='Berlin' AND PostalCode LIKE '1%'


--Medium: Retrieve all employees who are either in the 'Sales Representative' position or have been hired after January 1, 1995.
SELECT * FROM Employees
WHERE Title = 'Sales Representative' OR HireDAte > '1995-01-01'

--Medium: Retrieve all orders ordered by OrderDate in descending order.
SELECT * FROM Orders
ORDER BY OrderDate DESC

--Hard: Retrieve all products that have a UnitPrice between $20 and $50 and a UnitsInStock greater than 100.
SELECT * FROM Products
WHERE (UnitPrice BETWEEN 20 AND 50) AND (UnitsInStock > 100)

--Hard: Retrieve all suppliers who are either located in 'Tokyo' or whose company name starts with 'Exotic'.
SELECT * FROM Suppliers
WHERE (City = 'Tokyo') OR (CompanyName LIKE 'Exotic%')

--Hard: Retrieve the top 10 customers who are either from 'London' or 'Paris' and order them by CompanyName in ascending order.

SELECT TOP(10) * FROM Customers
WHERE (City = 'London') OR (City = 'Paris')
Order By CompanyName


Select * from Customers
Order by CustomerID
OFFSET 20 ROWS FETCH NEXT 5 ROWS ONLY;



--Easy: Retrieve the top 10% of products with the highest UnitPrice.

SELECT TOP(10) Percent * FROM Products ORDER BY UnitPrice DESC

--Medium: Retrieve the bottom 20% of products with the lowest UnitsInStock.

SELECT TOP (20) PERCENT * FROM Products ORDER BY UnitsInStock ASC;


--Medium: Retrieve 30% of orders placed in the year 1996.
SELECT TOP (30) PERCENT * FROM Orders WHERE YEAR(OrderDate) = '1996';

--Easy: Retrieve all products with NULL values in the ReorderLevel column.
SELECT * FROM Products WHERE ReorderLevel = 0;

--Easy: Retrieve all products with non-NULL values in the UnitsInStock column.
SELECT * FROM Products WHERE UnitsInStock <> 0;

SELECT * FROM Products WHERE NOT UnitsInStock = 0;

--Medium: Retrieve all products whose names start with 'C'.
SELECT * FROM Products
WHERE ProductName LIKE 'C%'


--Hard: Retrieve all products with a UnitsInStock less than or equal to 10.
SELECT * FROM Products
WHERE UnitsInStock <= 10
--Hard: Retrieve all customers from 'Berlin' who have postal codes starting with '1' or '2'.
SELECT *FROM Customers
WHERE (City = 'Berlin' AND PostalCode LIKE '1%') OR (City = 'Berlin' AND PostalCode LIKE '2%')
--Medium: Retrieve all products with a UnitPrice not equal to $10.
select *from Products
where UnitPrice <> 10


--Medium: Retrieve all orders with a RequiredDate greater than or equal to '1997-07-01'.
SELECT * FROM ORDERS 
Where RequiredDate >='07.01.1997'





--Hard: Retrieve all products with a UnitsOnOrder less than 10.

SELECT *FROM Products
Where UnitsOnOrder <10
--Hard: Retrieve all employees hired on or before '1994-01-01' who are not Sales Representatives.
SELECT *FROM Employees
where HireDate<'01.01.1994' and Title <>'Sales Representative'

--Hard: Retrieve all orders placed between '1996-01-01' and '1996-03-31' that were shipped after '1996-04-15'.
SELECT * FROM ORDERS 
Where (OrderDate between '09.01.1996'and'11.29.1996' )and (ShippedDate>'10.22.1996')