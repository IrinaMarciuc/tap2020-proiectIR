CREATE TABLE [dbo].[Ingredients] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ingredients]
    ON [dbo].[Ingredients]([Name] ASC);

