-- =============================================
-- Script Template
-- =============================================
USE names
GO
UPDATE [names].[dbo].[PersonName]
   SET SexOf = 'female'
      ,Surname = 'false'
 WHERE LEN(SexOf) < 3
GO
UPDATE [names].[dbo].[PersonName]
   SET SexOf = 'both'
      ,Surname = 'false'
 WHERE LEN(SexOf) > 3 
 GO
 UPDATE [names].[dbo].[PersonName]
   SET SexOf = 'male'
      ,Surname = 'false'
 WHERE LEN(SexOf) = 3
 GO
 UPDATE [names].[dbo].[PersonName]
   SET SexOf = 'both'
      ,Surname = 'true'
 WHERE SexOf = 'both' AND LEN(Name) > 5