create database Test
use Test

CREATE TABLE Category
(
	id int primary key IDENTITY(1,1),
	Name nvarchar(50) not NULL
) 


CREATE TABLE Products
(
	id int primary key IDENTITY(1,1),
	Name nvarchar(50) not NULL
)

CREATE TABLE ProductsInCategory
(
	id int primary key IDENTITY(1,1),
	pID int FOREIGN KEY REFERENCES Products(id),
	cID int FOREIGN KEY REFERENCES Category(id),
)



select c.Name,p.Name,t.count  from 
	(SELECT p1.id, count(pc1.id) count
	 FROM  Products p1
	 LEFT JOIN ProductsInCategory pc1 on p1.id = pc1.cID
	 group by p1.ID) t
LEFT JOIN Products p on p.id = t.id
LEFT JOIN ProductsInCategory pc on pc.pID = p.id
LEFT JOIN Category c on c.id =pc.cID 