CREATE TABLE [dbo].[RecipeIngredients] (
    [RecipeId]        UNIQUEIDENTIFIER NOT NULL,
    [IngredientId]    UNIQUEIDENTIFIER NOT NULL,
    [Quantity]        DECIMAL (18, 2)  NOT NULL,
    [MeasurementUnit] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED ([RecipeId] ASC, [IngredientId] ASC),
    CONSTRAINT [FK_RecipeIngredients_Ingredients] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredients] ([IngredientId]),
    CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([RecipeId])
);

