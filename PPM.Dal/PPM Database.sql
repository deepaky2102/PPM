--	Using Database DotNet_Training.
	Use PPM;

/*	Creating Tables. */

--	Create PPM_Project Table.
	Create Table PPM_Project
	(
		ProjectId Bigint Identity (1,1) Primary Key,
		Name NVARCHAR(MAX) Not Null,
		StartDate DateTime Not Null,
		EndDate DateTime Not Null
	);

--	Create PPM_Role Table.
	Create Table PPM_Role
	(
		RoleId Bigint Identity (1,1) Primary Key,
		Name Varchar(100) Not Null
	);

--	Create PPM_Employee Table.
	CREATE TABLE PPM_Employee
	(
		EmployeeId BIGINT IDENTITY(1,1) PRIMARY KEY,
		FirstName NVARCHAR(MAX) NOT NULL,
		LastName NVARCHAR(MAX) NOT NULL,
		Email VARCHAR(100) NOT NULL 
		CHECK 
		(
			Email LIKE '%[A-Za-z0-9]%[A-Za-z0-9.]%[A-Za-z0-9]%@[A-Za-z0-9]%[A-Za-z.]%[cC][oO][mM]' OR
	        Email LIKE '%[A-Za-z0-9]%[A-Za-z0-9.]%[A-Za-z0-9]%@[A-Za-z0-9]%[A-Za-z.]%[aA][cC].[iI][nN]'
		),
		MobileNumber VARCHAR(10) NOT NULL 
		CHECK
		(
			MobileNumber NOT LIKE '%[^0-9]%' AND LEN(MobileNumber) = 10
		),
		Address VARCHAR(300) NOT NULL,
		RoleId BIGINT FOREIGN KEY REFERENCES PPM_Role(RoleId)
	);

--	Create PPM_ProEmpRel Table.
	CREATE TABLE PPM_ProEmpRel
	(
		Id BIGINT IDENTITY (1,1) PRIMARY KEY,
		ProjectId BIGINT FOREIGN KEY REFERENCES PPM_Project(ProjectId),
		EmployeeId BIGINT FOREIGN KEY REFERENCES PPM_Employee(EmployeeId),
		RoleId BIGINT FOREIGN KEY REFERENCES PPM_Role(RoleId),
		Status VARCHAR(10) DEFAULT 'Active'
	);

/*	Inserting The Data Values in Tables: PPM_Project, PPM_Role, PPM_Employee and PPM_ProEmpRel. */

--	Insert Data Values From into PPM_Project.
	Insert Into PPM_Project(Name, StartDate, EndDate) Values ('Btech', '2019-07-08','2023-04-19');

--	Insert Data Values From into PPM_Role.
	Insert Into PPM_Role(Name) Values ('Student');

--	Insert Data Values From into PPM_Employee.
	Insert Into PPM_Employee(FirstName, LastName, Email, MobileNumber, Address, RoleId) Values ('Deepak','Yadav','dy260218@gmail.com','9974901567', 'Silvassa', 1);

--	Insert Data Values From into PPM_ProEmpRel.
	Insert Into PPM_ProEmpRel(ProjectId, EmployeeId) Values (1, 1, 1);

/*	Retrieve Data From Tables: PPM_Project, PPM_Role, PPM_Employee and PPM_ProEmpRel. */

--	Retrieving Data From PPM_Project Table.
	Select ProjectId, Name, StartDate, EndDate From PPM_Project;

--	Retrieving Data From PPM_Project Table.
	Select RoleId, Name From PPM_Role;

--	Retrieving Data From PPM_Employee Table.
	Select EmployeeId, FirstName, LastName, Email, MobileNumber, Address, RoleId From PPM_Employee;

--	Retrieving Data From PPM_ProEmpRel Table.
	Select Id, ProjectId, EmployeeId, RoleId, Status From PPM_ProEmpRel;

--	Retrieve All data from PPM's Tables.
	Select * From PPM_Role;
	Select * From PPM_Project;
	Select * From PPM_Employee;
	Select * From PPM_ProEmpRel;

/* Truncate Tables: PPM_Project, PPM_Role, PPM_Employee and PPM_ProEmpRel. */
	TRUNCATE TABLE PPM_Project;
	TRUNCATE TABLE PPM_Employee;
	TRUNCATE TABLE PPM_Role;
	TRUNCATE TABLE PPM_Project;

/* Delete Tables: PPM_Project, PPM_Role, PPM_Employee and PPM_ProEmpRel. */
	DELETE FROM PPM_Project;
	DELETE FROM PPM_Employee;
	DELETE FROM PPM_Role;
	DELETE FROM PPM_Project;

/* Drop Tables: PPM_Project, PPM_Role, PPM_Employee and PPM_ProEmpRel. */

	Drop Table PPM_ProEmpRel;
	Drop Table PPM_Employee;
	Drop Table PPM_Role;
	Drop Table PPM_Project;