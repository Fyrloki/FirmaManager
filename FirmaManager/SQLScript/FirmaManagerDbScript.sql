--===========================--
--------CREATE DATABASE--------
--===========================--

USE master
GO

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'DieFirma')
	BEGIN
		CREATE DATABASE DieFirma
	END
GO

USE DieFirma
GO

--===========================--
---------CREATE TABLES---------
--===========================--

DROP TABLE IF EXISTS dbo.tb_EintrittAustrittMitarbeiter
DROP TABLE IF EXISTS dbo.tb_Mitarbeiter
DROP TABLE IF EXISTS dbo.tb_Kauf
DROP TABLE IF EXISTS dbo.tb_Kunde
DROP TABLE IF EXISTS dbo.tb_Person
DROP TABLE IF EXISTS dbo.tb_ErrorList
DROP TABLE IF EXISTS dbo.tb_Name
DROP TABLE IF EXISTS dbo.tb_Lesson
GO

CREATE TABLE dbo.tb_Person
(
	[UID]			UNIQUEIDENTIFIER PRIMARY KEY	NOT NULL
    ,PersonNummer   NVARCHAR(4)			UNIQUE      NOT NULL
	,Vorname		NVARCHAR(30)					NOT NULL
	,[Name]			NVARCHAR(30)					NOT NULL
	,Geburtsdatum	DATETIME						NOT NULL
	,Geschlecht		BIT								NOT NULL
)
GO

--------DML--------			--- 0 = weiblich, 1 = männlich ---
																								
INSERT INTO dbo.tb_Person
	 ([UID],        PersonNummer,		Vorname,    [Name],		Geburtsdatum,	Geschlecht) VALUES
	 (NEWID(),	    '005',              'Guguss',   'Meier',	'04/18/1977',	0)
	,(NEWID(),	    '008',              'Brasil',   'Meier',	'04/18/1976',	0)
	,(NEWID(),	    '007',              'Homer',    'Meier',	'04/18/2000',	0)
	,(NEWID(),	    '227',              'Monika',   'Meier',	'04/18/1975',	0)
	,(NEWID(),		'A002',             'Hans',	    'Müller',	'12/14/1970',	1)
	,(NEWID(),		'B003',             'Jack',	    'Barbur',	'08/30/1995',	1)
	,(NEWID(),		'B001',		        'Hugo',	    'Peter',	'08/30/1950',	1)
GO