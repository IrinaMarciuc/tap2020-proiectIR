CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER CONSTRAINT [DF_User_Id] DEFAULT (newid()) NOT NULL,
    [Username]     NVARCHAR (50)    NOT NULL,
    [PasswordHash] NVARCHAR (50)    NOT NULL,
    [Role]         VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Users]
    ON [dbo].[Users]([Id] ASC);

