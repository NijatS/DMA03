--*View: ActiveCustomers
--List all customers who have placed at least one order.

create view ActiveCustomersDMA03
as
Select c.CustomerID , c.ContactName from Customers c 
inner join Orders o
on o.CustomerID = c.CustomerID
group by c.CustomerID , c.ContactName


select * from ActiveCustomersDMA03

--*View: ProductsInStock
--List all products that are currently in stock.


create view ProductInStockDMA03
as
Select * from Products
Where UnitsInStock > 0

select * from ProductInStockDMA03

--*View: EmployeeContactInfo
--Show a list of employees with their contact information.

go
Create view EmployeeContactInfoDMA03
as
Select FirstName+' ' + LastName as [Name],HomePhone from Employees

Select * from EmployeeContactInfoDMA03

--*View: OrdersByCountry
--List the number of orders placed by customers from each country.

create view OrdersByCountryDMA03
as
Select c.Country, COUNT(OrderId) as [Total Orders] from Orders o
join Customers c 
on o.CustomerID = c.CustomerID
group by c.Country

Select * from OrdersByCountryDMA03

--*View: ProductSales
--Show the total sales for each product.

create view ProductSalesDMA03
as
Select p.ProductName,SUM(Quantity * od.UnitPrice * (1-Discount)) as [Total Sales] 
from [Order Details] od
join Products p
on od.ProductID  = p.ProductID
group by p.ProductName

Select * from ProductSalesDMA03


--*View: ShippedOrders
--List all orders that have been shipped, along with their shipment date.

create view ShippedOrdersDMA03
as
Select * from Orders
Where ShippedDate is not null

Select * from ShippedOrdersDMA03

--*View: MonthlySales
--Show the total sales for each month.

Create view MonthlySalesDMA03
as 
Select MONTH(o.ShippedDate) as [Month] ,
Sum(UnitPrice * Quantity * (1-Discount)) as [Total Sales]
from Orders o
inner join [Order Details] od
on o.OrderID = od.OrderID
group by MONTH(ShippedDate)


--*Procedure: GetCustomerOrders
--This procedure retrieves all orders placed by a specific customer.
go
Alter procedure GetCustomerOrdersDMA03
@CustomerId nchar(5) as
Select * from Orders
Where CustomerID = @CustomerId
go
exec GetCustomerOrdersDMA03 @CustomerId = 'HANAR'

--*Procedure: GetProductsInStock
--This procedure retrieves all products that are currently in stock.


create procedure GetProductsInStockDMA03
as 
Begin
Select * from  Products
Where UnitsInStock >0
End

exec GetProductsInStockDMA03

--*Procedure: GetOrdersByCountry
--This procedure retrieves the number of orders placed 
--by customers from a specific country.

Alter Procedure GetOrdersByCountryDMA03
@CountryName nvarchar(15) 
as
Begin  
Select C.CustomerID, Country,Count(OrderId) as [Orders Count] from Orders o
join Customers c
on o.CustomerID = c.CustomerID
group by c.CustomerID,c.Country
having c.Country = @CountryName
End

exec GetOrdersByCountryDMA03 @CountryName = 'Germany'


Select * from Customers