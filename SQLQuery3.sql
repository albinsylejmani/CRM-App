/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Email]
      ,[Password]
      ,[FirstName]
      ,[LastName]
  FROM [CrmDB].[dbo].[Users]

  USE [CrmDB];

ALTER TABLE Users
ADD Role VARCHAR(50) NULL,
    IsActive BIT NULL