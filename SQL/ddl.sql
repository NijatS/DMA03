--1)Create Tables

--Create a table named students with the following columns:
--student_id (Integer)
--first_name (VARCHAR(50))
--last_name (VARCHAR(50))
--birthdate (DATE)
--enrollment_date (DATE)

create database DMA03;
use DMA03


create table Students(
  student_id int,
  first_name nvarchar(50),
  last_name nvarchar(50),
  birthdate date,
  enrollment_date date
);


--Alter Table
--2)Add a new column email (VARCHAR(100)) to the students table.

Alter table Students
Add email nvarchar(100)
--Drop Table
--3)Drop the table old_students.

Drop table Students

--4)Create Table

--Create a table named courses with the following columns:
--course_id (Integer)
--course_name (VARCHAR(100))
--credits (Integer)



--Create a table named enrollments with the following columns:
--student_id (Integer)
--course_id (Integer)
--enrollment_date (DATE)


create table Courses(
   course_id int,
   course_name nvarchar(100),
   credits int
);

create table Enrollments(
student_id int,
course_id int ,
enrollment_date date
)
--5)Create Table  

--Create a table named employees with the following columns:
--employee_id (Integer)
--first_name (VARCHAR(50))
--last_name (VARCHAR(50))
--hire_date (DATE)
--salary (Decimal(10, 2))

create table Employees(
employee_id int,
first_name varchar(50),
last_name varchar(50),
hire_date date,
salary decimal(8,2)
)


--6)Create Table

--Create a table named departments with the following columns:
--department_id (Integer)
--department_name (VARCHAR(100))
--location (VARCHAR(100))

create table Departments(
department_id int,
department_name varchar(100),
[location] varchar(100)
)


--8)Rename Table

--Rename the table departments to department_info.

exec sp_rename 'Departments','Department_Info'

--9)Drop Column

--Drop the location column from the department_info table.

alter table Department_Info
drop column [location]


--DML

--1)Insert Data

--Insert a new student into the students table with the following details:
--student_id: 1
--first_name: "John"
--last_name: "Doe"
--birthdate: '2000-01-01'
--enrollment_date: '2020-09-01'

Insert into Students(student_id,first_name,last_name,birthdate,enrollment_date)
values (1,'Farid','Ahadov','2000-01-01','2024-01-01')


--Update Data
--2)Update the enrollment_date for the student with 
--student_id 1 to '2020-10-01'.

Update Students 
set enrollment_date = '2020-10-01'
where student_id = 1

Select * from Students

Update Students 
Set email = 'nicat@gmail.com'
where student_id = 1



--Delete Data
--3)Delete the student with student_id 1 from the students table.

Delete from Students
Where student_id = 1



--Insert Data into Multiple Tables
--5)Insert a new course into the courses table with the following details:
--course_id: 101
--course_name: "Database Systems"
--credits: 3

insert into Courses(course_id,course_name,credits)
Values (101,'Database Systems',3)

--Enroll a student into a course by inserting into the enrollments table:
--student_id: 1
--course_id: 101
--enrollment_date: '2020-09-01'

insert into Enrollments(student_id,course_id,enrollment_date)
Values (1,101,'2020-09-01')



--7)Insert Multiple Rows

--Insert the following students into the students table:
--student_id: 2, first_name: "Jane", last_name: "Smith", birthdate: '1999-05-15', enrollment_date: '2020-09-01'
--student_id: 3, first_name: "Mike", last_name: "Johnson", birthdate: '2001-02-20', enrollment_date: '2021-01-15'


insert into Students(student_id,first_name,last_name,birthdate,enrollment_date)
values(2,'Jane','Smith','1999-05-15','2020-09-01'),(2,'Mike','Johnson','2001-02-20','2001-02-20')


--8)Update Multiple Rows

--Update the enrollment_date to '2021-02-01' for all students whose enrollment_date is '2020-09-01'.

Select * from Students

Update Students
Set enrollment_date = '2021-02-01'
where enrollment_date = '2020-09-01'


--9)Delete Rows with Condition

--Delete all students from the students table where the last_name is 'Johnson'.

Delete from Students
Where last_name = 'Johnson'


--10)Select Specific Columns

--Select the first_name and last_name of all students from the students table.

Select first_name,last_name from Students
