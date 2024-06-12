--Task 1: Primary Key and Unique Constraints
--Create a table to store customer information. Ensure that each customer has a unique
--identifier as a primary key. Also, ensure that email and phone number are unique for each customer.

--Insert at least three records into the customer table, making sure that email and 
--phone numbers are not duplicated.

create Table Customer_Info(
  Id int Primary key ,
  Email nvarchar(50) Unique,
  PhoneNumber nvarchar(50) Unique
);

Select * from Customer_Info


Insert into Customer_Info
Values(3,'nurlan2@gmail.com','0505005055')


--Task 2: Foreign Key Constraint
--Create two tables: one for departments and one for employees. Ensure that each department has
--a unique identifier as a primary key. The employees table should reference the department table, 
--establishing a foreign key relationship.

--Insert at least three records into the departments table and at least five records into the 
--employees table. Make sure each employee is linked to a valid department.

create table Department(
Id int Primary key,
[Name] nvarchar(50)
);

create table Employee(
Id int Primary key,
[Name] nvarchar(50),
DepartmentId int Foreign key References Department(Id)
);




--Task 3: Check Constraint
--Create a table to store product information. Ensure that the price is always greater than zero 
--and the stock quantity is non-negative using check constraints.

--Insert at least five records into the product table, making sure that all constraints are satisfied.

create table Products(
Id int Primary key Identity,
Price decimal check  (Price > 0)
);

Insert into Products
values (1.01),(5)

Select * from Products



--Task 4: Default Constraint
--Create a table to store order information. Include default values for order 
--date and order status columns.

--Insert at least three records into the order table without specifying values for the columns with 
--default constraints. Verify that the defaults are applied correctly.


create table [Orders](
Id int Primary key Identity,
Order_Date datetime default GetDate(),
Order_Status nvarchar(50) default 'Accepted'
)

insert into Orders(Order_Status)
values ('Shipped')

Select * from Orders



--Task 5: NOT NULL Constraint
--Create a table to store supplier information. Ensure that critical fields such as supplier 
--name and contact email cannot be null.

--Insert at least three records into the supplier table, ensuring that all required fields are filled.


create table Suppliers(
Id int Primary key Identity,
[Name] nvarchar(30) not null,
Contact_Email nvarchar(50) not null
)



--Task 6: Composite Primary Key
--Create a table to store course enrollments. Use a composite primary key to ensure that
--each student-course combination is unique.

--Insert at least four records into the enrollments table, ensuring the uniqueness of the student-course pairs.

create table Course_Enrollment(
StudentId int ,
CourseId int ,
Primary key(StudentId,CourseId)
)


Select * from Course_Enrollment


--Task 7: Cascading Actions with Foreign Keys
--Create two tables: one for authors and one for books. Ensure a foreign key relationship 
--from books to authors with a cascading delete action.

--Insert at least three records into the authors table and at least five records into the 
--books table. Delete one author and observe the effect on the related records in the books table.



--Task 8: Default Constraint
--Create a table to store employee timesheets. Ensure that the hours worked column has a default value of 8 hours.

--Insert at least five records into the timesheets table, some with and some without specifying 
--hours worked. Verify that the default value is correctly applied where not specified.


create table Employee_TimeSheets(
Id int primary key Identity,
HoursWork int default 8
);

insert into Employee_TimeSheets
Values (24)


--Task 9: Check Constraint for Date Range
--Create a table to store event schedules. Ensure that the event date is always in the future 
--using a check constraint.

--Insert at least five records into the event schedules table, ensuring that all event dates are in the future.



--Task 10: Primary Key and Auto-Increment
--Create a table to store inventory items. Ensure that each item has a unique identifier that auto-increments.

--Insert at least five records into the inventory items table without specifying the 
--auto-incrementing identifier. Verify that the identifiers are automatically generated.



--Task 11: Check Constraint with Multiple Conditions
--Create a table to store student grades. Ensure that grades are within the range 0 to 100,
--and if the grade is below 50, the status should be 'Fail'; otherwise, it should be 'Pass'.

--Insert at least five records into the student grades table, ensuring all constraints are satisfied.



--Task 12: Foreign Key with ON UPDATE CASCADE
--Create two tables: one for departments and one for employees. Ensure that if a department ID is updated, 
--the corresponding department ID in the employees table is automatically updated using an ON UPDATE CASCADE action.

--Insert at least three records into the departments table and five records into the employees table.
--Update one department ID and verify the cascade effect on the employees table.



--Task 13: Composite Primary Key
--Create a table to store product orders. Use a composite primary key to ensure that each combination of order
--ID and product ID is unique.

--Insert at least four records into the product orders table, ensuring the uniqueness of the order-product pairs.



--Task 14: Foreign Key with Self-Reference
--Create a table for storing employee information with a self-referencing foreign key to represent managerial hierarchy.

--Insert at least five records into the employee table, with some employees having managers. 
--Ensure the self-referencing foreign key is correctly established.



--Task 15: Check Constraint with Multiple Conditions
--Create a table to store loan applications. Ensure that the loan amount is greater than zero and if
--the loan type is 'Home Loan', the amount must be at least 50,000.

--Insert at least five records into the loan applications table, ensuring all constraints are satisfied.



--Task 16: Default and Check Constraints
--Create a table to store book reviews. Ensure that the review date defaults to the current date 
--and the rating is between 1 and 5.

--Insert at least five records into the book reviews table, some without specifying the review 
--date. Verify that the default date and rating constraints are correctly applied.



--Task 17: NOT NULL Constraint
--Create a table to store project details. Ensure that the project name and start date cannot be null.

--Insert at least five records into the project details table, ensuring that all required fields are filled.



--Task 18: Check Constraint for Numeric Range
--Create a table to store temperature readings. Ensure that the temperature is within the 
--range -50 to 50 degrees Celsius using a check constraint.

--Insert at least five records into the temperature readings table, ensuring all constraints are satisfied.



--Task 19: Check Constraint for String Length
--Create a table to store usernames. Ensure that the username is at least 5 characters long 
--using a check constraint.

--Insert at least five records into the usernames table, ensuring all constraints are satisfied.



--Task 20: Default and Check Constraints on Multiple Columns
--Create a table to store customer orders. Ensure that the order date defaults to the current date, 
--and the order quantity is greater than zero.

--Insert at least five records into the customer orders table, some without specifying the order date.
--Verify that the default date and quantity constraints are correctly applied.