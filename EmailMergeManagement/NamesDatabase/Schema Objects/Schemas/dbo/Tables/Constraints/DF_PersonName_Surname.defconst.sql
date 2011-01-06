ALTER TABLE [dbo].[PersonName]
    ADD CONSTRAINT [DF_PersonName_Surname] DEFAULT ((1)) FOR [Surname];

