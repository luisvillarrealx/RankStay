CREATE DATABASE RankStayData;
GO
USE RankStayData;
GO

-- Tables with PRIMARY KEY
CREATE TABLE ROLES(
RoleId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
RoleName VARCHAR(30) NOT NULL
); 

CREATE TABLE PROVINCES(
ProvinceId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ProvinceName VARCHAR(30) NOT NULL
);

-- Tables with FOREIGN KEY
CREATE TABLE USERS(
UserId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
UserName VARCHAR(15),
UserLastName1 VARCHAR(15),
UserLastName2 VARCHAR(15),
UserEmail VARCHAR(30),
UserPassword VARCHAR(25),
UserRole INT NOT NULL,
FOREIGN KEY (UserRole) REFERENCES ROLES(RoleId)
);

CREATE TABLE PROPERTIES(
PropertyId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
PropertyProvinceId INT NOT NULL,
PropertyName VARCHAR(100),
PropertyDescription VARCHAR(255),
PropertyUserId INT,
FOREIGN KEY (PropertyProvinceId) REFERENCES PROVINCES(ProvinceId),
FOREIGN KEY (PropertyUserId) REFERENCES USERS(UserId)
);

CREATE TABLE REVIEWS(
ReviewId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ReviewPropertyId INT NOT NULL,
ReviewComment VARCHAR(200), 
ReviewStar FLOAT, 
FOREIGN KEY (ReviewPropertyId) REFERENCES PROPERTIES(PropertyId)
);

-- Inserts
INSERT INTO [dbo].[ROLES]([RoleName])
VALUES ('Admin'), ('User');
GO
INSERT INTO [dbo].[PROVINCES]([ProvinceName])
VALUES ('San José'), ('Alajuela'), ('Cartago'), ('Heredia'), ('Guanacaste'), ('Puntarenas'), ('Limón');
GO

INSERT INTO [dbo].[USERS]
           ([UserName]
           ,[UserLastName1]
           ,[UserLastName2]
           ,[UserEmail]
           ,[UserPassword]
           ,[UserRole])
     VALUES
           ('Luis'
           ,'Villarreal'
           ,'Retes'
           ,'lvillarreal00332@ufide.ac.cr'
           ,'00332'
           ,1),
		('Luis'
           ,'Navarro'
           ,'Murillo'
           ,'lnavarro70469@ufide.ac.cr'
           ,'70469'
           ,1),
	 	('Bryan'
           ,'Rojas'
           ,'Chacón'
           ,'brojas30828@ufide.ac.cr'
           ,'30828'
           ,1),
		('Norlan'
           ,'González'
           ,'Quesada'
           ,'ngonzalez40383@ufide.ac.cr'
           ,'40383'
           ,1)
GO

INSERT INTO [dbo].[PROPERTIES]
           ([PropertyProvinceId]
           ,[PropertyName]
           ,[PropertyDescription]
           ,[PropertyUserId])
     VALUES
           (1
           ,'Residencial San José'
           ,'Residencial privado cerca de La Sabana'
           ,1),
		   (1
           ,'Bosques de San José'
           ,'Apartamentos amplios'
           ,2),
		   (1
           ,'Casas San José'
           ,'Viviendas de 3 habitaciones'
           ,3),
		   (1
           ,'Apartamentos Chepe'
           ,'Apartamentos tipo studio'
           ,4),
		   (2
           ,'Residencial Alajuela'
           ,'Residencial privado cerca de Plaza Real'
           ,1),
		   (2
           ,'Bosques de Alajuela'
           ,'Apartamentos amplios'
           ,2),
		   (2
           ,'Casas Alajuela'
           ,'Viviendas de 3 habitaciones'
           ,3),
		   (2
           ,'Apartamentos La Liga'
           ,'Apartamentos tipo studio'
           ,4),
		   (3
           ,'Residencial Cartagos'
           ,'Residencial privado cerca de La Sabana'
           ,1),
		   (3
           ,'Bosques de Cartago'
           ,'Apartamentos amplios'
           ,2),
		   (3
           ,'Casas Cartago'
           ,'Viviendas de 3 habitaciones'
           ,3),
		   (3
           ,'Apartamentos Bruma'
           ,'Apartamentos tipo studio'
           ,4),
		   (4
           ,'Residencial Heredia'
           ,'Residencial privado cerca de La Sabana'
           ,1),
		   (4
           ,'Bosques de Heredia'
           ,'Apartamentos amplios'
           ,2),
		   (4
           ,'Casas Heredia'
           ,'Viviendas de 3 habitaciones'
           ,3),
		   (4
           ,'Apartamentos Flores'
           ,'Apartamentos tipo studio'
           ,4),
		   (5
           ,'Residencial Guanacaste'
           ,'Residencial privado cerca de La Sabana'
           ,1),
		   (5
           ,'Bosques de Guanacaste'
           ,'Apartamentos amplios'
           ,2),
		   (5
           ,'Casas Guanacaste'
           ,'Viviendas de 3 habitaciones'
           ,3),
		   (5
           ,'Apartamentos Guana'
           ,'Apartamentos tipo studio'
           ,4),
		   (6
           ,'Residencial Puntarenas'
           ,'Residencial privado cerca de La Sabana'
           ,1),
		   (6
           ,'Bosques de Puntarenas'
           ,'Apartamentos amplios'
           ,2),
		   (6
           ,'Casas Puntarenas'
           ,'Viviendas de 3 habitaciones'
           ,3),
		   (6
           ,'Apartamentos Puntarenas'
           ,'Apartamentos tipo studio'
           ,4),
		  (7
           ,'Residencial Limón'
           ,'Residencial privado cerca de La Sabana'
           ,1),
		   (7
           ,'Bosques de Limón'
           ,'Apartamentos amplios'
           ,2),
		   (7
           ,'Casas Limón'
           ,'Viviendas de 3 habitaciones'
           ,3),
		   (7
           ,'Apartamentos Limón'
           ,'Apartamentos tipo studio'
           ,4)
GO

INSERT INTO [dbo].[REVIEWS]
           ([ReviewPropertyId]
           ,[ReviewComment]
           ,[ReviewStar])
     VALUES
            (1,'Excelente en general',5)
		   ,(1,'Buena',4)
		   ,(1,'Regular',3)
		   ,(1,'Mala',2)
		   ,(1,'Muy mala',1)
		   ,(2,'Excelente en general',5)
		   ,(2,'Buena',4)
		   ,(2,'Regular',3)
		   ,(2,'Mala',2)
		   ,(2,'Muy mala',1)
		   ,(3,'Excelente en general',5)
		   ,(3,'Buena',4)
		   ,(3,'Regular',3)
		   ,(3,'Mala',2)
		   ,(3,'Muy mala',1)
		   ,(4,'Excelente en general',5)
		   ,(4,'Buena',4)
		   ,(4,'Regular',3)
		   ,(4,'Mala',2)
		   ,(4,'Muy mala',1)
		   ,(5,'Excelente en general',5)
		   ,(5,'Buena',4)
		   ,(5,'Regular',3)
		   ,(5,'Mala',2)
		   ,(5,'Muy mala',1)
		   ,(6,'Excelente en general',5)
		   ,(6,'Buena',4)
		   ,(6,'Regular',3)
		   ,(6,'Mala',2)
		   ,(6,'Muy mala',1)
		   ,(7,'Excelente en general',5)
		   ,(7,'Buena',4)
		   ,(7,'Regular',3)
		   ,(7,'Mala',2)
		   ,(7,'Muy mala',1)
GO

-- Stored Procedures
CREATE OR ALTER PROCEDURE [dbo].[SP_SignUp]	
@UserEmail VARCHAR(30),
@UserPassword VARCHAR(25)
AS
BEGIN
INSERT INTO USERS(UserEmail, UserPassword, UserRole)
VALUES(@UserEmail, @UserPassword, 1);
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_LogIn]
@userEmail VARCHAR (30),
@userPassword VARCHAR(MAX)
AS 
BEGIN 
SELECT * FROM USERS WHERE 
UserEmail = @userEmail
AND
UserPassword = @userPassword; 
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_ResetPassword]
@UserId INT,
@UserPassword VARCHAR(25)
AS
BEGIN
UPDATE USERS SET 
UserPassword = @UserPassword 
WHERE UserId=@UserId;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetProvinces]
AS
SELECT * FROM PROVINCES
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetAllUsers]
AS
SELECT UserId, UserName, UserLastName1, UserLastName2, UserEmail, UserPassword, UserRole, ROLES.RoleName
FROM USERS
INNER JOIN ROLES
ON USERS.UserRole = ROLES.RoleId
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetReviews]
AS
SELECT 
    REVIEWS.ReviewId,
    PROPERTIES.PropertyName,
    PROVINCES.ProvinceName,
    REVIEWS.ReviewComment,
    REVIEWS.ReviewStar
FROM 
    REVIEWS
INNER JOIN 
    PROPERTIES 
ON 
    REVIEWS.ReviewPropertyId = PROPERTIES.PropertyId
INNER JOIN
    PROVINCES
ON
    PROPERTIES.PropertyProvinceId = PROVINCES.ProvinceId;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetAllProperties]
AS
SELECT 
    P.PropertyId,
    PR.ProvinceName,
    P.PropertyName,
    P.PropertyDescription,
    P.PropertyUserId
FROM 
    PROPERTIES P
INNER JOIN 
    PROVINCES PR
ON 
    P.PropertyProvinceId = PR.ProvinceId;
GO
CREATE OR ALTER   PROCEDURE [dbo].[SP_RegisterProperty]	
@PropertyProvinceId INT,
@PropertyName VARCHAR(100)
AS
BEGIN
INSERT INTO PROPERTIES(PropertyProvinceId, PropertyName)
VALUES(@PropertyProvinceId, @PropertyName);
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetReviewsByProperty]
    @ReviewPropertyId INT
AS
BEGIN
    SELECT *
    FROM REVIEWS
    WHERE ReviewPropertyId = @ReviewPropertyId;
END
--EXEC dbo.[SP_GetReviewsByProperty] @PropertyId = 1;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetPropertiesByProvince]
    @PropertyProvinceId INT
AS
BEGIN
    SELECT *
    FROM PROPERTIES
    WHERE PropertyProvinceId = @PropertyProvinceId;
END
--EXEC dbo.[SP_GetPropertiesByProvince] @ProvinceId = 1;
GO

CREATE OR ALTER   PROCEDURE [dbo].[SP_RegisterReview]	
@ReviewPropertyId INT,
@ReviewComment VARCHAR(200),
@ReviewStar FLOAT
AS
BEGIN
INSERT INTO REVIEWS(ReviewPropertyId, ReviewComment, ReviewStar)
VALUES(@ReviewPropertyId, @ReviewComment, @ReviewStar);
END;
GO