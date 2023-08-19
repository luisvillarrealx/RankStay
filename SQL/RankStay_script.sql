CREATE DATABASE [RankStayData];
GO
USE [RankStayData];
GO

-- Tables with PRIMARY KEY
CREATE TABLE [dbo].[ROLES](
RoleId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
RoleName VARCHAR(30) NOT NULL
); 

CREATE TABLE [dbo].[PROVINCES](
ProvinceId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ProvinceName VARCHAR(30) NOT NULL,
ProvinceDescription VARCHAR(200),
ProvincePhoto VARCHAR(30)
);

-- Tables with FOREIGN KEY
CREATE TABLE [dbo].[USERS](
UserId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
UserName VARCHAR(15),
UserLastName1 VARCHAR(15),
UserLastName2 VARCHAR(15),
UserEmail VARCHAR(30),
UserPassword VARCHAR(25),
UserRole INT NOT NULL,
FOREIGN KEY (UserRole) REFERENCES ROLES(RoleId)
);

CREATE TABLE [dbo].[PROPERTIES](
PropertyId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
PropertyProvinceId INT NOT NULL,
PropertyName VARCHAR(100),
PropertyDescription VARCHAR(255),
PropertyUserId INT,
FOREIGN KEY (PropertyProvinceId) REFERENCES PROVINCES(ProvinceId),
FOREIGN KEY (PropertyUserId) REFERENCES USERS(UserId)
);

CREATE TABLE [dbo].[REVIEWS](
ReviewId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
ReviewPropertyId INT NOT NULL,
ReviewComment VARCHAR(200), 
ReviewStar FLOAT, 
FOREIGN KEY (ReviewPropertyId) REFERENCES PROPERTIES(PropertyId)
);

-- Inserts
INSERT INTO [dbo].[ROLES]
                ([RoleName])
VALUES
    ('Admin')
    ,('User');
GO

INSERT INTO [dbo].[PROVINCES]
                ([ProvinceName]
                ,[ProvinceDescription]
                ,[ProvincePhoto])
VALUES
    ('San José', 'La capital y ciudad más grande de Costa Rica.', 'sanjose.jpg')
    ,('Alajuela', 'Conocida por sus hermosos paisajes y el Aeropuerto Internacional Juan Santamaría.', 'alajuela.jpg')
    ,('Cartago', 'Históricamente significativa y antigua capital de Costa Rica.', 'cartago.jpg')
    ,('Heredia', 'Famosa por sus plantaciones de café y una vibrante escena cultural.', 'heredia.jpg')
    ,('Guanacaste', 'Famosa por sus impresionantes playas y parques nacionales.', 'guanacaste.jpg')
    ,('Puntarenas', 'Una provincia costera con una diversidad de vida marina y atracciones turísticas.', 'puntarenas.jpg')
    ,('Limón', 'Situada en la costa caribeña, conocida por su cultura afrocaribeña y belleza natural.', 'limon.jpg')
GO

INSERT INTO [dbo].[USERS]
                ([UserName]
                ,[UserLastName1]
                ,[UserLastName2]
                ,[UserEmail]
                ,[UserPassword]
                ,[UserRole])
VALUES
    ('Luis', 'Villarreal', 'Retes', 'lvillarreal00332@ufide.ac.cr', '00332',1)
    ,('Luis', 'Navarro' ,'Murillo', 'lnavarro70469@ufide.ac.cr', '70469', 2)
    ,('Bryan', 'Rojas', 'Chacón', 'brojas30828@ufide.ac.cr', '30828', 2)
    ,('Norlan', 'González', 'Quesada', 'ngonzalez40383@ufide.ac.cr', '40383', 2)
GO

INSERT INTO [dbo].[PROPERTIES]
                ([PropertyProvinceId]
                ,[PropertyName]
                ,[PropertyDescription]
                ,[PropertyUserId])
VALUES
    (1, 'Residencial San José', 'Residencial privado cerca de La Sabana', 1)
    ,(1, 'Bosques de San José', 'Apartamentos amplios', 2)
    ,(1, 'Casas San José', 'Viviendas de 3 habitaciones', 3)
    ,(1, 'Apartamentos Chepe', 'Apartamentos tipo studio', 4)
    ,(2, 'Residencial Alajuela', 'Residencial privado cerca de Plaza Real', 1)
    ,(2, 'Bosques de Alajuela', 'Apartamentos amplios', 2)
    ,(2, 'Casas Alajuela', 'Viviendas de 3 habitaciones', 3)
    ,(2, 'Apartamentos La Liga', 'Apartamentos tipo studio', 4)
    ,(3, 'Residencial Cartagos', 'Residencial privado cerca de La Basílica', 1)
    ,(3, 'Bosques de Cartago', 'Apartamentos amplios', 2)
    ,(3, 'Casas Cartago', 'Viviendas de 3 habitaciones', 3)
    ,(3, 'Apartamentos Bruma', 'Apartamentos tipo studio', 4)
    ,(4, 'Residencial Heredia', 'Residencial privado cerca de la UNA', 1)
    ,(4, 'Bosques de Heredia', 'Apartamentos amplios', 2)
    ,(4, 'Casas Heredia', 'Viviendas de 3 habitaciones', 3)
    ,(4, 'Apartamentos Flores', 'Apartamentos tipo studio', 4)
    ,(5, 'Residencial Guanacaste', 'Residencial privado cerca de Aeropuerto Daniel Oduber',1)
    ,(5, 'Bosques de Guanacaste', 'Apartamentos amplios', 2)
    ,(5, 'Casas Guanacaste', 'Viviendas de 3 habitaciones', 3)
    ,(5, 'Apartamentos Guana', 'Apartamentos tipo studio', 4)
    ,(6, 'Residencial Puntarenas', 'Residencial privado cerca del Paseo de los Estudiantes', 1)
    ,(6, 'Bosques de Puntarenas', 'Apartamentos amplios', 2)
    ,(6, 'Casas Puntarenas', 'Viviendas de 3 habitaciones', 3)
    ,(6,'Apartamentos Puntarenas', 'Apartamentos tipo studio', 4)
    ,(7, 'Residencial Limón', 'Residencial privado cerca de Playa Cocles', 1)
    ,(7, 'Bosques de Limón', 'Apartamentos amplios', 2)
    ,(7, 'Casas Limón', 'Viviendas de 3 habitaciones', 3)
    ,(7, 'Apartamentos Limón', 'Apartamentos tipo studio', 4)
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
    ,(2,'Excelente en general',3)
    ,(2,'Buena',1)
    ,(2,'Regular',5)
    ,(2,'Mala',2)
    ,(2,'Muy mala',1)
    ,(3,'Excelente en general',2)
    ,(3,'Buena',5)
    ,(3,'Regular',3)
    ,(3,'Mala',2)
    ,(3,'Muy mala',1)
    ,(4,'Excelente en general',1)
    ,(4,'Buena',2)
    ,(4,'Regular',3)
    ,(4,'Mala',2)
    ,(4,'Muy mala',1)
    ,(5,'Excelente en general',4)
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
    INSERT INTO [dbo].[USERS]([UserEmail], [UserPassword], [UserRole])
VALUES(@UserEmail, @UserPassword, 2);
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_LogIn]
@userEmail VARCHAR (30),
@userPassword VARCHAR(MAX)
AS 
BEGIN 
    SELECT * 
        FROM [dbo].[USERS]
    WHERE 
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
UPDATE [dbo].[USERS] SET 
UserPassword = @UserPassword 
WHERE UserId = @UserId;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetProvinces]
AS
BEGIN
    SELECT
        P.ProvinceId,
        P.ProvinceName,
        P.ProvinceDescription,
        P.ProvincePhoto,
        COUNT(PROP.PropertyId) AS PropertyCount
    FROM
        [dbo].[PROVINCES] P
    LEFT JOIN
        [dbo].[PROPERTIES] PROP ON P.ProvinceId = PROP.PropertyProvinceId
    GROUP BY
        P.ProvinceId,
        P.ProvinceName,
        P.ProvinceDescription,
		P.ProvincePhoto
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetAllUsers]
AS
SELECT UserId, UserName, UserLastName1, UserLastName2, UserEmail, UserPassword, UserRole, ROLES.RoleName
FROM [dbo].[USERS]
INNER JOIN [dbo].[ROLES]
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
    [dbo].[REVIEWS]
INNER JOIN 
    [dbo].[PROPERTIES]
ON 
    REVIEWS.ReviewPropertyId = PROPERTIES.PropertyId
INNER JOIN
    [dbo].[PROVINCES]
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
INSERT INTO [dbo].[PROPERTIES]([PropertyProvinceId], [PropertyName])
VALUES(@PropertyProvinceId, @PropertyName);
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetReviewsByProperty]
    @ReviewPropertyId INT
AS
BEGIN
    SELECT
    REVIEWS.ReviewId,
    REVIEWS.ReviewPropertyId,
    PROPERTIES.PropertyName,
	PROVINCES.ProvinceName,
    REVIEWS.ReviewComment,
	REVIEWS.ReviewStar
FROM
    [dbo].[REVIEWS]
INNER JOIN
    [dbo].[PROPERTIES]
ON
    REVIEWS.ReviewPropertyId = PROPERTIES.PropertyId
INNER JOIN
	[dbo].[PROVINCES]
ON
	PROVINCES.ProvinceId = PROPERTIES.PropertyProvinceId
WHERE
    REVIEWS.ReviewPropertyId = @ReviewPropertyId;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_GetPropertiesByProvince]
    @PropertyProvinceId INT
AS
BEGIN
    SELECT
    PROPERTIES.PropertyId,
    PROPERTIES.PropertyProvinceId,
    PROVINCES.ProvinceName,
    PROVINCES.ProvincePhoto,
    PROPERTIES.PropertyName,
    PROPERTIES.PropertyDescription,
    PROPERTIES.PropertyUserId,
    ROUND(AVG(REVIEWS.ReviewStar), 1) AS AverageReviewStar
FROM
    [dbo].[PROPERTIES]
INNER JOIN
    [dbo].[PROVINCES]
ON
    PROPERTIES.PropertyProvinceId = PROVINCES.ProvinceId
LEFT JOIN
    [dbo].[REVIEWS]
ON
    PROPERTIES.PropertyId = REVIEWS.ReviewPropertyId
WHERE
    PROPERTIES.PropertyProvinceId = @PropertyProvinceId
GROUP BY
    PROPERTIES.PropertyId,
    PROPERTIES.PropertyProvinceId,
    PROVINCES.ProvinceName,
    PROVINCES.ProvincePhoto,
    PROPERTIES.PropertyName,
    PROPERTIES.PropertyDescription,
    PROPERTIES.PropertyUserId;
END
GO

CREATE OR ALTER   PROCEDURE [dbo].[SP_RegisterReview]	
@ReviewPropertyId INT,
@ReviewComment VARCHAR(200),
@ReviewStar FLOAT
AS
BEGIN
    INSERT INTO [dbo].[REVIEWS]([ReviewPropertyId], [ReviewComment], [ReviewStar])
VALUES(@ReviewPropertyId, @ReviewComment, @ReviewStar);
END;
GO

CREATE OR ALTER   PROCEDURE [dbo].[SP_RegisterProvince]	
@ProvinceName VARCHAR(30)
AS
BEGIN
    INSERT INTO [dbo].[PROVINCES]([ProvinceName])
VALUES(@ProvinceName);
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_DeleteReview]
@ReviewId INT
AS
BEGIN
    DELETE FROM [dbo].[REVIEWS] WHERE ReviewId = @ReviewId;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_UpdateUser] 
@UserId INT,
@UserRole INT
AS 
UPDATE USERS SET UserRole = @UserRole 
WHERE UserId = @UserId; 
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_UpdateProvince] 
@ProvinceId INT,
@ProvinceName VARCHAR(30), 
@ProvinceDescription VARCHAR(200)
AS 
UPDATE PROVINCES SET ProvinceName = @ProvinceName, ProvinceDescription = @ProvinceDescription
WHERE ProvinceId = @ProvinceId; 
GO
