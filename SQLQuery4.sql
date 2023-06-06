/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Email]
      ,[Password]
      ,[FirstName]
      ,[LastName]
      ,[Role]
      ,[IsActive]
  FROM [CrmDB].[dbo].[Users]
