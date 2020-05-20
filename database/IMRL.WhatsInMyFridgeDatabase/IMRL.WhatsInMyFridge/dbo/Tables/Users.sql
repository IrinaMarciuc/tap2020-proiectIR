CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER CONSTRAINT [DF_User_Id] DEFAULT (newid()) NOT NULL,
    [Username]     NVARCHAR (50)    NOT NULL,
    [Email]        NVARCHAR (50)    NOT NULL,
    [PasswordHash] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_UserRole] FOREIGN KEY ([Id]) REFERENCES [dbo].[UserRole] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User]
    ON [dbo].[Users]([Username] ASC);

