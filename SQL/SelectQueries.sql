--Retrieve all records from the Customers table:

select * from Customers

--Select the names of all products:


Select  ProductName from Products


--Get a list of all employees' first and last names:

Select FirstName,LastName  from Employees


--Get the list of all customers in Germany:

Select * from Customers
Where Country = 'Germany'

--Retrieve all orders with a freight cost greater than 100:

Select * from Orders
Where Freight >100

--List all employees who live in London:

Select * from Employees
Where City = 'London'

--Retrieve all categories:

Select  * from Categories
Where CategoryID = 3

--Get the names and contact titles of all suppliers:

Select  ContactName,ContactTitle from Suppliers

--Find orders that were shipped after January 1, 1997:

Select * from Orders
Where ShippedDate > '01-01-1997'

--Select all products with units in stock less than 20:

Select * from Products
Where UnitsInStock <20

--Retrieve the order details for a specific order (e.g., OrderID = 10248):

select * from [Order Details]
Where OrderID = 10248



--Find the company names of all customers in France:

Select CompanyName from Customers
Where Country = 'France'



--Find the names of customers whose contact title is 'Owner':

Select ContactName from Customers
Where ContactTitle = 'owner'


--Find customers in Mexico:

Select * from Customers
Where Country = 'Mexico'


--Retrieve all suppliers from the USA:

Select * from Suppliers
Where Country = 'USA'


--Find all products with discontinued status:

Select * from Products
Where Discontinued = 1

--Get the names and phone numbers of customers in London:

Select ContactName, Phone from Customers
Where City = 'London'


--Select the products that need to be reordered (units on order greater than units in stock):

Select * from Products
Where UnitsInStock <= UnitsOnOrder



--Find all orders with a ship city of 'Paris':

Select * from Orders
Where ShipCity = 'Paris'


--List all products that are not discontinued:
Select * from Products
Where Discontinued =0

--Get orders with a freight cost less than 50:

Select * from Orders
Where Freight <50


--Find products with a stock quantity of exactly 0:

Select * from Products
Where UnitsInStock = 0

--Find orders placed on or after July 1, 1996:

Select * from Orders
Where OrderDate > '07/01/1996'



--Get suppliers from Japan:


Select * from Suppliers
Where Country = 'Japan'


--Find products supplied by supplier ID 1:

select * from Products
Where SupplierID=1