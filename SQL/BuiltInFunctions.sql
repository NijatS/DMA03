--COUNT(): Counts the number of rows in a table.

Select Count(*) from Products

--SUM(): Adds up the values in a column.
SELECT Sum(UnitPrice) from Products

--AVG(): Calculates the average value of a column.
SELECT AVG(UnitPrice) from Products

--MIN(): Finds the minimum value in a column.

SELECT MIN(UnitPrice) from Products

--MAX(): Finds the maximum value in a column.

SELECT MAX(UnitPrice) FROM Products

--UPPER(): Converts a string to uppercase.

SELECT UPPER(ProductName) FROM Products

--LOWER(): Converts a string to lowercase.

SELECT LOWER(ProductName) FROM Products

--LENGTH(): Returns the length of a string.

SELECT LEN(ProductName) FROM Products

--ROUND(): Rounds a number to a specified number of decimal places.

SELECT ROUND(UnitPrice, -1) FROM Products

--CONCAT(): Concatenates two or more strings.

SELECT CONCAT(CompanyName, ' ', ContactName) FROM Customers

--SUBSTRING(): Extracts a substring from a string.

SELECT SUBSTRING(CompanyName, 1, 5) FROM Customers


--1. Calculate the average unit price of all products:
SELECT AVG(UnitPrice) from Products
--2. Retrieve the maximum and minimum freight charges from the orders table:
SELECT MIN(Freight) AS [Minimum], MAX(Freight) AS [MAXIMUM] FROM Orders
--3. Find the first and last names of employees with a space between them:
SELECT CONCAT(FirstName, ' ', LastName) FROM Employees
--4. Calculate the average discount given on all products:
SELECT AVG(Discount) FROM [Order Details]
--5. Retrieve the total number of orders:
SELECT COUNT(*) FROM Orders

--6. Calculate the total quantity of products ordered:
SELECT SUM(Quantity) FROM [Order Details]

--7. Calculate the average time taken to ship an order (in days):
SELECT AVG(DATEDIFF(DAY, OrderDate, ShippedDate)) FROM Orders

--8. Get the product names of the top 5 most expensive products:
SELECT TOP(5) ProductName FROM Products
Order By UnitPrice DESC

--9. Retrieve the average freight cost for all orders:
SELECT AVG(Freight) FROM Orders

--10. Get the highest unit price of all products:
SELECT MAX(UnitPrice) FROM Products

SELECT OrderID, DATEDIFF(DAY, OrderDate, ShippedDate) 
AS[NECE GUNE CATDIRILDI.] FROM Orders 

SELECT CONCAT(LastName,' ', FirstName) 
AS[FULLNAME] ,DATEDIFF(YEAR, BirthDate, HireDate) 
AS[NECE YASINDA ISE DAXIL OLUB.] FROM Employees


select * from Orders
where power(Freight, 2) <=100

SELECT CAST(ROUND(UnitPrice, 0) as INT) FROM Products;

SELECT ProductName,
CASE 
	WHEN Discontinued = 1 THEN 'ENDIRIMLI'
	WHEN Discontinued = 0 THEN 'ENDIRIMSIZ'
END AS [ENDIRIM]

FROM Products;

SELECT ContactName, ContactTitle ,
CASE 
	WHEN ContactTitle LIKE '%Manager%' THEN 'MGR'
	WHEN ContactTitle LIKE '%Agent%' THEN 'AGT'
	WHEN ContactTitle LIKE '%Representative%' THEN 'RPR'
	WHEN ContactTitle LIKE '%Assistant%' OR ContactTitle LIKE '%Associate%' THEN 'AST'
	WHEN ContactTitle LIKE '%Administrator%' OR ContactTitle LIKE '%Owner%' THEN '001'
END AS [MUSHTERIKODU]
from Customers


--Task 1: Classify Orders Based on Freight Cost
--Write a query to classify orders into three categories based on their freight cost: 'Low' for freight less than 50, 'Medium' for freight between 50 and 100, and 'High' for freight over 100.
SELECT OrderID,
CASE 
	WHEN Freight < 50 THEN 'Low'
	WHEN Freight BETWEEN 50 AND 100 THEN 'Medium'
	WHEN Freight > 100 THEN 'High'
END AS [FREIGHT_CATEGORY]
FROM ORDERS;

--Task 2: Determine Employee Salary Grade
--Write a query to determine the salary grade of employees based on their salary: 'Junior' for salaries below 30000, 'Mid' for salaries between 30000 and 50000, and 'Senior' for salaries above 50000.

SELECT COUNT(EmployeeID),
CASE 
	WHEN Extension * 12 < 30000 THEN 'JUNIOR'
	WHEN Extension * 12 BETWEEN 30000 AND 50000 THEN 'MID'
	WHEN Extension * 12 > 50000 THEN 'SENIOR'
END AS ANNUAL_SALARY 
FROM Employees
GROUP BY  CASE 
           WHEN Extension * 12 < 30000 THEN 'JUNIOR'
           WHEN Extension * 12 BETWEEN 30000 AND 50000 THEN 'MID'
           WHEN Extension * 12 > 50000 THEN 'SENIOR'
       END;
