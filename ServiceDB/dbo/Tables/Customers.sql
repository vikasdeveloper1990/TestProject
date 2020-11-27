CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerName] NCHAR(30) NULL, 
    [CustomerAddress] NCHAR(300) NULL
)
