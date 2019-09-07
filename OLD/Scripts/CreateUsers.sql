CREATE TABLE dbo.FCP_Users
(
    ID INT,
    [Name] NVARCHAR(512),
    Gender BIT,
    BirthDay DATE,
    Height FLOAT,
    CONSTRAINT PK_FCP_Users_ID
        PRIMARY KEY (ID)
);