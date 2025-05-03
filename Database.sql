CREATE DATABASE sqlserver_container;
GO

CREATE TABLE Companies (
    Id INT PRIMARY KEY 
    Name NVARCHAR(100) NOT NULL,
);
GO

CREATE TABLE Products (
    Id INT PRIMARY KEY 
    Name NVARCHAR(100) NOT NULL,
    CompanyId INT NOT NULL,
    FOREIGN KEY (CompanyId) REFERENCES Companies(Id) ON DELETE CASCADE
);
GO

INSERT INTO Companies (Id, Name) VALUES
(1, 'Tech Solutions'),
(2, 'GreenFarm Ltd.'),
(3, 'BuildCorp'),
(4, 'SmartGears'),
(5, 'Foodies Inc.');
GO

INSERT INTO Products (Id, Name, CompanyId) VALUES
(1, 'Laptop Pro', 1),
(2, 'Cloud Server Access', 1),
(3, 'Organic Fertilizer', 2),
(4, 'Smart Sprinkler', 2),
(5, 'Industrial Drill', 3),
(6, 'Safety Helmet', 3),
(7, 'Smart Watch', 4),
(8, 'Fitness Tracker', 4),
(9, 'Vegan Snacks', 5),
(10, 'Energy Drink', 5);
GO