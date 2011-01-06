ALTER TABLE [dbo].[PersonName]
    ADD CONSTRAINT [DF_PersonName_NameId] DEFAULT (newid()) FOR [NameId];

