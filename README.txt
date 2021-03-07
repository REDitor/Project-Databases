Report Assignment 2 (Variant A):
============================================================================================================
SomerenDAL --> Student_DAO.cs:
	- Changed querry string to retrieve the data needed (not using SELECT *).
	- Added required variables inherited from Model Layer(SomerenModel) and used by sql-query for the 
	  students.

SomerenLogic --> Student_Services.cs:
	- Separated 'Name' variable inherited from SomerenModel/Student.cs into 'FirstName' and 'LastName'
	  for testing purposes.

SomerenModel --> Student.cs:
	- Changed and added properties to meet the variables used by the database connection.

SomerenUI --> SomerenUI.cs(Form Design):
	- Changed property 'view' to show details (for displaying columns).
	
SomerenUI --> SomerenUI.cs(code):
	- Added ColumnHeader Objects for each required column header.
	- Added SubItems to tthe ListViewItems with 'li.SubItems.Add(column)'
	- Added AutoResizeColumns method for both ColumnContent and HeaderSize.

EXTRA:
	- Added 'dateOfBirth' property to dbo.student within the database using an SQL query.
	- Updated 'studentID' for student 'Fehri Imen'
	