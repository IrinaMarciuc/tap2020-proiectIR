CREATE TABLE [dbo].[Recipes] (
    [RecipeId]   UNIQUEIDENTIFIER NOT NULL,
    [Name]       NVARCHAR (50)    NOT NULL,
    [Status]     NVARCHAR (50)    NOT NULL,
    [RecipeType] VARCHAR (50)     NOT NULL,
    [Link]       NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([RecipeId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Recipes]
    ON [dbo].[Recipes]([Name] ASC);

