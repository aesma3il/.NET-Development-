# Database & SQL Fundamentals

## Installing SQL Server 2022
- How to install SQL Server 2022

## Revision
- Differences between Data, Information, Knowledge and Wisdom
- Differences between Data Structure and Database

## Introduction to Databases
- What is Database?
- What is NULL?
- Primary Key vs Foreign Key / Referential Integrity
- What is Redundancy? and why it's a problem?
- What is Data Integrity? and Why it's Important and Critical?
- What is Constraint? and Why it's Important?
- What is SQL?
- DBMs vs RDBMS Summary

# Database Design: Conceptual Design

## Entity Relationship Diagram (ERD)
- What is ERD? and Why?
- ERD Symbols
- Components of ERD
- Entity (Strong) and Weak Entity
- Attributes
- Relationships
- One-to-One Relationship
- One-to-Many / Many-to-One Relationship
- Many-to-Many Relationship
- Cardinality vs Ordinality
- Cardinality Symbols and Practices
- Total vs Partial Participation
- Process of Creating ERD Step by Step - Small Project
- Recommended ERD Software to Use
- Aggregation / Associative Entities
- Generalization
- Specialization

# Relational Schema

## Converting ERD to Relational Schema
- What is Relational Schema?
- Convert Self Referential to Relational Schema
- Convert Composite, Multivalued, Derived Attributes to Relational Schema
- Convert One-to-One to Relational Schema
- Convert One-to-Many / Many-to-One to Relational Schema
- Convert Many-to-Many to Relational Schema
- Generalization and Specialization to Relational Schema
- Convert Associative Entity to Relational Schema
- How to create Relational Schema on ERDPlus.com

# SQL - Data Definition Language (DDL)

## Database Operations
- Create Database
- Create Database IF NOT EXISTS
- Switch Database
- Drop Database
- Drop Database IF EXISTS
- Backup Database
- Differential Backup
- Restore Database

## Table Operations
- Create Table
- SQL DataTypes
- Drop Table

## Alter Table
- Add Column
- Rename Column
- Rename a table
- Modify a column
- Delete a column

# SQL - Data Manipulation Language (DML)

## CRUD Operations
- Insert Into Statement
- Update Statement
- Delete Statement
- Select Into Statement
- Insert Into .. Select From Statement

## Special Operations
- Identity Field (Auto Increment)
- Delete vs Truncate statement
- Foreign Key Constraint
- Solution To "Saving changes is not permitted" error

# SQL - Queries

## Basic Queries
- Restore Sample HR Database
- Select Statement
- Select Distinct Statement
- Where Statement with AND, OR, NOT
- In Operator
- Sorting with Order By
- Select Top Statement
- Select As (Aliases)
- Between Operator

## Aggregate Functions
- Count, Sum, Avg, Min, Max Functions
- Group By
- Having

## Pattern Matching
- Like
- WildCards

# SQL - Joins

- Restore Shop Database
- Inner Join
- Left Outer Join
- Right Outer Join
- Full Outer Join

# SQL - Views

- Views

# Advanced SQL Queries

- Exists
- Union
- Case

# SQL - Constraints

- What is Constraint? and Why it's Important?
- Primary Key Constraint
- Foreign Key Constraint
- Not Null Constraint
- DEFAULT Constraint
- Check Constraint
- Unique Constraint
- SQL Index

# Database Normalization

- What is Normalization?
- First Normal Form (1NF)
- Second Normal Form (2NF)
- Third Normal Form (3NF)
- Boyce Codd Normal Form (BCNF), 4NF and 5NF

# SQL Projects & Practice

## Relational Diagram Projects
- Project 1 - Simple Clinic (Requirements and Solution)
- Project 2 - Simple Library (Requirements and Solution)
- Project 3 - Karate Club (Requirements and Solution)
- Project 4 - Car Rental (Requirements and Solution)
- Project 5 - Online Store (Requirements and Solution)

## Database Utilities
- What is GUID? and how to use it In Database?
- Buy and Import Data
- Extract Data to a Separate Table

# SQL Problems (Practice Exercises)

## Basic Queries
- Create Master View
- Get all vehicles made between 1950 and 2000
- Get number of vehicles made between 1950 and 2000
- Get number of vehicles made between 1950 and 2000 per make ordered by Number Of Vehicles Descending
- Get all makes that have manufactured more than 12000 Vehicles in years 1950 to 2000
- Get number of vehicles made between 1950 and 2000 per make with total vehicles column
- Get number of vehicles made between 1950 and 2000 per make with total and percentage
- Get Make, FuelTypeName and Number of Vehicles per FuelType per Make
- Get all vehicles that run with GAS
- Get all makes that run with GAS
- Get total makes that run with GAS

## Aggregation and Grouping
- Count vehicles by make ordered by NumberOfVehicles from high to low
- Get all makes with count of vehicles that manufacture more than 20K Vehicles
- Get total makes that manufacture DriveTypeName = FWD
- Get total vehicles per DriveTypeName per Make ordered by make asc then by total desc
- Get total vehicles per DriveTypeName per Make then filter only results with total > 10,000

## String Pattern Matching
- Get all makes with make starts with 'B'
- Get all makes with make ends with 'W'
- Get all makes that manufacture DriveTypeName = FWD

## NULL Handling
- Get all vehicles where number of doors is not specified
- Get total vehicles where number of doors is not specified
- Get percentage of vehicles that have no doors specified

## Multi-Table Queries
- Get MakeID, Make, SubModelName for all vehicles that have SubModelName 'Elite'
- Get all vehicles with Engines > 3 Liters and only 2 doors
- Get make and vehicles where engine contains 'OHV' and Cylinders = 4
- Get all vehicles where body is 'Sport Utility' and Year > 2020
- Get all vehicles where body is 'Coupe' or 'Hatchback' or 'Sedan'
- Get all vehicles where body is 'Coupe' or 'Hatchback' or 'Sedan' and manufactured in year 2008 or 2020 or 2021

## Conditional Logic
- Return found=1 if there is any vehicle made in year 1950
- Get Vehicle_Display_Name, NumDoors with description column (if door is null display 'Not Set')
- Get Vehicle_Display_Name, year with age column, sort by age desc
- Get vehicles where age between 15 and 25 years

## Statistical Analysis
- Get Minimum, Maximum, and Average Engine CC of all vehicles
- Get all vehicles with minimum Engine_CC
- Get all vehicles with maximum Engine_CC
- Get all vehicles with Engine_CC below average
- Get total vehicles with Engine_CC above average
- Get all unique Engine_CC sorted descending

## Advanced Filtering
- Get the maximum 3 Engine CC values
- Get all vehicles with one of the top 3 Engine CC
- Get all makes that manufacture one of the top 3 Engine CC
- Get unique Engine_CC with calculated tax per Engine CC

## Complex Aggregations
- Get make and total number of doors manufactured per make
- Get total number of doors manufactured by 'Ford'
- Get number of models per make
- Get the highest 3 manufacturers by number of models
- Get the highest number of models manufactured
- Get the highest manufacturers that produced the highest number of models
- Get the lowest manufacturers that produced the lowest number of models

## Miscellaneous
- Get all fuel types, each time results in random order

# Self-Referential Queries

- Restore sample database
- Get all employees with manager along with manager's name
- Get all employees with or without manager along with manager's name (show null if no manager)
- Get all employees with or without manager, incase no manager show employee name as manager to himself
- Get all employees managed by 'Mohammed'


# T-SQL (Transact-SQL) Programming

## Introduction to T-SQL
- Introduction to T-SQL

## Variables in T-SQL
- Variables
- Example 1 - Employee Report
- Example 2 - Monthly Sales Summary Report
- Example 3 - Employee Attendance Tracking
- Example 4 - Loyalty points

## IF Statement
- Simple IF Statement
- IF...ELSE Statement
- Nested IF Statements
- Using IF with Variables and Conditional Assignments
- Using IF Statement with AND/OR/NOT
- Error Handling with IF
- Using IF with EXISTS
- Best Practices & Summary

## CASE Statement
- CASE Statement
- Simple CASE as SWITCH
- Searched CASE (More Flexible)
- Using CASE in ORDER BY (Custom Sorting)
- CASE in UPDATE Statements (Conditional Data Modification)
- Nested Case Statements
- CASE statement within a GROUP BY

## Loops Statements In T-SQL
- WHILE Loops - Example 1 - Simple Counter
- Example 2: Iterating Over a Table
- Example 3 - Loop with Conditional Exit
- Example 4 - Nested While Loops - 10 x 10 Multiplication Table
- Example 5 - 10 x 10 Matrix Multiplication Table
- Example 6 - BREAK and CONTINUE Statements
- Important: There is No For Loop or Do While Statement In T-SQL

## BEGIN...END Blocks
- BEGIN...END Blocks in T-SQL

## Error Handling
- Error Handling in T-SQL - Try .. Catch
- Error Functions
- THROW Statement
- @@ERROR Function

## @@ROWCOUNT
- @@ROWCOUNT

## Transactions
- Introduction to Transactions
- Example Performing a Bank Transfer

## Table Variables
- Table Variables in T-SQL
- Example

## Temporary Tables
- Introduction to Temporary Tables
- Example
- Differences between Temp Table vs Table Variable
- Differences between temporary tables and normal (permanent) tables

## Stored Procedures
- Stored Procedures in T-SQL
- CREATE: Add a New Person SP
- READ: Get All People
- READ: Get Person By ID way 1
- READ: Get Person By ID way 2
- UPDATE: Update a Person's Details
- DELETE: Remove a Person
- RETURN Statement
- Drop SP
- SP_HELPTEXT command

## Built-In Functions
- String Functions
- Date Functions
- Aggregate functions (SUM, AVG, COUNT, MIN, MAX)

## Window Functions
- What is Window Functions?
- Understanding the ROW_NUMBER() Function in SQL
- Understanding the RANK() Function in SQL
- Understanding the Difference Between RANK and DENSE_RANK in SQL
- Using the RANK() Function with PARTITION BY in SQL
- Aggregate Functions with Partition
- Exploring LAG and LEAD Functions Using a Single SQL Query
- Paging in SQL using OFFSET and FETCH NEXT

## Scalar Functions
- Scalar Functions in T-SQL

## Table-Valued Functions
- Inline Table-Valued Functions (ITVFs) in T-SQL
- Using Inline Table-Valued Functions with JOIN in T-SQL
- Multi-Statement Table-Valued Functions (MTVFs) in T-SQL

## Dynamic SQL and SQL Injection Attack
- Dynamic SQL
- SQL injection attack

## Triggers
- Introduction to Triggers in T-SQL

## After Triggers
- After Insert Triggers in T-SQL
- After Update Triggers in T-SQL
- After Delete Triggers in T-SQL
- Inserted and Deleted Tables in T-SQL Triggers

## Instead of Triggers
- Understanding Instead Of Triggers in T-SQL
- Instead Of Delete Trigger in T-SQL
- Instead of Update Trigger in T-SQL
- Instead of Delete Trigger in T-SQL

## Cursors in T-SQL
- Introduction to Cursors in T-SQL
- Static Cursors in T-SQL
- Dynamic Cursors in T-SQL
- Forward-Only Cursors in T-SQL
- Scrollable Cursors in T-SQL

## Common Table Expressions (CTE)
- Common Table Expressions (CTEs) in T-SQL
- Recursive CTE Example 1
- Understanding Recursive CTEs for Building Employee Hierarchies
- Generating a Date Series Using CTE
- Identifying Duplicate Records Using CTE in T-SQL
- Ranking Items Using CTE
- Calculating Average Sales of Top Performing Employees Using CTE