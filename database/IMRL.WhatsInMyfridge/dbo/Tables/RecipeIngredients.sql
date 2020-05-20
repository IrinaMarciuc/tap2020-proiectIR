CREATE TABLE [dbo].[RecipeIngredients] (
    [RecipeId]        UNIQUEIDENTIFIER NOT NULL,
    [IngredientsId]   UNIQUEIDENTIFIER NOT NULL,
    [Quantity]        DECIMAL (18, 2)  NOT NULL,
    [MeasurementUnit] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED ([RecipeId] ASC, [IngredientsId] ASC),
    CONSTRAINT [FK_RecipeIngredients_Ingredients] FOREIGN KEY ([IngredientsId]) REFERENCES [dbo].[Ingredients] ([Id]),
    CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id])
);

