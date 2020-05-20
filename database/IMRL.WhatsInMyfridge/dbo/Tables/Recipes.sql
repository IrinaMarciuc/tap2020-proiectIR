CREATE TABLE [dbo].[Recipes] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [StatusId]     NVARCHAR (50)    NOT NULL,
    [RecipeTypeId] INT              NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Recipes]
    ON [dbo].[Recipes]([Name] ASC);

