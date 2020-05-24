CREATE TABLE [dbo].[Ingredients] (
    [IngredientId] UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([IngredientId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ingredients]
    ON [dbo].[Ingredients]([Name] ASC);

